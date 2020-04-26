using MyBlogDAL;
using MyBlogDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL
{
    public class BlogContextDbInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext db)
        {
            #region Category
            Category category1 = new Category { Description = "Description1", Name = "Name1" };
            Category category2 = new Category { Description = "Description2", Name = "Name2" };
            Category category3 = new Category { Description = "Description3", Name = "Name3" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);
            db.SaveChanges();
            #endregion

            #region Tag
            Tag tag1 = new Tag { Name = "Tag Name1" };
            Tag tag2 = new Tag { Name = "Tag Name2" };
            Tag tag3 = new Tag { Name = "Tag Name3" };

            db.Tags.Add(tag1);
            db.Tags.Add(tag2);
            db.Tags.Add(tag3);
            db.SaveChanges();
            #endregion

            #region User
            User user1 = new User { FirstName = "FName1", LastName = "LName1", Email = "email1@gmail.com" };
            User user2 = new User { FirstName = "FName2", LastName = "LName2", Email = "email2@gmail.com" };
            User user3 = new User { FirstName = "FName3", LastName = "LName3", Email = "email3@gmail.com" };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.SaveChanges();
            #endregion

            #region Post
            Post post1 = new Post { Title = "Title1", Body = "Post Body1", UserId = 1 };
            Post post2 = new Post { Title = "Title2", Body = "Post Body2", UserId = 2 };
            Post post3 = new Post { Title = "Title3", Body = "Post Body3", UserId = 3 };

            db.Posts.Add(post1);
            db.Posts.Add(post2);
            db.Posts.Add(post3);
            db.SaveChanges();
            #endregion

            #region Comment
            Comment comment1 = new Comment { Body = "Comment Body1", PostId = 1, UserId = 1 };
            Comment comment2 = new Comment { Body = "Comment Body2", PostId = 2, UserId = 2 };
            Comment comment3 = new Comment { Body = "Comment Body3", PostId = 3, UserId = 3 };

            db.Comments.Add(comment1);
            db.Comments.Add(comment2);
            db.Comments.Add(comment3);
            db.SaveChanges();
            #endregion         

        }
    }
}
