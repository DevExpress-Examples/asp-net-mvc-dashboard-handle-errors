@Imports System.Web.UI.WebControls

<!DOCTYPE html>

<html>
<head>
    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Dashboard}
    )
    @Html.DevExpress().GetScripts(
        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
        New Script With {.ExtensionSuite = ExtensionSuite.Editors},
        New Script With {.ExtensionSuite = ExtensionSuite.Dashboard}
    )

    <style type="text/css">
        html, body, form {  
            height: 100%;  
            margin: 0;  
            padding: 0;  
            overflow: hidden;  
        }
    </style>
</head>
<body>
    @Html.DevExpress().Dashboard(
    Sub(settings)
        settings.ControllerName = "CustomDashboard"
        settings.Name = "Dashboard"
        settings.Width = Unit.Percentage(100)
        settings.Height = Unit.Percentage(100)
    End Sub).GetHtml()
</body>
</html>
