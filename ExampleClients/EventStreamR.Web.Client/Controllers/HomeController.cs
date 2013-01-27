using System.Web.Mvc;
using EventStreamR.Client.Core;
using EventStreamR.Client.Core.Messages;

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
			EventStreamer.Instance.CreateEvent()
				.WithMessage("Some kind of message")
				.WithSeverity(Severity.Critical)
				.WithTags("registration UK")
				.WithSource("web1")
				.Send();
			
			return RedirectToAction("Index");


		}

		public ActionResult Increment(string key)
		{
			EventStreamer.Instance.Increment(key);
			return RedirectToAction("Index");
		}

    }
}
