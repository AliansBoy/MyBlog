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
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: Category
        public ActionResult Index()
        {
            var userBL = _service.GetAll().ToList();
            var users = _mapper.Map<IEnumerable<UserViewModel>>(userBL);

            return View(users);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var userBL = _service.GetById(id);
            var users = _mapper.Map<UserViewModel>(userBL);

            return View(users);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email")] UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<UserBL>(model);
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
            var userBL = _service.GetById(id);
            var users = _mapper.Map<UserViewModel>(userBL);

            return View(users);
        }

        // POST: Category/Edit/
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,FirstName,LastName,Email")] UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<UserBL>(model);
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
            var userBL = _service.GetById(id);
            var users = _mapper.Map<UserViewModel>(userBL);

            return View(users);
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

