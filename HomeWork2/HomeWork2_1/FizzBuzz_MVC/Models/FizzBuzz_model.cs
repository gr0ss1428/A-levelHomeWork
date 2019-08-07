using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuzz_MVC.Models
{
    public class FizzBuzz_model
    {
        /*
         * вот тут существуют ещё не понятки по проверкам, а точнее почему не перехватываются мной созданые условия и берутся ошибки по умолчанию, проявлется это в англ тексте что слегка
         * не красиво получается
        */
        [Required(ErrorMessage = "Введите число")]
        public int? start { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public int? end { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public uint? divider1 { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public uint? divider2 { get; set; }

    }
}