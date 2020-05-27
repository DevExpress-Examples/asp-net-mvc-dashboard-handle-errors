Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.DashboardCommon

Namespace MvcDashboardOverrideOnException

	Public Class DefaultController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function
	End Class
End Namespace