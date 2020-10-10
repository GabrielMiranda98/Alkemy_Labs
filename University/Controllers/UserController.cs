using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Models.TableViewModels;

namespace University.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string user, string password)
        {
            try
            {   using (universityEntities db = new universityEntities())
                {
                    var lst = from d in db.user
                              where d.user1 == user && d.password == password 
                              select d;
                    if (lst.Count()>0)
                    {
                        user auxUser = lst.First();
                        Session["User"] = auxUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Error, usuario invalido");

                    }

                }

            }
            catch (Exception ex)
            {

                return Content("Error"+ex.Message);
            }
        }
    
        public ActionResult Subject()
        {
            List<UserTableSubjet> lst = null;
            using (universityEntities db = new universityEntities())
            {
                lst = (from d in db.subjet
                       orderby d.name
                       select new UserTableSubjet
                       {
                           Id=d.id,Info=d.info,MaxStudent=d.maxStudent,Name=d.name,Teacher=d.teacher,Time=d.time
                       }).ToList();
            }

            return View(lst);
        }
    }
}