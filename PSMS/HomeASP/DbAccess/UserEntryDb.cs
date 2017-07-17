using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeASP.DataSet;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace HomeASP.DbAccess
{
    class UserEntryDb : dbAccess
    {
        public int insertUser(DataSet.DsPSMS.ST_USER_MSTRow ur, string tbName)
        {
            int result;
            if (ur == null)
                return -1;//parameter path is not,return null
            string query = "INSERT INTO " + tbName + " (USER_NAME, PASSWORD, USER_TYPE, CRT_DT_TM, CRT_USER_ID, DEL_FLG)";
            string data = "";

            data += " '" + ur.USER_NAME + "'";

            data += ", '" + ur.PASSWORD + "'";

            data += ", '" + ur.USER_TYPE + "'";

            data += ", '" + ur.CRT_DT_TM + "'";

            data += ", '" + ur.CRT_USER_ID + "'";

            data += ", '" + ur.DEL_FLG + "'";

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_USER_MSTDataTable selectUser(DataSet.DsPSMS.ST_USER_MSTRow ur)
        {
            string query = "SELECT * FROM ST_USER_MST where USER_NAME= '" + ur.USER_NAME + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_USER_MSTDataTable dt = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            da.Fill(dt);
            return dt;
        }


        public DataSet.DsPSMS.ST_USER_MSTDataTable selectAllUsers()
        {
            string query = "SELECT * FROM ST_USER_MST WHERE DEL_FLG = 0;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_USER_MSTDataTable dt = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_USER_MSTDataTable selectUserById(int id)
        {
            string query = "SELECT * FROM ST_USER_MST WHERE USER_ID =" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_USER_MSTDataTable dt = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_USER_MSTRow selectUserId( DataSet.DsPSMS.ST_USER_MSTRow  dr)
        {
            string query = "SELECT * FROM ST_USER_MST WHERE USER_NAME ='" + dr.USER_NAME + "' AND PASSWORD='" + dr.PASSWORD + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_USER_MSTDataTable dt = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            da.Fill(dt);
            return dt[0];
        }


        public int updateUser(DataSet.DsPSMS.ST_USER_MSTRow ur)
        {
            int result;
            if (ur == null)
                return -1;
            string query = "UPDATE ST_USER_MST SET ";
            string data = "";
            if (ur.USER_NAME != null)
                data += "USER_NAME= '" + ur.USER_NAME + "'";
            if (ur.USER_NAME != null)
                data += ", PASSWORD='" + ur.PASSWORD + "'";
            if (ur.USER_TYPE != null)
                data += ", USER_TYPE='" + ur.USER_TYPE + "'";
            if (ur.UPD_DT_TM != null)
                data += ", UPD_DT_TM='" + ur.UPD_DT_TM + "'";
            if (ur.UPD_USER_ID != null)
                data += ", UPD_USER_ID='" + ur.UPD_USER_ID + "'";

            query += data + " WHERE USER_ID= " + ur.USER_ID ;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public void deleteUser(int userId)
        {
            string query = "UPDATE ST_USER_MST SET DEL_FLG = 1 WHERE USER_ID =" + userId;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
