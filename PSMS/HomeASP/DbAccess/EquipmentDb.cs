using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess
{
    public class EquipmentDb :dbAccess
    {
        string query;
        string data;
        int result;

        //insert Equipment Title  into ST_EQUIPMENT_MST table
        public int insertEquipMST(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            if (dr == null)
                return -1;

            Open();
            query = "INSERT INTO ST_EQUIPMENT_MST (EDU_YEAR, EQUIPMENT_NAME, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
           // data += ", '" + dr.EQUIPMENT_ID + "'";
            data += ", '" + dr.EQUIPMENT_NAME + "'";
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

        //insert Equipment Data  into ST_EQUIPMENT_DATA table
        public int insertEquipData(DsPSMS.ST_EQUIPMENT_DATARow dr)
        {
            if (dr == null)
                return -1;
            Open();
           
            query = "INSERT INTO ST_EQUIPMENT_DATA (EDU_YEAR, EQUIPMENT_ID, DATE, QUANTITY, TYPE, REMARK, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
            data += ", '" + dr.EQUIPMENT_ID + "'";
            data += ", '" + dr.DATE + "'";
            data += ", '" + dr.QUANTITY + "'";
            data += ", '" + dr.TYPE + "'";
            data += ", '" + dr.REMARK + "'";
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

        // select all Equipment data from ST_EQUIPMENT_MST
        public DsPSMS.ST_EQUIPMENT_MSTDataTable selectAllEquipMSt()
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable stuEquipMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            Open();
            query = "SELECT* FROM ST_EQUIPMENT_MST WHERE DEL_FLG = "+0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMSTDt);
            Close();
            return stuEquipMSTDt;
        }

        public DsPSMS.ST_EQUIPMENT_MSTDataTable selectEquipMStByOption(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable stuEquipMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            Open();
            query = "SELECT * FROM ST_EQUIPMENT_MST WHERE DEL_FLG = " + 0 +" AND EQUIPMENT_NAME='"+ dr.EQUIPMENT_NAME +"' AND EDU_YEAR='"+ dr.EDU_YEAR+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMSTDt);
            Close();
            return stuEquipMSTDt;
        }

        // select all Equipment data from ST_EQUIPMENT_DATA
        public DsPSMS.ST_EQUIPMENT_DATADataTable selectAllEquipData()
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable stuEquipDataDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            Open();
            query = "SELECT* FROM ST_EQUIPMENT_DATA WHERE DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipDataDt);
            Close();
            return stuEquipDataDt;
        }

        // select Equipment data from ST_EQUIPMENT_MST by id
        public DsPSMS.ST_EQUIPMENT_MSTDataTable selectEquipDataById(int id)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable stuEquipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            Open();
            query = "SELECT* FROM ST_EQUIPMENT_MST WHERE DEL_FLG = " + 0 + " AND EQUIPMENT_ID='" + id +"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMstDt);
            Close();
            return stuEquipMstDt;
        }
        
        // update the Equipment Data of ST_EQUIPMENT_MST
        public int updateEquipMST(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EQUIPMENT_MST SET ";
           
            data += " EDU_YEAR = '" + dr["EDU_YEAR"] + "'";
            //data += ", EQUIPMENT_ID = '" + dr["EQUIPMENT_ID"] + "'";
            data += ", EQUIPMENT_NAME = '" + dr["EQUIPMENT_NAME"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = " + 0 ;
            query += data + " WHERE EQUIPMENT_ID =" + dr["EQUIPMENT_ID"];
            
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // update the Equipment Data of ST_EQUIPMENT_DATA
        public int updateEquipData(DsPSMS.ST_EQUIPMENT_DATARow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EQUIPMENT_DATA SET ";

            data += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            data += ", EQUIPMENT_ID = '" + dr.EQUIPMENT_ID + "'";
            data += ", DATE = '" + dr.DATE + "'";
            data += ", QUANTITY = '" + dr.QUANTITY + "'";
            data += ", TYPE = '" + dr.TYPE + "'";
            data += ", REMARK = '" + dr.REMARK + "'";
            data += ", UPD_DT_TM = '" + dr.UPD_DT_TM + "'";
            query += data + " WHERE ID =" + dr.ID + "AND DEL_FLG=" +0;

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // delet the Equipment Data of ST_EQUIPMENT_MST but not delete just update the DEL_FLG
        public int deleteEquipMST(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EQUIPMENT_MST SET DEL_FLG = " + 1 + " WHERE EQUIPMENT_ID =" + dr["EQUIPMENT_ID"];
           
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // delet the Equipment Data of ST_EQUIPMENT_DATA but not delete just update the DEL_FLG
        public int deleteEquipData(DsPSMS.ST_EQUIPMENT_DATARow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EQUIPMENT_DATA SET DEL_FLG = " + 1 + " WHERE ID =" + dr["ID"];

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // select Equipment data from ST_EQUIPMENT_DATA by id
        public DsPSMS.ST_EQUIPMENT_DATADataTable selectEquipmentById(int id)
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable stuEquipMstDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            Open();
            query = "SELECT* FROM ST_EQUIPMENT_DATA WHERE DEL_FLG = " + 0 + " AND ID='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMstDt);
            Close();
            return stuEquipMstDt;
        }

        public DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable isExitEquipData(DataSet.DsPSMS.ST_EQUIPMENT_DATARow dr)
        {
            if (dr == null)
                return null;
            string query = "SELECT * FROM ST_EQUIPMENT_DATA ";
            string where = "";
            if (dr.EDU_YEAR != null)
            {
                where += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            }

            if (dr.EQUIPMENT_ID != null)
            {
                where += " AND EQUIPMENT_ID = '" + dr.EQUIPMENT_ID + "'";
            }

            if (dr.DATE != null)
            {
                if (where.Length > 0)
                    where += " AND DATE= '" + dr.DATE + "'";
            }

            if (dr.QUANTITY != null)
            {
                if (where.Length > 0)
                    where += " AND QUANTITY= '" + dr.QUANTITY + "'";
            }

            if (where.Length > 0)
                query += " WHERE " + where;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable dt = new DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable();
            da.Fill(dt);
            return dt;
        }

    }
}