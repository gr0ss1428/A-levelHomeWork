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

    public class ArticleService<T> :IService<T>
        where T:class
    {
        //TODO:
        private readonly IGenericRepository<Article> _repository;

        public ArticleService()
        {
            _repository = new GenericRepository<Article>();
        }

        public void Add(T model)
        {
            _repository.Create(MapperTools.MapTo<T, Article>(model));
        }

        public void Delete(T model)
        {
            _repository.Remove(MapperTools.MapTo<T, Article>(model));
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public ICollection<T> GetAll()
        {
            var articles = _repository.GetAll();
            return MapperTools.MapToCollection<Article, T>(articles);
        }

        public T GetById(int id)
        {
           var articleEntity= _repository.FindById(id);
            //TODO: Install mapper
            return MapperTools.MapTo<Article, T>(articleEntity);
        }

        public void Update(T model)
        {
            _repository.Update(MapperTools.MapTo<T, Article>(model));
        }
    }
}
