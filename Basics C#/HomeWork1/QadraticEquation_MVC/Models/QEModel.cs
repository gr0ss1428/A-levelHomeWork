using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QadraticEquation_Lib;

namespace QadraticEquation_MVC.Models
{
    public class QEModel
    {
        // double a;
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }


    }
    public class QEModel1
    {
        double doubleA;
        int errorA;
        public string A
        {
            get
            {
                if (errorA != 0) return "NA";
                else return doubleA.ToString();
            }
            set
            {
                
                if (double.TryParse(value, out doubleA)) errorA = 0;
                else errorA = 1;
            }
        }
    }
    
    


}