using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using HomeASP.DataSet;


namespace HomeASP.DbAccess
{
    public class ExamResultList : dbAccess
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
        public DsPSMS.ST_GRADE_SUBJECT_DETAILRow selectSubList(string grade)
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
        public DsPSMS.ST_STUDENT_EXAM_HEDRow selectStdResult(string stdId,string month)
        {
            DsPSMS.ST_STUDENT_EXAM_HEDDataTable dt = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable();
            Open();
            query = "SELECT * FROM ST_STUDENT_EXAM_HED  WHERE STUDENT_ID ='" + stdId + "' AND EXAM_MONTH ='"+month+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        //select result from ST_STUDENT_EXAM_DETAIl
        public DsPSMS.ST_STUDENT_EXAM_DETAILRow selectSubMark(int resId,string subId)
        {
            DsPSMS.ST_STUDENT_EXAM_DETAILDataTable dt = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable();
            
            query = "SELECT * FROM ST_STUDENT_EXAM_DETAIL  WHERE RESULT_ID =" + resId + " AND SUBJECT_ID='" + subId+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            return dt[0];
        }
    }
}