using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Repository
{
    public class PostRepository
    {
        /// <summary>
        /// Lista todos los post ordenador descendientemente por fecha de creacion
        /// </summary>
        /// <returns></returns>
        public List<Post> TraerTodos()
        {
            using (var db = new BlogContext())
            {
               
                return db.blogPosts.OrderByDescending(x=>x.FechaDeCreacion).ToList();
            }

        }
        /// <summary>
        /// Agrega un post a la base de datos
        /// </summary>
        /// <param name="model"></param>
        public void Alta(Post model)
        {
            using (var db = new BlogContext())
            {
                db.blogPosts.Add(model);
                db.SaveChanges();
            }
        }


    }
}