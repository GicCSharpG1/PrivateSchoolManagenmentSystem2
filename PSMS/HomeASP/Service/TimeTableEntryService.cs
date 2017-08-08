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
     class TimeTableEntryService:dbAccess
    {
         TimeTableEntry timedb = new TimeTableEntry();

         public bool isExist(DataSet.DsPSMS.ST_TIMETABLERow dr, out string msg)
         {
             msg = null;
             DataSet.DsPSMS.ST_TIMETABLERow userData = new DataSet.DsPSMS.ST_TIMETABLEDataTable().NewST_TIMETABLERow();
             DataSet.DsPSMS.ST_TIMETABLEDataTable selectedUser = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
             bool existFlag = true;
             //if (dr == null)
             //{
             //    msg = "data is empty ";
             //    return false;
             //}
             //try
             //{
             //    timedb.Open();
             //    if (dr.DAY != null)
             //        userData.DAY = dr.DAY;
             //        selectedUser = timedb.selectTimetable(userData);

             //    if (selectedUser != null && selectedUser.Rows.Count > 0)
             //    {
             //        msg = "exist user";
             //    }
             //    else
             //    {
             //        selectedUser = null;
             //    }
             //}
             //catch
             //{
             //    msg = "error has occure when insert data";
             //    return false;
             //}
             //finally
             //{
             //    timedb.Close();
             //}
             return existFlag;
         }

         public DataSet.DsPSMS.ST_GRADE_MSTDataTable getAllGradeData(out string msg)
         {
             DataSet.DsPSMS.ST_GRADE_MSTDataTable result = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllGradeData();
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
                 timedb.Close();
             }
             return result;
         }

         public DataSet.DsPSMS.ST_ROOM_MSTDataTable getAllRoomData(out string msg)
         {
             DataSet.DsPSMS.ST_ROOM_MSTDataTable result = new DataSet.DsPSMS.ST_ROOM_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllRoomData();
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
                 timedb.Close();
             }
             return result;
         }

         public DataSet.DsPSMS.ST_TEACHER_DATADataTable getAllTeacherData(out string msg)
         {
             DataSet.DsPSMS.ST_TEACHER_DATADataTable result = new DataSet.DsPSMS.ST_TEACHER_DATADataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllTeacherData();
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
                 timedb.Close();
             }
             return result;
         }

         public bool saveTimeTable(DataSet.DsPSMS.ST_TIMETABLERow dr, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.insertStuTimeTable(dr);
                 msg = "insert complete";
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TIMETABLE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public bool saveTeacherGrade(DataSet.DsPSMS.ST_TEACHER_GRADERow dr, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.insertTeacherGrade(dr);
                 msg = "insert complete";
                 
                 
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TEACHER_GRADE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public bool deleteTimeTable(int id, out string msg)
         {
             bool isOk = true;

             if (id == 0)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.deleteStuTimeTable(id);
                 msg = "delete complete";
             }
             catch
             {
                 msg = "error occurs when deleting data to ST_TIMETABLE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }
             return isOk;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getAllTimeTableData(out string msg)
        {
            DataSet.DsPSMS.ST_TIMETABLEDataTable result = new DataSet.DsPSMS.ST_TIMETABLEDataTable();

            try
            {
                timedb.Open();
                result = timedb.selectAllTimetable();
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
                timedb.Close();
            }
            return result;
        }

         public DataSet.DsPSMS.ST_TIMETABLERow getTimeTableByid(int id)
         {
            DataSet.DsPSMS.ST_TIMETABLERow resultData = new DataSet.DsPSMS.ST_TIMETABLEDataTable().NewST_TIMETABLERow();
            try
            {
                timedb.Open();
                resultData = timedb.selectTimetableByid(id);
            }
            finally
            {
                timedb.Close();
            }
             return resultData;
         }

         public bool updateTimeTable(DataSet.DsPSMS.ST_TIMETABLERow dr,int id, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.updateStuTimeTable(dr,id);
                 msg = "update complete";
             }
             catch
             {
                 msg = "error occurs when updating data to ST_TIMETABLE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_GRADE_MSTRow getGradeByid(int id)
         {
             DataSet.DsPSMS.ST_GRADE_MSTRow resultData = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
             string msg;

             try
             {
                 timedb.Open();
                 resultData = timedb.selectGradeByid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             
             return resultData;
         }

         public DataSet.DsPSMS.ST_TEACHER_DATARow getTeacherByid(int id)
         {
             DataSet.DsPSMS.ST_TEACHER_DATARow resultData = new DataSet.DsPSMS.ST_TEACHER_DATADataTable().NewST_TEACHER_DATARow();
             string msg;
             
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTeacherByid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableByidanddate(int id,string date)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = new DsPSMS.ST_TIMETABLEDataTable();
             string msg = "";
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimetableBydateandid(id, date);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableByteacherid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = new DsPSMS.ST_TIMETABLEDataTable();
             string msg = "";
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimetableByteacherid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableBydate(string date)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = new DsPSMS.ST_TIMETABLEDataTable();
             string msg = "";
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimetableBydate(date);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableBygradeid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = new DsPSMS.ST_TIMETABLEDataTable();
             string msg = "";
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimetableBygradeid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow getGradeSubjectBygradeid(int id)
         {
             DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow resultData = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
             
             string msg;

             try
             {
                 timedb.Open();
                 resultData = timedb.selectGradeSubjectBygradeId(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectName(string subjectId, out string msg)
         {
             DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.getAllSubjectName(subjectId);
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
                 timedb.Close();
             }
             return result;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable getAllTimetableHedData(out string msg)
         {
             DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable result = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllTimetableHed();
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
                 timedb.Close();
             }
             return result;
         }

         public bool saveTimetableHedData(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.insertTimetableHed(dr);
                 msg = "insert complete";
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TIMETABLE_HED table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_ROOM_MSTRow getClassByid(int id)
         {
             DataSet.DsPSMS.ST_ROOM_MSTRow resultData = new DataSet.DsPSMS.ST_ROOM_MSTDataTable().NewST_ROOM_MSTRow();
             string msg;

             try
             {
                 timedb.Open();
                 resultData = timedb.selectClassByid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_HEDRow getTimetableHedByid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLE_HEDRow resultData = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable().NewST_TIMETABLE_HEDRow();
             string msg;

             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimetableHedByid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             
             return resultData;
         }

         public bool updateTimeTableHed(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr, int id, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.updateTimeTableHed(dr, id);
                 msg = "update complete";
             }
             catch
             {
                 msg = "error occurs when updating data to ST_TIMETABLE_HED table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectData(out string msg)
         {
             DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllSubjectData();
                 
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
                 timedb.Close();
             }
             return result;
         }

         public bool saveTimetableDetailData(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.insertTimetableDetail(dr);
                 msg = "insert complete";
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TIMETABLE_DETAIL table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_DETAILRow getTimetableDetailByid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLE_DETAILRow resultData = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable().NewST_TIMETABLE_DETAILRow();
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimetableDetailByid(id);
                 //if (resultData != null && resultData.Rows.Count > 0)
                 //{
                 //    //msg = resultData.Rows.Count + " user found";
                 //}

                 //else
                 //{
                 //    resultData = null;
                 //    //msg = "user not found";
                 //}
             }
             catch
             {
                 // msg = "error has occure when insert data";
                 return null;
             }
             finally
             {
                 timedb.Close();
             }
             return resultData;
         }

         public bool updateTimeTableDetail(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr, int id, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.updateTimeTableDetail(dr, id);
                 msg = "update complete";
             }
             catch
             {
                 msg = "error occurs when updating data to ST_TIMETABLE_DETAIL table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public bool deleteTimeDetail(int id, out string msg)
         {
             bool isOk = true;

             if (id == 0)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.deleteTimeTableDetail(id);
                 msg = "delete complete";
             }
             catch
             {
                 msg = "error occurs when deleting data to ST_TIMETABLEDETAIL table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }
             return isOk;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable getAllTimeDetailData(string id,out string msg)
         {
             DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable result = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable();

             try
             {
                 timedb.Open();
                 result = timedb.selectAllTimeDetail(id);
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
                 timedb.Close();
             }
             return result;
         }

         public DataSet.DsPSMS.ST_SUBJECT_MSTRow getSubjectByid(int id)
         {
             DataSet.DsPSMS.ST_SUBJECT_MSTRow resultData = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
             string msg;

             try
             {
                 timedb.Open();
                 resultData = timedb.selectSubjectByid(id);
                 if (resultData != null)
                 {
                     msg = " user found";
                 }

                 else
                 {
                     resultData = null;
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
                 timedb.Close();
             }
             
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_HEDRow searchTimeHedBygradeclassid(int gradeId,int classId)
         {
             DataSet.DsPSMS.ST_TIMETABLE_HEDRow resultData = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable().NewST_TIMETABLE_HEDRow();
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimeHedBygradeclass(gradeId, classId);
                 if (resultData != null)
                 {
                     //msg = resultData.Rows.Count + " user found";
                 }

                 else
                 {
                     resultData = null;
                     //msg = "user not found";
                 }
             }
             catch
             {
                 // msg = "error has occure when insert data";
                 return null;
             }
             finally
             {
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_DETAILRow searchTimeDetailByTimeHedId(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLE_DETAILRow resultData = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable().NewST_TIMETABLE_DETAILRow();
             try
             {
                 timedb.Open();
                 resultData = timedb.selectTimeDetailBytimeHedId(id);
                 //if (resultData != null && resultData.Rows.Count > 0)
                 //{
                 //    //msg = resultData.Rows.Count + " user found";
                 //}

                 //else
                 //{
                 //    resultData = null;
                 //    //msg = "user not found";
                 //}
             }
             catch
             {
                // msg = "error has occure when insert data";
                 return null;
             }
             finally
             {
                 timedb.Close();
             }
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable isExistTimeHed(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr)
         {
             if (dr == null)
                 return null;
             try
             {
                 timedb.Open();
                 DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable dt = timedb.isExitTimeHedData(dr);
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
                 timedb.Close();
             }
         }
         public DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable isExistTimeHed1(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr)
         {
             if (dr == null)
                 return null;
             try
             {
                 timedb.Open();
                 DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable dt = timedb.isExitTimeHedData1(dr);
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
                 timedb.Close();
             }
         }
    }
}