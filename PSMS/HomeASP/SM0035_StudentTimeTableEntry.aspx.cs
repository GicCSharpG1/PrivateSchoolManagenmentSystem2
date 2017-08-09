using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace HomeASP
{
    public partial class SM_StudentTimeTableEntry : System.Web.UI.Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
        private string msg = "";
        string userId = "";
        
        static int updateTimeHedId;
        DataSet.DsPSMS.ST_TIMETABLE_HEDRow timetablehed = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable().NewST_TIMETABLE_HEDRow();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }

            if (ddlentrygradelist.Items.Count == 0)
            {
                bindGrade();
            }

            if (ddlentryclasslist.Items.Count == 0)
            {
                bindClass();
            }
            if (ddlentryteacherlist.Items.Count == 0)
            {
                bindRoomTeacher();
            }

                DisplayRoomTeacher();
        }

        public void bindGrade()
        {
            msg = "aaa";
            ddlentrygradelist.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddlentrygradelist.DataSource = grades;
            ddlentrygradelist.DataTextField = "GRADE_NAME";
            ddlentrygradelist.DataValueField = "GRADE_ID";
            ddlentrygradelist.DataBind();
            ddlentrygradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
        }

        public void bindClass()
        {
            msg = "aaa";
            ddlentryclasslist.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable rooms = timeService.getAllRoomData(out msg);
            ddlentryclasslist.DataSource = rooms;
            ddlentryclasslist.DataTextField = "ROOM_NAME";
            ddlentryclasslist.DataValueField = "ROOM_ID";
            ddlentryclasslist.DataBind();
            ddlentryclasslist.Items.Insert(0, new ListItem("Select Class", "0"));
        }

        public void bindRoomTeacher()
        {
            msg = "aaa";
            ddlentryteacherlist.Items.Clear();
            DataSet.DsPSMS.ST_TEACHER_DATADataTable teachers = timeService.getAllTeacherData(out msg);
            ddlentryteacherlist.DataSource = teachers;
            ddlentryteacherlist.DataTextField = "TEACHER_NAME";
            ddlentryteacherlist.DataValueField = "TEACHER_ID";
            ddlentryteacherlist.DataBind();
            ddlentryteacherlist.Items.Insert(0, new ListItem("Select Teacher", "0"));
        }

        public void DisplayRoomTeacher()
        {
            DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable resultDt = timeService.getAllTimetableHedData(out msg);

            if (resultDt != null)
            {
                foreach (DataSet.DsPSMS.ST_TIMETABLE_HEDRow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    int teacherId;
                    string teachervalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }

                    if (row.ROOM_TEACHER_ID != null)
                    {
                        teacherId = int.Parse(row.ROOM_TEACHER_ID);
                        DataSet.DsPSMS.ST_TEACHER_DATARow teacher = timeService.getTeacherByid(teacherId);
                        teachervalue = teacher.TEACHER_NAME;
                        row.ROOM_TEACHER_ID = teachervalue;
                    }

                    if (row.ROOM_ID != null)
                    {
                        int roomId = int.Parse(row.ROOM_ID);
                        DataSet.DsPSMS.ST_ROOM_MSTRow room = timeService.getClassByid(roomId);
                        string roomvalue = room.ROOM_NAME;
                        row.ROOM_ID = roomvalue;
                    }
                }
                gvRoomTeacher.DataSource = resultDt;
                gvRoomTeacher.DataBind();
            }
            else
            {
                gvRoomTeacher.DataSource = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable();
                gvRoomTeacher.DataBind();
            }
        }

        protected void btnRoomteaSave_Click(object sender, EventArgs e)
        {
            bool  isOK = true;
            if (checkValidation())
            {
                if (btnRoomteaSave.Text.Equals("Save"))
                {
                    timetablehed.EDU_YEAR = ddleduyearlist.SelectedItem.Value;
                    timetablehed.GRADE_ID = ddlentrygradelist.SelectedItem.Value;
                    timetablehed.ROOM_ID = ddlentryclasslist.SelectedItem.Value;
                    timetablehed.ROOM_TEACHER_ID = ddlentryteacherlist.SelectedItem.Value;
                    timetablehed.CRT_DT_TM = DateTime.Now;
                    timetablehed.CRT_USER_ID = this.userId;
                    timetablehed.DEL_FLG = 0;
                    if (checkAldyRecord(timetablehed))
                    {
                        errmsgexist.Visible = true;
                        errmsgeduyear.Visible = false;
                        isOK = false;
                    }
                    else
                    {
                        errmsgexist.Visible = false;
                        isOK = timeService.saveTimetableHedData(timetablehed, out msg);
                    }
                    
                }
                else if (btnRoomteaSave.Text.Equals("Edit"))
                {
                    timetablehed.EDU_YEAR = ddleduyearlist.SelectedItem.Value;
                    timetablehed.GRADE_ID = ddlentrygradelist.SelectedItem.Value;
                    timetablehed.ROOM_ID = ddlentryclasslist.SelectedItem.Value;
                    timetablehed.ROOM_TEACHER_ID = ddlentryteacherlist.SelectedItem.Value;
                    timetablehed.UPD_DT_TM = DateTime.Now;
                    timetablehed.UPD_USER_ID = this.userId;
                    isOK = timeService.updateTimeTableHed(timetablehed, updateTimeHedId, out msg);
                }

                if (isOK)
                {
                    DisplayRoomTeacher();
                    resetForm();
                }
            }
            
        }

        protected void resetForm()
        {
            errmsgeduyear.Visible = false;
            ddleduyearlist.SelectedIndex = 0;
            ddlentrygradelist.SelectedIndex = 0;
            ddlentryclasslist.SelectedIndex = 0;
            ddlentryteacherlist.SelectedIndex = 0;
            btnRoomteaSave.Text = "Save";
            errmsgclasslist.Visible = false;
            errmsggradelist.Visible = false;
            errmsgteaacherlist.Visible = false;
            errmsgexist.Visible = false;
        }

        protected void btnRoomTeaUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string timetablrHedId = btn.CommandName;
            if (timetablrHedId != null)
            {
                updateTimeHedId = int.Parse(timetablrHedId);
                DataSet.DsPSMS.ST_TIMETABLE_HEDRow timetableHed = timeService.getTimetableHedByid(updateTimeHedId);
                ddleduyearlist.SelectedIndex = ddleduyearlist.Items.IndexOf(ddleduyearlist.Items.FindByValue(timetableHed.EDU_YEAR));
                ddlentrygradelist.SelectedIndex = ddlentrygradelist.Items.IndexOf(ddlentrygradelist.Items.FindByValue(timetableHed.GRADE_ID));
                ddlentryteacherlist.SelectedIndex = ddlentryteacherlist.Items.IndexOf(ddlentryteacherlist.Items.FindByValue(timetableHed.ROOM_TEACHER_ID));
                ddlentryclasslist.SelectedIndex = ddlentryclasslist.Items.IndexOf(ddlentryclasslist.Items.FindByValue(timetableHed.ROOM_ID));
                btnRoomteaSave.Text = "Edit";
            }
        }

        protected void btnroomteaCancel_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        protected void btnRoomTeaNext_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string timetablrHedId = btn.CommandName;
            if (timetablrHedId != null)
            {
                Session["TimetableHedId"] = timetablrHedId;
                Response.Redirect("SM0035_StudentTimeTableEntry_2.aspx");
            }
        }

        public bool checkValidation()
        {
            bool chkFlag = true;

            if (ddleduyearlist.SelectedIndex == 0 || ddlentrygradelist.SelectedIndex == 0 || ddlentryclasslist.SelectedIndex == 0 || ddlentryteacherlist.SelectedIndex == 0)
            {
                errmsgeduyear.Visible = true;
                chkFlag = false;
            }
            else
            {
                errmsggradelist.Visible = false;
            }

         
            return chkFlag;
        }

        private bool checkAldyRecord(DataSet.DsPSMS.ST_TIMETABLE_HEDRow drr)
        {
            bool alreadyExist = false;
            for (int i = 0; i < gvRoomTeacher.Rows.Count; i++)
            {
                DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable result = timeService.isExistTimeHed(drr);
                if (result != null && result.Rows.Count > 0)
                {
                    alreadyExist = true;
                }
                else
                {
                    alreadyExist = false;
                }
            }
            return alreadyExist;
        }

        protected void gvRoomTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomTeacher.PageIndex = e.NewPageIndex;
            gvRoomTeacher.DataBind();
        }

        protected void gvRoomTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}