using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBl.BlModel
{
   public class ArticleBl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
        public List<CommentBl> Comments { get; set; }
    }
}
