Imports System
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Xml.Linq
Imports DevExpress.DashboardWeb

Namespace MvcThrowCustomExceptionDashboardErrorToast
	Public Class MvcApplication
		Inherits System.Web.HttpApplication
		Protected Sub Application_Start()
			DashboardConfig.RegisterService(RouteTable.Routes)
			AreaRegistration.RegisterAllAreas()
			RouteConfig.RegisterRoutes(RouteTable.Routes)
			ControllerBuilder.Current.SetControllerFactory(GetType(RestrictedControllerFactory))

			DashboardConfigurator.Default.SetDashboardStorage(New CustomDashboardStorage())
		End Sub
	End Class

	Public Class CustomException
		Inherits Exception
		Public Const SafeMessage As String = "Custom exception text for end users"
		Public Const UnsafeMessage As String = "Custom exception text for developers"
	End Class

	Public Class CustomDashboardStorage
		Implements IDashboardStorage
		Private Function GetAvailableDashboardsInfo() As IEnumerable(Of DashboardInfo) Implements IDashboardStorage.GetAvailableDashboardsInfo
			Return {New DashboardInfo With {
				.ID = "Dashboard",
				.Name = "Dashboard"
			}}
		End Function

		Private Function LoadDashboard(ByVal dashboardID As String) As XDocument Implements IDashboardStorage.LoadDashboard
			' Custom Exception:
			Throw New CustomException()
		End Function

		Private Sub SaveDashboard(ByVal dashboardID As String, ByVal dashboard As XDocument) Implements IDashboardStorage.SaveDashboard
		End Sub
	End Class
End Namespace
