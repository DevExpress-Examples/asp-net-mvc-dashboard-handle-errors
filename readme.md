<!-- default file list -->
*Files to look at*:
* [Global.asax.cs](./CS/MvcDashboardCallbackError/Global.asax.cs) (VB: [Global.asax.vb](./VB/MvcDashboardCallbackError/Global.asax.vb))
* [CustomDashboardController.cs](./CS/MvcDashboardOverrideOnException/Controllers/CustomDashboardController.cs) (VB: [CustomDashboardController.vb](./VB/MvcDashboardOverrideOnException/Controllers/CustomDashboardController.vb))
* [DashboardConfig.cs](./CS/MvcDashboardOverrideOnException/App_Start/DashboardConfig.cs) (VB: [DashboardConfig.vb](./VB/MvcDashboardOverrideOnException/App_Start/DashboardConfig.vb))
* [Index.cshtml](./CS/MvcDashboardOverrideOnException/Views/Default/Index.cshtml) VB: [Index.vbhtml](./VB/MvcDashboardOverrideOnException/Views/Default/Index.vbhtml))
<!-- default file list end -->

# ASP.NET MVC Dashboard - How to specify custom exception text
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/267336836/)**
<!-- run online end -->

The dashboard in this project contains invalid data connection. This example shows how to override the [OnException](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.onexception) method in a custom dashboard controller to specify custom text in the exception. The exception occurs when the controller tries to load data.

![](image/web-exception-on-data-loading.png)

Create a custom dashboard controller and override the `OnException` method. The displayed text depends on whether the application is in development mode:

```cs
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
```

Specify the created custom controller's name in the view:

```html
<body>
    <div style="position:absolute; top: 0; right:0; left:0; bottom: 0">
        @Html.DevExpress().Dashboard(settings => {
            settings.ControllerName = "CustomDashboard";
            settings.Name = "Dashboard";
            settings.Width = Unit.Percentage(100);
            settings.Height = Unit.Percentage(100);
        }).GetHtml()
    </div>
</body>
```

Use the created `CustomDashboard` controller when you map a dashboard route:

```cs
public static void RegisterService(RouteCollection routes) {
	routes.MapDashboardRoute("dashboardDesigner", "CustomDashboard", new string[] { "MvcDashboardOverrideOnException" });
}
```
