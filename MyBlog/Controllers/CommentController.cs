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
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IPostService postService, IUserService userService, IMapper mapper)
        {
            _commentService = commentService;
            _userService = userService;
            _postService = postService;
            _mapper = mapper;
        }
        // GET: Category
        public ActionResult Index()
        {
            var commentsBL = _commentService.GetAll().ToList();
            var comments = _mapper.Map<IEnumerable<CommentViewModel>>(commentsBL);

            return View(comments);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var commentsBL = _commentService.GetById(id);
            var comments = _mapper.Map<CommentViewModel>(commentsBL);

            return View(comments);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var userBL = _userService.GetAll().ToList();
            var users = _mapper.Map<IEnumerable<UserViewModel>>(userBL);

            ViewBag.User = new SelectList(users.Select(x => new { x.Id, FullName = $"{x.FirstName} {x.LastName}" }), "Id", "FullName");

            var postBL = _postService.GetAll().ToList();
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(postBL);

            ViewBag.Post = new SelectList(posts.Select(x => new { x.Id, x.Title }), "Id", "Title");

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Body,UserId,PostId")] CommentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<CommentBL>(model);
                _commentService.Create(modelBL);

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
            var commentsBL = _commentService.GetById(id);
            var comments = _mapper.Map<CommentViewModel>(commentsBL);

            return View(comments);
        }

        // POST: Category/Edit/
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,Body,UserId,PostId")] CommentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var modelBL = _mapper.Map<CommentBL>(model);
                _commentService.Update(modelBL);

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
            var commentsBL = _commentService.GetById(id);
            var comments = _mapper.Map<CommentViewModel>(commentsBL);

            return View(comments);
        }

        // POST: Category/Delete/
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _commentService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

