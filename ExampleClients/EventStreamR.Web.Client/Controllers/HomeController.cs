using System.Web.Mvc;
using EventStreamR.Core;

namespace EventStreamR.Web.Client.Controllers
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

		public ActionResult Increment(string key)
		{
			EventStreamer.Instance.Increment(key);
			return RedirectToAction("Index");
		}

    }
}
