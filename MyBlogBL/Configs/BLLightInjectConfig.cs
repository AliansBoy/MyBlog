using LightInject;
using MyBlogDAL.Interfaces;
using MyBlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Configs
{
    public class BLLightInjectConfig
    {
        public static ServiceContainer Configuration(ServiceContainer container)
        {
            container.Register(typeof(IBlogRepository<>), typeof(BlogRepository<>));

            return container;
        }
    }
}
