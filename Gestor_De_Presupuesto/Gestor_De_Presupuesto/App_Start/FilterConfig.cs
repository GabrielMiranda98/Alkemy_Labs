using System.Web;
using System.Web.Mvc;

namespace Gestor_De_Presupuesto
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
