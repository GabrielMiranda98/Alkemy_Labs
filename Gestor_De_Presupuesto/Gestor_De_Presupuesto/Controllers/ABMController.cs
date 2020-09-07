using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestor_De_Presupuesto.Models;
using Gestor_De_Presupuesto.Models.ViewModels;

namespace Gestor_De_Presupuesto.Controllers
{
    public class ABMController : Controller
    {
        // GET: ABM
        public ActionResult Index()
        {
            List<ABMViewModels> lst;
            using ( db = new ())
            {
                 lst = (from d in db.ABM
                           select new ABMViewModels
                           {
                               Id = d.id,
                               Amount = d.amount,
                               Concept = d.concept,
                               Date = d.date,
                               Operations_registered = d.operations_registered,
                               Type = d.idType

                           }).ToList();
            }


            return View(lst);
        }
    }
}