using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HomeASP.DbAccess;
using HomeASP.DataSet;
using System.Data.SqlClient;

namespace HomeASP.Service
{
    public class EventsAndNewsEntryService : dbAccess
    {
        EventsAndNewsEntryDb db = new EventsAndNewsEntryDb();

        public DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable selectEventByID(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable selectedEvent = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            if (dr == null)
            {
                msg = "data is empty ";
                return selectedEvent;
            }
            try
            {
                db.Open();
                if (dr.ID != null)
                    selectedEvent = db.selectEventByID(dr);
            }
            catch
            {
                msg = "error has occure when insert data";
                return selectedEvent;
            }
            finally
            {
                db.Close();
            }
            return selectedEvent;
        }

        public bool saveEvent(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr, out string msg)
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
                int result = db.insertEvent(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_EVENT_NEWS_HED table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public bool updateEvent(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr, out string msg)
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
                int result = db.updateEvent(dr);
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

        public DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable getAllEventData(out string msg)
        {
            DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable result = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            try
            {
                db.Open();
                result = db.selectAllEventData();
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
  
        public DsPSMS.ST_EVENT_NEWS_HEDDataTable getEventNNByOption(DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {
            DsPSMS.ST_EVENT_NEWS_HEDDataTable eqnewDt = new DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            try
            {
                Open();
                eqnewDt = db.getEventNew(dr);

            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
            return eqnewDt;
        }

        public int deleteEvent(DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr, out string msg)
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
                    result = db.deleteEvent(dr);
                    msg = "event deleted";
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