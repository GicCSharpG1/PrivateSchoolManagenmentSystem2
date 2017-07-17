using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP
{
    public partial class SMS015 : System.Web.UI.Page
    {
        string msg = "";
        string userId = "";

        GradeSubjectDb grdDb = new GradeSubjectDb();
        StudentInfoService stuService = new StudentInfoService();
        StudentCashInfoService stuCashService = new StudentCashInfoService();
        StudentCashInfoDb stuCashDb = new StudentCashInfoDb();
        GradeSubjectService grdSubService = new GradeSubjectService();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            DsPSMS.ST_GRADE_MSTDataTable grdDt = new DsPSMS.ST_GRADE_MSTDataTable();
            DsPSMS.ST_STUDENT_DATARow stDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            DsPSMS.ST_GRADE_MSTRow grdDr = new DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();

            // binding grade to combo box
            grdDt = grdSubService.getAllGradeData(out msg);
            if (grdDt != null && grdDt.Rows.Count != 0)
            {
                if (CoboGrade.Items.Count == 1)
                {
                    CoboGrade.DataSource = grdDt;
                    CoboGrade.DataTextField = "GRADE_NAME";
                    CoboGrade.DataValueField = "GRADE_ID";
                    CoboGrade.DataBind();
                }
            }

            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            if (Session["EDU_YEAR"] != null)
            {
                CoboYear.Text = (string)(Session["EDU_YEAR"] ?? "  ");
                stDr.EDU_YEAR = CoboYear.Text;
                Session.Remove("EDU_YEAR");
            }
            if (Session["STUDENT_ID"] != null)
            {
                TxtStudID.Text = (string)(Session["STUDENT_ID"] ?? "  ");
                stDr.STUDENT_ID = TxtStudID.Text;
                stDr = stuService.getStuName(stDr, out msg);
                if (stDr != null)
                {
                    TxtStuName.Text = stDr.STUDENT_NAME;
                    grdDr.GRADE_ID = stDr.GRADE_ID;
                    grdDt = grdSubService.selectGradeByID(grdDr, out msg);
                    //CoboGrade.Text = "Grade " + stDr.GRADE_ID;
                    CoboGrade.SelectedValue = stDr.GRADE_ID.ToString();
                    //CoboGrade.SelectedIndex = Convert.ToInt32(stDr.GRADE_ID);
                    //CoboGrade.SelectedItem.Text = grdDt[0].GRADE_NAME;
                    CoboSelect_Change(sender, e);
                    Session.Remove("STUDENT_ID");
                }
                else
                    CoboSelect_Change(sender, e);
            }
            if (Session["CASH_DATE"] != null)
            {
                cashDate.Text = (string)(Session["CASH_DATE"] ?? "  ");
                Session.Remove("CASH_DATE");
            }
        }

        protected bool Validation()
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();

            stuCashDr.STUDENT_ID = TxtStudID.Text;
            stuCashDr.EDU_YEAR = CoboYear.Text;
            stuCashDr.CASH_DATE = cashDate.Text;
            stuCashDt = stuCashService.getCashDataByOption(stuCashDr, out msg);
            if (stuCashDt != null)
            {
                if (stuCashDt.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            return false;
        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();

            stuCashDr.EDU_YEAR = CoboYear.Text;
            stuCashDr.STUDENT_ID = TxtStudID.Text;
            stuCashDr.CASH_TITLE = LabCashTypeVal.Text;
            stuCashDr.CASH_DATE = cashDate.Text;
            stuCashDr.ACCOUNT_NO = txtAccNoVal.Text;
            stuCashDr.AMOUNT = Convert.ToInt64(TxtAmountVal.Text);
            stuCashDr.CRT_DT_TM = DateTime.Now;
            stuCashDr.CRT_USER_ID = this.userId;
            stuCashDr.UPD_DT_TM = DateTime.Now;
            stuCashDr.UPD_USER_ID = "";
            stuCashDr.DEL_FLG = 0;
            if (Validation() != true)
            {
                stuCashService.SaveStudentCashInfo(stuCashDr, out msg);
                insertComp.Text = msg;
            }
            else
                insertComp.Text = "You already payed!!";
            calculation();

        }

        protected void CoboSelect_Change(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_DATARow stDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();

            if (TxtStudID.Text.Trim().Length != 0 && TxtStuName.Text.Trim().Length != 0 && CoboGrade.SelectedIndex != 0 && CoboYear.SelectedIndex != 0)
            {

                // select Cash Type
                stDr.EDU_YEAR = CoboYear.Text;
                stDr.STUDENT_ID = TxtStudID.Text;
                stDr.STUDENT_NAME = TxtStuName.Text;
                stDr.GRADE_ID =int.Parse(CoboGrade.SelectedItem.Value);
                stDr = stuService.getCashType(stDr, out msg);

                // show Cash Type
                if (stDr != null)
                {
                    LabCashTypeVal.Text = stDr.CASH_TYPE1;
                    calculation();
                }
                else
                    alert.Text = "This student is not registered Please check information!!!";
            }
        }

        public void calculation()
        {
            int totalPaid = 0;
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            DsPSMS.ST_GRADE_MSTDataTable grdDt = new DsPSMS.ST_GRADE_MSTDataTable();
            DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
            DsPSMS.ST_GRADE_MSTRow grdDr = new DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();

            // select GRADE_ID and CASH_AMOUNT
            grdDr.GRADE_ID =int.Parse(CoboGrade.SelectedItem.Text.Substring(6,1));
            grdDt = grdSubService.selectGradeByID(grdDr, out msg);

            //get cash data and calculate paid amount
            stuCashDr.STUDENT_ID = TxtStudID.Text;
            stuCashDr.EDU_YEAR = CoboYear.Text;
            stuCashDt = stuCashService.getCashData(stuCashDr, out msg);
            for (int i = 0; i < stuCashDt.Rows.Count; i++)
            {
                totalPaid += Convert.ToInt32(stuCashDt[i].AMOUNT);
            }
            LabMonVal.Text = "10 months";
            LabKyatVal.Text = Convert.ToString(grdDt[0].MONTHLY_FEE);
            LabPaidVal.Text = Convert.ToString(totalPaid);
            LabRemainVal.Text = Convert.ToString((10 * Convert.ToInt32(LabKyatVal.Text)) - totalPaid);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            TxtStudID.Text = "";
            TxtStuName.Text = "";
            CoboGrade.SelectedIndex = -1;
            CoboYear.SelectedIndex = -1;
            cashDate.Text = "";
        }
    }
}