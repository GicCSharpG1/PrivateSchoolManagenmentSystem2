using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.DbAccess
{
    public class StaffDb : dbAccess
    {
        string query = "";

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectStaffByID(DataSet.DsPSMS.ST_STAFF_DATARow dr)
        {
            string query = "SELECT * FROM ST_STAFF_DATA where STAFF_ID= " + dr.STAFF_ID + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STAFF_DATADataTable dt = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertStaff(DataSet.DsPSMS.ST_STAFF_DATARow dr)
        {
            int result;
            string data = "";
            if (dr == null)
                return -1;
            Open();
            //int currentYear = DateTime.Now.Year;
            //DateTime date = DateTime.Now.Date;
            //String currentDate = date.ToString().Substring(0, 19);
            string query = "INSERT INTO ST_STAFF_DATA (EDU_YEAR, STAFF_ID,POSITION_ID, STAFF_NAME,GENDER,PHONE,DOB,NRC_NO,MARRIED_STATUS,ADDRESS,EDUCATION,PHOTO_PATH,SALARY, CRT_DT_TM, CRT_USER_ID, DEL_FLG)";
            data += " '" + dr.EDU_YEAR + "'";
            data += ", '" + dr.STAFF_ID + "'";
            data += ", '" + dr.POSITION_ID + "'";
            data += ", '" + dr.STAFF_NAME + "'";
            data += ", '" + dr.GENDER + "'";
            data += ", '" + dr.PHONE + "'";
            data += ", '" + dr.DOB + "'";
            data += ", '" + dr.NRC_NO + "'";
            data += ", '" + dr.MARRIED_STATUS + "'";
            data += ", '" + dr.ADDRESS + "'";
            data += ", '" + dr.EDUCATION + "'";

            data += ", '" + dr.PHOTO_PATH + "'";

            data += ", " + dr.SALARY + "";
            if (!dr.IsCRT_DT_TMNull())
                data += ", '" + dr.CRT_DT_TM + "'";
            else
                data += ", '  '";
            if (!dr.IsCRT_USER_IDNull())
                data += ", '" + dr.CRT_USER_ID + "'";
            else
                data += ", '  '";
            

            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int insertPhoto(string strname, DataSet.DsPSMS.ST_STAFF_DATARow dr)
        {
            int result;
            string data = "";
            if (strname == null)
                return -1;
            Open();
            int currentYear = DateTime.Now.Year;
            //DateTime date = DateTime.Now.Date;
            //String currentDate = date.ToString().Substring(0, 19);
            string query = "UPDATE  ST_STAFF_DATA SET";

            if (strname != null)
                query += "PHOTO_PATH= '" + strname + "'";
            else
                data += " '  '";
            query += " WHERE STAFF_ID= '" + dr.STAFF_ID + "'";
            query += " AND STAFF_NAME= '" + dr.STAFF_NAME + "';";

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int updateStaff(DataRow dr)
        {
            Open();
            string query = "";
            string data = "";
            int result;

            query = "UPDATE ST_STAFF_DATA SET ";
            data += "EDU_YEAR ='" + dr["EDU_YEAR"] + "'";
            data += ", STAFF_ID = '" + dr["STAFF_ID"] + "'";
            data += ", POSITION_ID = '" + dr["POSITION_ID"] + "'";
            data += ", STAFF_NAME = '" + dr["STAFF_NAME"] + "'";
            data += ", GENDER= '" + dr["GENDER"] + "'";
            data += ", PHONE= '" + dr["PHONE"] + "'";
            data += ", DOB= '" + dr["DOB"] + "'";
            data += ", NRC_NO= '" + dr["NRC_NO"] + "'";
            data += ", MARRIED_STATUS= '" + dr["MARRIED_STATUS"] + "'";
            data += ", ADDRESS= '" + dr["ADDRESS"] + "'";
            data += ", EDUCATION= '" + dr["EDUCATION"] + "'";
            data += ", PHOTO_PATH= '" + dr["PHOTO_PATH"] + "'";
            data += ", SALARY= " + dr["SALARY"] + "";

            data += ", CRT_DT_TM = '" + dr["CRT_DT_TM"] + "'";
            data += ", CRT_USER_ID = '" + dr["CRT_USER_ID"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = '" + 0 + "'";

            query += data + " WHERE STAFF_ID =" + dr["STAFF_ID"];
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;

        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectAllStaffData()
        {
            Open();
            string query = "SELECT * FROM ST_STAFF_DATA WHERE DEL_FLG = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STAFF_DATADataTable dt = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            da.Fill(dt);
            Close();
            return dt;
        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectStaffData(string staffname,string staffId)
        {
                        
            DsPSMS.ST_STAFF_DATADataTable StaffNaId = new DsPSMS.ST_STAFF_DATADataTable();
            Open();
            string query = "SELECT * from ST_STAFF_DATA WHERE STAFF_NAME='" + staffname + "'AND STAFF_ID= '" + staffId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(StaffNaId);
            Close();
            return StaffNaId;
                       
        }

        public int deletestaffdata(string staffId)
        {
            int result;

            if (staffId == "")
                return -1;
            Open();
            string query = "UPDATE ST_STAFF_DATA SET DEL_FLG =" + 1 + "WHERE STAFF_ID =" + staffId;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        //Detail page 
        public DataSet.DsPSMS.ST_STAFF_DATARow selectOneStaff(DataSet.DsPSMS.ST_STAFF_DATARow dr)
        {
            DataSet.DsPSMS.ST_STAFF_DATADataTable dt = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            if (dr == null)
                return null;
            Open();
            string query = "SELECT * FROM ST_STAFF_DATA WHERE  STAFF_ID='" + dr.STAFF_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "'"; //+"'";//


            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            da.Fill(dt);
            Close();
            return dt[0];
        }

        public DataSet.DsPSMS.ST_POSITION_MSTRow selectOnePosition(string dr)
        {
            DataSet.DsPSMS.ST_POSITION_MSTDataTable dt = new DataSet.DsPSMS.ST_POSITION_MSTDataTable();
            if (dr == null)
                return null;
            Open();
            string query = "SELECT * FROM ST_POSITION_MST WHERE  POSITION_ID='" + dr + "'" ;


            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            da.Fill(dt);
            Close();
            return dt[0];
        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectNameOnly(string name)
        {
            DsPSMS.ST_STAFF_DATADataTable nameonly = new DsPSMS.ST_STAFF_DATADataTable();
            Open();
            string query = "SELECT * from ST_STAFF_DATA WHERE STAFF_NAME Like'" + name + "%'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(nameonly);
            Close();
            return nameonly;
        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectIdOnly(string staffId)
        {
            DsPSMS.ST_STAFF_DATADataTable idonly = new DsPSMS.ST_STAFF_DATADataTable();
            Open();
            string query = "SELECT * from ST_STAFF_DATA WHERE STAFF_ID ='" + staffId + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(idonly);
            Close();
            return idonly;
        }

    }
}




