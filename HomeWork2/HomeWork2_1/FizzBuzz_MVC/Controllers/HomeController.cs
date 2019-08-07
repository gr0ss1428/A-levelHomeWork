using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FizzBuzz_Lib;
using FizzBuzz_MVC.Models;
namespace FizzBuzz_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.pattern = String.Empty;
            ViewBag.FizzBuzz = String.Empty;
            return View(new FizzBuzz_model() { start = FizzBuzzTools.defaultStart, end = FizzBuzzTools.defaultEnd, divider1 = FizzBuzzTools.defaultDivider1, divider2 = FizzBuzzTools.defaultDivider2 });
        }
        [HttpPost]
        public ActionResult Index(FizzBuzz_model fizzBuzz_Model)
        {
            ViewBag.pattern = String.Empty;
            ViewBag.FizzBuzz = String.Empty;

            /*
            * вот тут существуют ещё не понятки по проверкам, а точнее почему не перехватываются мной созданые условия и берутся ошибки по умолчанию, проявлется это в англ тексте что слегка
            * не красиво получается
            */
            // if (fizzBuzz_Model.divider1.HasValue && fizzBuzz_Model.divider2.HasValue)
            {
                if (fizzBuzz_Model.divider1 < 2)
                {
                    ModelState.AddModelError("divider1", "Число больше 1");

                }
                if (!FizzBuzzTools.PrimeNumber(fizzBuzz_Model.divider1))
                {
                    ModelState.AddModelError("divider1", "Число не простое");
                }
                if (!FizzBuzzTools.PrimeNumber(fizzBuzz_Model.divider2))
                {
                    ModelState.AddModelError("divider2", "Число не простое");
                }
            }
            if (ModelState.IsValid)
            {
                ViewBag.pattern=FizzBuzzTools.FizzBuzzPatternString(fizzBuzz_Model.start, fizzBuzz_Model.end, fizzBuzz_Model.divider1, fizzBuzz_Model.divider2);
                ViewBag.FizzBuzz = FizzBuzzTools.FizzBuzzLstString(fizzBuzz_Model.start, fizzBuzz_Model.end, fizzBuzz_Model.divider1, fizzBuzz_Model.divider2,40);
            }
            return View(fizzBuzz_Model);
        }
    }
}