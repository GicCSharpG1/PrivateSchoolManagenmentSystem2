using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using System.Data.SqlClient;

namespace HomeASP.Service 
{
    public class EquipmentService :dbAccess
    {
        EquipmentDb equipDb = new EquipmentDb();

        public bool SaveEquipmentMST(DsPSMS.ST_EQUIPMENT_MSTRow dr, out string msg)
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
                int result = equipDb.insertEquipMST(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                    Close();
            }

            return isOk;
        }

        public bool SaveEquipmentData(DsPSMS.ST_EQUIPMENT_DATARow dr, out string msg)
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
                int result = equipDb.insertEquipData(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DsPSMS.ST_EQUIPMENT_MSTDataTable getAllEquipMST(out string msg)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            try
            {
                Open();
                EqMSTDt = equipDb.selectAllEquipMSt();
                msg = "Have data";
            }
            catch
            {
                 msg = "error occurs when selecting the equipment master";
                return null;
            }
            finally
            {
                Close();
            }

            return EqMSTDt;
        }

        public DsPSMS.ST_EQUIPMENT_MSTDataTable getEquipMSTByOption(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            try
            {
                Open();
                EqMSTDt = equipDb.selectEquipMStByOption(dr);
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
            return EqMSTDt;
        }

        public DsPSMS.ST_EQUIPMENT_MSTRow getEquipDataById(int id, out string msg)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            try
            {
                Open();
                EqMstDt = equipDb.selectEquipDataById(id);
                msg = "Have data";
            }
            catch
            {
                 msg = "error occurs when selecting the equipment data";
                return null;
            }
            finally
            {
                Close();
            }

            return EqMstDt[0];
        }

        public DsPSMS.ST_EQUIPMENT_DATADataTable getAllEquipData(out string msg)
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable EqDataDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();

            try
            {
                Open();
                EqDataDt = equipDb.selectAllEquipData();
                msg = "Have data";
            }
            catch
            {
                 msg = "error occurs when selecting the all equipment data";
                return null;
            }
            finally
            {
                Close();
            }

            return EqDataDt;
        }

        public bool editEquipmentMST(DsPSMS.ST_EQUIPMENT_MSTRow dr, out string msg)
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
                int result = equipDb.updateEquipMST(dr);
                msg = "Edited";
            }
            catch
            {
                msg = "error occurs when editing the Equipment master";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool editEquipmentData(DsPSMS.ST_EQUIPMENT_DATARow dr, out string msg)
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
                int result = equipDb.updateEquipData(dr);
                msg = "Edited";
            }
            catch
            {
                msg = "error occurs when Editing the Equipment data ";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool removeEquipmentMST(DsPSMS.ST_EQUIPMENT_MSTRow dr, out string msg)
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
                int result = equipDb.deleteEquipMST(dr);
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

        public bool removeEquipmentData(DsPSMS.ST_EQUIPMENT_DATARow dr, out string msg)
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
                int result = equipDb.deleteEquipData(dr);
                msg = "Deleted";
            }
            catch
            {
                msg = "error occurs when deleting the Equipment Data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_EQUIPMENT_DATARow getUpdateEquipmentById(int id, out string msg)
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable EqMstDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();

            try
            {
                Open();
                EqMstDt = equipDb.selectEquipmentById(id);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting the equipment data";
                return null;
            }
            finally
            {
                Close();
            }

            return EqMstDt[0];
        }

        public DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable isExistEquipmentData(DataSet.DsPSMS.ST_EQUIPMENT_DATARow dr)
        {
            if (dr == null)
                return null;
            try
            {
                equipDb.Open();
                DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable dt = equipDb.isExitEquipData(dr);
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
                equipDb.Close();
            }
        }
    }
}