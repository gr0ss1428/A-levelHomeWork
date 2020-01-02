using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMvc.Models
{
    public class DetailsModel
{
        public int Id { get; set; }
        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "1Поле должно быть установлено")]
        [StringLength(maximumLength:50,MinimumLength=1)]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public string Image { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
    }
}