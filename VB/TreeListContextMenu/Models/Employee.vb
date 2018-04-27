Imports System
Imports System.ComponentModel.DataAnnotations

Public Class Employee
    Public Property EmployeeID() As Integer
    Public Property ReportsTo() As Integer?
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property HireDate() As Date
End Class
