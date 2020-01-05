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

    public class ArticleService : GService<ArticleBl,Article>//, IService<ArticleBl>
    {
        //TODO:
       /* private readonly IGenericRepository<Article> _repository;

        public ArticleService()
        {
            _repository = new GenericRepository<Article>();
        }

        public void Add(ArticleBl model)
        {
            _repository.Create(MapperTools.MapTo<ArticleBl, Article>(model));
        }

        public void Delete(ArticleBl model)
        {
            _repository.Remove(MapperTools.MapTo<ArticleBl, Article>(model));
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public ICollection<ArticleBl> GetAll()
        {
            var articles = _repository.GetAll();
            return MapperTools.MapToCollection<Article, ArticleBl>(articles);
        }

        public ArticleBl GetById(int id)
        {
           var articleEntity= _repository.FindById(id);
            //TODO: Install mapper
            return MapperTools.MapTo<Article, ArticleBl>(articleEntity);
        }

        public void Update(ArticleBl model)
        {
            _repository.Update(MapperTools.MapTo<ArticleBl, Article>(model));
        }*/
    }
}
