<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>

    @Html.DevExpress().GetStyleSheets( new StyleSheet with { .ExtensionSuite = ExtensionSuite.TreeList },
     new StyleSheet with { .ExtensionSuite = ExtensionSuite.NavigationAndLayout })
@Html.DevExpress().GetScripts(new Script with { .ExtensionSuite = ExtensionSuite.NavigationAndLayout },   
    new Script with { .ExtensionSuite = ExtensionSuite.TreeList })
</head>

<body>
    @RenderBody()
</body>
</html>