using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Array_MVC.Models
{
    public class ViewMatrixModel
    {
        public int[,] Matrix { get; set; }
        public int[,] MatrixUpperTriangular { get; set; }
        public int[,] MatrixLowerTriangular { get; set; }
        public int[,] MatrixTranspose { get; set; }
        public int Count { get; set; }
        public int Size { get; set; }
        public int HistoryCount { get; set; }
        public ViewMatrixModel()
        {
            /* Matrix = new int[size, size];
             MatrixUpperTriangular = new int[size, size];
             MatrixLowerTriangular = new int[size, size];
             MatrixTranspose = new int[size, size];*/
        }
    }
}