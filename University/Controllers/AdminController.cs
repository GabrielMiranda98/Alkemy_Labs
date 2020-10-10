using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string admin, string password)
        {
            try
            {
                using (universityEntities db = new universityEntities())
                {
                    var lst = from d in db.admin
                              where d.user == admin && d.password == password && d.idTeacher==1
                              select d;
                    if (lst.Count() > 0)
                    {
                        admin admin1 = lst.First();
                        Session["Admin"] = admin1;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Error, admin invalido");

                    }
                }


            }
            catch (Exception ex)
            {

                return Content("Error" + ex.Message);
            }
        }
    }
}