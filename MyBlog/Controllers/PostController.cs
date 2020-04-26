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
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IUserService userService, IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }
        // GET: Category
        public ActionResult Index()
        {
            var postBL = _postService.GetAll().ToList();
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(postBL);

            return View(posts);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var postBL = _postService.GetById(id);
            var posts = _mapper.Map<PostViewModel>(postBL);

            return View(posts);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var userBL = _userService.GetAll().ToList();
            var users = _mapper.Map<IEnumerable<UserViewModel>>(userBL);

            ViewBag.User = new SelectList(users.Select(x => new { x.Id, FullName = $"{x.FirstName} {x.LastName}" }), "Id", "FullName");


            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Title,Body,UserId")] PostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<PostBL>(model);
                _postService.Create(modelBL);

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
            var postBL = _postService.GetById(id);
            var posts = _mapper.Map<PostViewModel>(postBL);

            return View(posts);
        }

        // POST: Category/Edit/
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,Title,Body,UserId")] PostViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<PostBL>(model);
                _postService.Update(modelBL);

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
            var postBL = _postService.GetById(id);
            var posts = _mapper.Map<PostViewModel>(postBL);

            return View(posts);
        }

        // POST: Category/Delete/
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _postService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

