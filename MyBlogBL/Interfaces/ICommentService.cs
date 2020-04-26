using MyBlogBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Interfaces
{
    public interface ICommentService : IBlogService<CommentBL>
    {
    }
}
