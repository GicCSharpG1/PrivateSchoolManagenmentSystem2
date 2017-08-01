using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.Service
{
    public class SalaryCalculationService:dbAccess
    {
        SalaryCalculationDb salaryDB = new SalaryCalculationDb();
        public DataSet.DsPSMS.ST_STAFF_DATADataTable getStaffData(int posId, out string msg)
        {
            DataSet.DsPSMS.ST_STAFF_DATADataTable result = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            try
            {
                salaryDB.Open();
                result = salaryDB.selectStaffData(posId);
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
                salaryDB.Close();
            }
            return result;
        }

        //public DataSet.DsPSMS.ST_STAFF_DATADataTable getAllStaffData(out string msg)
        //{
        //    DataSet.DsPSMS.ST_STAFF_DATADataTable result = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
        //    try
        //    {
        //        salaryDB.Open();
        //        result = salaryDB.selectAllStaffData();
        //        if (result != null && result.Rows.Count > 0)
        //        {
        //            msg = result.Rows.Count + " user found";
        //        }

        //        else
        //        {
        //            result = null;
        //            msg = "user not found";
        //        }
        //    }
        //    catch
        //    {
        //        msg = "error has occure when insert data";
        //        return null;
        //    }
        //    finally
        //    {
        //        salaryDB.Close();
        //    }
        //    return result;
        //}

        public DataSet.DsPSMS.ST_SALARYDataTable getAllSalaryData(int reflag,out string msg)
        {
            DataSet.DsPSMS.ST_SALARYDataTable result = new DataSet.DsPSMS.ST_SALARYDataTable();
            try
            {
                salaryDB.Open();
                result = salaryDB.selectAllSalaryData(reflag);
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
                salaryDB.Close();
            }
            return result;
        }


        public DataSet.DsPSMS.ST_SALARYDataTable getAllSalaryData()
        {
            DataSet.DsPSMS.ST_SALARYDataTable result = new DataSet.DsPSMS.ST_SALARYDataTable();
            try
            {
                salaryDB.Open();
                result = salaryDB.selectAllSalaryData();
                if (result != null && result.Rows.Count > 0)
                {
                  //  msg = result.Rows.Count + " user found";
                }

                else
                {
                    result = null;
                  //  msg = "user not found";
                }
            }
            catch
            {
               // msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                salaryDB.Close();
            }
            return result;
        }

        public DataSet.DsPSMS.ST_SALARYDataTable getSalaryDataByCondition(DataSet.DsPSMS.ST_SALARYRow dr)
        {
            DataSet.DsPSMS.ST_SALARYDataTable result = new DataSet.DsPSMS.ST_SALARYDataTable();
            try
            {
                salaryDB.Open();
                result = salaryDB.selectSalaryDataByCondition(dr);
                if (result != null && result.Rows.Count > 0)
                {
                  //  msg = result.Rows.Count + " user found";
                }

                else
                {
                    result = null;
                  //  msg = "user not found";
                }
            }
            catch
            {
               // msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                salaryDB.Close();
            }
            return result;
        }

        public bool saveSalaryData(DataSet.DsPSMS.ST_SALARYRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                salaryDB.Open();
                int result = salaryDB.insertSalaryData(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_SALARY table";
                return false;
            }
            finally
            {
                salaryDB.Close();
            }

            return isOk;
        }

        public bool updateSalaryData(DataSet.DsPSMS.ST_SALARYRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                salaryDB.Open();
                int result = salaryDB.updateSalaryData(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_SALARY table";
                return false;
            }
            finally
            {
                salaryDB.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_STAFF_DATARow getStaffIdByid(int id)
        {
            DataSet.DsPSMS.ST_STAFF_DATARow resultData = new DataSet.DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();
            try
            {
                salaryDB.Open();
                resultData = salaryDB.selectStaffByid(id);
            }
            catch
            {
                return null;
            }
            finally
            {
                salaryDB.Close();
            }
            
            return resultData;
        }

        public DataSet.DsPSMS.ST_STAFF_DATARow getStaffByName(string name)
        {
            DataSet.DsPSMS.ST_STAFF_DATARow resultData = new DataSet.DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();
            try
            {
                salaryDB.Open();
                resultData = salaryDB.selectStaffByName(name);
            }
            catch
            {
                return null;
            }
            finally
            {
                salaryDB.Close();
            }

            return resultData;
        }

        public DataSet.DsPSMS.ST_TEACHER_DATARow getTeacherByid(int id)
        {
            DataSet.DsPSMS.ST_TEACHER_DATARow resultData = new DataSet.DsPSMS.ST_TEACHER_DATADataTable().NewST_TEACHER_DATARow();
            try
            {
                salaryDB.Open();
                resultData = salaryDB.selectTeacherByid(id);
            }
            catch
            {
                return null;
            }
            finally
            {
                salaryDB.Close();
            }
            
            return resultData;
        }

        public DataSet.DsPSMS.ST_TEACHER_DATARow getTeacherByName(string name)
        {
            DataSet.DsPSMS.ST_TEACHER_DATARow resultData = new DataSet.DsPSMS.ST_TEACHER_DATADataTable().NewST_TEACHER_DATARow();
            try
            {
                salaryDB.Open();
                resultData = salaryDB.selectTeacherByName(name);
            }
            catch
            {
                return null;
            }
            finally
            {
                salaryDB.Close();
            }

            return resultData;
        }

        public DataSet.DsPSMS.ST_SALARYDataTable getSalaryByMonthRemark(string month, int reflag)
        {
            DataSet.DsPSMS.ST_SALARYDataTable resultData = new DataSet.DsPSMS.ST_SALARYDataTable();
            try
            {
                salaryDB.Open();
                resultData = salaryDB.selectSalaryByRemark(month, reflag);
            }
            catch
            {
                return null;
            }
            finally
            {
                salaryDB.Close();
            }

            return resultData;
        }

        public bool deleteSalaryData(string month,int reflag)
        {
            bool isOk = true;
            try
            {
                salaryDB.Open();
                int result = salaryDB.deleteSalaryByRemark(month,reflag);
            }
            catch
            {
                return false;
            }
            finally
            {
                salaryDB.Close();
            }

            return isOk;
        }
    }
}
