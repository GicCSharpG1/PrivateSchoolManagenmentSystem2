using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeASP.DbAccess;
using HomeASP.DataSet;


namespace HomeASP.Service
{
    class AttendanceService : dbAccess
    {
        AttendanceDb db = new AttendanceDb();
        DsPSMS.ATTENDANCE_RESULTDataTable attResDt = null;
        DsPSMS.ST_ATTENDANCE_DATADataTable attDt = null;

        //public DataSet.DsPSMS.ATTENDANCE_RESULTDataTable selectAttendanceData(DataSet.DsPSMS.ST_STUDENT_DATARow sr, DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr, out string msg)
        //{
        //    DataSet.DsPSMS.ATTENDANCE_RESULTDataTable result = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();
        //    if (dr == null)
        //    {
        //        msg = "data is empty";
        //        return null;
        //    }
        //    try
        //    {
        //        db.Open();
        //        result = db.selectAttendanceData(sr, dr);
        //        if (result != null)
        //        {
        //            msg = result.Rows.Count + " day found";
        //        }
        //        else
        //        {
        //            result = null;
        //            msg = "attendance not found";
        //        }
        //    }
        //    catch
        //    {
        //        msg = "error has occure when insert data";
        //        return null;
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }

        //    return result;
        //}

        //public DataSet.DsPSMS.ATTENDANCE_RESULTDataTable selectAttendanceEdu(string edu, out string msg)
        //{
        //    DataSet.DsPSMS.ATTENDANCE_RESULTDataTable result = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();
           
        //    try
        //    {
        //        db.Open();
        //        result = db.selectAttendanceEdu(edu);
        //        if (result != null)
        //        {
        //            msg = result.Rows.Count + " day found";
        //        }
        //        else
        //        {
        //            result = null;
        //            msg = "attendance not found";
        //        }
        //    }
        //    catch
        //    {
        //        msg = "error has occure when insert data";
        //        return null;
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }

        //    return result;
        //}

        public DataSet.DsPSMS.ATTENDANCE_RESULTDataTable selectAttendanceOption(DataSet.DsPSMS.ST_STUDENT_DATARow stuDr, DataSet.DsPSMS.ST_ATTENDANCE_DATARow attDr, string month, out string msg)
        {
            attResDt = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();

            try
            {
                db.Open();
                attResDt = db.selectAttendanceOption(stuDr, attDr, month);
                if (attResDt != null)
                {
                    msg = attResDt.Rows.Count + " day found";
                }
                else
                {
                    attResDt = null;
                    msg = "attendance not found";
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

            return attResDt;
        }

        //public DataSet.DsPSMS.ATTENDANCE_RESULTDataTable selectAttendanceMonth(string month, out string msg)
        //{
        //    DataSet.DsPSMS.ATTENDANCE_RESULTDataTable result = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();

        //    try
        //    {
        //        db.Open();
        //        result = db.selectAttendanceMonth(month);
        //        if (result != null)
        //        {
        //            msg = result.Rows.Count + " day found";
        //        }
        //        else
        //        {
        //            result = null;
        //            msg = "attendance not found";
        //        }
        //    }
        //    catch
        //    {
        //        msg = "error has occure when insert data";
        //        return null;
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }

        //    return result;
        //}

        public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectAllAttendance()
        {
            attDt = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
           
            try
            {
                db.Open();
                attDt = db.selectAllAttendance();
                if (attDt != null)
                {
                    return attDt;
                }
                else
                {
                    attDt = null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Close();
            }

            return attDt;
        }


        public int saveAttendanceRecord(DataSet.DsPSMS.ST_ATTENDANCE_DATARow adr, out string msg)
        {
            int resultDt = 0;
            if (adr == null)
            {
                msg = "data in empty";
                return resultDt;
            }
            try
            {
                db.Open();
                db.insertAttendanceRecord(adr);
                msg = "record complete";
                return resultDt;
            }
            catch
            {
                msg = "error has occurred when insert data";
                return resultDt;
            }
            finally
            {
                db.Close();
            }
        }

        public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable getAttendanceByDate(DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr)
        {
            attDt = new DsPSMS.ST_ATTENDANCE_DATADataTable();

            if (dr == null)
                return null;
            try
            {
                db.Open();
                attDt = db.selectAttendanceByDate(dr);
                if (attDt != null && (attDt.Rows.Count > 0))
                    return attDt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Close();
            }
        }

        public int updateAttendanceRecord(DataSet.DsPSMS.ST_ATTENDANCE_DATARow adr, out string msg)
        {
            int resultDt = 0;
            if (adr == null)
            {
                msg = "data in empty";
                return resultDt;
            }
            try
            {
                db.Open();
                db.updateAttendanceRecord(adr);
                msg = "record complete";
                return resultDt;
            }
            catch
            {
                msg = "error has occurred when insert data";
                return resultDt;
            }
            finally
            {
                db.Close();
            }
        }

        //public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectAttendanceList(DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr)
        //{
        //    DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable result = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();            
        //    try
        //    {
        //        db.Open();
        //        result = db.selectAttendanceList(dr);                
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }
        //    return result;
        //}
    }
}
