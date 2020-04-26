using MyBlogAPI.Models;
using MyBlogAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlogAPI.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;

        public PostController (IPostService postService)
        {
            _postService = postService;
        }

        //GET api/Post
        public IEnumerable<PostData> Get()
        {
            var posts = _postService.GetAllPosts().ToList();
            return posts;
        }

    }
}
