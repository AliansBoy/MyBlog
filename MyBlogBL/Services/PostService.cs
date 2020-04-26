using AutoMapper;
using MyBlogBL.Interfaces;
using MyBlogBL.Models;
using MyBlogDAL.Interfaces;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MyBlogBL.Services
{
    public class PostService : BlogService<PostBL, Post>, IPostService
    {
        private readonly RestClient _restClient;
        private IMapper _mapper;
        public PostService(IBlogRepository<Post> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _restClient = new RestClient("https://localhost:44338/");
        }

        public override PostBL Map(Post entity)
        {
            return _mapper.Map<PostBL>(entity);
        }

        public override Post Map(PostBL blmodel)
        {
            return _mapper.Map<Post>(blmodel);
        }

        public override IEnumerable<PostBL> Map(IList<Post> entities)
        {
            var request = new RestRequest("api/Post");
            var postsAPI = _restClient.Execute<List<PostBL>>(request, Method.GET).Data;
            var posts = _mapper.Map<IEnumerable<PostBL>>(entities);
            postsAPI.AddRange(posts);
            return postsAPI;
        }

        public override IEnumerable<Post> Map(IList<PostBL> models)
        {
            return _mapper.Map<IEnumerable<Post>>(models);
        }
    }
}
