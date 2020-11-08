using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        : base("localhost")
        {
        }
        public DbSet<Post> blogAndPosts { get; set; }
    }
}