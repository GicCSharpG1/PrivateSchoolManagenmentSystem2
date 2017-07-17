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
    public partial class SM_StudentTimeTabledisplay : System.Web.UI.Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
        private string msg = "";
        DataSet.DsPSMS.ST_TIMETABLE_HEDRow timetablehed = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable().NewST_TIMETABLE_HEDRow();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (ddlstugradelist.Items.Count == 0)
            {
                bindGrade();
            }

            if (ddlstuclasslist.Items.Count == 0)
            {
                bindClass();
            }

            gvStuTimetable.DataSource = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable();
            gvStuTimetable.DataBind();
            
        }

        public void bindGrade()
        {
            msg = "aaa";
            ddlstugradelist.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddlstugradelist.DataSource = grades;
            ddlstugradelist.DataTextField = "GRADE_NAME";
            ddlstugradelist.DataValueField = "GRADE_ID";
            ddlstugradelist.DataBind();
            ddlstugradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
        }

        public void bindClass()
        {
            msg = "aaa";
            ddlstuclasslist.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable rooms = timeService.getAllRoomData(out msg);
            ddlstuclasslist.DataSource = rooms;
            ddlstuclasslist.DataTextField = "ROOM_NAME";
            ddlstuclasslist.DataValueField = "ROOM_ID";
            ddlstuclasslist.DataBind();
            ddlstuclasslist.Items.Insert(0, new ListItem("Select Class", "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (checkValidation())
            {
                //errSelectGrade.Visible = false;
                //errSelectRoom.Visible = false;
                int gradeId = int.Parse(ddlstugradelist.SelectedItem.Value);
                int classId = int.Parse(ddlstuclasslist.SelectedItem.Value);

                timetablehed = timeService.searchTimeHedBygradeclassid(gradeId, classId);
                if (timetablehed != null)
                {
                    DataSet.DsPSMS.ST_TEACHER_DATARow teacher = timeService.getTeacherByid(int.Parse(timetablehed.ROOM_TEACHER_ID));
                    if (teacher != null)
                    {
                        Panelteacher.Visible = true;
                        lblroomteachname.Text = teacher.TEACHER_NAME;
                    }
                    DisplayTimetable(Convert.ToString(timetablehed.TIMETABLE_ID));
                }
                else
                {
                    Panelteacher.Visible = false;
                    gvStuTimetable.DataSource = new  DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable() ;
                    gvStuTimetable.DataBind();
                }
            }   
        }

        protected void DisplayTimetable(string timeHedId)
        {
            DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable resultDt = timeService.getAllTimeDetailData(timeHedId, out msg);

            if (resultDt != null)
            {
                gvStuTimetable.Visible = true;
                //lblNodata.Visible = false;
                foreach (DataSet.DsPSMS.ST_TIMETABLE_DETAILRow row in resultDt.Rows)
                {
                    int subjectId;
                    string subvalue = null;

                    if (row.MONDAY != null)
                    {
                        subjectId = int.Parse(row.MONDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.MONDAY = subvalue;
                    }

                    if (row.TUESDAY != null)
                    {
                        subjectId = int.Parse(row.TUESDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.TUESDAY = subvalue;
                    }

                    if (row.WEDNESDAY != null)
                    {
                        subjectId = int.Parse(row.WEDNESDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.WEDNESDAY = subvalue;
                    }

                    if (row.THURSDAY != null)
                    {
                        subjectId = int.Parse(row.THURSDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.THURSDAY = subvalue;
                    }

                    if (row.FRIDAY != null)
                    {
                        subjectId = int.Parse(row.FRIDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.FRIDAY = subvalue;
                    }
                }

                gvStuTimetable.DataSource = resultDt;
                gvStuTimetable.DataBind();
            }
            else
            {
                Panelteacher.Visible = false;
                gvStuTimetable.DataSource = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable();
                gvStuTimetable.DataBind();
            }
        }

        public bool checkValidation()
        {
            bool chkFlag = true;

            if (ddlstugradelist.SelectedIndex == 0)
            {
                errSelectGrade.Visible = true;
                chkFlag = false;
            }
            else
            {
                errSelectGrade.Visible = false;
            }

            if (ddlstuclasslist.SelectedIndex == 0)
            {
                errSelectRoom.Visible = true;
                chkFlag = false;
            }
            else
            {
                errSelectRoom.Visible = false;
            }

            return chkFlag;
        }
    }
}