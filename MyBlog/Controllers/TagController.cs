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
    public class TagController : Controller
    {
        private readonly ITagService _service;
        private readonly IMapper _mapper;

        public TagController(ITagService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: Category
        public ActionResult Index()
        {
            var tagBL = _service.GetAll().ToList();
            var tags = _mapper.Map<IEnumerable<TagViewModel>>(tagBL);

            return View(tags);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var tagBL = _service.GetById(id);
            var tags = _mapper.Map<TagViewModel>(tagBL);

            return View(tags);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] TagViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<TagBL>(model);
                _service.Create(modelBL);

                return RedirectToAction("Index");
            }
            catch
            {
                var tagBL = _service.GetAll().ToList();
                var tags = _mapper.Map<IEnumerable<TagViewModel>>(tagBL);

                return View(tags);
            }
        }

        // GET: Category/Edit/
        public ActionResult Edit(int id)
        {
            var tagBL = _service.GetAll().ToList();
            var tags = _mapper.Map<IEnumerable<TagViewModel>>(tagBL);

            return View(tags);
        }

        // POST: Category/Edit/
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,Name")] TagViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<TagBL>(model);
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
            var tagBL = _service.GetAll().ToList();
            var tags = _mapper.Map<IEnumerable<TagViewModel>>(tagBL);

            return View(tags);
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

