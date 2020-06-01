using System.Net;
using System.Web.Mvc;
using DevExpress.DashboardWeb.Mvc;

namespace MvcThrowCustomExceptionDashboardErrorToast.Controllers {
    public class CustomDashboardController : DashboardController {
        protected override void OnException(ExceptionContext context) {
            var exception = context.Exception;
            if(exception != null && context.HttpContext != null) {
                var response = context.HttpContext.Response;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.ContentType = "application/json";

                CustomException customException = exception as CustomException;
                bool isCustomErrorsEnabled = System.Web.HttpContext.Current != null ? System.Web.HttpContext.Current.IsCustomErrorEnabled : true;
                string message = customException != null ? (isCustomErrorsEnabled ? CustomException.SafeMessage : CustomException.UnsafeMessage) : "";
                response.Write(GetJson(message));

                context.ExceptionHandled = true;
            }
        }

        static string GetJson(string message) {
            return $"{{ \"Message\":\"{message}\" }}";
        }
    }
}