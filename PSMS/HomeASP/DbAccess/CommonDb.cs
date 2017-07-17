using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HomeASP.DbAccess
{
    public class CommonDb :dbAccess
    {
        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectAllGrade()
        {
            Open();
            string query = "SELECT * FROM ST_GRADE_MST";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            Close();
            return dt;

        }
    }
}