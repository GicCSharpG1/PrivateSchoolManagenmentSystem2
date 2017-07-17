using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DbAccess;
using HomeASP.DataSet;
using System.Text;
using System.Threading.Tasks;
using HomeASP.Service;

namespace HomeASP.Service
{
    public class StudentInfoService : dbAccess
    {
        StudentInfo stu = new StudentInfo();
        CommonService cmSer = new CommonService();
        RoomService roSer = new RoomService();

        //saving Student Data
        public bool saveData(DataSet.DsPSMS.ST_STUDENT_DATARow dr, string tbName, out string msg)
        {
            bool isOk = true;
            int result = 0;
            if (dr == null)
            {
                msg = "data is empty";
                return false;
            }
            try
            {
                Open();
                result = stu.insertData(dr, tbName);
                msg = "insert complete";
            }
            catch
            {
                msg = "error has occure when insert data";
                return false;
            }
            finally
            {
                Close();
            }
            return isOk;
        }

        //Update student's data
        public bool updatedata(DataSet.DsPSMS.ST_STUDENT_DATARow dr, out string msg)
        {
            bool isOk = true;
            if (dr == null)
            {
                msg = "data is empty";
                return false;
            }
            try
            {
                Open();
                stu.updateStudent(dr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            { Close(); }
            return isOk;
        }

        //Delete student's data
        public bool removedata(string studentId, out string msg)
        {
            bool isOk = true;
            if (studentId == null)
            {
                msg = "data is empty";
                return false;
            }
            try
            {
                Open();
                stu.deleteStudent(studentId);
                msg = "deleted";
            }
            catch
            {
                msg = "error occurs when deleting student data";
                return false;
            }
            finally
            {
                Close();
            }
            return isOk;
        }

        // Get all student data
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable getAllData(out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                Open();
                dt = stu.selectAllData();
                msg = "Student found";
            }
            catch
            {
                msg = "error has occure when select data";
                return null;
            }
            finally
            { Close(); }
            return dt;
        }

        //Get cash type of student
        public DsPSMS.ST_STUDENT_DATARow getCashType(DsPSMS.ST_STUDENT_DATARow stuDr, out string msg)
        {

            try
            {
                Open();
                stuDr = stu.selectCashType(stuDr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash type";
                return null;
            }
            finally
            {
                Close();
            }

            return stuDr;
        }

        public DsPSMS.ST_STUDENT_DATARow getStuName(DsPSMS.ST_STUDENT_DATARow dr, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow stuDr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            try
            {
                Open();
                stuDr = stu.selectStuName(dr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting name";
                return null;
            }
            finally
            {
                Close();
            }

            return stuDr;
        }

        //Searching Name and Education Year
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable getStudentDataById(string stuId)
        {
            string msg;
            DataSet.DsPSMS.ST_STUDENT_DATADataTable student = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                Open();
                student = stu.selectStuID(stuId);
                msg = "Have Data";

            }
            catch
            {
                msg = "error occurs when searching name and education year";
                return null;

            }
            finally
            {
                Close();
            }
            return student;

        }

        //Searching photo in db
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable SearchPhoto(string photo)
        {
            string msg;
            DataSet.DsPSMS.ST_STUDENT_DATADataTable searchinPhoto = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                Open();
                searchinPhoto = stu.selectPhoto(photo);
                msg = "Have Data";

            }
            catch
            {
                msg = "error occurs when searching ID";
                return null;

            }
            finally
            {
                Close();
            }
            return searchinPhoto;

        }

        //Get Student's data various condition
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable getDataOption(DsPSMS.ST_STUDENT_DATARow dr)
        {
            string msg;
            DataSet.DsPSMS.ST_STUDENT_DATADataTable gyear = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                Open();
                gyear = stu.selectDataOption(dr);
                msg = "Have Data";

            }
            catch
            {
                msg = "error occurs when searching grade and education year";
                return null;

            }
            finally
            {
                Close();
            }
            return gyear;

        }
         
        public DataSet.DsPSMS.ST_STUDENT_DATARow searchIdNaEdGd(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            string msg;
            DataSet.DsPSMS.ST_STUDENT_DATADataTable gyear = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                Open();
                gyear = stu.selectIdNaEdGd(dr);
                msg = "Have Data";
            }
            catch
            {
                msg = "error occurs when searching grade and education year";
                return null;
            }
            finally
            {
                Close();
            }
            return gyear[0];

        }
    }
}











