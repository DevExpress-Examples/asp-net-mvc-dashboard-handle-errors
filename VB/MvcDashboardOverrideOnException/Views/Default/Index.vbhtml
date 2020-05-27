@Using System.Web.UI.WebControls

<head>
@Html.DevExpress().GetStyleSheets(
        New StyleSheet { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        New StyleSheet { ExtensionSuite = ExtensionSuite.Editors },
        New StyleSheet { ExtensionSuite = ExtensionSuite.Dashboard }
    )
@Html.DevExpress().GetScripts(
    New Script { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
    New Script { ExtensionSuite = ExtensionSuite.Editors },
    New Script { ExtensionSuite = ExtensionSuite.Dashboard }
)

</head>
<body>
    <div style = "position: absolute; top: 0; bottom: 0; left: 0; right: 0" >
@Html.DevExpress().Dashboard(settings >= {
    settings.Name = "Dashboard";
    settings.ControllerName = "CustomDashboard";
    settings.Width = Unit.Percentage(100);
    settings.Height = Unit.Percentage(100);
}).GetHtml()
    </div>
</body>
