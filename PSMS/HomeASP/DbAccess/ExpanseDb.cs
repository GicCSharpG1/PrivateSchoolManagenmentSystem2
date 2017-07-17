using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess 
{
    public class ExpanseDb :dbAccess
    {
        string query = "";
        string data = "";
        int result = 0;
       
        //insert expanse info into ST_EXP_HED table
        public int insertExpanseHed(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            if (dr == null)
                return -1;
           Open();
            query = "INSERT INTO ST_EXP_HED (EDU_YEAR, EXP_TITLE, EXP_DATE, REMARK, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
            //data += ", '" + dr.EXP_ID + "'";
            data += ", '" + dr.EXP_TITLE + "'";
            data += ", '" + dr.EXP_DATE + "'";
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

        //insert expanse info into ST_EXP_DETAIL table
        public int insertExpanseDet(DataSet.DsPSMS.ST_EXP_DETAILRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "INSERT INTO ST_EXP_DETAIL (EXP_ID, EXP_SUB_TITLE, AMOUNT, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += dr.EXP_ID;
            data += ", '" + dr.EXP_SUB_TITLE + "'";
            data += ", '" + dr.AMOUNT + "'";
            data += ", '" + DateTime.Now + "'";
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

        //select all cash information from ST_EXP_HED table
        public DataSet.DsPSMS.ST_EXP_HEDDataTable selectExpHedAllData()
        {
            DsPSMS.ST_EXP_HEDDataTable expHedDt = new DsPSMS.ST_EXP_HEDDataTable();
            Open();
            query = "SELECT* FROM ST_EXP_HED WHERE DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(expHedDt);
            Close();
            return expHedDt;
        }

        //select expense information from ST_EXP_HED table
        public DataSet.DsPSMS.ST_EXP_HEDDataTable selectExpHedAllDataByOption(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            DsPSMS.ST_EXP_HEDDataTable expHedDt = new DsPSMS.ST_EXP_HEDDataTable();
            Open();
            query = "SELECT* FROM ST_EXP_HED WHERE DEL_FLG =" + 0 ;
            if (!dr.IsEDU_YEARNull())
                query += "AND EDU_YEAR='" + dr.EDU_YEAR + "'";
            if (!dr.IsEXP_TITLENull())
                query += " AND EXP_TITLE='" + dr.EXP_TITLE + "'";
            if(!dr.IsEXP_DATENull())
                query += "AND EXP_DATE='" + dr.EXP_DATE + "'";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(expHedDt);
            Close();
            return expHedDt;
        }

        //select cash information by id from ST_EXP_DETAIL table
        public DataSet.DsPSMS.ST_EXP_DETAILDataTable selectExpDetDataById(int expId)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            Open();
            query = "SELECT* FROM ST_EXP_DETAIL WHERE EXP_ID = " + expId + " AND DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(expDetDt);
            Close();
            return expDetDt;
        }

        //select expense information by option from ST_EXP_DETAIL table
        public DataSet.DsPSMS.ST_EXP_DETAILDataTable selectExpDetDataByOption(DataSet.DsPSMS.ST_EXP_DETAILRow dr)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            Open();
            query = "SELECT* FROM ST_EXP_DETAIL WHERE EXP_ID = " + dr.EXP_ID + " AND DEL_FLG = " + 0 + " AND EXP_SUB_TITLE='" + dr.EXP_SUB_TITLE + "' AND AMOUNT='" + dr.AMOUNT +"'" ;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(expDetDt);
            Close();
            return expDetDt;
        }


        // update the cash information from ST_EXP_HED table
        public int updateExpanseHed(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EXP_HED SET ";
           
            data += " EDU_YEAR = '" + dr["EDU_YEAR"] + "'";
            //data += ", EXP_ID = '" + dr["EXP_ID"] + "'";
            data += ", EXP_TITLE = '" + dr["EXP_TITLE"] + "'";
            data += ", EXP_DATE = '" + dr["EXP_DATE"] + "'";
            data += ", REMARK = '" + dr["REMARK"] + "'";
            //data += ", CRT_DT_TM = '" + dr["CRT_DT_TM"] + "'";
            //data += ", CRT_USER_ID = '" + dr["CRT_USER_ID"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", UPD_USER_ID = '" + dr["CRT_USER_ID"] + "'";
            query += data + " WHERE EXP_ID =" + dr["EXP_ID"] + " AND  DEL_FLG = " + 0;
            
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // update the cash information from ST_EXP_DETAIL tabel
        public int updateExpanseDet(DataSet.DsPSMS.ST_EXP_DETAILRow dr,int id)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EXP_DETAIL SET ";
            data += " EXP_ID = " + dr.EXP_ID;
            data += ", EXP_SUB_TITLE = '" + dr.EXP_SUB_TITLE + "'";
            data += ", AMOUNT = '" + dr.AMOUNT + "'";
            data += ", UPD_DT_TM = '" + dr.UPD_DT_TM + "'";
            data += ", UPD_USER_ID = '" + dr.UPD_USER_ID + "'";
            query += data + " WHERE ID =" + id ;

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // delete the expense information from ST_EXP_HED tabel
        public void deleteExpHed(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            Open();
            string query = "";

            query = "UPDATE ST_EXP_HED SET DEL_FLG =" + 1 + " WHERE EXP_ID = " + dr.EXP_ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            Close();

        }

        // delete the cash information from ST_EXP_DETAIL tabel
        public void deleteExpDet(DataSet.DsPSMS.ST_EXP_DETAILRow dr)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
                Open();
                string query = "";
                query = "UPDATE ST_EXP_DETAIL SET DEL_FLG =" + 1 + " WHERE EXP_ID = " + dr.EXP_ID + " AND EXP_SUB_TITLE='" + dr.EXP_SUB_TITLE + "' AND AMOUNT='"+ dr.AMOUNT +"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                Close();
        }
    }
}