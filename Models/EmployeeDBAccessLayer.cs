using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeeDB_Demo.Models;
using System.Data;

namespace EmployeeDB_Demo.Models
{
    public class EmployeeDBAccessLayer
    {

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=CoreMvcDB;Integrated Security=True");
        public string AddEmployeeRecord(EmployeeEntities employeeEntities)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_name", employeeEntities.Emp_name);
                cmd.Parameters.AddWithValue("@City", employeeEntities.City);
                cmd.Parameters.AddWithValue("@State", employeeEntities.State);
                cmd.Parameters.AddWithValue("@Country", employeeEntities.Country);
                cmd.Parameters.AddWithValue("@Department", employeeEntities.Department);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data saved Successfully");

            }
            catch (Exception ex)
            {

                if (con.State == ConnectionState.Open)
                {

                    con.Close();

                }

                return (ex.Message.ToString());
            }

        }

    }
}
