using Gestor_Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestor_Presupuesto.Models.ViewModels;

namespace Gestor_Presupuesto.Controllers
{
    public class AbmController : Controller
    {
        // GET: Abm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alta()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Alta(AbmViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (presupuestos_gestorEntities db = new presupuestos_gestorEntities())
                    {
                        abm oTabla = new abm();
                        oTabla.amount = model.Amount;
                        oTabla.concept = model.Concept;
                        oTabla.date = model.Date;
                        oTabla.idType = model.IdType;
                        oTabla.operations_registered = model.Operations_registered;
                        db.abm.Add(oTabla);                       
                        db.SaveChanges();
                    }
                    return Redirect("~/Abm");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public ActionResult Operation()
        {
            List<AbmViewModels> lst;
            using (presupuestos_gestorEntities db = new presupuestos_gestorEntities())
            {
                lst = (from d in db.abm
                       select new AbmViewModels
                       {
                           Id = d.id,
                           Amount = d.amount,
                           Concept = d.concept,
                           Date = d.date,
                           IdType = d.idType,
                           Operations_registered = d.operations_registered

                       }).ToList();

            }
            return View(lst);
            
        }

        
    
    }

    
}