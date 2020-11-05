using System;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
