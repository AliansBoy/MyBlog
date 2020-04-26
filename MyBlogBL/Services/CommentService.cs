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

namespace MyBlogBL.Services
{
    public class CommentService : BlogService<CommentBL, Comment>, ICommentService
    {
        private IMapper _mapper;
        public CommentService(IBlogRepository<Comment> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override CommentBL Map(Comment entity)
        {
            return _mapper.Map<CommentBL>(entity);
        }

        public override Comment Map(CommentBL blmodel)
        {
            return _mapper.Map<Comment>(blmodel);
        }

        public override IEnumerable<CommentBL> Map(IList<Comment> entities)
        {
            return _mapper.Map<IEnumerable<CommentBL>>(entities);
        }

        public override IEnumerable<Comment> Map(IList<CommentBL> models)
        {
            return _mapper.Map<IEnumerable<Comment>>(models);
        }
    }
}
