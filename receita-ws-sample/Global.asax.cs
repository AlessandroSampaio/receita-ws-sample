using System.Web.Mvc;
using System.Web.Routing;
using receita_ws_sample;

namespace ReceitaWsSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
