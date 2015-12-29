using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using opm_validation_service.Services;

namespace opm_validation_service {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

#region IoC
            var container = new UnityContainer();
            container.RegisterType<IOpmVerificator, OpmVerificator>(new HierarchicalLifetimeManager());

            //TODO SP: load uri from app.config..
            IIdentityManagement idm = new IdentityManagement(@"https://am-proxytest.bohemiaenergy.cz/opensso/identity/");
            container.RegisterInstance(idm);
            
            //TODO SP: load uri from app.config..
            IEanEicCheckerHttpClient eanEicCheckerHttpClient = new EanEicCheckerHttpClient("http://be-ean-eic-validator.azurewebsites.net/api/EanEicCheck");
            container.RegisterInstance(eanEicCheckerHttpClient);

            container.RegisterType<IOpmRepository, OpmRepository>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);
#endregion IoC
        }
    }
}
