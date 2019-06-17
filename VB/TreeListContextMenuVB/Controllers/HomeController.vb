Imports DevExpress.Web.Mvc
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    <ValidateInput(False)>
    Public Function TreeListPartial() As ActionResult
        Dim model = NorthwindDataProvider.GetEmployees()
        Return PartialView("_TreeListPartial", model)
    End Function

    Public Function TreeListMovePartial(ByVal employeeID As Integer, ByVal reportsTo? As Integer) As ActionResult
        NorthwindDataProvider.MoveEmployee(employeeID, Convert.ToInt32(reportsTo))
        Return TreeListPartial()
    End Function
End Class