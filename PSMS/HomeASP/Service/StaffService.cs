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


namespace HomeASP.Service
{
    public class StaffService : dbAccess
    {
        StaffDb db = new StaffDb();

     public DataSet.DsPSMS.ST_STAFF_DATADataTable selectStaffByID(DataSet.DsPSMS.ST_STAFF_DATARow dr)
        {
            DataSet.DsPSMS.ST_STAFF_DATADataTable selectedStaff = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            if (dr == null)
            {
                return selectedStaff;
            }
            try
            {
                db.Open();
                if (dr.STAFF_ID != null)
                    selectedStaff = db.selectStaffByID(dr);
            }
            catch
            {
                return selectedStaff;
            }
            finally
            {
                db.Close();
            }
            return selectedStaff;
        }

        public bool saveStaff(DataSet.DsPSMS.ST_STAFF_DATARow dr, out string msg)
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
                int result = db.insertStaff(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_STAFF_DATA table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable getAllStaffData(out string msg)
         {
             DsPSMS.ST_STAFF_DATADataTable staffDt = new DsPSMS.ST_STAFF_DATADataTable();
             try
             {
                 Open();
                 staffDt = db.selectAllStaffData();
                 msg = "Have data";
             }
             catch
             {
                 msg = "error occurs when selecting the Expanse Head";
                 return null;
             }
             finally
             {
                 Close();
             }

             return staffDt;
         }

        public bool updateStaff(DataSet.DsPSMS.ST_STAFF_DATARow dr, out string msg)
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
                int result = db.updateStaff(dr);
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

        public bool deleteStaff(string staffId, out string msg)
        {
            bool isOk = true;
            if (staffId =="")
            {
                msg = "data is empty";
                return false;
            }
            try
            {
                Open();
                int result = db.deletestaffdata(staffId);
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

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectSNameOnly(string name)
        {
            string msg;
            DataSet.DsPSMS.ST_STAFF_DATADataTable nameonly = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            try
            {
                Open();
                nameonly = db.selectNameOnly(name);
                msg = "Have Data";

            }
            catch
            {
                msg = "error occurs when searching name";
                return null;

            }
            finally
            {
                Close();
            }
            return nameonly;

        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectIdOnly(string staffId)
        {
            string msg;
            DataSet.DsPSMS.ST_STAFF_DATADataTable idonly = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            try
            {
                Open();
                idonly = db.selectIdOnly(staffId);
                msg = "Have Data";

            }
            catch
            {
                msg = "error occurs when searching name";
                return null;

            }
            finally
            {
                Close();
            }
            return idonly;

        }

    
        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectStaffData(string staffname, string staffId)
     {
         string msg;
         DataSet.DsPSMS.ST_STAFF_DATADataTable result = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
        
         try
         {
             db.Open();
             result = db.selectStaffData(staffname,staffId);
             if (result != null)
             {
                 msg = result.Rows.Count + " staff found";
             }
             else
             {
                 
                 msg = "staff not found";
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

        //For detail Page
     public DataSet.DsPSMS.ST_STAFF_DATARow getSelectedStaff(DsPSMS.ST_STAFF_DATARow dr, out string msg)
     {
         {

             DataSet.DsPSMS.ST_STAFF_DATARow selectedUser = new DataSet.DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();


             try
             {
                 Open();

                 selectedUser = db.selectOneStaff(dr);
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

             return selectedUser;
         }
     }

     public DataSet.DsPSMS.ST_POSITION_MSTRow getselectedPosition(string dr, out string msg)
     {
         

             DataSet.DsPSMS.ST_POSITION_MSTRow selectedUser = new DataSet.DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();

          if (dr == null)
            {
                msg = "data is empty ";
                return selectedUser;
            }
             try
             {
                 Open();
               
                 selectedUser = db.selectOnePosition(dr);
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

             return selectedUser;
         
     }

    }
}