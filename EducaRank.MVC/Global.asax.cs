using EducaRank.IOC;
using System.Web.Mvc;
using System.Web.Routing;

namespace EducaRank.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(SimpleInjectorContainer.RegisterServices());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
