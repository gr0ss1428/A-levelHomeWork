using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Array_MVC.Models
{
    public class ModelArrayHistory
    {
        public int pos { get; set; }
        public int size { get; set; }
    }
    public class ListModelHistory
    {
        public List<ModelArrayHistory> listModels { get; set; }
        public int CurrentIndex { get; set; }
        public ListModelHistory()
        {
            listModels = new List<ModelArrayHistory>();
        }
    }
}