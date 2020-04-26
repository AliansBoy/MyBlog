using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Models
{
    public class PostBL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public UserBL User { get; set; }

        public IEnumerable<TagBL> Tags { get; set; }
        public IEnumerable<CategoryBL> Categories { get; set; }
        public IEnumerable<CommentBL> Comments { get; set; }
    }
}
