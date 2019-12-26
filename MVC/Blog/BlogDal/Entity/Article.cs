using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace BlogDal.Entity
{
    [TableName("Article")]
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        [Column("Date")]
        public DateTime DateTime { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
