using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

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
                    var lst = from d in db.admin
                              where d.user == user && d.password == password 
                              select d;
                    if (lst.Count()>0)
                    {
                        admin admin1 = lst.First();
                        Session["User"] = admin1;
                        return Content("1");
                    }
                }


                return Content("Error, admin invalido");
            }
            catch (Exception ex)
            {

                return Content("Error"+ex.Message);
            }
        }
    }
}