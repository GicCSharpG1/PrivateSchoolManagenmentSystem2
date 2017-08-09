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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlGrade.Items.Count == 0)
            {
                getGrade();
            }
            if (ddlClass.Items.Count == 0)
            {
                bindStudentRoom();
                ddlClass.Items.Insert(0, new ListItem("Select Room", "0"));
            }
            if (ddlDay.Items.Count == 0)
            {
                getDay();
            }
            if (gvAttendanceList.Rows.Count == 0)
            {
                gvAttendanceList.DataSource = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
                gvAttendanceList.DataBind();
                studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
                studentRow.EDU_YEAR = eduYearGrade.Text;
                studentRow.GRADE_ID = Convert.ToInt16(ddlGrade.SelectedValue);
                studentRow.ROOM_ID = ddlClass.SelectedValue;
                studentRow.ROLL_NO = "";
                studentRow.STUDENT_NAME = "";

                DataSet.DsPSMS.ST_STUDENT_DATADataTable resultDt = stuentry.getDataOption(studentRow);
                if (resultDt == null || resultDt.Count == 0)
                {
                    gvAttendanceList.DataSource = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
                    gvAttendanceList.DataBind();
                }
                else
                {
                    gvAttendanceList.DataSource = resultDt;
                    gvAttendanceList.DataBind();
                    for (int i = 0; i < resultDt.Count; i++)
                    {
                        CheckBox chkAM = (CheckBox)gvAttendanceList.Rows[i].FindControl("AM");
                        if (chkAM != null && chkAM.Checked == true)
                        {
                            chkAM.Checked = false;
                        }
                        CheckBox chkPM = (CheckBox)gvAttendanceList.Rows[i].FindControl("PM");
                        if (chkPM != null && chkPM.Checked == true)
                        {
                            chkPM.Checked = false;
                        }
                    }
                    //showAllButton();
                    //Label0.Text = "";

                }
            }
        }


        public void bindStudentRoom()
        {
            ddlClass.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable stuRoom = smSer.getAllRoomMST();
            ddlClass.DataSource = stuRoom;
            ddlClass.DataTextField = "ROOM_NAME";
            ddlClass.DataValueField = "ROOM_ID";
            ddlClass.DataBind();
        }

        protected void getGrade()
        {
            ddlGrade.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeResult = gradeService.getAllGradeData(out msg);
            if (gradeResult != null)
            {
                ddlGrade.DataSource = gradeResult.OrderBy(item => item.GRADE_ID);
                ddlGrade.DataTextField = "GRADE_NAME";
                ddlGrade.DataValueField = "GRADE_ID";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, "Select Grade");
            }
        }

        protected void getDay()
        {
            ddlDay.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                if (i < 10)
                {
                    ddlDay.Items.Add("0" + i);
                }
                else
                {
                    ddlDay.Items.Add("" + i);
                }
            }
            ddlDay.Items.Insert(0, "Select Day");
        }

        protected void setDayByMonthYear()
        {
            if (ddlMonth.SelectedIndex != 0)
            {
                int month = Convert.ToInt16(ddlMonth.Text);
                if (month == 2)
                {
                    ddlDay.Items.Remove("30");
                    ddlDay.Items.Remove("31");
                    if (ddlYear.SelectedIndex != 0)
                    {
                        int year = Convert.ToInt16(ddlYear.Text);
                        bool isLeapYear = ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0));
                        if (!isLeapYear)
                        {
                            ddlDay.Items.Remove("29");
                        }
                    }
                }
                if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    ddlDay.Items.Remove("31");
                }
            }
        }

        protected void chooseMonthYear(object sender, EventArgs e)
        {
            setDayByMonthYear();
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
        }

        protected void btnShoAll_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }





    }
}