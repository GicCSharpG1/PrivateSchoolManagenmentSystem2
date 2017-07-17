using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using System.Data.SqlClient;

namespace HomeASP.Service
{
    public class PositionService : dbAccess
    {
        PositionDb posDb = new PositionDb();

        public bool SavePositionMST(DsPSMS.ST_POSITION_MSTRow dr, out string msg)
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
                int result = posDb.insertPositionMST(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Information";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool editPositionMST(DsPSMS.ST_POSITION_MSTRow dr, out string msg)
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
                int result = posDb.updatePositionMST(dr);
                msg = "Edited";
            }
            catch
            {
                msg = "error occurs when editing the Position master";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DsPSMS.ST_POSITION_MSTDataTable getPosMstByOption(DsPSMS.ST_POSITION_MSTRow dr)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_POSITION_MSTDataTable PosDt = new DsPSMS.ST_POSITION_MSTDataTable();
            try
            {
                Open();
                PosDt = posDb.selectPosMstByOption(dr);
                
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
            return PosDt;
        }

        public DsPSMS.ST_POSITION_MSTDataTable getAllPosMst(out string msg)
        {
            DsPSMS.ST_POSITION_MSTDataTable posMSTDt = new DsPSMS.ST_POSITION_MSTDataTable();

            try
            {
                Open();
                posMSTDt = posDb.selectAllPosMSt();
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting the Position master";
                return null;
            }
            finally
            {
                Close();
            }

            return posMSTDt;
        }

        public bool removePosMst(DsPSMS.ST_POSITION_MSTRow dr, out string msg)
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
                int result = posDb.deletePosMST(dr);
                msg = "deleted";
            }
            catch
            {
                msg = "error occurs when deleting equipment master";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DsPSMS.ST_POSITION_MSTDataTable getPosMstById(DsPSMS.ST_POSITION_MSTRow dr)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_POSITION_MSTDataTable PosDt = new DsPSMS.ST_POSITION_MSTDataTable();
            try
            {
                Open();
                PosDt = posDb.selectPositionByID(dr);

            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
            return PosDt;
        }

    }
}