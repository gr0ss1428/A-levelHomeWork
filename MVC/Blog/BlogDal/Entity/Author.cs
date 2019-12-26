using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace BlogDal.Entity
{
    [TableName("Author")]
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Article> Articles { get; set; }
    }
}
