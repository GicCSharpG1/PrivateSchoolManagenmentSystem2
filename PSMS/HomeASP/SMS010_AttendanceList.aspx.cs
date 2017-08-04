﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS010 : System.Web.UI.Page
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
            lblDay.Visible = false;
            lbMon.Visible = false;
            dpDay.Visible = false;
            ddlMonth.Visible = false;
        }

        //public void bindStudentRoom()
        //{
        //    ddlClass.Items.Clear();
        //    DataSet.DsPSMS.ST_ROOM_MSTDataTable stuRoom = smSer.getAllRoomMST();
        //    ddlClass.DataSource = stuRoom;
        //    ddlClass.DataTextField = "ROOM_NAME";
        //    ddlClass.DataValueField = "ROOM_ID";
        //    ddlClass.DataBind();
        //}

        //protected void getGrade()
        //{
        //    ddlGrade.Items.Clear();
        //    DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeResult = gradeService.getAllGradeData(out msg);
        //    if (gradeResult != null)
        //    {
        //        ddlGrade.DataSource = gradeResult.OrderBy(item => item.GRADE_ID);
        //        ddlGrade.DataTextField = "GRADE_NAME";
        //        ddlGrade.DataValueField = "GRADE_ID";
        //        ddlGrade.DataBind();
        //        ddlGrade.Items.Insert(0, "Select Grade");
        //    }
        //}

        //protected void getDay()
        //{
        //    ddlDay.Items.Clear();
        //    for (int i = 1; i <= 31; i++)
        //    {
        //        if (i < 10)
        //        {
        //            ddlDay.Items.Add("0" + i);
        //        }
        //        else
        //        {
        //            ddlDay.Items.Add("" + i);
        //        }
        //    }
        //    ddlDay.Items.Insert(0, "Select Day");
        //}

        protected void setDayByMonthYear()
        {
            //if (ddlMonth.SelectedIndex != 0)
            //{
            //    int month = Convert.ToInt16(ddlMonth.Text);
            //    if (month == 2)
            //    {
            //        ddlDay.Items.Remove("30");
            //        ddlDay.Items.Remove("31");
            //        if (ddlYear.SelectedIndex != 0)
            //        {
            //            int year = Convert.ToInt16(ddlYear.Text);
            //            bool isLeapYear = ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0));
            //            if (!isLeapYear)
            //            {
            //                ddlDay.Items.Remove("29");
            //            }
            //        }
            //    }
            //    if (month == 4 || month == 6 || month == 9 || month == 11)
            //    {
            //        ddlDay.Items.Remove("31");
            //    }
            //}
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
            //if (ddlDay.SelectedIndex > 0 || ddlMonth.SelectedIndex > 0 || ddlYear.SelectedIndex > 0 || ddlGrade.SelectedIndex > 0 || ddlClass.SelectedIndex > 0 || txtName.Text.Trim().Length != 0 || eduYearGrade.SelectedIndex > 0)
            //{
            //    studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            //    stdResult = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            //    attRow = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
            //    attResult = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();

            //    if (ddlGrade.SelectedIndex > 0)
            //        studentRow.GRADE_ID = int.Parse(ddlGrade.Text);
            //    if(eduYearGrade.SelectedIndex > 0)
            //        studentRow.EDU_YEAR = eduYearGrade.Text;
            //    if(ddlClass.SelectedIndex > 0)
            //        studentRow.ROOM_ID = ddlClass.Text;
            //    if(txtName.Text.Trim().Length != 0)
            //        studentRow.STUDENT_NAME = txtName.Text;
            //    stdResult = stuentry.getDataOption(studentRow);

            //    if (ddlDay.SelectedIndex != 0)
            //    {
            //        attRow.ATTENDANCE_DATE = ddlDay.Text + "/";
            //    }
            //    else
            //    {
            //        attRow.ATTENDANCE_DATE = "00/";
            //    }

            //    if (ddlMonth.SelectedIndex != 0)
            //    {
            //        attRow.ATTENDANCE_DATE += ddlMonth.Text + "/";
            //    }
            //    else
            //    {
            //        attRow.ATTENDANCE_DATE += "00/";
            //    }

            //    if (ddlYear.SelectedIndex != 0)
            //    {
            //        attRow.ATTENDANCE_DATE += ddlYear.Text;
            //    }
            //    else
            //    {
            //        attRow.ATTENDANCE_DATE += "0000";
            //    }

            //    if (stdResult.Count > 0)
            //    {
            //        if (stdResult.Count == 1)
            //        {
            //            attRow.STUDENT_ID = stdResult.Rows[0]["STUDENT_ID"].ToString();
            //        }
            //        else
            //        {
            //            attRow.STUDENT_ID = "";
            //            for (int i = 0; i < stdResult.Count; i++)
            //            {
            //                attRow.STUDENT_ID += stdResult.Rows[i]["STUDENT_ID"] + ",";
            //            }
            //            attRow.STUDENT_ID = attRow.STUDENT_ID.Substring(0, attRow.STUDENT_ID.Length - 1);
            //        }
            //        attResult = attService.selectAttendanceList(attRow);

            //        if (attResult.Count == 0)
            //        {
            //            ModelState.AddModelError(string.Empty, "Data does not exist!");
            //        }
            //        //Label aaa = new Label();
            //        //TemplateField tfObject = new TemplateField();
            //        //tfObject.HeaderText = "Header Text";
            //        //tfObject.HeaderStyle.Width = Unit.Percentage(30);
            //        //tfObject.ItemTemplate = aaa;
            //        //gvAttendanceList.Columns.Add(tfObject);

            //        attResultList = attResult;
            //        gvAttendanceList.DataSource = attResult;
            //        gvAttendanceList.DataBind();
            //    }
            //}
            //else
            //    errSer.Text = "Please Fill you want to search !!";
        }

      

      
        protected void btnClear_Click(object sender, EventArgs e)
        {
            //ddlDay.SelectedIndex = -1;
            //ddlMonth.SelectedIndex = -1;
            //ddlYear.SelectedIndex = -1;

            //studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            //stdResult = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            //studentRow.GRADE_ID =int.Parse(ddlGrade.Text);
            //studentRow.EDU_YEAR = eduYearGrade.Text;
            //studentRow.ROOM_ID = ddlClass.Text;
            //studentRow.STUDENT_NAME = txtName.Text;
            //stdResult = stuentry.getDataOption(studentRow);

            //attRow = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
            //attResult = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();

            //if (ddlDay.SelectedIndex != 0)
            //{
            //    attRow.ATTENDANCE_DATE = ddlDay.Text + "/";
            //}
            //else
            //{
            //    attRow.ATTENDANCE_DATE = "00/";
            //}

            //if (ddlMonth.SelectedIndex != 0)
            //{
            //    attRow.ATTENDANCE_DATE += ddlMonth.Text + "/";
            //}
            //else
            //{
            //    attRow.ATTENDANCE_DATE += "00/";
            //}

            //if (ddlYear.SelectedIndex != 0)
            //{
            //    attRow.ATTENDANCE_DATE += ddlYear.Text;
            //}
            //else
            //{
            //    attRow.ATTENDANCE_DATE += "0000";
            //}

            //if (stdResult.Count > 0)
            //{
            //    if (stdResult.Count == 1)
            //    {
            //        attRow.STUDENT_ID = stdResult.Rows[0]["STUDENT_ID"].ToString();
            //    }
            //    else
            //    {
            //        attRow.STUDENT_ID = "";
            //        for (int i = 0; i < stdResult.Count; i++)
            //        {
            //            attRow.STUDENT_ID += stdResult.Rows[i]["STUDENT_ID"] + ",";
            //        }
            //        attRow.STUDENT_ID = attRow.STUDENT_ID.Substring(0, attRow.STUDENT_ID.Length - 1);
            //    }
            //    attResult = attService.selectAttendanceList(attRow);

            //    if (attResult.Count == 0)
            //    {
            //        ModelState.AddModelError(string.Empty, "Data does not exist!");
            //    }
            //    //Label aaa = new Label();
            //    //TemplateField tfObject = new TemplateField();
            //    //tfObject.HeaderText = "Header Text";
            //    //tfObject.HeaderStyle.Width = Unit.Percentage(30);
            //    //tfObject.ItemTemplate = aaa;
            //    //gvAttendanceList.Columns.Add(tfObject);

            //    attResultList = attResult;
            //    gvAttendanceList.DataSource = attResult;
            //    gvAttendanceList.DataBind();
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

        }
    }
}