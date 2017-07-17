using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess
{
    public class PositionDb : dbAccess
    {
        string query;
        string data;
        int result;

        public int insertPositionMST(DsPSMS.ST_POSITION_MSTRow dr)
        {
            if (dr == null)
                return -1;

            Open();
            query = "INSERT INTO ST_POSITION_MST (EDU_YEAR, POSITION_NAME, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
            // data += ", '" + dr.EQUIPMENT_ID + "'";
            data += ", '" + dr.POSITION_NAME + "'";
            data += ", '" + dr.CRT_DT_TM + "'";
            data += ", '" + dr.CRT_USER_ID + "'";
            data += ", '" + dr.UPD_DT_TM + "'";
            data += ", '" + dr.UPD_USER_ID + "'";
            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        public DataSet.DsPSMS.ST_POSITION_MSTDataTable selectPositionByID(DataSet.DsPSMS.ST_POSITION_MSTRow dr)
        {
            string query = "SELECT * FROM ST_POSITION_MST where POSITION_ID= '" + dr.POSITION_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_POSITION_MSTDataTable dt = new DataSet.DsPSMS.ST_POSITION_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public DsPSMS.ST_POSITION_MSTDataTable selectPosMstByOption(DsPSMS.ST_POSITION_MSTRow dr)
        {
            
            DsPSMS.ST_POSITION_MSTDataTable posMst = new DsPSMS.ST_POSITION_MSTDataTable();

            Open();
            query = "SELECT * FROM ST_POSITION_MST WHERE DEL_FLG = " + 0 + " AND POSITION_NAME='" + dr.POSITION_NAME + "' AND EDU_YEAR='" + dr.EDU_YEAR + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(posMst);
            Close();
            return posMst;
        }

        public DsPSMS.ST_POSITION_MSTDataTable selectAllPosMSt()
        {
            DsPSMS.ST_POSITION_MSTDataTable posMSTDt = new DsPSMS.ST_POSITION_MSTDataTable();
            Open();
            query = "SELECT* FROM ST_POSITION_MST WHERE DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(posMSTDt);
            Close();
            return posMSTDt;
        }

        public int deletePosMST(DsPSMS.ST_POSITION_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_POSITION_MST SET DEL_FLG = " + 1 + " WHERE POSITION_ID =" + dr["POSITION_ID"];

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        public int updatePositionMST(DsPSMS.ST_POSITION_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_POSITION_MST SET ";

            data += " EDU_YEAR = '" + dr["EDU_YEAR"] + "'";
            //data += ", EQUIPMENT_ID = '" + dr["EQUIPMENT_ID"] + "'";
            data += ", POSITION_NAME = '" + dr["POSITION_NAME"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = " + 0;
            query += data + " WHERE POSITION_ID =" + dr["POSITION_ID"];

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }
    }
}