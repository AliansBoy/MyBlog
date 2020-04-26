using AutoMapper;
using LightInject;
using MyBlogBL.Configs;
using MyBlogBL.Interfaces;
using MyBlogBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyBlog.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutoMapperProfile(), new BLAutoMapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectConfig.Configuration(container);

            container.Register<IPostService, PostService>();
            container.Register<IUserService, UserService>();
            container.Register<ICategoryService, CategoryService>();
            container.Register<ITagService, TagService>();
            container.Register<ICommentService, CommentService>();

            container.EnableMvc();
        }
    }
}