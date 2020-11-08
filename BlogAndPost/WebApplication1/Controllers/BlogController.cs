using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using System.IO;
using System.Resources;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        #region Atributos 
        private PostRepository _repo;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor para inicializar la variable local
        /// </summary>
        public BlogController()
        {
            _repo = new PostRepository();
        }
        #endregion
        #region Metodos 
        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            try
            {
                byte[] imageBytes;
                BinaryReader reader = new BinaryReader(image.InputStream);
                imageBytes = reader.ReadBytes((int)image.ContentLength);
                return imageBytes;
            }
            catch (Exception)
            {
                throw;
            }

        }
        [AllowAnonymous]
        public ActionResult MostrarImagen(int id)
        {
            using (var db = new BlogContext())
            {
                Post post = db.blogAndPosts.Find(id);

                byte[] cover = post.Imagen;

                if (cover != null)
                {
                    return File(cover, "image/jpg");
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region Index       
        // GET: Blog
        /// <summary>
        /// Vista de todos los post que esten activos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _repo.TraerTodos();
            return View(model);
        }

        #endregion
        #region Detalles

        // GET: Blog/Details/5
        /// <summary>
        /// Detalle del post seleccionado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new BlogContext())
            {
                Post post = db.blogAndPosts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }
        }
        #endregion
        #region Crear
        // GET: Blog/Create
        /// <summary>
        /// Retorna la vista de la creacion de un nuevo post
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            Post post = new Post();
            return View(post);
        }

        // POST: Blog/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post model, HttpPostedFileBase ImagenForm)
        {

            if (ImagenForm != null && ImagenForm.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenForm.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenForm.ContentLength);
                }
                model.Imagen = imageData;
            }
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

        #endregion
        #region Editar
        // GET: Blog/Edit/5
        /// <summary>
        /// Busca el id para editarlo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            using (var db = new BlogContext())
            {
                Post post = db.blogAndPosts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }

        }

        /// <summary>
        /// Accion que edita el post y lo guarda en la base de datos
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Contenido,Imagen,Categoria,FechaDeCreacion")] Post post)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogContext())
                {
                    db.Entry(post).State = EntityState.Modified;
                    post.Activo = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(post);
        }

        #endregion
        #region Eliminar
        // GET: Blog/Edit/5
        /// <summary>
        /// Busca el id para eliminarlo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new BlogContext())
            {
                Post post = db.blogAndPosts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }
        }
        /// <summary>
        /// Accion que cambia el estado del post y lo guarda en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new BlogContext())
            {
                Post post = db.blogAndPosts.Find(id);
                //post.Activo = false;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        #endregion 
        #region Listar para Eliminacion
        /// <summary>
        /// Lista los post para que el usuario elija cual eliminar
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult ElegirEliminar(string searchString)
        {
            using (var db = new BlogContext())
            {
                var post = from d in db.blogAndPosts
                           select d;

                if (!String.IsNullOrEmpty(searchString))
                {
                    post = post.Where(s => s.Titulo.Contains(searchString));
                    if (post.Count() == 0)
                    {
                        return Content("Titulo no encontrado");
                    }
                }


                return View(post.ToList());
            }
        }

        #endregion
        #region Categorias
        /// <summary>
        /// Muestra solo los post de la Categoria Economia
        /// </summary>
        /// <returns></returns>
        public ActionResult Economia()
        {
            using (var db = new BlogContext())
            {
                var articuloEconomia = db.blogAndPosts.Where(x => x.Categoria == "Economia");

                return View(articuloEconomia.ToList());
            }
        }
        /// <summary>
        /// Muestra solo los post de la Categoria Politica
        /// </summary>
        /// <returns></returns>
        public ActionResult Politica()
        {
            using (var db = new BlogContext())
            {
                var articuloPolitica = db.blogAndPosts.Where(x => x.Categoria == "Politica");
                return View(articuloPolitica.ToList());
            }
        }
        /// <summary>
        /// Muestra solo los post de la Categoria Deporte
        /// </summary>
        /// <returns></returns>
        public ActionResult Deporte()
        {
            using (var db = new BlogContext())
            {
                var articuloDeporte = db.blogAndPosts.Where(x => x.Categoria == "Deporte");
                return View(articuloDeporte.ToList());
            }
        }
        /// <summary>
        /// Muestra solo los post de la Categoria Otro
        /// </summary>
        /// <returns></returns>
        public ActionResult Otro()
        {
            using (var db = new BlogContext())
            {
                var articuloOtro = db.blogAndPosts.Where(x => x.Categoria == "Otro");
                return View(articuloOtro.ToList());
            }
        }
        #endregion
        #region Listar para Edicion
        /// <summary>
        /// Lista los post para que el usuario elija cual editar
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult ElegirEdicion(string searchString)
        {
            using (var db = new BlogContext())
            {
                var post = from d in db.blogAndPosts
                           select d;

                if (!String.IsNullOrEmpty(searchString))
                {
                    post = post.Where(s => s.Titulo.Contains(searchString));
                    if (post.Count() == 0)
                    {
                        return Content("Titulo no encontrado");
                    }

                }


                return View(post.ToList());
            }
        }

        #endregion
        #region Listar Eliminados
        /// <summary>
        /// Muestra los post eliminados logicos 
        /// </summary>
        /// <returns></returns>
        public ActionResult Eliminados()
        {
            var model = _repo.TraerTodos();
            return View(model);
        }
        #endregion

    }
}
