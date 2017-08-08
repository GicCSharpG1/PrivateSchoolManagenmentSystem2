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
    public partial class SMS021 :Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
        DataSet.DsPSMS.ST_TIMETABLERow timetable = new DataSet.DsPSMS.ST_TIMETABLEDataTable().NewST_TIMETABLERow();
        DataSet.DsPSMS.ST_TEACHER_GRADERow teachergrade = new DataSet.DsPSMS.ST_TEACHER_GRADEDataTable().NewST_TEACHER_GRADERow();
        string userId = "";
        private string msg = "";
        static int delFlag = 0;
        static int updateId;
        bool errFlag = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }

            if (ddltimegradelist.Items.Count == 0)
            {
                bindGrade();
                ddltimegradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
            }
            if (ddlTeacherList.Items.Count == 0)
            {
                bindTeacher();
                ddlTeacherList.Items.Insert(0, new ListItem("Select Teacher", "0"));
            }
            if (ddlsubjectlist.Items.Count == 0)
            {
                ddlsubjectlist.Items.Insert(0, new ListItem("Select Subject", "0"));
            }
            if (dvtimetable.Rows.Count == 0)
            {
                DisplayData();
            }            
        }

        protected void ValidatePeriod(object source, System.Web.UI.WebControls.ServerValidateEventArgs args) {
            if (ddlclass1.SelectedIndex != 0 || ddlclass2.SelectedIndex != 0 || ddlclass3.SelectedIndex != 0 || ddlclass4.SelectedIndex != 0 || ddlclass5.SelectedIndex != 0 || ddlclass6.SelectedIndex != 0 || ddlclass7.SelectedIndex != 0)
            {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
                errFlag = true;
            }
        }

        public void bindGrade()
        {
            msg = "aaa";
            ddltimegradelist.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddltimegradelist.DataSource = grades;
            ddltimegradelist.DataTextField = "GRADE_NAME";
            ddltimegradelist.DataValueField = "GRADE_ID";
            ddltimegradelist.DataBind();
        }

        public void bindTeacher()
        {
            msg = "aaa";
            ddlTeacherList.Items.Clear();
            DataSet.DsPSMS.ST_TEACHER_DATADataTable grades = timeService.getAllTeacherData(out msg);
            ddlTeacherList.DataSource = grades;
            ddlTeacherList.DataTextField = "TEACHER_NAME";
            ddlTeacherList.DataValueField = "TEACHER_ID";
            ddlTeacherList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            msg = "";
            if (checkValidation() && errFlag != true)
            {
                timetable.EDU_YEAR = ddleduyearlist.SelectedItem.Value;
                timetable.GRADE_ID = ddltimegradelist.SelectedItem.Value;
                timetable.TEACHER_ID = ddlTeacherList.SelectedItem.Value;
                timetable.DAY = txttimetabledate.Text;
                timetable.PERIOD1 = checkselectIndex(ddlclass1.SelectedIndex, ddlclass1.SelectedItem.Value);
                timetable.PERIOD2 = checkselectIndex(ddlclass2.SelectedIndex, ddlclass2.SelectedItem.Value);
                timetable.PERIOD3 = checkselectIndex(ddlclass3.SelectedIndex, ddlclass3.SelectedItem.Value);
                timetable.PERIOD4 = checkselectIndex(ddlclass4.SelectedIndex, ddlclass4.SelectedItem.Value);
                timetable.PERIOD5 = checkselectIndex(ddlclass5.SelectedIndex, ddlclass5.SelectedItem.Value);
                timetable.PERIOD6 = checkselectIndex(ddlclass6.SelectedIndex, ddlclass6.SelectedItem.Value);
                timetable.PERIOD7 = checkselectIndex(ddlclass7.SelectedIndex, ddlclass7.SelectedItem.Value);
                timetable.CRT_DT_TM = DateTime.Now;
                timetable.CRT_USER_ID = this.userId;
                timetable.DEL_FLG = 0;

                teachergrade.EDU_YEAR = ddleduyearlist.SelectedItem.Value;
                teachergrade.TEACH_GRADE = ddltimegradelist.SelectedItem.Value;
                teachergrade.TEACH_SUBJECT = ddlsubjectlist.SelectedItem.Value;
                teachergrade.TEACHER_ID = ddlTeacherList.SelectedItem.Value;
                teachergrade.DEL_FLG = 0;
                teachergrade.CRT_DT_TM = DateTime.Now;
                teachergrade.CRT_USER_ID = this.userId;
                bool isOk = timeService.saveTeacherGrade(teachergrade, out msg);
                if (isOk)
                {
                    bool isComplete = timeService.saveTimeTable(timetable, out msg);
                    DisplayData();
                    resetForm();
                }
            }
        }

        protected string checkselectIndex(int selectIndex,string value)
        {
            string selectValue;

            if (selectIndex == 0)
            {
                selectValue = "-";
            }
            else
            {
                selectValue = value;
            }
            return selectValue;
        }

        private bool checkValidation()
        {
            bool isErr = true;
            if (ddltimegradelist.SelectedIndex == 0)
            {
               // validatorgrade.Visible = true;
                isErr = false;
            }
            else
            {
              //  validatorgrade.Visible = false;
                isErr = true;
            }
            if (ddlTeacherList.SelectedIndex == 0)
            {
              //  validatorteacher.Visible = true;
                isErr = false;
            }
            else
            {
              //  validatorteacher.Visible = false;
                isErr = true;
            }
            return isErr;
        }

        private void DisplayData()
        {
            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt = timeService.getAllTimeTableData(out msg);
            if (resultDt != null)
            {
                foreach (DataSet.DsPSMS.ST_TIMETABLERow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    int teacherId;
                    string teachervalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME.ToString();
                        row.GRADE_ID = gradevalue;
                    }

                    if (row.TEACHER_ID != null)
                    {
                        teacherId = int.Parse(row.TEACHER_ID);
                        DataSet.DsPSMS.ST_TEACHER_DATARow teacher = timeService.getTeacherByid(teacherId);
                        teachervalue = teacher.TEACHER_NAME;
                        row.TEACHER_ID = teachervalue;
                    }
                }
                dvtimetable.DataSource = resultDt;
                dvtimetable.DataBind();
            }
            else
            {
                dvtimetable.DataSource = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
                dvtimetable.DataBind();
            }
        }

        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(dvtimetable.DataKeys[e.RowIndex].Value.ToString());
            bool isOk = timeService.deleteTimeTable(id,out msg);
            DisplayData();
        }

        protected int checkClassIndex(String strClass)
        {
            int resIndex;
            if (strClass.Equals("Class A"))
            {
                resIndex = 1;
            }
            else if (strClass.Equals("Class B"))
            {
                resIndex = 2;
            }
            else if (strClass.Equals("Class C"))
            {
                resIndex = 3;
            }
            else if (strClass.Equals("Class D"))
            {
                resIndex = 4;
            }
            else if (strClass.Equals("Class E"))
            {
                resIndex = 5;
            }
            else
            {
                resIndex = 0;
            }
            return resIndex;
        }

        protected void resetForm()
        {
            txttimetabledate.Text = "";
            ddltimegradelist.SelectedIndex = 0;
            ddlTeacherList.SelectedIndex = 0;
            ddlsubjectlist.SelectedIndex = 0;
            ddleduyearlist.SelectedIndex = 0;
            ddlclass1.SelectedIndex = 0;
            ddlclass2.SelectedIndex = 0;
            ddlclass3.SelectedIndex = 0;
            ddlclass4.SelectedIndex = 0;
            ddlclass5.SelectedIndex = 0;
            ddlclass6.SelectedIndex = 0;
            ddlclass7.SelectedIndex = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            resetForm();
            DisplayData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             msg = "";
             if (checkValidation() && errFlag != true)
             {
                 timetable.EDU_YEAR = ddleduyearlist.SelectedItem.Value;
                 timetable.GRADE_ID = ddltimegradelist.SelectedItem.Value;
                 timetable.TEACHER_ID = ddlTeacherList.SelectedItem.Value;
                 timetable.DAY = txttimetabledate.Text;
                 timetable.PERIOD1 = checkselectIndex(ddlclass1.SelectedIndex, ddlclass1.SelectedItem.Value);
                 timetable.PERIOD2 = checkselectIndex(ddlclass2.SelectedIndex, ddlclass2.SelectedItem.Value); 
                 timetable.PERIOD3 = checkselectIndex(ddlclass3.SelectedIndex, ddlclass3.SelectedItem.Value); 
                 timetable.PERIOD4 = checkselectIndex(ddlclass4.SelectedIndex, ddlclass4.SelectedItem.Value); 
                 timetable.PERIOD5 = checkselectIndex(ddlclass5.SelectedIndex, ddlclass5.SelectedItem.Value); 
                 timetable.PERIOD6 = checkselectIndex(ddlclass6.SelectedIndex, ddlclass6.SelectedItem.Value); 
                 timetable.PERIOD7 = checkselectIndex(ddlclass7.SelectedIndex, ddlclass7.SelectedItem.Value);
                 timetable.UPD_DT_TM = DateTime.Now;
                 timetable.UPD_USER_ID = this.userId;
                 timetable.DEL_FLG = delFlag;
                 bool isOk = timeService.updateTimeTable(timetable, updateId, out msg);
                 DisplayData();
                 resetForm();
             }
        }

        protected void Edit(object sender, GridViewSelectEventArgs e)
        {
            updateId = int.Parse(dvtimetable.DataKeys[e.NewSelectedIndex].Value.ToString());
            DataSet.DsPSMS.ST_TIMETABLERow timetable = timeService.getTimeTableByid(updateId);

            if (timetable != null)
            {
                delFlag = (int)timetable.DEL_FLG;
                txttimetabledate.Text = timetable.DAY;
                ddltimegradelist.SelectedIndex = int.Parse(timetable.GRADE_ID);
                bindSubjectByGrade(int.Parse(timetable.GRADE_ID));
                ddlTeacherList.SelectedIndex = int.Parse(timetable.TEACHER_ID);
                ddlclass1.SelectedIndex = checkClassIndex(timetable.PERIOD1);
                ddlclass2.SelectedIndex = checkClassIndex(timetable.PERIOD2);
                ddlclass3.SelectedIndex = checkClassIndex(timetable.PERIOD3);
                ddlclass4.SelectedIndex = checkClassIndex(timetable.PERIOD4);
                ddlclass5.SelectedIndex = checkClassIndex(timetable.PERIOD5);
                ddlclass6.SelectedIndex = checkClassIndex(timetable.PERIOD6);
                ddlclass7.SelectedIndex = checkClassIndex(timetable.PERIOD7);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }  
        }

        protected void dvtimetable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvtimetable.PageIndex = e.NewPageIndex;
            DisplayData();
            dvtimetable.DataBind();
        }

        protected void ddltimegradelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gradeId =int.Parse(ddltimegradelist.SelectedItem.Value);
            bindSubjectByGrade(gradeId);
        }

        protected void bindSubjectByGrade(int gradeId)
        {
            string subList = "";
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow gradeSubject = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            gradeSubject = timeService.getGradeSubjectBygradeid(gradeId);
            if (gradeSubject != null)
            {
                subList = gradeSubject.SUBJECT_ID_LIST.ToString();
                DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjects = timeService.getAllSubjectName(subList, out msg);
                ddlsubjectlist.DataSource = subjects;
                ddlsubjectlist.DataTextField = "SUBJECT_NAME";
                ddlsubjectlist.DataValueField = "SUBJECT_ID";
                ddlsubjectlist.DataBind();
                ddlsubjectlist.Items.Insert(0, new ListItem("Select Subject", "0"));
                ddlsubjectlist.Enabled = true;
            }
        }

        protected void ddlclass5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}