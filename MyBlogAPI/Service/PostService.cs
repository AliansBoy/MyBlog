using MyBlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogAPI.Service
{
    public interface IPostService
    {
        IEnumerable<PostData> GetAllPosts();
    }
    public class PostService : IPostService
    {
        public IEnumerable<PostData> GetAllPosts()
        {
            var posts = new List<PostData>
            {
                new PostData{ Id = 1, Title = "Title from API1", Body = "Something might be here, 1 Post", UserId = 1, User = new UserData
                {  FirstName = "UserName1", LastName = "UserSurname1" , Email = "mail@mail.com", Id = 1} },
                new PostData{ Id = 2, Title = "Title from API2", Body = "Something might be here, 2 Post", UserId = 2, User = new UserData
                {  FirstName = "UserName2", LastName = "UserSurname2" , Email = "mail2@mail.com", Id = 2} },
                new PostData{ Id = 3, Title = "Title from API3", Body = "Something might be here, 3 Post", UserId = 3, User = new UserData
                {  FirstName = "UserName3", LastName = "UserSurname3" , Email = "mail3@mail.com", Id = 3} }
            };
            return posts;
        }

    }
}