﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
