using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Data;
using HomeASP.DbAccess;
namespace HomeASP
{
    public partial class SM0037_SalaryCalculationDisplay : System.Web.UI.Page
    {
        SalaryCalculationService salarySerivce = new SalaryCalculationService();
        PositionService pService = new PositionService();
        private string msg = "";
        static int reFlag = 0;
        string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }

            //  FillPositionListCombo();  // binding position to comboBox
            //if (Session["Staff_Type"] != null)
            //    comboPos.Text = (string)(Session["Staff_Type"] ?? "");

            if (Session["Salary_Month"] != null)
                ddlMonth.Text = (string)(Session["Salary_Month"] ?? "");
            if (Session["Salary_EduYear"] != null)
                ddlEducation.Text = (string)(Session["Salary_EduYear"] ?? "");
            if (!IsPostBack)
            {
                if (ddlMonth.SelectedIndex <= 0 && ddlEducation.SelectedIndex <= 0)
                {
                    btnShowAllSalary_Click(sender, e);
                }
                else
                {
                    btnSearchSarlary_Click(sender, e);
                }
            }
        }

        //void FillPositionListCombo()
        //{
        //    comboPos.Items.Clear();
        //    DataSet.DsPSMS.ST_POSITION_MSTDataTable resultDt = pService.getAllPosMst(out msg);
        //    comboPos.DataSource = resultDt;
        //    comboPos.DataTextField = "POSITION_NAME";
        //    comboPos.DataValueField = "POSITION_ID";
        //    comboPos.DataBind();

        //    comboPos.Items.Insert(0, new ListItem("Choose Position", "0"));
        //}

        //protected void bindBasicSalary(DataSet.DsPSMS.ST_SALARYDataTable salarys)
        //{
        //    int rw;
        //    int pgCount = gvsalarylist.PageSize - 1;
        //    int pgIndex = gvsalarylist.PageIndex;
        //    if (pgIndex == 0)
        //    {
        //        rw = 0;
        //    }
        //    else
        //    {
        //        rw = (pgIndex * pgCount) + 1;
        //    }

        //    foreach (GridViewRow row in gvsalarylist.Rows)
        //    {
        //        Label lblSalary = (Label)row.FindControl("lblBasicSalary");
        //        string staffName = salarys.Rows[rw]["STAFF_ID"].ToString();
        //        int remark = int.Parse(salarys.Rows[rw]["REMARK"].ToString());
        //        if (remark == 0)
        //        {
        //            DataSet.DsPSMS.ST_TEACHER_DATARow teacher = salarySerivce.getTeacherByName(staffName);
        //            lblSalary.Text = Convert.ToString(teacher.SALARY);
        //        }
        //        else
        //        {
        //            DataSet.DsPSMS.ST_STAFF_DATARow staff = salarySerivce.getStaffByName(staffName);
        //            lblSalary.Text = Convert.ToString(staff.SALARY);
        //        }

        //        rw++;
        //    }
        //}

        protected int calculateSalary(DataSet.DsPSMS.ST_SALARYRow temp, string salaryATM)
        {
            int resultAmt = 0;
            if (temp != null)
            {
                resultAmt = int.Parse(salaryATM);

                if (temp.LEAVE_AMOUNT != 0)
                {
                    int leave = temp.LEAVE_TIMES * temp.LEAVE_AMOUNT;
                    resultAmt -= leave;
                }

                if (temp.LATE_AMOUNT != 0)
                {
                    int late = temp.LATE_TIMES * temp.LATE_AMOUNT;
                    resultAmt -= late;
                }

                if (temp.OT_AMOUNT != 0)
                {
                    resultAmt += temp.OT_AMOUNT;
                }
            }
            return resultAmt;
        }

        protected void btnSearchSarlary_Click(object sender, EventArgs e)
        {
            int i = 0;
            DataSet.DsPSMS.ST_SALARYDataTable resultDt = new DataSet.DsPSMS.ST_SALARYDataTable();
            DataSet.DsPSMS.ST_SALARYRow resultDr = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();

            if (ddlMonth.SelectedIndex > 0 && ddlEducation.SelectedIndex > 0)
            {
                // Bining data
                resultDr.EDU_YEAR = ddlEducation.SelectedValue;
                resultDr.MONTH = ddlMonth.SelectedValue;
                resultDt = salarySerivce.getSalaryDataByCondition(resultDr);
                if (resultDt != null && resultDt.Rows.Count != 0)
                {
                    resultDt.Columns.Remove(resultDt.Columns[0]);
                    //resultDt.Columns.Remove(resultDt.Columns[0]);
                    resultDt.Columns.Remove(resultDt.Columns[1]);
                    resultDt.Columns.Remove(resultDt.Columns[1]);
                    resultDt.Columns.Remove(resultDt.Columns[9]);
                    resultDt.Columns.Remove(resultDt.Columns[9]);
                    resultDt.Columns.Remove(resultDt.Columns[9]);
                    resultDt.Columns.Remove(resultDt.Columns[9]);
                    gvsalarylist.DataSource = resultDt;
                    gvsalarylist.DataBind();

                    foreach (GridViewRow grdRow in gvsalarylist.Rows)
                    {
                        TextBox LeTime = (TextBox)grdRow.FindControl("TextBox1");
                        LeTime.Text = resultDt.Rows[i][2].ToString();
                        TextBox LeAmo = (TextBox)grdRow.FindControl("TextBox2");
                        LeAmo.Text = resultDt.Rows[i][3].ToString();
                        TextBox LaTime = (TextBox)grdRow.FindControl("TextBox3");
                        LaTime.Text = resultDt.Rows[i][4].ToString();
                        TextBox LaAmo = (TextBox)grdRow.FindControl("TextBox4");
                        LaAmo.Text = resultDt.Rows[i][5].ToString();
                        TextBox OTAm = (TextBox)grdRow.FindControl("TextBox5");
                        OTAm.Text = resultDt.Rows[i][6].ToString();
                        TextBox SalaryA = (TextBox)grdRow.FindControl("TextBox6");
                        SalaryA.Text = resultDt.Rows[i][7].ToString();
                        TextBox Rema = (TextBox)grdRow.FindControl("TextBox7");
                        Rema.Text = resultDt.Rows[i][8].ToString();
                        i++;
                    }
                }
                else
                {
                    gvsalarylist.DataSource = resultDt;
                    gvsalarylist.DataBind();
                    lblsalarybtnclick.Text = "There is not record !!!";
                }
            }
            else
                lblErroSms.Text = "Please Fill the Required Data !!";
        }

        protected void btnShowAllSalary_Click(object sender, EventArgs e)
        {
            int i = 0;
            DataSet.DsPSMS.ST_SALARYDataTable resultDt = new DataSet.DsPSMS.ST_SALARYDataTable();
            resultDt = salarySerivce.getAllSalaryData();
            if (resultDt != null && resultDt.Rows.Count != 0)
            {
                resultDt.Columns.Remove(resultDt.Columns[0]);
                //resultDt.Columns.Remove(resultDt.Columns[0]);
                resultDt.Columns.Remove(resultDt.Columns[1]);
                resultDt.Columns.Remove(resultDt.Columns[1]);
                resultDt.Columns.Remove(resultDt.Columns[9]);
                resultDt.Columns.Remove(resultDt.Columns[9]);
                resultDt.Columns.Remove(resultDt.Columns[9]);
                resultDt.Columns.Remove(resultDt.Columns[9]);
                gvsalarylist.DataSource = resultDt;
                gvsalarylist.DataBind();
                foreach (GridViewRow grdRow in gvsalarylist.Rows)
                {
                    TextBox LeTime = (TextBox)grdRow.FindControl("TextBox1");
                    LeTime.Text = resultDt.Rows[i][2].ToString();
                    TextBox LeAmo = (TextBox)grdRow.FindControl("TextBox2");
                    LeAmo.Text = resultDt.Rows[i][3].ToString();
                    TextBox LaTime = (TextBox)grdRow.FindControl("TextBox3");
                    LaTime.Text = resultDt.Rows[i][4].ToString();
                    TextBox LaAmo = (TextBox)grdRow.FindControl("TextBox4");
                    LaAmo.Text = resultDt.Rows[i][5].ToString();
                    TextBox OTAm = (TextBox)grdRow.FindControl("TextBox5");
                    OTAm.Text = resultDt.Rows[i][6].ToString();
                    TextBox SalaryA = (TextBox)grdRow.FindControl("TextBox6");
                    SalaryA.Text = resultDt.Rows[i][7].ToString();
                    TextBox Rema = (TextBox)grdRow.FindControl("TextBox7");
                    Rema.Text = resultDt.Rows[i][8].ToString();
                    i++;
                }
            }
        }

        protected void gvsalarylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsalarylist.PageIndex = e.NewPageIndex;
        }

        protected void gvsalarylist_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            int index;
            DataSet.DsPSMS.ST_SALARYRow resultDr = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "UpdateCol")
                {
                    string aa = gvsalarylist.Rows[index].Cells[0].Text;
                    resultDr.SALARY_ID = Convert.ToInt32((gvsalarylist.Rows[index].Cells[0].Text));
                    resultDr.STAFF_ID = gvsalarylist.Rows[index].Cells[1].Text;

                    TextBox LeTime = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox1");
                    resultDr.LEAVE_TIMES = Convert.ToInt16(LeTime.Text);

                    TextBox LeAmo = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox2");
                    resultDr.LEAVE_AMOUNT = Convert.ToInt16(LeAmo.Text);

                    TextBox LaTime = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox3");
                    resultDr.LATE_TIMES = Convert.ToInt16(LaTime.Text);

                    TextBox LaAmo = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox4");
                    resultDr.LATE_AMOUNT = Convert.ToInt16(LaAmo.Text);

                    TextBox OTAm = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox5");
                    resultDr.OT_AMOUNT = Convert.ToInt16(OTAm.Text);

                    TextBox SalaryA = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox6");
                    resultDr.SALARY_AMOUNT = Convert.ToInt32(SalaryA.Text);

                    TextBox Rema = (TextBox)gvsalarylist.Rows[index].FindControl("TextBox7");
                    resultDr.REMARK = Rema.Text;

                    resultDr.UPD_DT_TM = System.DateTime.Now;
                    resultDr.UPD_USER_ID = userId;

                    salarySerivce.updateSalaryData(resultDr, out msg);
                    errSMS.Text = msg;
                }

            }
            catch
            {
            }
        }
    }
}