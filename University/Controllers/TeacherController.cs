using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Models.TableViewModels;
using University.Models.ViewModels;

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

        public ActionResult Edit(int Id)
        {
            TeacherViewModel model = new TeacherViewModel();

            using (var db = new universityEntities())
            {
                var oTeacher = db.teacher.Find(Id);
                model.Name = oTeacher.name;
                model.Dni = oTeacher.dni;
                model.SurName = oTeacher.surname;
                model.Active = oTeacher.active;
                model.Id = oTeacher.id;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(TeacherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new universityEntities())
            {
                var oTeacher = db.teacher.Find(model.Id);
                oTeacher.name = model.Name;
                oTeacher.surname = model.SurName;
                oTeacher.active = model.Active;
                oTeacher.dni = model.Dni;
                db.Entry(oTeacher).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();   

            }

            return Redirect(Url.Content("~/Teacher/Index"));
        }
    }
}