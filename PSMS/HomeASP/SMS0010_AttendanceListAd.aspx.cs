using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using System.Drawing;

namespace HomeASP
{
    public partial class SMS0010_AttendanceListAd : System.Web.UI.Page
    {
        StudentInfoService stuentry = new StudentInfoService();
        RoomService smSer = new RoomService();
        GradeSubjectService gradeService = new GradeSubjectService();
        AttendanceService attService = new AttendanceService();
        DataSet.DsPSMS.ST_STUDENT_DATARow studentRow = null;
        DataSet.DsPSMS.ST_ATTENDANCE_DATARow attRow = null;
        DataSet.DsPSMS.ST_STUDENT_DATADataTable stdResult = null;
        DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable attResult = null;

        static DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable attResultList = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
        String msg = null;
        string loginUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ATTENDANCE_RESULTDataTable attResDt = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();
            //day_CheckedChanged(sender, e);
            //Month_CheckedChanged(sender, e);

            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }

            if (!IsPostBack)
            {
                //lblDay.Visible = false;
                //lbMon.Visible = false;
                //dpDay.Visible = false;
                //ddlMonth.Visible = false;

                int nowYr = Convert.ToInt16(System.DateTime.Now.Year);
                int nexYr = nowYr + 1;
                string EduYr = nowYr + " - " + nexYr;
                ddlEduyr.Text = EduYr;

                attResDt = attService.selectAttendanceEdu(EduYr, out msg);
                if (attResDt != null && attResDt.Rows.Count != 0)
                {
                    gvAttendanceList.DataSource = attResDt;
                    gvAttendanceList.DataBind();
                    for (int i = 0; i < gvAttendanceList.Rows.Count; i++)
                    {
                        if (gvAttendanceList.Rows[i].Cells[1].Text == "0")
                        {
                            
                            gvAttendanceList.Rows[i].Cells[1].ForeColor = Color.Red;
                        }
                        else
                        {
                            CheckBox chkAM = (CheckBox)gvAttendanceList.Rows[i].FindControl("AM");
                            chkAM.Checked = true;
                        }
                        if (gvAttendanceList.Rows[i].Cells[2].Text == "0")
                        {
                            gvAttendanceList.Rows[i].Cells[2].ForeColor = Color.Red;
                        }
                        else
                        {
                            CheckBox chkPM = (CheckBox)gvAttendanceList.Rows[i].FindControl("PM");
                            chkPM.Checked = true;
                        }
                    }
                    gvAttendanceList.Columns[1].Visible = false;
                    gvAttendanceList.Columns[2].Visible = false;
                }
            }
        }

        //protected void setDayByMonthYear()
        //{
        //    //if (ddlMonth.SelectedIndex != 0)
        //    //{
        //    //    int month = Convert.ToInt16(ddlMonth.Text);
        //    //    if (month == 2)
        //    //    {
        //    //        ddlDay.Items.Remove("30");
        //    //        ddlDay.Items.Remove("31");
        //    //        if (ddlYear.SelectedIndex != 0)
        //    //        {
        //    //            int year = Convert.ToInt16(ddlYear.Text);
        //    //            bool isLeapYear = ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0));
        //    //            if (!isLeapYear)
        //    //            {
        //    //                ddlDay.Items.Remove("29");
        //    //            }
        //    //        }
        //    //    }
        //    //    if (month == 4 || month == 6 || month == 9 || month == 11)
        //    //    {
        //    //        ddlDay.Items.Remove("31");
        //    //    }
        //    //}
        //}

        protected void chooseMonthYear(object sender, EventArgs e)
        {
            // setDayByMonthYear();
            btnSearch_Click(sender, e);
        }

        protected void chooseDay(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        protected void gvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttendanceList.DataSource = attResultList;
            gvAttendanceList.DataBind();
            gvAttendanceList.PageIndex = e.NewPageIndex;
            gvAttendanceList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ATTENDANCE_RESULTDataTable attResDt = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();
            if (day.Checked == true || Month.Checked == true)
            {
                if (day.Checked == true)
                {
                    lblDay.Visible = true;
                    dpDay.Visible = true;

                    DateTime datee = Convert.ToDateTime(dpDay.Text);
                    attResDt = attService.selectAttendanceDate(datee, out msg);
                    if (attResDt != null && attResDt.Rows.Count != 0)
                    {
                        gvAttendanceList.DataSource = attResDt;
                        gvAttendanceList.DataBind();
                        for (int i = 0; i < gvAttendanceList.Rows.Count; i++)
                        {
                            if (gvAttendanceList.Rows[i].Cells[1].Text == "0")
                            {
                                gvAttendanceList.Rows[i].Cells[1].Text = "Absent";
                                gvAttendanceList.Rows[i].Cells[1].ForeColor = Color.Red;
                            }
                            if (gvAttendanceList.Rows[i].Cells[2].Text == "0")
                            {
                                gvAttendanceList.Rows[i].Cells[2].Text = "Absent";
                                gvAttendanceList.Rows[i].Cells[2].ForeColor = Color.Red;
                            }
                        }
                    }
                }
                else
                {
                    lbMon.Visible = true;
                    ddlMonth.Visible = true;
                    string month = ddlMonth.SelectedValue;
                    attResDt = attService.selectAttendanceMonth(month, out msg);
                    if (attResDt != null && attResDt.Rows.Count != 0)
                    {
                        gvAttendanceList.DataSource = attResDt;
                        gvAttendanceList.DataBind();
                        for (int i = 0; i < gvAttendanceList.Rows.Count; i++)
                        {
                            if (gvAttendanceList.Rows[i].Cells[1].Text == "0")
                            {
                                gvAttendanceList.Rows[i].Cells[1].Text = "Absent";
                                gvAttendanceList.Rows[i].Cells[1].ForeColor = Color.Red;
                            }
                            if (gvAttendanceList.Rows[i].Cells[2].Text == "0")
                            {
                                gvAttendanceList.Rows[i].Cells[2].Text = "Absent";
                                gvAttendanceList.Rows[i].Cells[2].ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
            else
            {

            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnShoAll_Click(object sender, EventArgs e)
        {
            attResult = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
            attResult = attService.selectAllAttendance();
            gvAttendanceList.DataSource = attResult;
            gvAttendanceList.DataBind();
        }

        protected void day_CheckedChanged(object sender, EventArgs e)
        {
            if (day.Checked == true)
            {
                lblDay.Visible = true;
                dpDay.Visible = true;
            }

        }

        protected void Month_CheckedChanged(object sender, EventArgs e)
        {
            if (Month.Checked == true)
            {
                lbMon.Visible = true;
                ddlMonth.Visible = true;
            }
        }

        protected void updbtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvAttendanceList.Rows.Count; i++)
            {
                int resultDt = 0;
                DataSet.DsPSMS.ST_ATTENDANCE_DATARow row = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                row.STUDENT_ID = gvAttendanceList.Rows[i].Cells[0].Text;
                row.EDU_YEAR = ddlEduyr.Text;
                row.ATTENDANCE_DATE = dpDay.Text;
                row.CRT_USER_ID = loginUserId;
                row.CRT_DT_TM = DateTime.Now;
                row.DEL_FLG = 0;

                CheckBox chkAM = (CheckBox)gvAttendanceList.Rows[i].FindControl("AM");
                if (chkAM != null && chkAM.Checked == false)
                {
                    row.MORNING = "0";
                }
                else
                {
                    row.MORNING = "1";
                }
                CheckBox chkPM = (CheckBox)gvAttendanceList.Rows[i].FindControl("PM");
                if (chkPM != null && chkPM.Checked == false)
                {
                    row.EVENING = "0";
                }
                else
                {
                    row.EVENING = "1";
                }
                resultDt = attService.updateAttendanceRecord(row, out msg);
               // errSms.Text = msg;
                //showAllButton();
            }
        }
    }
}