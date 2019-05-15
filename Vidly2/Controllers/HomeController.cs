using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// using System.Web.UI; to access enum OutputCacheLocation
using System.Web.UI;

namespace Vidly2.Controllers
{
    // To allow anonymous users to access homepage add [AllowAnonymous] attribute to the controller
    // or to any action we want to allow anonym to visit
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // action filter, can be set to the whole controller or individual actions
        /*
         * [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam ="*")]
         * 
        [OutputCache(
            Duration = 50,  // duration of the cache set in seconds 
            Location = OutputCacheLocation.Server,  // sets the location of the cache on the server
            VaryByParam ="*")]  // ="paramName" makes a separate cache for every param of that type
                            // =" * " makes a separate cache for every param variation
        */
        // to disable output caching [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}