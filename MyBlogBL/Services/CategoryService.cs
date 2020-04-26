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
    public class CategoryService : BlogService<CategoryBL, Category>, ICategoryService
    {
        private IMapper _mapper;
        public CategoryService(IBlogRepository<Category> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override CategoryBL Map(Category entity)
        {
            return _mapper.Map<CategoryBL>(entity);
        }

        public override Category Map(CategoryBL blmodel)
        {
            return _mapper.Map<Category>(blmodel);
        }

        public override IEnumerable<CategoryBL> Map(IList<Category> entities)
        {
            return _mapper.Map<IEnumerable<CategoryBL>>(entities);
        }

        public override IEnumerable<Category> Map(IList<CategoryBL> models)
        {
            return _mapper.Map<IEnumerable<Category>>(models);
        }
    }
}

