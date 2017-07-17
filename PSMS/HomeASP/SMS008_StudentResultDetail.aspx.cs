using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using HomeASP.Service;
using System.Data;

namespace HomeASP
{
    public partial class SMS008 : System.Web.UI.Page
    {
        static string studentId;
        static string month;
        string msg = "";
        ExamResultEntryService resultService = new ExamResultEntryService();
        TimeTableEntryService timeService = new TimeTableEntryService();
        ExamResultService examService = new ExamResultService();
        DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow exMark;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["STUDENT_ID"] != null)
            {
                studentId = (string)(Session["STUDENT_ID"] ?? " ");
            }

            if (Session["EXAM_MONTH"] != null)
            {
                month = (string)(Session["EXAM_MONTH"] ?? " ");
            }
            showResultDetail(studentId,month);
            
        }

        protected void showResultDetail(string stuId,string month)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow student = resultService.getStudentById(stuId,out msg);

            if(student != null)
            {
                lblresultyear.Text = student.EDU_YEAR;
                lblresultmonth.Text = month;
                lblresultName.Text = student.STUDENT_NAME;
                lblresultroll.Text = student.ROLL_NO;

                if (student.GRADE_ID != null)
                {
                    int gradeId = student.GRADE_ID;
                    DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                    lblresultgrade.Text = grade.GRADE_NAME;
                }

                if (student.ROOM_ID != null)
                {
                    int roomId = int.Parse(student.ROOM_ID);
                    DataSet.DsPSMS.ST_ROOM_MSTRow room = timeService.getClassByid(roomId);
                    string roomvalue = room.ROOM_NAME;
                    lblresultclass.Text = roomvalue;
                }
                
                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow result = resultService.getResultByHed(stuId, month, out msg);

                DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = resultService.getSubList(student.GRADE_ID, out msg);

                string subjects = subList.SUBJECT_ID_LIST.ToString();
                DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subject = timeService.getAllSubjectName(subjects, out msg);
          
                int totalMark = 0;
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    TableRow tRow = new TableRow();
                    tblShowResult.Rows.Add(tRow);

                    TableCell subCell = new TableCell();
                    tRow.Cells.Add(subCell);
                    Label lblsub = new Label();
                    lblsub.Text = subject.Rows[j]["SUBJECT_NAME"].ToString();
                    lblsub.CssClass = "label";
                    subCell.Controls.Add(lblsub);

                    string subjectId = subject.Rows[j]["SUBJECT_ID"].ToString();
                    exMark = examService.getMarkBysubresult(result.RESULT_ID, subjectId);

                    TableCell markCell = new TableCell();
                    tRow.Cells.Add(markCell);
                    Label lblmark = new Label();
                    lblmark.Text = Convert.ToString(exMark.MARK);
                    lblmark.CssClass = checkMarkPassOrFail(exMark.MARK);
                    markCell.Controls.Add(lblmark);

                   
                    TableCell gradeCell = new TableCell();
                    tRow.Cells.Add(gradeCell);
                    Label lblGrade = new Label();
                    lblGrade.Text = calculateResultGrade(exMark);
                    lblGrade.CssClass = checkMarkPassOrFail(exMark.MARK);
                    gradeCell.Controls.Add(lblGrade);

                    totalMark += exMark.MARK;
                }

                bindTotlaMark(totalMark);
            }
        }

        protected string calculateResultGrade(DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow exMark)
        {
            string markGrade;
            if (exMark.MARK <= 100 && exMark.MARK >= 80)
            {
                markGrade = "  " + "A";
            }
            else if (exMark.MARK < 80 && exMark.MARK >= 60)
            {
                markGrade = "  " + "B";
            }
            else if (exMark.MARK < 60 && exMark.MARK >= 40)
            {
                markGrade = "  " + "C";
            }
            else if (exMark.MARK < 40 && exMark.MARK >= 20)
            {
                markGrade = "  " + "D";
            }
            else
            {
                markGrade = "  " + "E";
            }

            return markGrade;
        }

        protected string calculateTotalGrade(int totalMark)
        {
            string totalGrade;
            if (totalMark<= 600 && totalMark>= 500)
            {
                totalGrade = "  " + "A";
            }
            else if (totalMark < 500 && totalMark >= 400)
            {
                totalGrade = "  " + "B";
            }
            else if (totalMark< 400 && totalMark >= 300)
            {
                totalGrade = "  " + "C";
            }
            else if (totalMark < 300 && totalMark >= 200)
            {
                totalGrade = "  " + "D";
            }
            else
            {
                totalGrade = "  " + "E";
            }

            return totalGrade;
        }

        private void bindTotlaMark(int totalMark)
        {
            TableRow totalRow = new TableRow();
            tblShowResult.Rows.Add(totalRow);

            TableCell totalMarkCell = new TableCell();
            totalRow.Cells.Add(totalMarkCell);
            Label lbltotalmark = new Label();
            lbltotalmark.CssClass = "label";
            lbltotalmark.Text = "Total Mark ";
            totalMarkCell.Controls.Add(lbltotalmark);

            TableCell tgradeCell = new TableCell();
            totalRow.Cells.Add(tgradeCell);
            Label lbltgrade = new Label();
            lbltgrade.Text = Convert.ToString(totalMark);
            lbltgrade.CssClass = checkTotalPassOrFail(totalMark);
            tgradeCell.Controls.Add(lbltgrade);

            TableCell totalCell = new TableCell();
            totalRow.Cells.Add(totalCell);
            Label lbltmark = new Label(); 
            lbltmark.Text = calculateTotalGrade(totalMark);
            lbltmark.CssClass = checkTotalPassOrFail(totalMark);
            totalCell.Controls.Add(lbltmark);
        }

        private string checkTotalPassOrFail(int mark)
        {
            string strStyle;

            if(mark < 300)
            {
                strStyle = "failmark";
            }
            else
            {
                strStyle = "label";
            }

            return strStyle;
        }

        private string checkMarkPassOrFail(int mark)
        {
            string strStyle;

            if (mark < 40)
            {
                strStyle = "failmark";
            }
            else
            {
                strStyle = "label";
            }

            return strStyle;
        }

        protected void btnBackList_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS007_StudentResultList.aspx");
        }
    } 
}

