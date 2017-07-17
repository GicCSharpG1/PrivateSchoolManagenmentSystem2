using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DbAccess;
using HomeASP.DataSet;

namespace HomeASP.Service
{
    public class StudentCashInfoService :dbAccess
    {
        StudentCashInfoDb stuCashDb = new StudentCashInfoDb();
        
        public bool SaveStudentCashInfo(DsPSMS.ST_STUDENT_CASHRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                Open();
                int result = stuCashDb.insertStuCash(dr);
                msg = "Thank you!! Your payment is complete!!";
            }
            catch
            {
                msg = "Sorry!! Your payment is not complete!!";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DsPSMS.ST_STUDENT_CASHDataTable getCashAllData(out string msg)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            try
            {
                Open();
                stuCashDt = stuCashDb.selectCashAllData();
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                Close();
            }

            return stuCashDt;
        }

        public DsPSMS.ST_STUDENT_CASHDataTable getCashData(DataSet.DsPSMS.ST_STUDENT_CASHRow dr, out string msg)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            try
            {
                Open();
                stuCashDt = stuCashDb.selectCashDataByIdYear(dr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                Close();
            }

            return stuCashDt;
        }

        public DsPSMS.ST_STUDENT_CASHDataTable getCashDataByOption(DataSet.DsPSMS.ST_STUDENT_CASHRow dr, out string msg)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            try
            {
                Open();
                stuCashDt = stuCashDb.selectCashDataByOption(dr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                Close();
            }

            return stuCashDt;
        }

        public void deleteCashData(DsPSMS.ST_STUDENT_CASHRow dr, out string msg)
        {
            bool isOk = true;
            if (dr == null)
            {
                msg = "data is empty ";
            }
            try
            {
                Open();
                stuCashDb.deleteCashData(dr);
                msg = "Record is Deleted!!";
            }
            catch
            {
                msg = "error has occure when delete data";
            }
            finally
            {
                Close();
            }

        }
    }
}