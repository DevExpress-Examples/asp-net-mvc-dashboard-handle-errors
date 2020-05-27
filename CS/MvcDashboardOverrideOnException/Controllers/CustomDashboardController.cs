using DevExpress.DashboardWeb.Mvc;
using System;
using System.Net;
using System.Web.Mvc;

namespace MvcDashboardOverrideOnException {
    public class CustomDashboardController : DashboardController
    {
        protected override void OnException(ExceptionContext context) {
            var exception = context.Exception;
            if(exception != null && context.HttpContext != null) {
                var response = context.HttpContext.Response;
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                response.ContentType = "application/json";
                // The 'mode' attribute in the 'customErrors' section of the Web.config file specifies whether an application is in development mode.
                bool isCustomErrorsEnabled = System.Web.HttpContext.Current != null ? System.Web.HttpContext.Current.IsCustomErrorEnabled : true;

                response.Write(GetJson(isCustomErrorsEnabled ? "Custom exception text for end users" : "Custom exception text for developers"));

                context.ExceptionHandled = true;
            }
        }

        static string GetJson(string message) {
            return $"{{ \"Message\":\"{message}\" }}";
        }
    }

    public class CustomException : Exception {
        public const string SafeMessage = "Safe Message!";
        public const string UnsafeMessage = "Unsafe Message!";
    }
}