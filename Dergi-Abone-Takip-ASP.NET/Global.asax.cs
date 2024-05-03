using Dergi_Abone_Takip_ASP.NET.Tasks.Triggers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dergi_Abone_Takip_ASP.NET
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CezaArttirmaDusurmeTrigger.Baslat();
        }
    }
}
