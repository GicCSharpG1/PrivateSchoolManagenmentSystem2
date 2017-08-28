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
        StudentInfoService stuSer = new StudentInfoService();
        RoomService smSer = new RoomService();
        GradeSubjectService gradeService = new GradeSubjectService();
        AttendanceService attService = new AttendanceService();
        DsPSMS.ST_STUDENT_DATARow stdDr = null;
        DsPSMS.ST_STUDENT_DATADataTable stdDt = null;
        DsPSMS.ST_ATTENDANCE_DATARow attDr = null;
        DsPSMS.ST_ATTENDANCE_DATADataTable attDt = null;
        DsPSMS.ATTENDANCE_RESULTDataTable attResDt = null;
        String msg = null;
        string loginUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ATTENDANCE_RESULTDataTable attResDt = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();

            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }

            if (dlGrade.Items.Count == 0)
            {
                bindGrade();
               // dlGrade.Items.Insert(0, new ListItem("Select Room", "0"));
            }

            if (dlRoom.Items.Count == 0)
            {
                bindRoom();
               // dlRoom.Items.Insert(0, new ListItem("Select Room", "0"));
            }

            if (!IsPostBack)
            {
                int nowYr = Convert.ToInt16(System.DateTime.Now.Year);
                int nexYr = nowYr + 1;
                string EduYr = nowYr + " - " + nexYr;
                ddlEduyr.Text = EduYr;
            
                //attResDt = attService.selectAttendanceEdu(EduYr, out msg);
                //if (attResDt != null && attResDt.Rows.Count != 0)
                //{
                //    gvAttendanceList.DataSource = attResDt;
                //    gvAttendanceList.DataBind();
                //    for (int i = 0; i < gvAttendanceList.Rows.Count; i++)
                //    {
                //        if (gvAttendanceList.Rows[i].Cells[1].Text == "0")
                //        {

                //            gvAttendanceList.Rows[i].Cells[1].ForeColor = Color.Red;
                //        }
                //        else
                //        {
                //            CheckBox chkAM = (CheckBox)gvAttendanceList.Rows[i].FindControl("AM");
                //            chkAM.Checked = true;
                //        }
                //        if (gvAttendanceList.Rows[i].Cells[2].Text == "0")
                //        {
                //            gvAttendanceList.Rows[i].Cells[2].ForeColor = Color.Red;
                //        }
                //        else
                //        {
                //            CheckBox chkPM = (CheckBox)gvAttendanceList.Rows[i].FindControl("PM");
                //            chkPM.Checked = true;
                //        }
                //    }
                //    gvAttendanceList.Columns[1].Visible = false;
                //    gvAttendanceList.Columns[2].Visible = false;
                //}
            }
        }

        protected void bindGrade()
        {
            dlGrade.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeResult = gradeService.getAllGradeData(out msg);
            if (gradeResult != null)
            {
                dlGrade.DataSource = gradeResult.OrderBy(item => item.GRADE_ID);
                dlGrade.DataTextField = "GRADE_NAME";
                dlGrade.DataValueField = "GRADE_ID";
                dlGrade.DataBind();
                dlGrade.Items.Insert(0, "   ");
            }
        }

        public void bindRoom()
        {
            dlRoom.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable stuRoom = smSer.getAllRoomMST();
            dlRoom.DataSource = stuRoom;
            dlRoom.DataTextField = "ROOM_NAME";
            dlRoom.DataValueField = "ROOM_ID";
            dlRoom.DataBind();
            dlRoom.Items.Insert(0, "   ");
        }

        protected void gvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttendanceList.DataSource = attDt;
            gvAttendanceList.DataBind();
            gvAttendanceList.PageIndex = e.NewPageIndex;
            gvAttendanceList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string mon="";
            attDt = new DsPSMS.ST_ATTENDANCE_DATADataTable();
            attDr = new DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
            stdDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();

            if (ShDay.Checked == true || ShMonth.Checked == true)
            {
                attDr.EDU_YEAR = ddlEduyr.Text;
                if (dpDay.Text.Trim().Length != 0)
                    attDr.ATTENDANCE_DATE = Convert.ToDateTime(dpDay.Text);
                if (ddlMonth.SelectedIndex > 0)
                    mon = ddlMonth.SelectedValue;
                if (dlGrade.SelectedIndex > 0)
                    stdDr.GRADE_ID = Convert.ToInt16(dlGrade.SelectedValue);
                if (dlRoom.SelectedIndex > 0)
                    stdDr.ROOM_ID = dlRoom.SelectedValue;
                if (dlStuName.SelectedIndex > 0)
                    attDr.STUDENT_ID = dlStuName.SelectedValue;

                attResDt = attService.selectAttendanceOption(stdDr, attDr, mon, out msg);
                if (attResDt != null && attResDt.Rows.Count != 0)
                {
                    gvAttendanceList.DataSource = attDt;
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
                errSer.Text = "Please Check One of the Day and Month";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dpDay.Text = "";
            ddlMonth.SelectedIndex = 0;
            dlGrade.SelectedIndex = 0;
            dlRoom.SelectedIndex = 0;
            dlStuName.SelectedIndex = 0;
            gvAttendanceList.DataSource = null;
            gvAttendanceList.DataBind();
        }

        protected void updbtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvAttendanceList.Rows.Count; i++)
            {
                int resultDt = 0;
                DataSet.DsPSMS.ST_ATTENDANCE_DATARow row = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                row.STUDENT_ID = gvAttendanceList.Rows[i].Cells[0].Text;
                row.EDU_YEAR = ddlEduyr.Text;
                row.ATTENDANCE_DATE =Convert.ToDateTime(dpDay.Text);
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

        protected void dlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            stdDt = new DsPSMS.ST_STUDENT_DATADataTable();
            stdDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (dlRoom.SelectedIndex > 0)
            {
                stdDr.EDU_YEAR = ddlEduyr.Text;
                stdDr.GRADE_ID = Convert.ToInt16(dlGrade.SelectedValue);
                stdDr.ROOM_ID = dlRoom.SelectedValue;
                stdDt = stuSer.getDataOption(stdDr);
                dlStuName.DataSource = stdDt;
                dlStuName.DataTextField = "STUDENT_NAME";
                dlStuName.DataValueField = "STUDENT_ID";
                dlStuName.DataBind();
                dlStuName.Items.Insert(0, "  ");
            }
        }

        protected void dlRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            stdDt = new DsPSMS.ST_STUDENT_DATADataTable();
            stdDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (dlGrade.SelectedIndex > 0)
            {
                stdDr.EDU_YEAR = ddlEduyr.Text;
                stdDr.GRADE_ID = Convert.ToInt16(dlGrade.SelectedValue);
                stdDr.ROOM_ID = dlRoom.SelectedValue;
                stdDt = stuSer.getDataOption(stdDr);
                dlStuName.DataSource = stdDt;
                dlStuName.DataTextField = "STUDENT_NAME";
                dlStuName.DataValueField = "STUDENT_ID";
                dlStuName.DataBind();
                dlStuName.Items.Insert(0, "  ");
            }
            else
            {
                errSer.Text = "Please Choose the Grade !!";
            }
        }

        protected void dlStuName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}