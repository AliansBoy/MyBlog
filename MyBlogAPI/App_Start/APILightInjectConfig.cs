using LightInject;
using MyBlogAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace MyBlogAPI.App_Start
{
    public class APILightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers();

            container.EnablePerWebRequestScope();

            container.Register<IPostService, PostService>();

            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}