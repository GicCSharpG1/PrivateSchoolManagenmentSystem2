using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeASP.DbAccess;

namespace HomeASP.Service
{
    class ExamResultService : dbAccess
    {
        ExamResultList db = new ExamResultList();

        public DataSet.DsPSMS.ST_STUDENT_DATADataTable getStdName(string gId, string rId, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable result = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                db.Open();
                result = db.selectStdName(gId, rId);
                if (result != null)
                {
                    msg = " user found";
                }

                else
                {
                    result = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow getSubList(string gId, out string msg)
        {
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow result = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            try
            {
                db.Open();
                result = db.selectSubList(gId);
                if (result != null)
                {
                    msg = " user found";
                }

                else
                {
                    result = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                db.Close();
            }
            return result;
        }


        public DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow getStdResult(string stdId,string exMonth, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow result = new DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();
            try
            {
                db.Open();
                result = db.selectStdResult(stdId, exMonth);
                if (result != null)
                {
                    msg = " user found";
                }

                else
                {
                    result = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow getMarkBysubresult(int resId, string subId)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow result = new DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            try
            {
                db.Open();
                result = db.selectSubMark(resId, subId);
                if (result != null)
                {
                    //msg = " user found";
                }

                else
                {
                    result = null;
                    //msg = "user not found";
                }
            }
            catch
            {
                //msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

    }
}