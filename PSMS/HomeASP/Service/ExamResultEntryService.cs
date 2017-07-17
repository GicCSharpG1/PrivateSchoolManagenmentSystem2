using HomeASP.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeASP.Service
{
    public class ExamResultEntryService
    {
        ExamResultEntryDb db = new ExamResultEntryDb();
        string msg = "";

        public DataSet.DsPSMS.ST_STUDENT_DATADataTable getStudentDataBystuObj(DataSet.DsPSMS.ST_STUDENT_DATARow dr,out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable result = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                db.Open();
                result = db.selectStudentData(dr);
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

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow getSubList(int gId, out string msg)
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

        public DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow getStdResult(string stdId, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow result = new DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();
            try
            {
                db.Open();
                result = db.selectStdResult(stdId);
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

        public DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow getMarkBysubresult(int resId, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow result = new DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            try
            {
                db.Open();
                result = db.selectSubMark(resId);
                msg = " user found";
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

        public bool saveStuResultHedData(DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertStuResultHed(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_TIMETABLE table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public bool saveStuExamDetail(DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertStuExamDetail(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_STUDENT_EXAM_DETAIL table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_STUDENT_DATARow getStudentById(string sId,out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow result = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            try
            {
                db.Open();
                result = db.selectStudentById(sId);
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

        public DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow getResultByHed(string stdId, string month, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow result = new DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();
            try
            {
                db.Open();
                result = db.selectResultIdByHed(stdId,month);
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

        public DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable getChkExamResultByHed(DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow dr, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable result = new DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable();
            try
            {
                db.Open();
                result = db.selectExistStuExamHed(dr);
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
                msg = "error has occure when select data";
                return null;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow getExamDetailkBysubresult(int resId,int subId)
        {
            
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow result = new DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            try
            {
                db.Open();
                result = db.selectExamDetailMark(resId, subId);
                msg = " user found";
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

        public bool updateStuExamDetail(DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.editStudentExamMark(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when update data to ST_STUDENT_EXAM_DETAIL table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }
    }
}