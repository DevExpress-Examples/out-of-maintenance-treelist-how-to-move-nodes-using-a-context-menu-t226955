Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel.DataAnnotations

Public Class Employee
	Private privateEmployeeID As Integer
	Public Property EmployeeID() As Integer
		Get
			Return privateEmployeeID
		End Get
		Set(ByVal value As Integer)
			privateEmployeeID = value
		End Set
	End Property
	Private privateReportsTo? As Integer
	Public Property ReportsTo() As Integer?
		Get
			Return privateReportsTo
		End Get
		Set(ByVal value? As Integer)
			privateReportsTo = value
		End Set
	End Property
	Private privateFirstName As String
	Public Property FirstName() As String
		Get
			Return privateFirstName
		End Get
		Set(ByVal value As String)
			privateFirstName = value
		End Set
	End Property
	Private privateLastName As String
	Public Property LastName() As String
		Get
			Return privateLastName
		End Get
		Set(ByVal value As String)
			privateLastName = value
		End Set
	End Property
	Private privateHireDate As DateTime
	Public Property HireDate() As DateTime
		Get
			Return privateHireDate
		End Get
		Set(ByVal value As DateTime)
			privateHireDate = value
		End Set
	End Property
End Class
