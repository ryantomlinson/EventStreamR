using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tombola.eventstreamer.core;

namespace tombola.eventstreamer.web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult SendEvent()
		{
			EventStreamer.Instance.Send("ryan", "test");
			return RedirectToAction("Index");
		}

    }
}
