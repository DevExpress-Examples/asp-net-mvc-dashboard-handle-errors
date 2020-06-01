Imports Microsoft.VisualBasic
Imports DevExpress.DashboardWeb.Mvc
Imports System
Imports System.Net
Imports System.Web.Mvc

Namespace MvcCustomTextForInternalDashboardErrors
	Public Class CustomDashboardController
		Inherits DashboardController
		Protected Overrides Sub OnException(ByVal context As ExceptionContext)
			Dim exception = context.Exception
			If exception IsNot Nothing AndAlso context.HttpContext IsNot Nothing Then
				Dim response = context.HttpContext.Response
				response.StatusCode = CInt(Fix(HttpStatusCode.BadRequest))

				response.ContentType = "application/json"
				' The 'mode' attribute in the 'customErrors' section of the Web.config file specifies whether an application is in development mode.
				Dim isCustomErrorsEnabled As Boolean = If(System.Web.HttpContext.Current IsNot Nothing, System.Web.HttpContext.Current.IsCustomErrorEnabled, True)

				response.Write(GetJson(If(isCustomErrorsEnabled, "Custom exception text for end users", "Custom exception text for developers")))

				context.ExceptionHandled = True
			End If
		End Sub

		Private Shared Function GetJson(ByVal message As String) As String
			Return $"{{ ""Message"":""{message}"" }}"
		End Function
	End Class
End Namespace