using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QadraticEquation_Lib;
using QadraticEquation_MVC.Models;
namespace QadraticEquation_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = string.Empty;
            return View(new QEModel());
        }
        [HttpPost]
        public ActionResult Index(QEModel qEModel)
        {
            ViewBag.Message = string.Empty;
            ViewBag.Result = string.Empty;
            ViewBag.LinMult = string.Empty;
            ViewBag.Error = 0;
            if (qEModel.A == 0)
            {
                ViewBag.Error = 1;
                ViewBag.Message += "Первый коэффициент не должен равняться 0.Повторите ввод.";
            }
            else if (qEModel.B == 0 && qEModel.C == 0)
            {
                ViewBag.Error = 1;
                ViewBag.Message += "Уровнение не имеет смысла второй и третий коэффициент равны 0. Повторите ввод.";
            }
            else
            {
                qEModel.D = QETools.GetDiscriminant(qEModel.A, qEModel.B, qEModel.C);
                ViewBag.Message += QETools.QEToString(qEModel.A, qEModel.B, qEModel.C) + "0";
                if (qEModel.D < 0)
                {
                    ViewBag.Result += String.Format("Квадратное уровнение не имеет корней. D={0} (D<0)", qEModel.D);
                }
                else if (qEModel.D == 0)
                {
                    qEModel.x1 = qEModel.x2 = QETools.GetX1(qEModel.D, qEModel.B, qEModel.A);
                    ViewBag.Result += String.Format("Уровнение имеет два равных корня x1=x2={0}", qEModel.x1);
                }
                else if (qEModel.D > 0)
                {
                    qEModel.x1 = QETools.GetX1(qEModel.D, qEModel.B, qEModel.A);
                    qEModel.x2 = QETools.GetX2(qEModel.D, qEModel.B, qEModel.A);
                    ViewBag.Result += String.Format("Уровнение имеет два корня x1={0}, x2={1}", qEModel.x1, qEModel.x2);
                }
                if (qEModel.D >= 0)
                {


                    ViewBag.LinMult += QETools.LinMult(qEModel.A, qEModel.B, qEModel.C, qEModel.x1, qEModel.x2);


                }
            }



            return View(qEModel);
        }
        

    }
}