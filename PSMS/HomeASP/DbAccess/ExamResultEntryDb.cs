using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess
{
    public class ExamResultEntryDb : dbAccess
    {
        string query;
        string data;
        int result;

        //select studentName from ST_STUDENT_DATA
        public DsPSMS.ST_STUDENT_DATADataTable selectStdName(string grade, string room)
        {

            DsPSMS.ST_STUDENT_DATADataTable dt = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            query = "SELECT * FROM ST_STUDENT_DATA  WHERE GRADE_ID='" + grade + "' AND  ROOM_ID='" + room + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt;
        }

        //select subjectList from ST_GRADE_SUBJECT_DETAIL
        public DsPSMS.ST_GRADE_SUBJECT_DETAILRow selectSubList(int grade)
        {

            DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable dt = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            Open();
            query = "SELECT * FROM ST_GRADE_SUBJECT_DETAIL  WHERE GRADE_ID='" + grade + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        //select result from ST_STUDENT_EXAM_HED
        public DsPSMS.ST_STUDENT_EXAM_HEDRow selectStdResult(string stdId)
        {
            DsPSMS.ST_STUDENT_EXAM_HEDDataTable dt = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable();
            Open();
            query = "SELECT * FROM ST_STUDENT_EXAM_HED  WHERE STUDENT_ID ='" + stdId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        //select result from ST_STUDENT_EXAM_DETAIl
        public DsPSMS.ST_STUDENT_EXAM_DETAILRow selectSubMark(int resId)
        {
            DsPSMS.ST_STUDENT_EXAM_DETAILDataTable dt = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable();
            Open();
            query = "SELECT * FROM ST_STUDENT_EXAM_DETAIL  WHERE RESULT_ID =" + resId ;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        //insert studentId&exDate into ST_STUDENT_EXAM_HED
        public int insertStuResultHed(DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow dr)
        {
            int result;
            if (dr == null)
                return -1;
            string query = "INSERT INTO ST_STUDENT_EXAM_HED (EDU_YEAR,STUDENT_ID,EXAM_MONTH,CRT_DT_TM,CRT_USER_ID,DEL_FLG) VALUES ('" + dr.EDU_YEAR + "'," + "'" + dr.STUDENT_ID + "'," + "'" + dr.EXAM_MONTH + "','" + dr.CRT_DT_TM + "','" + dr.CRT_USER_ID + "'," + 0 + ")";
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        //insert studentId&exDate into ST_STUDENT_EXAM_DETAIl
        public int insertStuExamDetail(DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow dr)
        {
            int result;
            if (dr == null)
                return -1;
            string query = "INSERT INTO ST_STUDENT_EXAM_DETAIL (EDU_YEAR,RESULT_ID,SUBJECT_ID,MARK,DEL_FLG) VALUES ('" + dr.EDU_YEAR + "','" + dr.RESULT_ID + "','" + dr.SUBJECT_ID + "'," + dr.MARK + "," + 0 + ")";
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        //select student by id from ST_STUDENT_DATA
        public DsPSMS.ST_STUDENT_DATARow selectStudentById(string stuId)
        {

            DsPSMS.ST_STUDENT_DATADataTable dt = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            query = "SELECT * FROM ST_STUDENT_DATA  WHERE STUDENT_ID=" + stuId;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        //select * from ST_STUDENT_EXAM_HED where STUDENT_ID = '001' and EXAM_MONTH = 'January'
        public DsPSMS.ST_STUDENT_EXAM_HEDRow selectResultIdByHed(string stdId,string month)
        {
            DsPSMS.ST_STUDENT_EXAM_HEDDataTable dt = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable();
            
            query = "SELECT * FROM ST_STUDENT_EXAM_HED  WHERE STUDENT_ID ='" + stdId + "' and EXAM_MONTH ='" +month+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            return dt[0];
        }

        //select all from ST_STUDENT_DATA
        public DsPSMS.ST_STUDENT_DATADataTable selectStudentData(DsPSMS.ST_STUDENT_DATARow dr)
        {

            DsPSMS.ST_STUDENT_DATADataTable dt = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            string query = "SELECT * FROM ST_STUDENT_DATA ";
            string where = "";
            if (dr.EDU_YEAR != null)
            {
                where += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            }

            if (dr.GRADE_ID != null)
            {
                where += " AND GRADE_ID = '" + dr.GRADE_ID + "'";
            }

            if (dr.ROOM_ID != null)
            {
                if (where.Length > 0)
                    where += " AND ROOM_ID= '" + dr.ROOM_ID + "'";
            }

            if (where.Length > 0)

                query += " WHERE " + where;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt;
        }

        //select all from ST_STUDENT_RESULT_HED
        public DsPSMS.ST_STUDENT_EXAM_HEDDataTable selectExistStuExamHed(DsPSMS.ST_STUDENT_EXAM_HEDRow dr)
        {

            DsPSMS.ST_STUDENT_EXAM_HEDDataTable dt = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable();
            Open();
            string query = "SELECT * FROM ST_STUDENT_EXAM_HED";
            string where = "";
            if (dr.EDU_YEAR != null)
            {
                where += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            }

            if (dr.EXAM_MONTH != null)
            {
                where += " AND EXAM_MONTH = '" + dr.EXAM_MONTH + "'";
            }

            if (where.Length > 0)
                query += " WHERE " + where;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt;
        }

        public DsPSMS.ST_STUDENT_EXAM_DETAILRow selectExamDetailMark(int resId,int subId)
        {
            DsPSMS.ST_STUDENT_EXAM_DETAILDataTable dt = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable();
            Open();
            query = "SELECT * FROM ST_STUDENT_EXAM_DETAIL  WHERE RESULT_ID =" + resId + " AND SUBJECT_ID=" + subId;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        public int editStudentExamMark(DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow dr)
        {
            int result;
            
            string query = "UPDATE ST_STUDENT_EXAM_DETAIL SET MARK='" + dr.MARK + "',UPD_DT_TM='" + dr.UPD_DT_TM + "',UPD_USER_ID='" + dr.UPD_USER_ID + "' WHERE RESULT_ID=" + dr.RESULT_ID + " AND SUBJECT_ID=" + dr.SUBJECT_ID;
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        } 
    }
}