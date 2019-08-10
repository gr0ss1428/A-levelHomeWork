using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alcohol_Lib;
using Buhlishko_MVC.Models;
namespace Buhlishko_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewData[""] = AlcoholBase.GetAlcoholItemsByTypesArr("Beer");
            return View();
        }
        public ActionResult ByTypes(string types)
        {
            ViewBag.types = types;
            ViewData["ArrPos"] = AlcoholBase.GetAlcoholItemsByTypesArr(types);
            return View(new BottleModel(){Types=types});
        }
        [HttpPost]
        public ActionResult ByTypes(BottleModel bottleModel)
        {
            if(ModelState.IsValid)
            {
                AlcoholBase.AddNewPosition(new AlcoholBottle(bottleModel.Types, bottleModel.Name, bottleModel.Manufacturer, (double)bottleModel.AbvPercent,
                    (uint)bottleModel.KCal, (uint)bottleModel.Volume, (uint)bottleModel.Quantity, (uint)bottleModel.Prise));
                return Redirect($"/Home/ByTypes?types={bottleModel.Types}");
            }
            else
            {
                ViewBag.types = bottleModel.Types;
                ViewData["ArrPos"] = AlcoholBase.GetAlcoholItemsByTypesArr(bottleModel.Types);
                return View(bottleModel);
            }
        }
        public ActionResult Delposition(string types, uint possition)
        {
            AlcoholBase.RemoveAlcohoBottleinBase(types, possition);
            return Redirect($"/Home/ByTypes?types={types}");
        }
        public ActionResult DelAllPositioninTypes(string types)
        {
            AlcoholBase.RemoveAlcohoBottleAll(types);
            return Redirect($"/Home/ByTypes?types={types}");
        }
        public ActionResult NewPosition()
        {
            return View(new BottleModel());
        }
        [HttpPost]
        public ActionResult EditPosition(EditValue editValue)
        {
            if (ModelState.IsValid)
            {
                AlcoholBase.EditPosition(editValue.Types, (int)editValue.Pos, (uint)editValue.Quantity, (uint)editValue.Prise);
            }
            return Redirect($"/Home/ByTypes?types={editValue.Types}");
        }
        [HttpPost]
        public ActionResult NewPosition(BottleModel bottleModel)
        {
            if (ModelState.IsValid)
            {
                AlcoholBase.AddNewPosition(new AlcoholBottle(bottleModel.Types, bottleModel.Name, bottleModel.Manufacturer, (double)bottleModel.AbvPercent,
                    (uint)bottleModel.KCal, (uint)bottleModel.Volume, (uint)bottleModel.Quantity, (uint)bottleModel.Prise));
                return Redirect($"/Home/ByTypes?types={bottleModel.Types}");
            }
            else  return View(bottleModel);
        }

    }
}