Imports Microsoft.VisualBasic
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace MvcCustomTextForInternalDashboardErrors
	Public Class MvcApplication
		Inherits System.Web.HttpApplication

		Protected Sub Application_Start()
			DashboardConfig.RegisterService(RouteTable.Routes)
			AreaRegistration.RegisterAllAreas()
			RouteConfig.RegisterRoutes(RouteTable.Routes)
			ControllerBuilder.Current.SetControllerFactory(GetType(RestrictedControllerFactory))

			Dim dataSourceStrorage As New DataSourceInMemoryStorage()

			Dim sql As New DashboardSqlDataSource("sql")
			sql.Queries.Add(SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("query"))
			dataSourceStrorage.RegisterDataSource(sql.SaveToXml())

			DashboardConfigurator.Default.SetDashboardStorage(New DashboardFileStorage(Server.MapPath("~/App_Data/Dashboards")))
			DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStrorage)
			AddHandler DashboardConfigurator.Default.ConfigureDataConnection, AddressOf ASPxDashboard1_ConfigureDataConnection
		End Sub

		Private Sub ASPxDashboard1_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureDataConnectionWebEventArgs)
			' Invalid connection parameters:
			Select Case e.DataSourceName
				Case "sql"
					e.ConnectionParameters = New MsSqlConnectionParameters("localhost", "Northwind123", Nothing, Nothing, MsSqlAuthorizationType.Windows)
			End Select
		End Sub
	End Class
End Namespace
