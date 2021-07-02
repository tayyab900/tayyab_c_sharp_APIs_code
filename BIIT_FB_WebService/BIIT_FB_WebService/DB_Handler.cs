using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace BIIT_FB_WebService
{
    public class DB_Handler
    {
        SqlConnection sqlcon;
        SqlCommand sqlcom;
        SqlDataAdapter adp;


        public DB_Handler()
        {
            sqlcon = new SqlConnection(@"Data Source=PROBOOK;Initial Catalog=BIIT_FB;Persist Security Info=True;User ID=sa;Password=123");
            sqlcom = new SqlCommand();

        }
        private bool openConnection()
        {
            try
            {
                sqlcon.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }
        private void closeConnection()
        {
            sqlcon.Close();
        }
        public object ExecuteAggResult(string query)
        {
            if (openConnection())
            {
                openConnection();
                sqlcom.CommandText = query;
                sqlcom.Connection = sqlcon;
                object result = sqlcom.ExecuteScalar();
                closeConnection();
                return result;
            }
            else
                return null;
        }

        public DataTable ExecuteSelect(string query)
        {
            // if (openConnection())
            {
                openConnection();
                var dt = new DataTable();
                adp = new SqlDataAdapter(query, sqlcon);
                adp.Fill(dt);
                closeConnection();
                int b = dt.Rows.Count;
                return dt;
            }
            //return null;
        }

        public SqlDataReader ExecuteSelect_reader(string query)
        {
            // if (openConnection())
            {
                openConnection();
                sqlcom = new SqlCommand(query, sqlcon);
                SqlDataReader sdr;
                sdr = sqlcom.ExecuteReader();
                closeConnection();
                return sdr;
            }
            //return null;
        }

        public bool ExecuteQuery(string query)
        {
            try
            {

                openConnection();
                sqlcom.CommandText = query;
                sqlcom.Connection = sqlcon;
                sqlcom.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }

}