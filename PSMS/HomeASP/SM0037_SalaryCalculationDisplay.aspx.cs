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
            DataSet.DsPSMS.ST_SALARYDataTable resultDt = new DataSet.DsPSMS.ST_SALARYDataTable();
            DataSet.DsPSMS.ST_SALARYRow resultDr = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();
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

            if (ddlMonth.SelectedIndex <= 0 && ddlEducation.SelectedIndex <= 0)
            {
                btnShowAllSalary_Click(sender, e);
            }
            else
            {
                btnSearchSarlary_Click(sender, e);
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

        protected void bindBasicSalary(DataSet.DsPSMS.ST_SALARYDataTable salarys)
        {
            int rw;
            int pgCount = gvsalarylist.PageSize - 1;
            int pgIndex = gvsalarylist.PageIndex;
            if (pgIndex == 0)
            {
                rw = 0;
            }
            else
            {
                rw = (pgIndex * pgCount) + 1;
            }

            foreach (GridViewRow row in gvsalarylist.Rows)
            {
                Label lblSalary = (Label)row.FindControl("lblBasicSalary");
                string staffName = salarys.Rows[rw]["STAFF_ID"].ToString();
                int remark = int.Parse(salarys.Rows[rw]["REMARK"].ToString());
                if (remark == 0)
                {
                    DataSet.DsPSMS.ST_TEACHER_DATARow teacher = salarySerivce.getTeacherByName(staffName);
                    lblSalary.Text = Convert.ToString(teacher.SALARY);
                }
                else
                {
                    DataSet.DsPSMS.ST_STAFF_DATARow staff = salarySerivce.getStaffByName(staffName);
                    lblSalary.Text = Convert.ToString(staff.SALARY);
                }

                rw++;
            }
        }

        //protected void gvsalarylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //    gvsalarylist.PageIndex = e.NewPageIndex;
        //   // displayGridData(reFlag);
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
            DataSet.DsPSMS.ST_SALARYDataTable resultDt = new DataSet.DsPSMS.ST_SALARYDataTable();
            DataSet.DsPSMS.ST_SALARYRow resultDr = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();

            if (ddlMonth.SelectedIndex > 0 && ddlEducation.SelectedIndex > 0)
            {
                // Bining data
                resultDr.EDU_YEAR = ddlEducation.SelectedValue;
                resultDr.MONTH = ddlMonth.SelectedValue;
                resultDt = salarySerivce.getSalaryDataByCondition(resultDr);
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
            }
           
        }

        //protected void gvsalarylist_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvsalarylist.EditIndex = e.NewEditIndex;
        //   // displayGridData(reFlag);   
        //}

        //protected void gvsalarylist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    e.Cancel = true;
        //    gvsalarylist.EditIndex = -1;
        //   // displayGridData(reFlag);  
        //}

        //protected void gvsalarylist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = gvsalarylist.Rows[e.RowIndex];
        //    int updateId = Int32.Parse(gvsalarylist.DataKeys[e.RowIndex].Value.ToString());

        //    DataSet.DsPSMS.ST_SALARYRow salary = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();

        //    salary.SALARY_ID = updateId;
        //    string salaryAMT =((Label)(row.FindControl("lblBasicSalary"))).Text.ToString();

        //    TextBox tb1 = (TextBox)(row.FindControl("txtLeaveTime"));
        //    salary.LEAVE_TIMES = int.Parse(tb1.Text);

        //    TextBox tb2 = (TextBox)(row.FindControl("txtLeaveAmt"));
        //    salary.LEAVE_AMOUNT = int.Parse(tb2.Text);

        //    TextBox tb3 = (TextBox)(row.FindControl("txtlateTime"));
        //    salary.LATE_TIMES = int.Parse(tb3.Text);


        //    TextBox tb4 = (TextBox)(row.FindControl("txtLateAmt"));
        //    salary.LATE_AMOUNT = int.Parse(tb4.Text);

        //    TextBox tb5 = (TextBox)(row.FindControl("txtOtAmt"));
        //    salary.OT_AMOUNT = int.Parse(tb5.Text);
        //    salary.REMARK =Convert.ToString(reFlag);
        //    salary.SALARY_AMOUNT = calculateSalary(salary, salaryAMT);
        //    salary.MONTH = ddlMonth.SelectedItem.Value;
        //    salary.UPD_DT_TM = DateTime.Now;
        //    salary.UPD_USER_ID = this.userId;
        //    bool isOK = salarySerivce.updateSalaryData(salary, out msg);
        //    if (isOK)
        //    {
        //        lblsalarybtnclick.Text = "Data Update Succesful !";
        //        gvsalarylist.EditIndex = -1;
        //    }
        //    else
        //    {
        //        lblsalarybtnclick.Text = "Data Update Fail !";
        //    }
        //  //  displayGridData(reFlag);
        //}

        protected void gvsalarylist_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvsalarylist_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gvsalarylist.PageIndex = e.NewPageIndex;
            // displayGridData(reFlag);
        }

        protected void btnShowAllSalary_Click(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ST_SALARYDataTable resultDt = new DataSet.DsPSMS.ST_SALARYDataTable();
            resultDt = salarySerivce.getAllSalaryData();
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
        }
    }
}