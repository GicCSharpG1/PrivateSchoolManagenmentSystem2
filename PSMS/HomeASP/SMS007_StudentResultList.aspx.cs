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
    public partial class SMS007 : System.Web.UI.Page
    {
        string msg = "";
        static string loginUserId = "";
        string stuId = "";
        static int indexLoop = 0;
        static string month = "";
        ExamResultService service = new ExamResultService();
        TimeTableEntryService timeService = new TimeTableEntryService();
        ExamResultEntryService resultService = new ExamResultEntryService();
        static DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subject = new DsPSMS.ST_SUBJECT_MSTDataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            if (ddlresultgrade.Items.Count == 0)
            {
                bindGrade();
            }

            if (ddlresultroom.Items.Count == 0)
            {
                bindClass();
            }
        }

        protected void BtnSearch_Click(object a, EventArgs b)
        {
            if (checkValidation())
            {
                //DataTable resultTemp = createCustomDataSet(gradeId, roomId);
                //stdResultGiv.DataSource = resultTemp;
                //stdResultGiv.DataBind();
                DataSet.DsPSMS.ST_STUDENT_DATARow studentRw = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
                studentRw.EDU_YEAR = ddlYearList.SelectedItem.Value;
                month = ddlMonthList.SelectedItem.Value;
                studentRw.GRADE_ID = int.Parse(ddlresultgrade.SelectedItem.Value);
                studentRw.ROOM_ID = ddlresultroom.SelectedItem.Value;
                bindStuGridView(studentRw);

                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow stuExamHed = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();
                stuExamHed.EDU_YEAR = ddlYearList.SelectedItem.Value;
                stuExamHed.EXAM_MONTH = month;
                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable ExamHed = resultService.getChkExamResultByHed(stuExamHed, out msg);
                txtSubMarkDataBind(ExamHed);

                ddlMonthList.SelectedIndex = 0;
                ddlresultgrade.SelectedIndex = 0;
                ddlresultroom.SelectedIndex = 0;
                ddlYearList.SelectedIndex = 0;
            }
        }

        protected string getStuResultMark(string stuId, string subjectId)
        {
            string mark;
            month = ddlMonthList.SelectedItem.Value;
            DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow result = service.getStdResult(stuId, month, out msg);
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow detail = service.getMarkBysubresult(result.RESULT_ID, subjectId);
            mark = Convert.ToString(detail.MARK);
            return mark;
        }

        public void bindGrade()
        {
            msg = "aaa";
            ddlresultgrade.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddlresultgrade.DataSource = grades;
            ddlresultgrade.DataTextField = "GRADE_NAME";
            ddlresultgrade.DataValueField = "GRADE_ID";
            ddlresultgrade.DataBind();
            ddlresultgrade.Items.Insert(0, new ListItem("Select Grade", "0"));
        }

        public void bindClass()
        {
            msg = "aaa";
            ddlresultroom.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable rooms = timeService.getAllRoomData(out msg);
            ddlresultroom.DataSource = rooms;
            ddlresultroom.DataTextField = "ROOM_NAME";
            ddlresultroom.DataValueField = "ROOM_ID";
            ddlresultroom.DataBind();
            ddlresultroom.Items.Insert(0, new ListItem("Select Class", "0"));
        }

        protected void stdResultGiv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            stdResultGiv.PageIndex = e.NewPageIndex;
            string gradeId = ddlresultgrade.SelectedItem.Value;
            string roomId = ddlresultroom.SelectedItem.Value;
            DataTable resultTemp = createCustomDataSet(gradeId, roomId);
            stdResultGiv.DataSource = resultTemp;
            stdResultGiv.DataBind();
        }

        protected bool checkValidation()
        {
            bool chkFlag = true;

            if (ddlYearList.SelectedIndex == 0)
            {
                errresultyr.Text = "Please choose year !";
                chkFlag = false;
            }
            else
            {
                errresultyr.Text = " ";
            }

            if (ddlMonthList.SelectedIndex == 0)
            {
                errresultmonth.Text = "Please choose year !";
                chkFlag = false;
            }
            else
            {
                errresultmonth.Text = " ";
            }

            if (ddlresultgrade.SelectedIndex == 0)
            {
                errresultgrade.Text = "Please choose grade !";
                chkFlag = false;
            }
            else
            {
                errresultgrade.Text = " ";
            }

            if (ddlresultroom.SelectedIndex == 0)
            {
                errresultroom.Text = "Please choose room !";
                chkFlag = false;
            }
            else
            {
                errresultroom.Text = " ";
            }

            return chkFlag;
        }

        private DataTable createCustomDataSet(string gradeId, string roomId)
        {
            DataColumn resColumn;
            DataRow resRow;

            DataTable resTable = new DataTable();

            //Add Fix column
            resColumn = new DataColumn("ID", Type.GetType("System.String"));
            resTable.Columns.Add(resColumn);

            resColumn = new DataColumn("Name", Type.GetType("System.String"));
            resTable.Columns.Add(resColumn);

            resColumn = new DataColumn("Roll_No", Type.GetType("System.String"));
            resTable.Columns.Add(resColumn);

            DataSet.DsPSMS.ST_STUDENT_DATADataTable student = service.getStdName(gradeId, roomId, out msg);

            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = service.getSubList(gradeId, out msg);

            //IdList=1,2,3...(cut by index)
            string subjects = subList.SUBJECT_ID_LIST.ToString();

            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subject = timeService.getAllSubjectName(subjects, out msg);

            //Add column of subject_name
            for (int j = 0; j < subject.Rows.Count; j++)
            {
                DataColumn subColumn = new DataColumn();
                subColumn.ColumnName = subject.Rows[j]["SUBJECT_NAME"].ToString();
                subColumn.DataType = Type.GetType("System.String");
                resTable.Columns.Add(subColumn); 
            }

            //Add mark value in subject_name column
            
            for (int k = 0; k < student.Rows.Count; k++) // loop for row 
            {

                resRow = resTable.NewRow();
                resRow["ID"] = student.Rows[k]["STUDENT_ID"].ToString();
                resRow["Name"] = student.Rows[k]["STUDENT_NAME"].ToString();
                resRow["Roll No"] = student.Rows[k]["ROLL_NO"].ToString();

                for (int j = 0; j < subject.Rows.Count; j++) // loop for column = Cell
                {
                    string subjectName = subject.Rows[j]["SUBJECT_NAME"].ToString();
                    string subjectId = subject.Rows[j]["SUBJECT_ID"].ToString();
                    string stuId = student.Rows[k]["STUDENT_ID"].ToString();
                    string submark = getStuResultMark(stuId, subjectId);
                    if (!submark.Equals(" "))
                    {
                        resRow[subjectName] = submark;
                    }                    
                }
                resTable.Rows.Add(resRow);
            }

            return resTable;
        }

        protected void btnResultUpdate_Click(object sender, EventArgs e)
        {
            
            bool isEdit = false;
            DataSet.DsPSMS.ST_STUDENT_DATARow editStudent = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow examDetail = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            LinkButton btn = (LinkButton)(sender);
            string studentId = btn.CommandName;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;

            if (studentId != null)
            {
                editStudent = resultService.getStudentById(studentId, out msg);
                subList = resultService.getSubList(editStudent.GRADE_ID, out msg);

                // get the subject name from subject Id list
                string subjects = subList.SUBJECT_ID_LIST.ToString();
                subject = timeService.getAllSubjectName(subjects, out msg);

                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow ExamHed = resultService.getResultByHed(studentId, month, out msg);
                
                
                int txtIndex = 1;
                
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    examDetail.RESULT_ID = ExamHed.RESULT_ID;
                    examDetail.SUBJECT_ID = subject.Rows[j]["SUBJECT_ID"].ToString();
                    examDetail.UPD_DT_TM = DateTime.Now;
                    examDetail.UPD_USER_ID = loginUserId;
                    TextBox tb1 = new TextBox();
                    tb1 = (TextBox)(stdResultGiv.Rows[gvRow.RowIndex].FindControl("txtsubject" + txtIndex));
                    examDetail.MARK = int.Parse(tb1.Text);
                    txtIndex++;

                    isEdit = resultService.updateStuExamDetail(examDetail, out msg);

                }

               
                

                if (isEdit)
                {
                    lblmsg.Text = "Update Successfully Complete " + editStudent.STUDENT_NAME;
                }
                else
                {
                    lblmsg.Text = "Not Complete Update Data " + editStudent.STUDENT_NAME;
                }
            }
        }

        public void bindStuGridView(DataSet.DsPSMS.ST_STUDENT_DATARow stuDr)
        {

            DataSet.DsPSMS.ST_STUDENT_DATADataTable student = new DsPSMS.ST_STUDENT_DATADataTable();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();

            // bind student data to gridview
            student = resultService.getStudentDataBystuObj(stuDr, out msg);

            if (student != null && student.Count > 0)
            {
                stdResultGiv.DataSource = student;
                stdResultGiv.DataBind();

                // getting subject's Id list
                subList = resultService.getSubList(stuDr.GRADE_ID, out msg);

                // get the subject name from subject Id list
                string subjects = subList.SUBJECT_ID_LIST.ToString();
                subject = timeService.getAllSubjectName(subjects, out msg);

                // Add column of subject_name
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    this.stdResultGiv.Columns[j + 3].HeaderText = subject.Rows[j]["SUBJECT_NAME"].ToString();
                    stdResultGiv.DataBind();
                }

                for (int rowIndex = 0; rowIndex < student.Count; rowIndex++)
                {
                    int index = subject.Count + 1;
                    for (int colIndex = subject.Count + 3; colIndex < 9; colIndex++)
                    {
                        TextBox tb1 = new TextBox();
                        tb1 = (TextBox)(stdResultGiv.Rows[rowIndex].FindControl("txtsubject" + index));
                        tb1.Enabled = false;
                        index++;
                    }
                }
                
                //stdResultGiv.Columns[9].Visible = false;
            }
            else
            {
                stdResultGiv.DataSource = student;
                stdResultGiv.DataBind();
            }
        }

        protected void btnResultDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string studentId = btn.CommandName;

            Session["STUDENT_ID"] = studentId;
            Session["EXAM_MONTH"] = month;
            Response.Redirect("SMS008_StudentResultDetail.aspx");
        }

        protected void txtSubMarkDataBind(DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable ExamHed)
        {
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow examDetail = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            foreach (DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow rowHed in ExamHed.Rows)
            {
                int txtIndex = 1;
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    string subjectId = subject.Rows[j]["SUBJECT_ID"].ToString();
                    examDetail = resultService.getExamDetailkBysubresult(rowHed.RESULT_ID, int.Parse(subjectId));

                    TextBox tb1 = new TextBox();
                    tb1 = (TextBox)(stdResultGiv.Rows[indexLoop].FindControl("txtsubject" + txtIndex));
                    tb1.Text = Convert.ToString(examDetail.MARK);
                    txtIndex++;
                }
                indexLoop++;
            }
        }
    }
}