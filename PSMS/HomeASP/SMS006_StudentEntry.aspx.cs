using HomeASP.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeASP
{
    public partial class SMS006_StudentEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ddlgradeList.Items.Count == 0)
                {
                    bindGrade();
                }
                if (ddlroomList.Items.Count == 0)
                {
                    bindRoom();
                }
            }
            
                
        }
        public void bindGrade()
        {
            ddlgradeList.Items.Clear();
            StudentEntryService student = new StudentEntryService();

            DataTable dtGrade = student.selectGradeList();
            ddlgradeList.DataSource = dtGrade;
            ddlgradeList.DataTextField = "GRADE_NAME";
            ddlgradeList.DataValueField = "GRADE_ID";
            ddlgradeList.DataBind();
            ddlgradeList.Items.Insert(0, new ListItem("Choose Grade", "0"));
              
        }
        public void bindRoom()
        {
            ddlroomList.Items.Clear();
            StudentEntryService student = new StudentEntryService();
            DataTable dtRoom = student.selectRoomList();
            ddlroomList.DataSource = dtRoom;
            ddlroomList.DataTextField = "ROOM_NAME";
            ddlroomList.DataValueField = "ROOM_ID";
            ddlroomList.DataBind();
            ddlroomList.Items.Insert(0, new ListItem("Choose Room", "0"));
        }

        protected void btnSearchRes_Click(object sender, EventArgs e)
        {
            String eduYear = ddlresyearlist.SelectedItem.Value;
            String grade = ddlgradeList.SelectedItem.Value;
            String month = ddlresmonthlist.SelectedItem.Value;
            String room = ddlroomList.SelectedItem.Value;

            StudentEntryService student = new StudentEntryService();
            if (checkValidation())
            {

                DataTable dtStudentResult = student.selectStudentData(eduYear, grade, month, room);
                if (dtStudentResult != null)
                {
                    gvstdResult.DataSource = dtStudentResult;
                    gvstdResult.DataBind();
                }
                else
                {
                    lblmsg.Text = "Data doesn't exists!!";
                }


               
            }
             
        }
        protected bool checkValidation()
        {
            bool chkFlag = true;

            if (ddlresyearlist.SelectedIndex == 0)
            {
                errresuyear.Text = "Please choose year !";
                chkFlag = false;
            }
            else
            {
                errresuyear.Text = " ";
            }

            if (ddlresmonthlist.SelectedIndex == 0)
            {
                errresmonth.Text = "Please choose year !";
                chkFlag = false;
            }
            else
            {
                errresmonth.Text = " ";
            }

            if (ddlgradeList.SelectedIndex == 0)
            {
                errresgrade.Text = "Please choose grade !";
                chkFlag = false;
            }
            else
            {
                errresgrade.Text = " ";
            }

            if (ddlroomList.SelectedIndex == 0)
            {
                errresroom.Text = "Please choose room !";
                chkFlag = false;
            }
            else
            {
                errresroom.Text = " ";
            }

            return chkFlag;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StudentEntryService student = new StudentEntryService();

            DataTable dtSubject = student.selectSubjectByGradeId(ddlresyearlist.SelectedValue, ddlgradeList.SelectedValue);
            if (dtSubject != null)
            {
                String subject = dtSubject.Rows[0]["SUBJECT_ID_LIST"].ToString();

                string[] values = subject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();

                    String subID = values[i];
                    //student.saveSubjectMark(subID, txtSubject1.Text);
                    
                }
            }
        }
    }
}