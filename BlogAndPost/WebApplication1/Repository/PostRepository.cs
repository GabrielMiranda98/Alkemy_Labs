using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PostRepository
    {
        public List<Post> TraerTodos()
        {
            using (var db = new BlogContext())
            {
                return db.blogPosts.ToList();

            }

        }

        internal void Alta(Post model)
        {
            using (var db = new BlogContext())
            {
                db.blogPosts.Add(model);
                db.SaveChanges();

            }


                    }
    }
}