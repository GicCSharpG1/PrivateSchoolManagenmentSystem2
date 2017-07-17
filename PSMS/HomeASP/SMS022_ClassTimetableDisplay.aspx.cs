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
    public partial class SMS022 : System.Web.UI.Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();

        private string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (ddlteacherlist.Items.Count == 0)
            {
                bindTeacher();
            }

            if (gvresultlist.Rows.Count == 0)
            {
                gvresultlist.DataSource = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
                gvresultlist.DataBind();
            }
        }

        public void bindTeacher()
        {
            msg = "aaa";
            ddlteacherlist.Items.Clear();
            DataSet.DsPSMS.ST_TEACHER_DATADataTable grades = timeService.getAllTeacherData(out msg);
            ddlteacherlist.DataSource = grades;
            ddlteacherlist.DataTextField = "TEACHER_NAME";
            ddlteacherlist.DataValueField = "TEACHER_ID";
            ddlteacherlist.DataBind();
            ddlteacherlist.Items.Insert(0, new ListItem("Select Teacher", "0"));
        }

        protected void btnteacher_Click(object sender, EventArgs e)
        {
            int selvalue = int.Parse(ddlteacherlist.SelectedItem.Value);
            if (txtdate.Text.Equals("") && selvalue == 0)
            {
                errTeacherSearch.Visible = true;
            }
            else
            {
                errTeacherSearch.Visible = false;
                if (!txtdate.Text.Equals("") && selvalue > 0)
                {
                    string date = txtdate.Text;
                    int teacherId = int.Parse(ddlteacherlist.SelectedItem.Value);
                    DisplayDatabydatenid(teacherId, date);
                }
                else if (txtdate.Text.Equals("") && selvalue > 0)
                {
                    int teacherId = int.Parse(ddlteacherlist.SelectedItem.Value);
                    DisplayDatabyid(teacherId);
                }
                else if (!txtdate.Text.Equals("") && selvalue == 0)
                {
                    string date = txtdate.Text;
                    DisplayDatabydate(date);
                }
            }
        }

        private void DisplayDatabydatenid(int id,string date)
        {
            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt= timeService.getTimetableByidanddate(id, date);
            BindSearchResult(resultDt);
        }

        private void DisplayDatabyid(int id)
        {
            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt = timeService.getTimetableByteacherid(id);
            BindSearchResult(resultDt);
        }

        private void DisplayDatabydate(string date)
        {
            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt = timeService.getTimetableBydate(date);
            BindSearchResult(resultDt);
        }

        private void BindSearchResult(DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt)
        {
            if (resultDt != null)
            {
                foreach (DataSet.DsPSMS.ST_TIMETABLERow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }
                }

                gvresultlist.DataSource = resultDt;
                gvresultlist.DataBind();
            }

        }
     }    
}