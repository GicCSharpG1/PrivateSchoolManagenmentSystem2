using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.Service
{
    public class ExpanseService :dbAccess
    {
        ExpanseDb expDb = new ExpanseDb();
        
        public bool SaveExpHedInfo(DsPSMS.ST_EXP_HEDRow dr, out string msg)
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
                int result = expDb.insertExpanseHed(dr);
                msg = "Inserted";
            }
            catch
            {
                msg = "error occurs when inserting the expanse head data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool SaveExpDetInfo(DsPSMS.ST_EXP_DETAILRow dr, out string msg)
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
                int result = expDb.insertExpanseDet(dr);
                msg = "Inserted";
            }
            catch
            {
                msg = "error occurs when inserting the expanse detail data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_EXP_HEDDataTable getExpHedAllData(out string msg)
        {
            DsPSMS.ST_EXP_HEDDataTable expHedDt = new DsPSMS.ST_EXP_HEDDataTable();
            try
            {
                Open();
                expHedDt = expDb.selectExpHedAllData();
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

            return expHedDt;
        }

        public DataSet.DsPSMS.ST_EXP_HEDDataTable getExpHedDataByOption(DsPSMS.ST_EXP_HEDRow dr,out string msg)
        {
            DsPSMS.ST_EXP_HEDDataTable expHedDt = new DsPSMS.ST_EXP_HEDDataTable();
            try
            {
                Open();
                expHedDt = expDb.selectExpHedAllDataByOption(dr);
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

            return expHedDt;
        }

        public DataSet.DsPSMS.ST_EXP_DETAILDataTable getExpDetDataById(int expId,out string msg)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            try
            {
                Open();
                expDetDt = expDb.selectExpDetDataById(expId);
                int ttt = expDetDt.Rows.Count;
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting the Expanse data";
                return null;
            }
            finally
            {
                Close();
            }

            return expDetDt;
        }

        public DataSet.DsPSMS.ST_EXP_DETAILDataTable getExpDetDataByOption(DsPSMS.ST_EXP_DETAILRow dr, out string msg)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            try
            {
                Open();
                expDetDt = expDb.selectExpDetDataByOption(dr);
                int ttt = expDetDt.Rows.Count;
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting the Expanse data";
                return null;
            }
            finally
            {
                Close();
            }

            return expDetDt;
        }

        public bool updateExpHedInfo(DsPSMS.ST_EXP_HEDRow dr, out string msg)
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
                int result = expDb.updateExpanseHed(dr);
                msg = "Edited";
            }
            catch
            {
                msg = "error occurs when editing the expanse head data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool updateExpDetInfo(DsPSMS.ST_EXP_DETAILRow dr,int id, out string msg)
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
                int result = expDb.updateExpanseDet(dr,id);
                msg = "Edited";
            }
            catch
            {
                msg = "error occurs when editing the expanse detail data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool deleteExpHed(DsPSMS.ST_EXP_HEDRow dr, out string msg)
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
               expDb.deleteExpHed(dr);
               msg = "Deleted";
            }
            catch
            {
                msg = "error has occure when delete data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool deleteExpDet(DsPSMS.ST_EXP_DETAILRow dr, out string msg)
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
                expDb.deleteExpDet(dr);
                msg = "Deleted";
            }
            catch
            {
                msg = "error has occure when delete data";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }
    }
}