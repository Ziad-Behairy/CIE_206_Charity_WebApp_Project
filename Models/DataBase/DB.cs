using CIE_206.Models.TableModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;

namespace CIE_206.Models.DataBase
{
    public class DB
    {
        public SqlConnection Con { get; set; }
        public DB() 
        {

            string ConnectionString = "Data Source=DESKTOP-G5CNRES;Initial Catalog=Charity_DataBase;Integrated Security=True";
            /*"Data Source=ELZOZ;Initial Catalog=TestDB;Integrated Security=True";*/
            /*"Server=DESKTOP-A27M9ME;Database=UsersAdminDB;Trusted_Connection=True;MultipleActiveResultSets=true;";*/
            Con = new SqlConnection(ConnectionString);
        }

        public object FunctionExcuteReader(string Q)
        {
            DataTable dt= new DataTable();
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand(Q, Con);
                dt.Load(cmd.ExecuteReader());
                Con.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Con.Close();
                return ex;
            }
        }

        public object FunctionExcuteScalar(string Q)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand(Q, Con);
                object NumberOfRows = cmd.ExecuteScalar();
                Con.Close();
                return NumberOfRows;
            }
            catch (SqlException ex)
            {
                Con.Close();
                return ex;
            }
        }

        public object FunctionExcuteNonQuery(string Q)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand(Q, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                Con.Close();
                return ex;
            }
        }


        public int ExcuteCommand(SqlCommand command)
        {
            int result = 0;
            try
            {
                if (Con.State != ConnectionState.Open)
                {
                    Con.Open();
                }

                command.Connection = Con;
                result = command.ExecuteNonQuery();
                Con.Close();
                return result;

            }
            catch (Exception ex)
            {
                Con.Close();
                throw ex;
            }
           

        }



        public object GetAllRows(string TableName)
        {
            return FunctionExcuteReader("Select * From " + TableName);
        }

        public object GetRow(string TableName, string Condition)
        {
            return FunctionExcuteReader("Select * From " + TableName + " where " + Condition);
        }




    }
}
