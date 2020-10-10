using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Models.TableViewModels;

namespace University.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            List<AdminTableTeacher> lst = null;
            using (universityEntities db = new universityEntities())
            {
                lst=(from d in db.teacher
                    where d.active==1
                    orderby d.name
                    select new AdminTableTeacher { 
                        Name=d.name,Id=d.id,Dni=d.dni,Surname=d.surname,Active=d.active
                       }).ToList();
             }

            return View(lst);
        }
    }
}