using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MultipleModels.Models
{
    public class CDBDataContext
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from employee", conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Employee emp = new Employee();
                        emp.Empid = Convert.ToInt32(rdr["Eno"]);
                        emp.Ename = rdr["Ename"].ToString();
                        emp.Job = rdr["Job"].ToString();
                        emp.Salary = Convert.ToDecimal(rdr["Salary"]);
                        emp.Dname = rdr["Dname"].ToString();
                        employees.Add(emp);
                    }
                }
                con.Close();
            }
            return employees;
        }
        public List<Dept> GetDepartments()
        {
            List<Dept> depts = new List<Dept>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Dept", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Dept dept = new Dept();
                        dept.Deptno = Convert.ToInt32(rdr["Deptno"]);
                        dept.dname = rdr["Deptname"].ToString();
                        depts.Add(dept);
                    }
                }
                con.Close();
            }
            return depts;
        }
    }
}