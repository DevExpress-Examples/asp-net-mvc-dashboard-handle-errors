using System.Web;
using System.Web.Mvc;

namespace MvcCustomTextForInternalDashboardErrors {
    public class RestrictedControllerFactory : DefaultControllerFactory {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName) {
            var controller = base.CreateController(requestContext, controllerName);
            if (controller.GetType() == typeof(DevExpress.DashboardWeb.Mvc.DashboardController)) {
                throw new HttpException(404, string.Format("The controller '{0}' was not found", controllerName));
            }
            return controller;
        }
    }
}