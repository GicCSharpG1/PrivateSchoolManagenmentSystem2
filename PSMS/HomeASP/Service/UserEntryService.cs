using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.Service
{
    class UserEntryService : dbAccess
    {
        UserEntryDb userDb = new UserEntryDb();

        public bool isExistUser(DataSet.DsPSMS.ST_USER_MSTRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_USER_MSTRow userData = new DataSet.DsPSMS.ST_USER_MSTDataTable().NewST_USER_MSTRow();
            DataSet.DsPSMS.ST_USER_MSTDataTable selectedUser = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            bool existFlag = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                userDb.Open();
                if (dr.USER_NAME != null)
                    userData.USER_NAME = dr.USER_NAME;
                selectedUser = userDb.selectUser(userData);

                if (selectedUser != null && selectedUser.Rows.Count > 0)
                {
                    msg = "exist user";
                }
                else
                {
                    selectedUser = null;
                }
            }
            catch
            {
                msg = "error has occure when insert data";
                return false;
            }
            finally
            {
                userDb.Close();
            }
            return existFlag;
        }

        public bool saveUser(DataSet.DsPSMS.ST_USER_MSTRow ur, string tbName, out string msg)
        {
            bool isOk = true;
            int result = 0;
            if (ur == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                userDb.Open();
                result = userDb.insertUser(ur, tbName);
                msg = "insert complete";
            }
            catch
            {
                msg = "error has occure when insert data";
                return false;
            }
            finally
            {
                userDb.Close();
            }
            return isOk;
        }

        public DataSet.DsPSMS.ST_USER_MSTDataTable getAllUsers(out string msg)
        {
            DataSet.DsPSMS.ST_USER_MSTDataTable userLists = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            try
            {
                userDb.Open();
                userLists = userDb.selectAllUsers();
                if (userLists != null && userLists.Rows.Count > 0)
                {
                    msg = userLists.Rows.Count + " Person found";
                }
                else
                {
                    userLists = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occur when select all users!";
                return null;
            }
            finally
            {
                userDb.Close();
            }
            return userLists;
        }

        public DataSet.DsPSMS.ST_USER_MSTDataTable getUserById(int id, out string msg)
        {
            DataSet.DsPSMS.ST_USER_MSTDataTable user = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            try
            {
                userDb.Open();
                user = userDb.selectUserById(id);
                if (user != null && user.Rows.Count > 0)
                {
                    msg = user.Rows.Count + " Person found";
                }
                else
                {
                    user = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occur when select user by id!";
                return null;
            }
            finally
            {
                userDb.Close();
            }
            return user;
        }

        public DataSet.DsPSMS.ST_USER_MSTRow getUserId(DataSet.DsPSMS.ST_USER_MSTRow dr, out string msg)
        {
            DataSet.DsPSMS.ST_USER_MSTDataTable user = new DataSet.DsPSMS.ST_USER_MSTDataTable();
            DataSet.DsPSMS.ST_USER_MSTRow userDr = new DataSet.DsPSMS.ST_USER_MSTDataTable().NewST_USER_MSTRow();
            try
            {
                userDb.Open();
                userDr = userDb.selectUserId(dr);
                if (user != null && user.Rows.Count > 0)
                {
                    msg = user.Rows.Count + " Person found";
                }
                else
                {
                    user = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occur when select user by id!";
                return null;
            }
            finally
            {
                userDb.Close();
            }
            return userDr;
        }

        public bool updateUser(DataSet.DsPSMS.ST_USER_MSTRow ur, out string msg)
        {
            bool isOk = true;
            if (ur == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                userDb.Open();
                userDb.updateUser(ur);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occur when update user";
                return false;
            }
            finally
            {
                userDb.Close();
            }
            return isOk;
        }

        public bool deleteUser(int userId, out string msg)
        {
            bool isOk = true;
            try
            {
                userDb.Open();
                userDb.deleteUser(userId);
                msg = "delete complete";
            }
            catch
            {
                msg = "error has occure when update user";
                return false;
            }
            finally
            {
                userDb.Close();
            }
            return isOk;
        }
        
    }
}
