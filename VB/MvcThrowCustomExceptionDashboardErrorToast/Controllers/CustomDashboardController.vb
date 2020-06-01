Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Web.Mvc
Imports DevExpress.DashboardWeb.Mvc

Namespace MvcThrowCustomExceptionDashboardErrorToast.Controllers
	Public Class CustomDashboardController
		Inherits DashboardController
		Protected Overrides Sub OnException(ByVal context As ExceptionContext)
			Dim exception = context.Exception
			If exception IsNot Nothing AndAlso context.HttpContext IsNot Nothing Then
				Dim response = context.HttpContext.Response
				response.StatusCode = CInt(Fix(HttpStatusCode.BadRequest))
				response.ContentType = "application/json"

				Dim customException As CustomException = TryCast(exception, CustomException)
				Dim isCustomErrorsEnabled As Boolean = If(System.Web.HttpContext.Current IsNot Nothing, System.Web.HttpContext.Current.IsCustomErrorEnabled, True)
				Dim message As String = If(customException IsNot Nothing, (If(isCustomErrorsEnabled, CustomException.SafeMessage, CustomException.UnsafeMessage)), "")
				response.Write(GetJson(message))

				context.ExceptionHandled = True
			End If
		End Sub

		Private Shared Function GetJson(ByVal message As String) As String
			Return $"{{ ""Message"":""{message}"" }}"
		End Function
	End Class
End Namespace