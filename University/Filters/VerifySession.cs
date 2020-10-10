using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Controllers;
using University.Models;

namespace University.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var admin = (admin)HttpContext.Current.Session["Admin"];

            if (admin == null)
            {
                if (filterContext.Controller is AdminController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Admin/Index");
                }
            }
            else if (admin!=null&&filterContext.Controller is AdminController == true)
            {
                filterContext.HttpContext.Response.Redirect("~/Teacher/Index");

            }

            base.OnActionExecuting(filterContext);
        }
    }
}