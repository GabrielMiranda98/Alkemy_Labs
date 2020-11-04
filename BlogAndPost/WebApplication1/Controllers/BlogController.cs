using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        private PostRepository _repo;

        public BlogController()
        {
            _repo = new PostRepository();
        }
        // GET: Blog
        public ActionResult Index()
        {
            var model = _repo.TraerTodos();
            return View(model);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Post model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Alta(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(model);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using(var db = new BlogContext())
            {
                Post post = db.blogPosts.Find(id);
            if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Contenido,Imagen,Categoria,FechaDeCreacion")] Post post)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogContext()) 
                { 
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            }
            return View(post);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
