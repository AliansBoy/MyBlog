using AutoMapper;
using MyBlog.Models;
using MyBlogBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.App_Start
{
    public class WebAutoMapperProfile: Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<CategoryBL, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryBL>().ReverseMap();

            CreateMap<CommentBL, CommentViewModel>().ReverseMap();
            CreateMap<CommentViewModel, CommentBL>().ReverseMap();

            CreateMap<PostBL, PostViewModel>().ReverseMap();
            CreateMap<PostViewModel, PostBL>().ReverseMap();

            CreateMap<TagBL, TagViewModel>().ReverseMap();
            CreateMap<TagViewModel, TagBL>().ReverseMap();

            CreateMap<UserBL, UserViewModel>().ReverseMap();
            CreateMap<UserViewModel, UserBL>().ReverseMap();

        }
    }
}