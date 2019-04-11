using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace TrainingDB
{
    public class EmployeeRepository
    {
        string connString = @"Server = VALJASEK\SQL2017; Database = AdventureWorks; Trusted_Connection = True;";

        public BindingList<Employee> FillData()
        {
            string sqlGetAll = @" select * from HumanResources.Employee;";
            BindingList<Employee> employees = new BindingList<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    try
                    {
                        using(SqlCommand cmd = new SqlCommand(sqlGetAll, connection))
                        {
                            try
                            {
                                using(SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Employee employee = new Employee();
                                        employee.BussinessEntityID = reader.GetInt32(0);
                                        employee.NationallIDNumber = reader.GetString(1);
                                        employee.LoginID = reader.GetString(2);
                                        //employee.OrganizationNode = reader.GetString(3);
                                        employee.OrgnizationLevel = reader.IsDBNull(4) ? 0:reader.GetInt16(4);
                                        employee.JobTitle = reader.GetString(5);
                                        employee.BirthDate = reader.GetDateTime(6);
                                        employee.MaritalStatus = reader.GetString(7)[0];
                                        employee.Gender = reader.GetString(8)[0];
                                        employee.HireDate = reader.GetDateTime(9);
                                        employee.SalariedFlag = reader.GetBoolean(10);
                                        employee.VacationHours = reader.GetInt16(11);
                                        employee.SickLeaveHours = reader.GetInt16(12);
                                        employee.CurrentFlag = reader.GetBoolean(13);
                                        employee.RowGuid = reader.GetGuid(14);
                                        employee.ModifiedDate = reader.GetDateTime(15);
                                        employees.Add(employee);

                                    }
                                }
                            }
                            catch(Exception e)
                            {
                                Debug.WriteLine(e.Message);
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return employees;
        }

        public DataSet FillDataSet()
        {
            string sqlQuery = @"select p.[BusinessEntityID]
       ,[PersonType]
      ,[NameStyle]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[EmailPromotion]
      ,[AdditionalContactInfo]
      ,[Demographics]
      ,p.[rowguid]
      ,p.[ModifiedDate]
	  ,EmailAddress
	  ,PhoneNumber from Person.Person as p
  join Person.EmailAddress as e on p.BusinessEntityID=e.BusinessEntityID
  join Person.PersonPhone as ph on p.BusinessEntityID = ph.BusinessEntityID ";
            DataSet ds = new DataSet();
            try
            {
                using(SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                    adapter.Fill(ds, "Person");
                    DataTable dt = ds.Tables["Person"];  
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }


            return ds;
        }

        public DataSet FilterDataSet(string name,string surname)
        {
            string sqlQuery = @"select p.[BusinessEntityID]
       ,[PersonType]
      ,[NameStyle]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[EmailPromotion]
      ,[AdditionalContactInfo]
      ,[Demographics]
      ,p.[rowguid]
      ,p.[ModifiedDate]
	  ,EmailAddress
	  ,PhoneNumber from Person.Person as p
  join Person.EmailAddress as e on p.BusinessEntityID=e.BusinessEntityID
  join Person.PersonPhone as ph on p.BusinessEntityID = ph.BusinessEntityID
  where firstname like @name and lastname like @surname";
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    using(SqlCommand sqlCmd = new SqlCommand(sqlQuery, connection))
                    {
                        sqlCmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = $"%{name}%";
                        sqlCmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = $"%{surname}%";
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                        adapter.Fill(ds, "Person");
                        DataTable dt = ds.Tables["Person"];
                    }                    
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return ds;
        }
    }
}
