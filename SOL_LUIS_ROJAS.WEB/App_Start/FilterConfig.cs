using System.Web;
using System.Web.Mvc;

namespace SOL_LUIS_ROJAS.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
