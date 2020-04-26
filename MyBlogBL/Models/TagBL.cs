using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Models
{
    public class TagBL
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<PostBL> Posts { get; set; }
    }
}
