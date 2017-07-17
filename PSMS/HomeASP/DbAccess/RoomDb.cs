using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess
{
    public class RoomDb:dbAccess
    {

        string query;
        string data;
        int result;

        //insert 
        public int insertRoomMST(DsPSMS.ST_ROOM_MSTRow dr)
        {
            if (dr == null)
                return -1;

            Open();
            query = "INSERT INTO ST_ROOM_MST (EDU_YEAR,ROOM_NAME, CRT_DT_TM, CRT_USER_ID,DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
            data += ", '" + dr.ROOM_NAME + "'";
            data += ", '" + dr.CRT_DT_TM + "'";
            data += ", '" + dr.CRT_USER_ID + "'";
            data += ", " + 0;
            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // select all 
        public DsPSMS.ST_ROOM_MSTDataTable selectAllRoomData()
        {
            DsPSMS.ST_ROOM_MSTDataTable stuEquipMSTDt = new DsPSMS.ST_ROOM_MSTDataTable();
            Open();
            query = "SELECT* FROM ST_ROOM_MST WHERE DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMSTDt);
            Close();
            return stuEquipMSTDt;
        }

        // select by id
        public DsPSMS.ST_ROOM_MSTDataTable selectRoomDataById(int id)
        {
            DsPSMS.ST_ROOM_MSTDataTable stuEquipMstDt = new DsPSMS.ST_ROOM_MSTDataTable();
            Open();
            query = "SELECT* FROM ST_ROOM_MST WHERE DEL_FLG = " + 0 + " AND ROOM_ID='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMstDt);
            Close();
            return stuEquipMstDt;
        }

        // update 
        public int updateRoomMST(DsPSMS.ST_ROOM_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_ROOM_MST SET ";

            data += " EDU_YEAR = '" + dr["EDU_YEAR"] + "'";
            data += ", ROOM_NAME = '" + dr["ROOM_NAME"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = " + 0;
            query += data + " WHERE ROOM_ID =" + dr["ROOM_ID"];

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // delet 
        public int deleteRoomMST(DsPSMS.ST_ROOM_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_ROOM_MST SET DEL_FLG = " + 1 + " WHERE ROOM_ID =" + dr["ROOM_ID"];

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        public DataSet.DsPSMS.ST_ROOM_MSTDataTable isExitRoomData(DataSet.DsPSMS.ST_ROOM_MSTRow dr)
        {
            if (dr == null)
                return null;
            string query = "SELECT * FROM ST_ROOM_MST ";
            string where = "";
            if (dr.EDU_YEAR != null)
            {
                where += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            }

            if (dr.ROOM_NAME!= null)
            {
                if (where.Length > 0)
                    where += " AND ROOM_NAME= '" + dr.ROOM_NAME + "'";
            }

            if (where.Length > 0)
                query += " WHERE " + where;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_ROOM_MSTDataTable dt = new DataSet.DsPSMS.ST_ROOM_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

    }
}