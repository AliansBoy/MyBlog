using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Models
{
    public class UserBL
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IEnumerable<PostBL> Posts { get; set; }
        public IEnumerable<CommentBL> Comments { get; set; }
    }
}
