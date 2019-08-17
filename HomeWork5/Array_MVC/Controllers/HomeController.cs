using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Array_MVC.Models;
using Array_Lib;

namespace Array_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ListModelHistory lstModel = new ListModelHistory();
            lstModel.CurrentIndex = History.GetCurrentMatrixPosInHistory;
            for (int i=0; i < History.Count;i++)
            {
                ModelArrayHistory md = new ModelArrayHistory();
                md.pos = i;
                md.size = History.GetMatrixSizeByPos(i);
                lstModel.listModels.Add(md);
            }
            return View(lstModel);
        }
        public ActionResult NewMatrix()
        {
            return View(new NewMatrixModel());
        }
        [HttpPost]
        public ActionResult NewMatrix(NewMatrixModel newMatrix)
        {
            if(ModelState.IsValid)
            {
                History.NewGenArray((int)newMatrix.Size);
                return RedirectToAction("ViewMatrix", routeValues:new { pos = History.GetCurrentMatrixPosInHistory });
            }
            return View(newMatrix);
        }
        public ActionResult ViewMatrix(int? pos)
        {
            /*
             *  В View скорее всего я делаю не правильно вывод и надо было его посылыть отседова
             */
            History.SetCurrentMatrix((int)pos);
            ViewMatrixModel viewMatrixModel = new ViewMatrixModel();
            viewMatrixModel.Count = History.GetCurrentMatrixPosInHistory;
            ViewBag.count = viewMatrixModel.Count + 1;
            viewMatrixModel.HistoryCount = History.Count;
            viewMatrixModel.Size = History.GetCurrentMatrixSize();
            viewMatrixModel.Matrix = History.GetCurentMatrix;
            viewMatrixModel.MatrixTranspose = History.Transpose(History.GetCurentMatrix);
            viewMatrixModel.MatrixLowerTriangular = History.LowerTriangular(History.GetCurentMatrix);
            viewMatrixModel.MatrixUpperTriangular = History.UpperTriangular(History.GetCurentMatrix);
            return View(viewMatrixModel);
        }
    }
}