using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kest.UI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyTest1()
        {
            return View();
        }
        public ActionResult MyTest2()
        {
            return View();
        }
    }
}