using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBl.BlModel;
using BlogDal.Entity;
using BlogDal.Repository;
using AutoMapper;

namespace BlogBl
{
    public interface IService<T> where T : class
    {
        T GetById(int id);
        ICollection<T> GetAll();
        void Update(T model);
        void Add(T model);
        void Delete(int id);
        void Delete(T model);
    }

    public abstract class GService<BlModel, DalModel> : IService<BlModel>
        where BlModel : class
        where DalModel : class
    {
        private readonly IGenericRepository<DalModel> _repository;

        public GService()
        {
            _repository = new GenericRepository<DalModel>();
        }
        public void Add(BlModel model)
        {
            _repository.Create(MapperTools.MapTo<BlModel, DalModel>(model));
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public void Delete(BlModel model)
        {
            _repository.Remove(MapperTools.MapTo<BlModel, DalModel>(model));
        }

        public ICollection<BlModel> GetAll()
        {
            var articles = _repository.GetAll();
            return MapperTools.MapToCollection<DalModel, BlModel>(articles);
        }

        public BlModel GetById(int id)
        {
            var articleEntity = _repository.FindById(id);
            return MapperTools.MapTo<DalModel, BlModel>(articleEntity);
        }

        public void Update(BlModel model)
        {
            _repository.Update(MapperTools.MapTo<BlModel, DalModel>(model));
        }
    }
}
