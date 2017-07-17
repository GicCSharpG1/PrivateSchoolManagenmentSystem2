using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP
{
    public partial class SMS016 : System.Web.UI.Page
    {
        string msg;
        int index;
        StudentInfoService stuService = new StudentInfoService();
        StudentCashInfoService stuCashService = new StudentCashInfoService();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            showCashList();
           
        }

        protected void showCashList()
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            stuCashDt = stuCashService.getCashAllData(out msg);
            if (stuCashDt != null && stuCashDt.Rows.Count != 0)
            {
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                cashList.DataSource = stuCashDt;
                cashList.DataBind();
            }
            else
            {
                cashList.DataSource = stuCashDt;
                cashList.DataBind();
            }
        }

        protected void CoboSelect_Change(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
            DsPSMS.ST_STUDENT_DATARow stuDataDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow(); 

            if (TxtStudID.Text.Trim().Length != 0)
            {
                stuDataDr.STUDENT_ID = TxtStudID.Text;
                stuCashDr.STUDENT_ID = TxtStudID.Text;
                stuDataDr.EDU_YEAR = CoboYear.Text;
                stuCashDr.EDU_YEAR = CoboYear.Text;
                stuDataDr = stuService.getStuName(stuDataDr, out msg);
                if (stuDataDr != null)
                    LabStuNameVal.Text = stuDataDr.STUDENT_NAME;
                else
                    errSeach.Text = "Not match the student's Id and year!!";
                showOneCashData(stuCashDr);
            }
        }

        protected void showOneCashData(DsPSMS.ST_STUDENT_CASHRow dr)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();

            stuCashDt = stuCashService.getCashData(dr,out msg);
            if (stuCashDt != null)
            {
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                cashList.DataSource = stuCashDt;
                cashList.DataBind();
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
            DsPSMS.ST_STUDENT_DATARow stuDataDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();

            if (CoboYear.Text.Trim().Length != 0 && TxtStudID.Text.Trim().Length != 0)
            {
                stuDataDr.STUDENT_ID = TxtStudID.Text;
                stuCashDr.STUDENT_ID = TxtStudID.Text;
                stuDataDr.EDU_YEAR = CoboYear.Text;
                stuCashDr.EDU_YEAR = CoboYear.Text;
                stuDataDr = stuService.getStuName(stuDataDr, out msg);
                if (stuDataDr != null)
                {
                    LabStuNameVal.Text = stuDataDr.STUDENT_NAME;
                    showOneCashData(stuCashDr);
                }
            }
            else
            {
                errSeach.Text = "Please Enter Student Id and Choose the Year";
            }
        }

        protected void showAll_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            stuCashDt = stuCashService.getCashAllData(out msg);
            if (stuCashDt != null && stuCashDt.Rows.Count != 0)
            {
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
                cashList.DataSource = stuCashDt;
                cashList.DataBind();
            }
        }

        protected void cashList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "DetailCol")
                {
                    Session["EDU_YEAR"] = cashList.Rows[index].Cells[0].Text;
                    Session["CASH_DATE"] = cashList.Rows[index].Cells[4].Text;
                    Session["STUDENT_ID"] = cashList.Rows[index].Cells[2].Text;
                    Response.Redirect("SMS015_StudentCashInfo.aspx");
                }
                //else if (e.CommandName == "EditCol")
                //{

                //    BtnPay.Enabled = false;
                //    txtExpIDVal.Text = expDetList.Rows[index].Cells[0].Text;
                //    TxtExpSubTitle.Text = expDetList.Rows[index].Cells[1].Text;
                //    TxtAmt.Text = expDetList.Rows[index].Cells[2].Text;
                //}

                else if (e.CommandName == "DeleteCol")
                {
                    DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
                    stuCashDr.CASH_ID = cashList.Rows[index].Cells[1].Text;
                    stuCashService.deleteCashData(stuCashDr, out msg);
                    alertMsg.Text = msg;
                    showCashList();
                }
            }
            catch
            {
            }
        }

        protected void cashList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showCashList();
            cashList.PageIndex = e.NewPageIndex;
            cashList.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            errSeach.Visible = false;
        }
    }
}