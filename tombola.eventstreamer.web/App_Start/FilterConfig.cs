using System.Web;
using System.Web.Mvc;

namespace tombola.eventstreamer.web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}