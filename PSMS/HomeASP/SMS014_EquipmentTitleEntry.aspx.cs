using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS014 : System.Web.UI.Page
    {
        string msg = "";
        string userId;
        DsPSMS.ST_EQUIPMENT_MSTDataTable eqpMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
        DsPSMS.ST_EQUIPMENT_MSTRow eqpMstDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();
        EquipmentService eqpService = new EquipmentService();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            showExpHedGv();
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            else
            {
                userId = "";
            }
        }

        protected bool Validation(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable eqpMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            eqpMstDt = eqpService.getEquipMSTByOption(dr);
            if (eqpMstDt != null)
            {
                if (eqpMstDt.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            return false;
        }

        protected void showExpHedGv()
        {
            eqpMstDt = eqpService.getAllEquipMST(out msg);
            if (eqpMstDt != null && eqpMstDt.Rows.Count != 0)
            {
                eqpMstList.DataSource = eqpMstDt;
                eqpMstList.DataBind();
            }
            else
            {
                eqpMstList.DataSource = eqpMstDt;
                eqpMstList.DataBind();
            }
        }

        protected void expList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "EditCol")
                {
                    btnConfirm.Enabled = true;
                    BtnEquipSave.Enabled = false;
                    CoboYear.Text = eqpMstList.Rows[index].Cells[0].Text;
                    LabelID.Text = eqpMstList.Rows[index].Cells[1].Text;
                    TxtEqpName.Text = eqpMstList.Rows[index].Cells[2].Text;
                }

                else if (e.CommandName == "DeleteCol")
                {
                    eqpMstDr.EQUIPMENT_ID = Convert.ToInt32(eqpMstList.Rows[index].Cells[1].Text);
                    eqpMstDr.EQUIPMENT_NAME = eqpMstList.Rows[index].Cells[2].Text;

                    //// to write for confirm message
                    eqpService.removeEquipmentMST(eqpMstDr, out msg);
                    showExpHedGv();
                }
            }

            catch (Exception ee)
            {
                string message = ee.Message;
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable eqpMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_EQUIPMENT_MSTRow eqpMstDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();

            eqpMstDr.EDU_YEAR = CoboYear.Text;
            eqpMstDr.EQUIPMENT_NAME = TxtEqpName.Text;
            eqpMstDr.CRT_DT_TM = DateTime.Now;
            eqpMstDr.CRT_USER_ID = this.userId;
            eqpMstDr.UPD_DT_TM = DateTime.Now;
            eqpMstDr.UPD_USER_ID = "";
            if (Validation(eqpMstDr) != true)
            {
                eqpService.SaveEquipmentMST(eqpMstDr, out msg);
                alertMsg.Text = msg;
            }
            else
                alertMsg.Text = "Record is already exist!!";

            showExpHedGv();
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable eqpMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_EQUIPMENT_MSTRow eqpMstDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();

            btnConfirm.Enabled = false;
            BtnEquipSave.Enabled = true;
            eqpMstDr.EDU_YEAR = CoboYear.Text;
            eqpMstDr.EQUIPMENT_NAME = TxtEqpName.Text;
            eqpMstDr.EQUIPMENT_ID = Convert.ToInt32(LabelID.Text);
            //eqpMstDr.CRT_DT_TM = DateTime.Now;
            // eqpMstDr.CRT_USER_ID = this.userId;
            eqpMstDr.UPD_DT_TM = DateTime.Now;
            eqpMstDr.UPD_USER_ID = this.userId;

            if (Validation(eqpMstDr) != true)
            {
                eqpService.editEquipmentMST(eqpMstDr, out msg);
                alertMsg.Text = msg;
            }
            else
                alertMsg.Text = "Record is already exist!!";

            showExpHedGv();
        }

        protected void EqpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showExpHedGv();
            eqpMstList.PageIndex = e.NewPageIndex;
            eqpMstList.DataBind();
        }


    }
}