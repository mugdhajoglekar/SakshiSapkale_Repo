namespace ADOCrud.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using Microsoft.Ajax.Utilities;

    public class EmployeeRepository
    {
        //Declare sql connection var
        SqlConnection con;

        //get connection
        public void getconnection(){
            string checkcon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            if (checkcon != null) {
                 con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
             }
         }

        //get data
        public List<Employee> GetData()
        {
            List<Employee> emplist = new List<Employee>();
            getconnection();
            SqlCommand cmd = new SqlCommand("select_emp", con); //command
            SqlDataAdapter adt=new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adt.Fill(dt);

            //pop up all values
            foreach(DataRow dr in dt.Rows)
            {
                emplist.Add(new Employee
                {
                    Id = Convert.ToInt32(dr[0]),
                    Name=Convert.ToString(dr[1]),
                    Email=Convert.ToString(dr[2]),
                }) ;
            }
            return emplist; 
        }

        //delete
        [HttpPost]
        public bool Del(Employee obj)
        {
            getconnection();
            SqlCommand cmd = new SqlCommand("crud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@id", obj.Id);
         
            if (con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            //if value inserted then it will become 1.
            if (i >= 1)
            {
                return true; //inserted
            }
            else
            {
                return false;
            }
        }

        //update
        public bool update(Employee obj)
        {
            getconnection();
            SqlCommand cmd = new SqlCommand("crud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@email", obj.Email);

            if (con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            //if value inserted then it will become 1.
            if (i >= 1)
            {
                return true; //inserted
            }
            else
            {
                return false;
            }
        }

        //add
        public bool Add(Employee obj)
        {
            getconnection();
            SqlCommand cmd = new SqlCommand("crud",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action","add");
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name",obj.Name);
            cmd.Parameters.AddWithValue("@email", obj.Email);

            if (con.State == ConnectionState.Closed)
                con.Open();

            int i=cmd.ExecuteNonQuery();
            con.Close();
            //if value inserted then it will become 1.
            if (i >= 1)
            {
                return true; //inserted
            }
            else
            {
                return false;
            } 
        }
    }
}