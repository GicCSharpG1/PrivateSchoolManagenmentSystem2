using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeASP.DbAccess;


namespace HomeASP.Service
{
    class GradeSubjectService : dbAccess
    {
        GradeSubjectDb db = new GradeSubjectDb();

        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectGradeByID(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_MSTDataTable selectedGrade = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            if (dr == null)
            {
                msg = "data is empty ";
                return selectedGrade;
            }
            try
            {
                db.Open();
                if (dr.GRADE_ID != null)
                    selectedGrade = db.selectGradeByID(dr);
            }
            catch
            {
                msg = "error has occure when insert data";
                return selectedGrade;
            }
            finally
            {
                db.Close();
            }
            return selectedGrade;
        }
        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectGradeByIDWithNOflate(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_MSTDataTable selectedGrade = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            if (dr == null)
            {
                msg = "data is empty ";
                return selectedGrade;
            }
            try
            {
                db.Open();
                if (dr.GRADE_ID != null)
                    selectedGrade = db.selectGradeByID(dr);
            }
            catch
            {
                msg = "error has occure when insert data";
                return selectedGrade;
            }
            finally
            {
                db.Close();
            }
            return selectedGrade;
        }

        public bool saveGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertGrade(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_GRADE_MST table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_GRADE_MSTDataTable getAllGradeData(out string msg)
        {
            DataSet.DsPSMS.ST_GRADE_MSTDataTable result = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            try
            {
                db.Open();
                result = db.selectAllGradeData();
                if (result != null && result.Rows.Count > 0)
                {
                    msg = result.Rows.Count + " user found";
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

        public bool updateGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.updateGrade(dr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            {
                db.Close();
            }
            return isOk;
        }

        public int deleteGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            int result;
            try
            {
                if (dr == null)
                {
                    msg = "data is empty";
                    return 0;
                }
                else
                {
                    db.Open();
                    result = db.deleteGrade(dr);
                    msg = "grade deleted";
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return 0;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectSubjectByIDWithNOflag(DataSet.DsPSMS.ST_SUBJECT_MSTRow subject, out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            if (subject == null)
            {
                msg = "data is empty ";
                return result;
            }
            try
            {
                db.Open();
                if (subject.SUBJECT_ID != null)
                    result = db.selectSubjectByIDWithNOflag(subject);
            }
            catch
            {
                msg = "error has occure when insert data";
                return result;
            }
            finally
            {
                db.Close();
            }
            msg = "exist user";
            return result;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectSubjectByID(DataSet.DsPSMS.ST_SUBJECT_MSTRow subject, out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            if (subject == null)
            {
                msg = "data is empty ";
                return result;
            }
            try
            {
                db.Open();
                if (subject.SUBJECT_ID != null)
                    result = db.selectSubjectByID(subject);
            }
            catch
            {
                msg = "error has occure when insert data";
                return result;
            }
            finally
            {
                db.Close();
            }
            msg = "exist user";
            return result;
        }

        public bool saveSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertSubject(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "duplicate id cannot be inserted";
                return false;

            }
            finally
            {
                db.Close();
            }
            return isOk;
        }

        public bool updateSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.updateSubject(dr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            {
                db.Close();
            }
            return isOk;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectData(out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            try
            {
                db.Open();
                result = db.selectAllSubjectData();
                if (result != null && result.Rows.Count > 0)
                {
                    msg = result.Rows.Count + " user found";
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

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectName(string subjectId, out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            try
            {
                db.Open();
                result = db.getAllSubjectName(subjectId);
                if (result != null && result.Rows.Count > 0)
                {
                    msg = result.Rows.Count + " user found";
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

        public int deleteSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
        {
            int result;
            try
            {
                if (dr == null)
                {
                    msg = "data is empty";
                    return 0;
                }
                else
                {
                    db.Open();
                    result = db.deleteSubject(dr);
                    msg = "grade deleted";
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return 0;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectGradeSubjectByID(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectedUser = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            if (dr == null)
            {
                msg = "data is empty ";
                return selectedUser;
            }
            try
            {
                db.Open();
                if (dr.ID != null)
                    selectedUser = db.selectGradeSubjectByID(dr);
                msg = "complete";
            }
            catch
            {
                msg = "error has occure when insert data";
                return selectedUser;
            }
            finally
            {
                db.Close();
            }
            return selectedUser;
        }

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectGradeSubjectByIDWithNOflate(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectedUser = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            if (dr == null)
            {
                msg = "data is empty ";
                return selectedUser;
            }
            try
            {
                db.Open();
                if (dr.ID != null)
                    selectedUser = db.selectGradeSubjectByIDWithNOflat(dr);
                msg = "complete";
            }
            catch
            {
                msg = "error has occure when insert data";
                return selectedUser;
            }
            finally
            {
                db.Close();
            }
            return selectedUser;
        }

        public bool saveGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, string subjectIdList, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertGradeSubjectDetail(dr, subjectIdList);
                msg = "insert complete";
            }
            catch
            {
                msg = "duplicate id cannot be inserted";
                return false;

            }
            finally
            {
                db.Close();
            }
            return isOk;
        }

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable getAllGradeSubjectData(out string msg)
        {
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable result = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            try
            {
                db.Open();
                result = db.getAllGradeSubjectData();
                if (result != null && result.Rows.Count > 0)
                {
                    msg = result.Rows.Count + " user found";
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

        public bool updateGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.updateGradeSubject(dr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            {
                db.Close();
            }
            return isOk;
        }

        public int deleteGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, out string msg)
        {
            int result;
            try
            {
                if (dr == null)
                {
                    msg = "data is empty";
                    return 0;
                }
                else
                {
                    db.Open();
                    result = db.deleteGradeSubject(dr);
                    msg = "grade deleted";
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return 0;
            }
            finally
            {
                db.Close();
            }
            return result;
        }
    }
}
