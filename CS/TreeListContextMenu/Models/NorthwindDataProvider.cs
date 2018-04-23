
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Linq;
using System.Web;

public class NorthwindDataProvider {
    public static List<Employee> GetEmployees()
    {
        List<Employee> employees = HttpContext.Current.Session["Employees"] as List<Employee>;
        if (employees == null)
        {
            employees = new List<Employee>();
            using (OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                OleDbCommand selectCommand = new OleDbCommand("SELECT * FROM Employees", connection);
                connection.Open();
                OleDbDataReader reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        HireDate = (DateTime)reader["HireDate"],
                        ReportsTo = (reader["ReportsTo"] == DBNull.Value ? null : (int?)reader["ReportsTo"])
                    });
                }
                reader.Close();
            }
        }

        return employees;
    }

    static Employee GetEmployeeByID(int employeeID)
    {
        return GetEmployees().Where(e => e.EmployeeID == employeeID).First();
    }
    static bool IsParent(int parentID, int childID)
    {
        Employee employee;
        int employeeID = childID;
        while (employeeID != 0)
        {
            employee = GetEmployeeByID(employeeID);
            if (employee.EmployeeID == parentID)
                return true;
            employeeID = (int)(employee.ReportsTo ?? 0);
        }
        return false;
    }

    public static void MoveEmployee(int employeeID, int reportsTo) {
        Employee employee = GetEmployeeByID(employeeID);
        if (employee.ReportsTo == reportsTo || IsParent(employeeID, reportsTo))
        {
            throw new Exception("You're trying to move a parent node to its child");
            return;
        }
        //comment the below line to perform updates
        throw new Exception("Updates aren't allowed in online demo");
        using (OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString)) {
            OleDbCommand updateCommand = new OleDbCommand("UPDATE [Employees] SET [ReportsTo] = ? WHERE [EmployeeID] = ?", connection);
            updateCommand.Parameters.AddWithValue("ReportsTo", reportsTo);
            updateCommand.Parameters.AddWithValue("EmployeeID", employeeID);
            connection.Open();
            updateCommand.ExecuteNonQuery();
            HttpContext.Current.Session["Employees"] = null;
        }
        
    }

    
}
