using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace HomeASP.DbAccess
{
    public class dbAccess
    {
        private string path = @"C:\Users\USER\Desktop\PSMS20170705\PSMS_Final\ConStrPSMS.txt";
        private string conStr = "";
        public SqlConnection conn = new SqlConnection();

        // Reading file path
        private void getConnectionStr()
        {
            StreamReader sr = File.OpenText(path);
            conStr = sr.ReadLine();
        }

        //Get connection to Database
        public SqlConnection Open()
        {
            getConnectionStr();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return conn;
            }
            else
            {
                conn = new SqlConnection(conStr);
                conn.Open();
            }
            return conn;
        }

        //close Database connection
        public void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    
    }
}
