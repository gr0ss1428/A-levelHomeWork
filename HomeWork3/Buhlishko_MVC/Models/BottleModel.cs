using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Buhlishko_MVC.Models
{
    public class BottleModel
    {
        [Required]
        public string Types { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public double? AbvPercent { get; set; }
        [Required]
        public uint? KCal { get; set; }
        [Required]
        public uint? Volume { get; set; }
        [Required]
        public uint? Quantity { get; set; }
        [Required]
        public uint? Prise { get;  set; }
        
    }
    public class EditValue
    {
        [Required]
        public string Types { get; set; }
        [Required]
        public int? Pos { get; set; }
        [Required]
        public uint? Quantity { get; set; }
        [Required]
        public uint? Prise { get; set; }

    }

}