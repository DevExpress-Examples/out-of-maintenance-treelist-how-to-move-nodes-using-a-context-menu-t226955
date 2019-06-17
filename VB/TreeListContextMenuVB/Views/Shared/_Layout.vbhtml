<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>@ViewData("Title")</title>

    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors },
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.TreeList }
    )
    @Html.DevExpress().GetScripts(
        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        New Script With {.ExtensionSuite = ExtensionSuite.Editors },
        New Script With {.ExtensionSuite = ExtensionSuite.TreeList }
    )
</head>

<body>
    @RenderBody()
</body>
</html>