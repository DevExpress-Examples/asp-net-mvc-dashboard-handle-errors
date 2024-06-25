<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/267336836/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T893871)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Dashboard for MVC - How to handle errors

The following example demostrates two approaches on how to handle errors in the ASP.NET MVC Dashboard application:

- [How to specify custom text for internal Dashboard errors](#how-to-specify-custom-text-for-internal-dashboard-errors)
- [How to throw a custom exception during a server-side processing and display the error in the Dashboard error toast](#how-to-throw-a-custom-exception-during-a-server-side-processing-and-display-the-error-in-the-dashboard-error-toast)

> Both projects in this example override the [OnException](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.onexception) method. You can also handle the [ASPxWebControl.CallbackError](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxWebControl.CallbackError) event to customize error text. See the following example for details about this approach: [ASP.NET Web Forms Dashboard - How to handle errors](https://github.com/DevExpress-Examples/asp-net-web-forms-dashboard-change-default-error-text-callback-error)

## How to specify custom text for internal Dashboard errors

### Files to Review

* [Global.asax.cs](./CS/MvcCustomTextForInternalDashboardErrors/Global.asax.cs) (VB: [Global.asax.vb](./VB/MvcCustomTextForInternalDashboardErrors/Global.asax.vb))
* [CustomDashboardController.cs](./CS/MvcCustomTextForInternalDashboardErrors/Controllers/CustomDashboardController.cs) (VB: [CustomDashboardController.vb](./VB/MvcCustomTextForInternalDashboardErrors/Controllers/CustomDashboardController.vb))
* [DashboardConfig.cs](./CS/MvcCustomTextForInternalDashboardErrors/App_Start/DashboardConfig.cs) (VB: [DashboardConfig.vb](./VB/MvcCustomTextForInternalDashboardErrors/App_Start/DashboardConfig.vb))
* [Index.cshtml](./CS/MvcCustomTextForInternalDashboardErrors/Views/Default/Index.cshtml) VB: [Index.vbhtml](./VB/MvcCustomTextForInternalDashboardErrors/Views/Default/Index.vbhtml))

### Description

The dashboard in this project contains invalid data connection. This example shows how to override the [OnException](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.onexception) method in a custom dashboard controller to specify custom text in the exception. The exception occurs when the controller tries to load data.

![](image/web-custom-text-for-internal-dashboard-errors.png)

1. Create a custom dashboard controller and override the `OnException` method. You can specify the displayed text depending on whether the application is in development mode.
2. Specify the created custom controller's name in the view.
3. Use the created `CustomDashboard` controller when you map a dashboard route.

## How to throw a custom exception during a server-side processing and display the error in the Dashboard error toast

### Files to Review

* [Global.asax.cs](./CS/MvcThrowCustomExceptionDashboardErrorToast/Global.asax.cs) (VB: [Global.asax.vb](./VB/MvcThrowCustomExceptionDashboardErrorToast/Global.asax.vb))
* [DashboardConfig.cs](./CS/MvcThrowCustomExceptionDashboardErrorToast/App_Start/DashboardConfig.cs) (VB: [DashboardConfig.vb](./VB/MvcThrowCustomExceptionDashboardErrorToast/App_Start/DashboardConfig.vb))
* [CustomDashboardController.cs](./CS/MvcThrowCustomExceptionDashboardErrorToast/Controllers/CustomDashboardController.cs) (VB: [CustomDashboardController.vb](./VB/MvcThrowCustomExceptionDashboardErrorToast/Controllers/CustomDashboardController.vb))
* [Index.cshtml](./CS/MvcThrowCustomExceptionDashboardErrorToast/Views/Default/Index.cshtml) (VB: [Index.vbhtml](./VB/MvcThrowCustomExceptionDashboardErrorToast/Views/Default/Index.vbhtml))

### Description

This example shows how to throw a custom exception when a controller loads a dashboard and display this exception in the dashboard error toast. The example overrides the [OnException](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.onexception) method.

![](image/web-throw-custom-exception-dashboard-toast.png)

- Create a custom dashboard controller and override the `OnException` method. You can specify the displayed text depending on whether the application is in development mode.
- Specify the created custom controller's name in the view.
- Use the created `CustomDashboard` controller when you map a dashboard route.
- To throw an exception when the control loads a dashboard, create custom dashboard storage and override the `LoadDashboard` method.

## Documentation

- [Handle and Log Server-Side Errors in ASP.NET MVC](https://docs.devexpress.com/Dashboard/400025/web-dashboard/integrate-dashboard-component/aspnet-mvc-dashboard-extension/handle-and-log-server-side-errors-in-asp-net-mvc)

## More Examples

- [ASP.NET Web Forms Dashboard - How to handle errors](https://github.com/DevExpress-Examples/asp-net-web-forms-dashboard-change-default-error-text-callback-error)
- [ASP.NET Core Dashboard - How to handle errors](https://github.com/DevExpress-Examples/asp-net-core-dashboard-change-default-error-text-exception-filter)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-dashboard-handle-errors&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-mvc-dashboard-handle-errors&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
