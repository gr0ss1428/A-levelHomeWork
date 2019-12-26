using BlogBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogMvc.Tools;
using BlogMvc.Models;
using BlogBl.BlModel;

namespace BlogMvc.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IService<ArticleBl> _articleService;
        
        public ArticleController()
        {
            _articleService = new ArticleService<ArticleBl>();
        }
        // GET: Article
        public ActionResult Index()
        {

            return RedirectToAction("ListArticle");
          //  return View();
        }

        public ActionResult ListArticle()
        {
            var artCollection = MapperTools.MapToCollection<ArticleBl, DetailsModel>(_articleService.GetAll());
            return View(artCollection);
        }

        // GET: Article/Details/5
        //TODO: add view thsi action
        public ActionResult Details(int id)
        {
            var res=MapperTools.MapTo<ArticleBl,DetailsModel>( _articleService.GetById(id));
            return View(res);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(DetailsModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    model.DateTime = DateTime.Now;
                    model.AuthorId = 1;
                    _articleService.Add(MapperTools.MapTo<DetailsModel, ArticleBl>(model));
                    return RedirectToAction("ListArticle");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            var res = MapperTools.MapTo<ArticleBl, DetailsModel>(_articleService.GetById(id));
            return View(res);
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DetailsModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _articleService.Update(MapperTools.MapTo<DetailsModel, ArticleBl>(model));
                    return RedirectToAction("ListArticle");
                }
               return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _articleService.Delete(id);

            }
            catch
            {
                
            }
            return RedirectToAction("ListArticle");
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
