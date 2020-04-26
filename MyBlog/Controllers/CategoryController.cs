using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyBlog.Models;
using MyBlogBL.Interfaces;
using MyBlogBL.Models;
using MyBlogDAL;

namespace MyBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: Category
        public ActionResult Index()
        {
            var categoriesBL = _service.GetAll().ToList();
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesBL);

            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var categoriesBL = _service.GetById(id);
            var categories = _mapper.Map<CategoryViewModel>(categoriesBL);

            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<CategoryBL>(model);
                _service.Create(modelBL);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/
        public ActionResult Edit(int id)
        {
            var categoriesBL = _service.GetById(id);
            var categories = _mapper.Map<CategoryViewModel>(categoriesBL);

            return View(categories);
        }

        // POST: Category/Edit/
        [HttpPost]
        public ActionResult Edit(int id,[Bind(Include = "Id,Name,Description")] CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<CategoryBL>(model);
                _service.Update(modelBL);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/
        public ActionResult Delete(int id)
        {
            var categoriesBL = _service.GetById(id);
            var categories = _mapper.Map<CategoryViewModel>(categoriesBL);

            return View(categories);
        }

        // POST: Category/Delete/
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
