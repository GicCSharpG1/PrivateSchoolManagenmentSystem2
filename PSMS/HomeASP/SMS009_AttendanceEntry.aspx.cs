using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Data;

namespace HomeASP
{    
    public partial class SMS009 : System.Web.UI.Page
    {
        StudentInfoService stuentry = new StudentInfoService();
        GradeSubjectService gradeService = new GradeSubjectService();
        AttendanceService attService = new AttendanceService();
        RoomService roSer = new RoomService();
        DataSet.DsPSMS.ST_STUDENT_DATARow studentRow = null;
        static DataSet.DsPSMS.ATTENDANCE_RESULTDataTable attResultList = new DataSet.DsPSMS.ATTENDANCE_RESULTDataTable();
        static int pageIndex = 0;
        string msg = null;
        static string loginUserId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (gradeList.Items.Count == 0)
            {
                getGrade();
            }

            if (roomList.Items.Count == 0)
            {
                bindStudentRoom();
                roomList.Items.Insert(0, new ListItem("Select Room", "0"));
            }
            if (gridViewAttendance.Rows.Count == 0)
            {
                gridViewAttendance.DataSource = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
                gridViewAttendance.DataBind();
            }
            attendDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            if (!IsPostBack)
            {
                btnAdd.Visible = false;
                //btnUpdate.Visible = false;
                btnCheckAM.Visible = false;
                btnCheckPM.Visible = false;
            }
        }
        public void bindStudentRoom()
        {
            roomList.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable stuRoom = roSer.getAllRoomMST();
            roomList.DataSource = stuRoom;
            roomList.DataTextField = "ROOM_NAME";
            roomList.DataValueField = "ROOM_ID";
            roomList.DataBind();
        }
        private void showAllButton()
        {
            btnAdd.Visible = true;
            btnCheckAM.Visible = true;
            btnCheckPM.Visible = true;
        }

        protected void getGrade()
        {
            gradeList.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeResult = gradeService.getAllGradeData(out msg);
            if (gradeResult != null)
            {
                gradeList.DataSource = gradeResult.OrderBy(item => item.GRADE_ID);
                gradeList.DataTextField = "GRADE_NAME";
                gradeList.DataValueField = "GRADE_ID";
                gradeList.DataBind();
                gradeList.Items.Insert(0, "Select Grade");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (eduYearGrade.SelectedIndex <= 0 || gradeList.SelectedIndex <= 0 || roomList.SelectedIndex <= 0)
            {
                errReqData.Text = "Please Enter Required Data !!";
            }
            else
            {
                studentRow.EDU_YEAR = eduYearGrade.Text;
                studentRow.GRADE_ID = Convert.ToInt16(gradeList.SelectedValue);
                studentRow.ROOM_ID = roomList.SelectedValue;

                DataSet.DsPSMS.ST_STUDENT_DATADataTable resultDt = stuentry.getDataOption(studentRow);
                if (resultDt == null || resultDt.Count == 0)
                {
                    gridViewAttendance.DataSource = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
                    gridViewAttendance.DataBind();
                }
                else
                {
                    gridViewAttendance.DataSource = resultDt;
                    gridViewAttendance.DataBind();
                    showAllButton();
                }
            }
            //gridViewAttendance.DataSource = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            //gridViewAttendance.DataBind();
            //studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            //studentRow.EDU_YEAR = eduYearGrade.Text;
            //studentRow.GRADE_ID =int.Parse(gradeList.DataValueField);
            //studentRow.ROOM_ID = roomList.Text;
            //studentRow.ROLL_NO = "";
            //studentRow.STUDENT_NAME = "";

            //if (attendDate.Text.Trim().Length == 0)
            //{
            //    DataSet.DsPSMS.ST_STUDENT_DATADataTable resultDt = stuentry.getDataOption(studentRow);
            //    if (resultDt == null || resultDt.Count == 0)
            //    {
            //        gridViewAttendance.DataSource = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            //        gridViewAttendance.DataBind();
            //    }
            //    else
            //    {                       
            //        gridViewAttendance.DataSource = resultDt;
            //        gridViewAttendance.DataBind();
            //        for (int i = 0; i < resultDt.Count; i++)
            //        {
            //            CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
            //            if (chkAM != null && chkAM.Checked == true)
            //            {
            //                chkAM.Checked = false;
            //            }
            //            CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
            //            if (chkPM != null && chkPM.Checked == true)
            //            {
            //                chkPM.Checked = false;
            //            }
            //        }
            //        showAllButton();
            //        Label0.Text = "";
                  
            //    }
            //}
            //else
            //{
            //    DataSet.DsPSMS.ST_ATTENDANCE_DATARow adr = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
            //    adr.ATTENDANCE_DATE = attendDate.Text;
            //    DataSet.DsPSMS.ATTENDANCE_RESULTDataTable resultDt = attService.selectAttendanceData(studentRow, adr, out msg);

            //    if (resultDt.Count != 0)
            //    {
            //        gridViewAttendance.DataSource = resultDt;
            //        gridViewAttendance.DataBind();
            //        showChecked(resultDt);                    
            //        //swap data to attResultList to show checkbox if data is over 5 records
            //        if (attResultList.Count == 0)
            //            attResultList = resultDt;
            //        showAllButton();
            //    }
            //}            
        }

        protected void gvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pageIndex = e.NewPageIndex;            
            btnSearch_Click(sender, e);
            gridViewAttendance.PageIndex = e.NewPageIndex;
            gridViewAttendance.DataBind();
            if (attendDate.Text.Trim().Length != 0)
                showChecked(attResultList);            
        }

        protected void showChecked(DataSet.DsPSMS.ATTENDANCE_RESULTDataTable resultDt)
        {
            int index = 0;
            if (gridViewAttendance.PageIndex != 0)
            {
                index += gridViewAttendance.PageIndex * 5;
            }

            int loopCount = 0;
            if (gridViewAttendance.PageSize < resultDt.Count && index == 0)
                loopCount = gridViewAttendance.PageSize;
            else if (index < resultDt.Count)
                loopCount = resultDt.Count - index;

            for (int i = 0; i < loopCount; i++)
            {
                Label date = (Label)gridViewAttendance.Rows[i].FindControl("Date");
                date.Text = resultDt.Rows[index]["ATTENDANCE_DATE"].ToString();

                CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
                chkAM.Checked = false;
                if (Convert.ToInt16(resultDt.Rows[index]["MORNING"]) == 1)
                {
                    chkAM.Checked = true;
                }
                else
                {
                    chkAM.Checked = false;
                }

                CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
                chkPM.Checked = false;
                if (Convert.ToInt16(resultDt.Rows[index]["EVENING"]) == 1)
                {
                    chkPM.Checked = true;
                }
                else
                {
                    chkPM.Checked = false;
                }
                index++;
            }
        }

        //protected void fillDate(object sender, EventArgs e)
        //{
        //    if (gridViewAttendance.Rows.Count != 0 && attendDate.Text.Trim().Length != 0)
        //    {
        //        foreach(GridViewRow row in gridViewAttendance.Rows)
        //        {
        //            Label date = (Label)row.FindControl("Date");
        //            date.Text = attendDate.Text;
        //        }
        //        showAllButton();
        //    }            
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!checkAldyRecord())
            {
                for (int i = 0; i < gridViewAttendance.Rows.Count; i++)
                {
                    int resultDt = 0;
                    DataSet.DsPSMS.ST_ATTENDANCE_DATARow row = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                    row.STUDENT_ID = gridViewAttendance.Rows[i].Cells[0].Text;
                    row.EDU_YEAR = eduYearGrade.Text;
                    row.ATTENDANCE_DATE = attendDate.Text;
                    row.CRT_USER_ID = loginUserId;
                    row.CRT_DT_TM = DateTime.Now;
                    row.DEL_FLG = 0;

                    CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
                    if (chkAM != null && chkAM.Checked == false)
                    {
                        row.MORNING = "0";
                    }
                    else
                    {
                        row.MORNING = "1";
                    }
                    CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
                    if (chkPM != null && chkPM.Checked == false)
                    {
                        row.EVENING = "0";
                    }
                    else
                    {
                        row.EVENING = "1";
                    }
                    resultDt = attService.saveAttendanceRecord(row, out msg);
                    errSms.Text = msg;
                    //showAllButton();
                }
            }
            else
            {
                //showAllButton();
                errSms.Text = msg;
            }
        }

        private bool checkAldyRecord()
        {
            bool alreadyExist = false;
            for (int i = 0; i < gridViewAttendance.Rows.Count; i++)
            {
                DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable result = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
                DataSet.DsPSMS.ST_ATTENDANCE_DATARow drr = result.NewST_ATTENDANCE_DATARow();
                drr.STUDENT_ID = gridViewAttendance.Rows[i].Cells[0].Text;
                if (attendDate.Text.Trim().Length == 0)
                {
                    alreadyExist = true;
                    // errDate.Visible = true;
                    // errExist.Visible = false;
                }
                else
                {
                    drr.ATTENDANCE_DATE = attendDate.Text;
                    result = attService.getAttendanceByDate(drr);
                    if (result != null && result.Rows.Count > 0)
                    {
                        alreadyExist = true;
                        //  errDate.Visible = false;
                        //  errExist.Visible = true;
                    }
                    else
                    {
                        alreadyExist = false;
                    }
                }
            }
            return alreadyExist;
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < gridViewAttendance.Rows.Count; i++)
        //    {
        //        int resultDt = 0;
        //        DataSet.DsPSMS.ST_ATTENDANCE_DATARow row = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
        //        row.EDU_YEAR = eduYearGrade.Text;
        //        row.STUDENT_ID = gridViewAttendance.Rows[i].Cells[0].Text;
        //        row.ATTENDANCE_DATE = attendDate.Text;
        //        row.UPD_USER_ID = loginUserId;
        //        row.UPD_DT_TM = DateTime.Now;
        //        row.DEL_FLG = 0;

        //        CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
        //        if (chkAM != null && chkAM.Checked == false)
        //        {
        //            row.MORNING = "0";
        //        }
        //        else
        //        {
        //            row.MORNING = "1";
        //        }

        //        CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
        //        if (chkPM != null && chkPM.Checked == false)
        //        {
        //            row.EVENING = "0";
        //        }
        //        else
        //        {
        //            row.EVENING = "1";
        //        }
        //        resultDt = attService.updateAttendanceRecord(row, out msg);
        //        Label0.Text = "Update!";
        //        showAllButton();
        //    }
        //}

        protected void btnCheckAllAM_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewAttendance.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("AM");                
                if (chk != null && chk.Checked == false)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
            //showAllButton();
            //Label0.Text = "";
        }

        protected void btnCheckAllPM_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewAttendance.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("PM");
                if (chk != null && chk.Checked == false)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
            //showAllButton();
            //Label0.Text = "";
        }
    }
}