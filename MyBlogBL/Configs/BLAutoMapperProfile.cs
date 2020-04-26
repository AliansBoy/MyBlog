using AutoMapper;
using MyBlogBL.Models;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Configs
{
    public class BLAutoMapperProfile: Profile
    {
        public BLAutoMapperProfile()
        {
            CreateMap<CategoryBL, Category>().ReverseMap();
            CreateMap<Category, CategoryBL>().ReverseMap();

            CreateMap<CommentBL, Comment>().ReverseMap();
            CreateMap<Comment, CommentBL>().ReverseMap();

            CreateMap<PostBL, Post>().ReverseMap();
            CreateMap<Post, PostBL>().ReverseMap();

            CreateMap<TagBL, Tag>().ReverseMap();
            CreateMap<Tag, TagBL>().ReverseMap();

            CreateMap<UserBL, User>().ReverseMap();
            CreateMap<User, UserBL>().ReverseMap();
        }
    }
}
