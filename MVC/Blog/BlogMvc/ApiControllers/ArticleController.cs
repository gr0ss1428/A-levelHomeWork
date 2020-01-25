using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogMvc.Tools;
using BlogMvc.Models;
using BlogBl.BlModel;
using BlogBl;
using BlogMvc.Service;

namespace BlogMvc.ApiControllers
{
    public class ArticleController : ApiController
    {
        private readonly IService<ArticleBl> _articleService;
       

        public ArticleController(IService<ArticleBl> service)
        {
            _articleService = service;//new ArticleService<ArticleBl>();
            
        }
        
        // GET: api/Article
        [HttpGet]
        public IEnumerable<DetailsModel> GetAllArticle()
        {
            // return new string[] { "value1", "value2" };
            var artCollection = MapperTools.MapToCollection<ArticleBl, DetailsModel>(_articleService.GetAll());
            return artCollection;
        }

        // GET: api/Article/5
        [HttpGet]
        public DetailsModel GetArticle(int id)
        {
            var res = MapperTools.MapTo<ArticleBl, DetailsModel>(_articleService.GetById(id));
            return res;
        }

        // POST: api/Article
        [HttpPost]
        public void CreateArticle(DetailsModel item)
        {
            item.DateTime = DateTime.Now;
            item.AuthorId = 1;
            _articleService.Add(MapperTools.MapTo<DetailsModel, ArticleBl>(item));
        }

        // PUT: api/Article/5
        [HttpPut]
        public void UpdateArticle(int id, DetailsModel item)
        {
            _articleService.Update(MapperTools.MapTo<DetailsModel, ArticleBl>(item));
        }

        // DELETE: api/Article/5
        [HttpDelete]
        public void DeleteArticle(int id)
        {
            _articleService.Delete(id);
        }
    }
}
