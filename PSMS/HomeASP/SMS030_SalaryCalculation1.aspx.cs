using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Collections.Specialized;
using HomeASP.DataSet;

namespace HomeASP
{
    public partial class SMS030_SalaryCalculation1 : System.Web.UI.Page
    {
        DsPSMS.ST_SALARYRow salaryDr = new DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();
        PositionService pService = new PositionService();
        SalaryCalculationService salarySerivce = new SalaryCalculationService();
        string msg = "";
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
                btnSalarySave.Enabled = false;
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            if(comboPos.Items.Count == 1)
                FillPositionListCombo();
        }
        void FillPositionListCombo()
        {
            comboPos.Items.Clear();
            DataSet.DsPSMS.ST_POSITION_MSTDataTable resultDt = pService.getAllPosMst(out msg);
            comboPos.DataSource = resultDt;
            comboPos.DataTextField = "POSITION_NAME";
            comboPos.DataValueField = "POSITION_ID";
            comboPos.DataBind();

           // comboPos.Items.Insert(0, new ListItem("Choose Position", "0"));
        }

        protected void btnSearchSarlary_Click(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ST_SALARYDataTable resultDt = new DataSet.DsPSMS.ST_SALARYDataTable();
            if (ddlMonth.SelectedIndex > 0 && ddlEducation.SelectedIndex > 0)
            {
                int posId = int.Parse(comboPos.SelectedItem.Value);
                DataSet.DsPSMS.ST_STAFF_DATADataTable teachers = salarySerivce.getStaffData(posId, out msg);
                gvsalarylist.DataSource = teachers;
                gvsalarylist.DataBind();
                btnSalarySave.Enabled = true;
            }
            else
            {
                lblErroSms.Visible = true;
            }

            // Bining data
            //resultDt = salarySerivce.getAllSalaryData();
           
            //TextBox box1 = (TextBox)gvsalarylist.Rows[0].Cells[3].FindControl("TextBox1"); //
            //box1.Text = resultDt.Rows[0][5].ToString();
        }

        protected void BtnSalarySave_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;

            try
            {
                for (int i = 1; i <= gvsalarylist.Rows.Count; i++)
                {
                    //extract the TextBox values
                    salaryDr.EDU_YEAR = ddlEducation.Text;
                    salaryDr.YEAR = 2016;
                    salaryDr.MONTH = ddlMonth.Text;
                    salaryDr.STAFF_ID = gvsalarylist.Rows[rowIndex].Cells[0].Text;

                    TextBox box1 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[3].FindControl("TextBox1");
                    salaryDr.LEAVE_TIMES = Convert.ToInt32(box1.Text);
                    TextBox box2 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[4].FindControl("TextBox2");
                    salaryDr.LEAVE_AMOUNT = Convert.ToInt32(box2.Text);
                    TextBox box3 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[5].FindControl("TextBox3");
                    salaryDr.LATE_TIMES = Convert.ToInt32(box3.Text);
                    TextBox box4 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[6].FindControl("TextBox4");
                    salaryDr.LATE_AMOUNT = Convert.ToInt32(box4.Text);
                    TextBox box5 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[7].FindControl("TextBox5");
                    salaryDr.OT_AMOUNT = Convert.ToInt32(box5.Text);

                    int totalSalary = calculateSalary(salaryDr, gvsalarylist.Rows[rowIndex].Cells[2].Text);
                    TextBox box6 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[8].FindControl("TextBox6");
                    salaryDr.SALARY_AMOUNT = Convert.ToInt32(box6.Text);

                    TextBox box7 = (TextBox)gvsalarylist.Rows[rowIndex].Cells[9].FindControl("TextBox7");
                    salaryDr.REMARK = box7.Text;
                    salaryDr.CRT_DT_TM = DateTime.Now;
                    salaryDr.CRT_USER_ID = "2";
                    salaryDr.UPD_DT_TM = DateTime.Now;
                    salaryDr.UPD_USER_ID = "";

                    salarySerivce.saveSalaryData(salaryDr, out msg);
                    rowIndex++;
                }
                Session["Staff_Type"] = comboPos.Text;
                Session["Salary_Month"] = ddlMonth.Text;
                Session["Salary_EduYear"] = ddlEducation.Text;
                Response.Redirect("SM0037_SalaryCalculationDisplay.aspx");
            }
            catch
            {
                errSms.Text = "Insert Fail !!";
            }

        }

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
    }
}