using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace BlogDal.Entity
{
    [TableName("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public string  Body { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateTime { get; set; }
        public int ArticleId { get; set; }
    }
}
