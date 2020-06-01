@Imports System.Web.UI.WebControls
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

</head>
<body>
    <div style="position:absolute; top: 0; right:0; left:0; bottom: 0">
        @Html.DevExpress().Dashboard(
        Sub(settings)
            settings.ControllerName = "CustomDashboard"
            settings.Name = "Dashboard"
            settings.Width = Unit.Percentage(100)
            settings.Height = Unit.Percentage(100)
        End Sub).GetHtml()
    </div>
</body>
