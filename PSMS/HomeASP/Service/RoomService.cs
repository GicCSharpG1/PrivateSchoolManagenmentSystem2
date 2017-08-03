using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using System.Data.SqlClient;

namespace HomeASP.Service
{
    public class RoomService : dbAccess
    {
        RoomDb roomDb = new RoomDb();

        public bool SaveRoomMST(DsPSMS.ST_ROOM_MSTRow dr, out string msg)
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
                int result = roomDb.insertRoomMST(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }


        public DsPSMS.ST_ROOM_MSTDataTable getAllRoomMST()
        {
            DsPSMS.ST_ROOM_MSTDataTable EqMSTDt = new DsPSMS.ST_ROOM_MSTDataTable();

            try
            {
                Open();
                EqMSTDt = roomDb.selectAllRoomData();
                //msg = "Have data";
            }
            catch
            {
               // msg = "error occurs when selecting themaster";
                return null;
            }
            finally
            {
                Close();
            }

            return EqMSTDt;
        }

        public DsPSMS.ST_ROOM_MSTRow getRoomDataById(int id, out string msg)
        {
            DsPSMS.ST_ROOM_MSTDataTable resultDate = new DsPSMS.ST_ROOM_MSTDataTable();

            try
            {
                Open();
                resultDate = roomDb.selectRoomDataById(id);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting the  data";
                return null;
            }
            finally
            {
                Close();
            }

            return resultDate[0];
        }

        public bool editRoomMST(DsPSMS.ST_ROOM_MSTRow dr, out string msg)
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
                int result = roomDb.updateRoomMST(dr);
                msg = "Edited";
            }
            catch
            {
                msg = "error occurs when editing the Room master";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool removeRoomMST(DsPSMS.ST_ROOM_MSTRow dr, out string msg)
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
                int result = roomDb.deleteRoomMST(dr);
                msg = "It is successfully deleted";
            }
            catch
            {
                msg = "error occurs when deleting room master";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_ROOM_MSTDataTable isExistRoomData(DataSet.DsPSMS.ST_ROOM_MSTRow dr)
        {
            if (dr == null)
                return null;
            try
            {
                roomDb.Open();
                DataSet.DsPSMS.ST_ROOM_MSTDataTable dt = roomDb.isExitRoomData(dr);
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
                roomDb.Close();
            }
        }
    }
}