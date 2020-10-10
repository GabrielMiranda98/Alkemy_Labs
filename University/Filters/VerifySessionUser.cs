using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Controllers;
using University.Models;
namespace University.Filters
{
    public class VerifySessionUser
    {
        public class VerifySession : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = (user)HttpContext.Current.Session["User"];

                if (user == null)
                {
                    if (filterContext.Controller is UserController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/User/Index");
                    }
                }
                else if (user != null && filterContext.Controller is UserController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/User/Subject");

                }

                base.OnActionExecuting(filterContext);
            }
        }
    }
}