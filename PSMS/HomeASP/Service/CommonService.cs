using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HomeASP.DbAccess;
using HomeASP.DataSet;

namespace HomeASP.Service
{
    public class CommonService : dbAccess
    {
        CommonDb cmDb = new CommonDb();
        public DsPSMS.ST_GRADE_MSTDataTable getAllGrade()
        {
            DsPSMS.ST_GRADE_MSTDataTable gdDt = new DsPSMS.ST_GRADE_MSTDataTable();
            try
            {
                Open();
                gdDt = cmDb.selectAllGrade();
                
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }

            return gdDt;
        }
    }
}