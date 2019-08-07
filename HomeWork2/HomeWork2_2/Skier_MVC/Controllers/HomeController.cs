using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skier_lib;
namespace Skier_MVC.Controllers
{
    /*
     * Это лютый звиздец что то делаешь и вроде как примерно понимаешь что делаешь но все же не совсем
     * особенно не понятно было почему глобальный солварь в каждом контролере пустой пришлось сделать такую передачу через TempData.
     * Но и с ним тоже не все так было понятно. Правда я нашел потом как передавать через сылку но не пробовал передавать словарь моделей через ссылку
     * использовал вывод из длл которая готовила для консоли что не совсем красиво получилос
     */
    public class HomeController : Controller
    {
        Dictionary<uint, List<SkierModel>> history = new Dictionary<uint, List<SkierModel>>();
        public ActionResult Index(int? z)
        {
//             history.Add(1, new List<SkierModel>() { new SkierModel() { id = 1, name = "sdf", distFirstDay = 10, persentBoost = 10, calcDist = 15, calcDay = 3 } });
           // history = (Dictionary<uint, List<SkierModel>>)TempData["history"];
            if(TempData.ContainsKey("history")) history = (Dictionary<uint, List<SkierModel>>)TempData["history"];
            ViewBag.history = history;
            TempData["history"] = history;
            return View(history);
        }
      
        public ActionResult NewTraining(uint? id)
        {
            
            
            ViewBag.thisTraining = String.Empty;
            history = (Dictionary<uint, List<SkierModel>>)TempData["history"];
            TempData["history"] = history;
            SkierModel sk = new SkierModel();
            if (id.HasValue)
            {
                if (history.ContainsKey((uint)id))
                {
                    if (history[(uint)id].Count != 0)
                    {
                        sk.id = id;
                        sk.name = history[(uint)id][0].name;
                        ViewBag.thisTraining = SkierTools.ListFormatingStrHistory(history[(uint)id]);
                    }
                }
            }
            return View(sk);
        }
        [HttpPost]
        public ActionResult NewTraining(SkierModel skierModel)
        {
            ViewBag.history = String.Empty;
            history = (Dictionary<uint, List<SkierModel>>)TempData["history"];
            if (ModelState.IsValid)
            {
                skierModel.calcDay = SkierTools.GetDayRunDistanse(skierModel.distFirstDay, skierModel.persentBoost, skierModel.calcDist);
                if (!history.ContainsKey((uint)skierModel.id)) history.Add((uint)skierModel.id, new List<SkierModel>() { skierModel });
                else history[(uint)skierModel.id].Add(skierModel);
                ViewBag.thisTraining = SkierTools.ListFormatingStrHistory( history[(uint)skierModel.id]);
            }
            TempData["history"] = history;
            return View(skierModel);

        }
        [HttpGet]
        public ActionResult AllHistory()
        {
           
            history = (Dictionary<uint, List<SkierModel>>)TempData["history"];
            ViewBag.AllTraining = history;
            TempData["history"] = history;
            return View();
        }
    }
}