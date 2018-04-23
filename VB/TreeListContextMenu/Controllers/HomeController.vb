Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace TreeListContextMenu.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		Public Function Index() As ActionResult
			Return View()
		End Function


		Public Function TreeListPartial() As ActionResult
			Return PartialView(NorthwindDataProvider.GetEmployees())
		End Function


		Public Function TreeListMovePartial(ByVal employeeID As Integer, ByVal reportsTo? As Integer) As ActionResult
			NorthwindDataProvider.MoveEmployee(employeeID, Convert.ToInt32(reportsTo))
			Return PartialView("TreeListPartial", NorthwindDataProvider.GetEmployees())
		End Function


	End Class
End Namespace
