using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Models
{
    public class CommentBL
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public UserBL User { get; set; }
        public int PostId { get; set; }
        public PostBL Post { get; set; }
    }
}
