Imports System.Web
Imports System.Web.Mvc

Public Class RestrictedControllerFactory
    Inherits DefaultControllerFactory

    Public Overrides Function CreateController(ByVal requestContext As System.Web.Routing.RequestContext, ByVal controllerName As String) As IController
        Dim controller = MyBase.CreateController(requestContext, controllerName)
        If DirectCast(controller, Object).GetType() Is GetType(DevExpress.DashboardWeb.Mvc.DashboardController) Then
            Throw New HttpException(404, String.Format("The controller '{0}' was not found", controllerName))
        End If
        Return controller
    End Function
End Class