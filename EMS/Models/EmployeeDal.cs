using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class EmployeeDal
    {
        string cs = ConfigurationManager.ConnectionStrings["emsconn"].ConnectionString;

        public List<Employee> GetAllEmployees()
        {
            //Read All Data
            List<Employee> list = new List<Employee>();
            using (SqlConnection con = new SqlConnection(cs)) 
            {
                SqlCommand cmd = new SqlCommand("select * from EmployeeDb", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(); 

                while (dr.Read()) 
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Age = Convert.ToInt32(dr["Age"]);
                    emp.Salary = Convert.ToInt32(dr["Salary"]);
                    emp.City = dr["City"].ToString();
                    emp.Location = dr["Location"].ToString();

                    list.Add(emp);
                }
            }
            return list;
        }

        //Insert

        public bool InsertEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("insert into EmployeeDb(Name,Gender,Age,Salary,City,Location) values(@Name,@Gender,@Age,@Salary,@City,@Location)", con);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Location", emp.Location);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;

            }
        }

        //Employye Get by Id

        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from EmployeeDb where Id = @Id",con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    //cmd.Parameters.AddWithValue("@Name", emp.Name);
                    //cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    //cmd.Parameters.AddWithValue("@Age", emp.Age);
                    //cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    //cmd.Parameters.AddWithValue("@City", emp.City);
                    //cmd.Parameters.AddWithValue("@Location", emp.Location);

                    emp.Id = Convert.ToInt32(dr["Id"]); 
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Age = Convert.ToInt32(dr["Age"]);
                    emp.Salary = Convert.ToInt32(dr["Salary"]);
                    emp.City = dr["City"].ToString();
                    emp.Location = dr["Location"].ToString();
                }
            }
            return emp;
        }

        //Update
        public bool UpdateEmployee(Employee emp)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                //SqlCommand cmd = new SqlCommand("update EmployeeDb set Name=@Name,Gender=@Gender,Age=@Age,@Salary=@Salary,City=@City,Location=@Location", con);
                SqlCommand cmd = new SqlCommand(
                  "update EmployeeDb set Name=@Name, Gender=@Gender, Age=@Age, " 
                + "Salary=@Salary, City=@City, Location=@Location "
                + "WHERE Id=@Id", con);
                {
                   cmd.Parameters.AddWithValue("@Id", emp.Id);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Age", emp.Age);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@City", emp.City);
                    cmd.Parameters.AddWithValue("@Location", emp.Location);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        //Delete

        public bool DeleteEmployee(int id)
        {
            using(SqlConnection con =new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("delete from EmployeeDb where Id = @Id", con);
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }


    }
}