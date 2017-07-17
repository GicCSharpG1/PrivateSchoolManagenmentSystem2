using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.DbAccess
{
    public class EventsAndNewsEntryDb : dbAccess
    {
        public DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable selectEventByID(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {
            string query = "SELECT * FROM .ST_EVENT_NEWS_HED where ID= " + dr.ID + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable dt = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertEvent(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {
            int result;
            string data = "";
            if (dr == null)
                return -1;
            Open();
           
            //DateTime date = DateTime.Now.Date;
            //String currentDate = date.ToString().Substring(0, 19);
            string query = "INSERT INTO ST_EVENT_NEWS_HED (EDU_YEAR,DATE,NAME,GRADE_ID,ROOM_ID,TYPE,PHOTO_PATH, CRT_DT_TM, CRT_USER_ID,UPD_DT_TM, DEL_FLG)";
            data += " '" + dr.EDU_YEAR + "'";                  
            data += ", '" + dr.DATE + "'";
            data += ", '" + dr.NAME + "'";
            data += ", '" + dr.GRADE_ID + "'";
            data += ", '" + dr.ROOM_ID + "'";
            data += ", '" + dr.TYPE + "'";           
            if (!dr.IsPHOTO_PATHNull())
                data += ", '" + dr.PHOTO_PATH + "'";
            else
                data += ", '  '";
            if (!dr.IsCRT_DT_TMNull())
                data += ", '" + dr.CRT_DT_TM + "'";
            else
                data += ", '  '";
            if (!dr.IsCRT_USER_IDNull())
                data += ", '" + dr.CRT_USER_ID + "'";
            else
                data += ", '  '";
            if(!dr.IsUPD_DT_TMNull())
                data += ", '"+ dr.UPD_DT_TM + "'";
            else
                 data += ", '  '";
           
             
            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int updateEvent(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {
            int result;
            if (dr == null)
                return -1;
            Open();

            string query = "UPDATE ST_EVENT_NEWS_HED SET ";
           
                query += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
                        
                query += ", DATE = '" + dr.DATE + "'";
            
           
                query += ", NAME = '" + dr.NAME + "'";
            
           
                query += ", GRADE_ID = '" + dr.GRADE_ID + "'";
            
            
                query += ", ROOM_ID = '" + dr.ROOM_ID + "'";
            
                query += ", TYPE = '" + dr.TYPE + "'";
            
            
                query += ", PHOTO_PATH = '" + dr.PHOTO_PATH + "'";

                query += ", UPD_DT_TM = '" + dr.UPD_DT_TM + "'";
              
                query += ", DEL_FLG = " + 0;
            query += " WHERE ID=" + dr.ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        public DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable selectAllEventData()
        {
            string query = "SELECT * FROM ST_EVENT_NEWS_HED WHERE DEL_FLG = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable dt = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            da.Fill(dt);
            return dt;
        }

        public int deleteEvent(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {
            int result;
            string query = "UPDATE ST_EVENT_NEWS_HED SET DEL_FLG = 1 WHERE ";
            query += " ID = " + "'" + dr.ID + "'";
            // query += " GRADE_NAME = " + "'" + dr.GRADE_NAME + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DsPSMS.ST_EVENT_NEWS_HEDDataTable getEventNew(DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {
            DsPSMS.ST_EVENT_NEWS_HEDDataTable EvNew = new DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            Open();
            string query = "SELECT * FROM ST_EVENT_NEWS_HED";
                 
            string where = "";
            if(dr.EDU_YEAR != null)
            {
                where += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            }

            if(dr.DATE != null)
            {
                where += " DATE = '" + dr.DATE + "'";
            }

            if(dr.NAME != null)
            {
                where += " NAME = '" + dr.NAME + "'";
            }
           
           if (dr.GRADE_ID != null)
           {
               if(where.Length > 0)
               where += " GRADE_ID = '" + dr.GRADE_ID + "'";
           }

           if (dr.ROOM_ID != null)
           {
               if (where.Length > 0)
                   where += " AND ROOM_ID = '" + dr.ROOM_ID + "'";
           }
            if(dr.TYPE != null)
            {
                where += " AND TYPE = '" + dr.TYPE + "'";
            }
           

           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           
           da.Fill(EvNew);
           return EvNew;
       
        }
    }
}