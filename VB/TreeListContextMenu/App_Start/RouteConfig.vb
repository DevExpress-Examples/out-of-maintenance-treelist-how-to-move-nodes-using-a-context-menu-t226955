Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace TreeListContextMenu
    Public Class RouteConfig
        Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}")

            routes.MapRoute(name:= "Default", url:= "{controller}/{action}/{id}", defaults:= New With { _
                Key .controller = "Home", _
                Key .action = "Index", _
                Key .id = UrlParameter.Optional _
            })
        End Sub
    End Class
End Namespace