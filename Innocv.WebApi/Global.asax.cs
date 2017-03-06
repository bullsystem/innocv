using System.Web;
using System.Web.Http;

namespace Innocv.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure((configuration)=>
            {
                //GlobalConfiguration.Configuration.Filters.Add(null);
                configuration.MapHttpAttributeRoutes();
                configuration.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { controller = "users", action = "getall", id = RouteParameter.Optional }
                );
            });
        }
    }
}
