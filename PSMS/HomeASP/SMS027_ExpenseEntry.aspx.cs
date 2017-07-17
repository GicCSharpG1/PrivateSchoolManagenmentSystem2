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
    public partial class SMS027 : System.Web.UI.Page
    {
        string msg = "";
        string userId = "";
        int index;
        DsPSMS.ST_EXP_HEDDataTable ExpHedDt = new DsPSMS.ST_EXP_HEDDataTable();
        DsPSMS.ST_EXP_HEDRow expHedDr = new DsPSMS.ST_EXP_HEDDataTable().NewST_EXP_HEDRow();
        ExpanseService expService = new ExpanseService();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            BtnConfirm.Enabled = false;

            showExpHedGv();
            
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
        }

        protected void showExpHedGv()
        {
            ExpHedDt = expService.getExpHedAllData(out msg);
            if (ExpHedDt != null && ExpHedDt.Rows.Count != 0)
            {
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                expHedList.DataSource = ExpHedDt;
                expHedList.DataBind();
            }
            else
            {
                expHedList.DataSource = ExpHedDt;
                expHedList.DataBind();
            }
        }

        protected void showExpHedGvByOption(DsPSMS.ST_EXP_HEDRow dr)
        {
            ExpHedDt = expService.getExpHedDataByOption(dr, out msg);
            if (ExpHedDt != null && ExpHedDt.Rows.Count != 0)
            {
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[5]);
                expHedList.DataSource = ExpHedDt;
                expHedList.DataBind();
            }
            else
            {
                expHedList.DataSource = ExpHedDt;
                expHedList.DataBind();
            }
        }

        /*protected bool Validation(DsPSMS.ST_EXP_HEDRow dr)
        {
            DsPSMS.ST_EXP_HEDDataTable ExpHedDt = new DsPSMS.ST_EXP_HEDDataTable();
            ExpHedDt = expService.getExpHedAllData(out msg);
            if (ExpHedDt.Rows.Count == 0)
                return false;
            else
                return true;
        }*/

        protected void expList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "DetailCol")
                {
                    Session["EDU_YEAR"] = expHedList.Rows[index].Cells[0].Text;
                    Session["EXP_ID"] = expHedList.Rows[index].Cells[1].Text;
                    Response.Redirect("SMS029_ExpenseDetail.aspx");
                }
                else if (e.CommandName == "EditCol")
                {
                    BtnConfirm.Enabled = true;
                    BtnPay.Enabled = false;
                    CoboYear.Text = expHedList.Rows[index].Cells[0].Text;
                    id.Text = expHedList.Rows[index].Cells[1].Text;
                    TxtExpTitle.Text = expHedList.Rows[index].Cells[2].Text;
                    cashDate.Text = expHedList.Rows[index].Cells[3].Text;
                    if (expHedList.Rows[index].Cells[4].Text != "&nbsp;")
                        TxtRe.Text = expHedList.Rows[index].Cells[4].Text;
                }

                else if (e.CommandName == "DeleteCol")
                {
                    expHedDr.EXP_ID = Convert.ToInt16(expHedList.Rows[index].Cells[1].Text);
                    // to write for confirm message
                    expService.deleteExpHed(expHedDr, out msg);
                    showExpHedGv();
                }
            }

            catch (Exception ee)
            {
                string message = ee.Message;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            expHedDr.EDU_YEAR = CoboYear.Text;
            expHedDr.EXP_TITLE = TxtExpTitle.Text;
            expHedDr.EXP_DATE = Convert.ToDateTime(cashDate.Text);
            expHedDr.REMARK = TxtRe.Text;
            expHedDr.CRT_DT_TM = DateTime.Now;
            expHedDr.CRT_USER_ID = this.userId;
            expHedDr.UPD_DT_TM = DateTime.Now;
            expHedDr.UPD_USER_ID = "";
            expHedDr.DEL_FLG = 0;

            expService.SaveExpHedInfo(expHedDr, out msg);
            showExpHedGv();

            clear();
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            expHedDr.EXP_ID = Convert.ToInt16(id.Text);
            expHedDr.EDU_YEAR = CoboYear.Text;
            expHedDr.EXP_TITLE = TxtExpTitle.Text;
            expHedDr.EXP_DATE = Convert.ToDateTime(cashDate.Text);
            expHedDr.REMARK = TxtRe.Text;
            expHedDr.UPD_DT_TM = DateTime.Now;
            expHedDr.UPD_USER_ID = this.userId;
            // to write for confirm message
            expService.updateExpHedInfo(expHedDr, out msg);
            showExpHedGv();

            BtnConfirm.Enabled = false;
            BtnPay.Enabled = true;

            clear();
        }

        protected void EqpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showExpHedGv();
            expHedList.PageIndex = e.NewPageIndex;
            expHedList.DataBind();
        }

        protected void clear()
        {
            CoboYear.Text = "";
            TxtExpTitle.Text = "";
            TxtRe.Text = "";
            cashDate.Text = "";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CoboYear.Text.Trim().Length != 0 || TxtExpTitle.Text.Trim().Length != 0 || cashDate.Text.Trim().Length != 0)
            {
                DsPSMS.ST_EXP_HEDRow dr = new DsPSMS.ST_EXP_HEDDataTable().NewST_EXP_HEDRow();
                if (TxtExpTitle.Text.Trim().Length != 0)
                    dr.EXP_TITLE = TxtExpTitle.Text;
                if (CoboYear.Text.Trim().Length != 0)
                    dr.EDU_YEAR = CoboYear.Text;
                if (cashDate.Text.Trim().Length != 0)
                    dr.EXP_DATE = Convert.ToDateTime(cashDate.Text);

                showExpHedGvByOption(dr);
            }
            else
            {
                showExpHedGv();
            }
        }

    }
}




