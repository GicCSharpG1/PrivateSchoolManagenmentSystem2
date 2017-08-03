using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeASP.DbAccess;


namespace HomeASP.Service
{
    class AttendanceService : dbAccess
    {
        AttendanceDb db = new AttendanceDb();

        public DataSet.DsPSMS.ATTENDANCE_RESULTDataTable selectAttendanceData(DataSet.DsPSMS.ST_STUDENT_DATARow sr, DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr, out string msg)
        {
            DataSet.DsPSMS.ATTENDANCE_RESULTDataTable result = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();
            if (dr == null)
            {
                msg = "data is empty";
                return null;
            }
            try
            {
                db.Open();
                result = db.selectAttendanceData(sr, dr);
                if (result != null)
                {
                    msg = result.Rows.Count + " day found";
                }
                else
                {
                    result = null;
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

            return result;
        }

        public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectAllAttendance()
        {
            DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable result = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
           
            try
            {
                db.Open();
                result = db.selectAllAttendance();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    result = null;
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

            return result;
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
            if (dr == null)
                return null;
            try
            {
                db.Open();
                DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable dt = db.selectAttendanceByDate(dr);
                if (dt != null && (dt.Rows.Count > 0))
                    return dt;
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

        public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectAttendanceList(DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr)
        {
            DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable result = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();            
            try
            {
                db.Open();
                result = db.selectAttendanceList(dr);                
            }
            catch
            {
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
