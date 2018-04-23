Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.Configuration
Imports System.Linq
Imports System.Web

Public Class NorthwindDataProvider
	Public Shared Function GetEmployees() As List(Of Employee)
		Dim employees As List(Of Employee) = TryCast(HttpContext.Current.Session("Employees"), List(Of Employee))
		If employees Is Nothing Then
			employees = New List(Of Employee)()
			Using connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
				Dim selectCommand As New OleDbCommand("SELECT * FROM Employees", connection)
				connection.Open()
				Dim reader As OleDbDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Do While reader.Read()
					employees.Add(New Employee() With {.EmployeeID = CInt(Fix(reader("EmployeeID"))), .FirstName = CStr(reader("FirstName")), .LastName = CStr(reader("LastName")), .HireDate = CDate(reader("HireDate")), .ReportsTo = (If(reader("ReportsTo") Is DBNull.Value, Nothing, CType(reader("ReportsTo"), Integer?)))})
				Loop
				reader.Close()
			End Using
		End If

		Return employees
	End Function

	Private Shared Function GetEmployeeByID(ByVal employeeID As Integer) As Employee
		Return GetEmployees().Where(Function(e) e.EmployeeID = employeeID).First()
	End Function
	Private Shared Function IsParent(ByVal parentID As Integer, ByVal childID As Integer) As Boolean
		Dim employee As Employee
		Dim employeeID As Integer = childID
		Do While employeeID <> 0
			employee = GetEmployeeByID(employeeID)
			If employee.EmployeeID = parentID Then
				Return True
			End If
			employeeID = CInt(Fix(If(employee.ReportsTo, 0)))
		Loop
		Return False
	End Function

	Public Shared Sub MoveEmployee(ByVal employeeID As Integer, ByVal reportsTo As Integer)
		Dim employee As Employee = GetEmployeeByID(employeeID)
		If employee.ReportsTo = reportsTo OrElse IsParent(employeeID, reportsTo) Then
			Throw New Exception("You're trying to move a parent node to its child")
			Return
		End If
		'comment the below line to perform updates
		Throw New Exception("Updates aren't allowed in online demo")
		Using connection As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
			Dim updateCommand As New OleDbCommand("UPDATE [Employees] SET [ReportsTo] = ? WHERE [EmployeeID] = ?", connection)
			updateCommand.Parameters.AddWithValue("ReportsTo", reportsTo)
			updateCommand.Parameters.AddWithValue("EmployeeID", employeeID)
			connection.Open()
			updateCommand.ExecuteNonQuery()
			HttpContext.Current.Session("Employees") = Nothing
		End Using

	End Sub


End Class
