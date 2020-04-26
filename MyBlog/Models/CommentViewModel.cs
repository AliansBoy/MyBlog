using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int PostId { get; set; }
        public PostViewModel Post { get; set; }
    }
}
