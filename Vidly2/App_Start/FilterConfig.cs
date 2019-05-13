using System.Web;
using System.Web.Mvc;

namespace Vidly2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // adding a global [Authorize] atribute
            filters.Add(new AuthorizeAttribute());

            // adding a new filter to stop access to the app on http channel
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
