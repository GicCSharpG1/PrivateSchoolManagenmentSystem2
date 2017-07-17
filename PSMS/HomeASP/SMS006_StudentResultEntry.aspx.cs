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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace HomeASP
{
    public partial class SMS006 : System.Web.UI.Page
    {
        string msg = "";
        static string loginUserId = "";
        string stuId = "";
        static int indexLoop = 0;
        static string month = "";
        static DataTable dsHed = new DataTable();
        ExamResultEntryService resultService = new ExamResultEntryService();
        TimeTableEntryService timeService = new TimeTableEntryService();
        DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow examRow = new DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();
        OleDbConnection oledbConn;

        static DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subject = new DsPSMS.ST_SUBJECT_MSTDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            if (ddlgradeList.Items.Count == 0)
            {
                bindGrade();
            }

            if (ddlroomList.Items.Count == 0)
            {
                bindClass();
            }
        }

        public void bindGrade()
        {
            msg = "aaa";
            ddlgradeList.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddlgradeList.DataSource = grades;
            ddlgradeList.DataTextField = "GRADE_NAME";
            ddlgradeList.DataValueField = "GRADE_ID";
            ddlgradeList.DataBind();
            ddlgradeList.Items.Insert(0, new ListItem("Choose Grade", "0"));
        }

        public void bindClass()
        {
            msg = "aaa";
            ddlroomList.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable rooms = timeService.getAllRoomData(out msg);
            ddlroomList.DataSource = rooms;
            ddlroomList.DataTextField = "ROOM_NAME";
            ddlroomList.DataValueField = "ROOM_ID";
            ddlroomList.DataBind();
            ddlroomList.Items.Insert(0, new ListItem("Choose Room", "0"));
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow student = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (checkValidation())
            {
                student.EDU_YEAR = ddlresyearlist.SelectedItem.Value;
                month = ddlresmonthlist.SelectedItem.Value;
                student.GRADE_ID = int.Parse(ddlgradeList.SelectedItem.Value);
                student.ROOM_ID = ddlroomList.SelectedItem.Value;
                DataSet.DsPSMS.ST_STUDENT_DATADataTable stuTable = resultService.getStudentDataBystuObj(student, out msg);
                bool expOk = ExportToExcel(stuTable,student);
                if (expOk)
                {
                    lblmsg.Text = "xcel create successful ! To open file ,click 'Open File' button";
                    btnViewExcel.Enabled = true;
                    btnMarkSave.Enabled = true;
                    btnSave.Enabled = false;
                    
                    msgSuccess.Visible = false;
                    ddlgradeList.SelectedIndex = 0;
                    ddlresmonthlist.SelectedIndex = 0;
                    ddlresyearlist.SelectedIndex = 0;
                    ddlroomList.SelectedIndex = 0;
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

        public void bindStuGridView(DataSet.DsPSMS.ST_STUDENT_DATARow stuDr)
        {
            
            DataSet.DsPSMS.ST_STUDENT_DATADataTable student = new DsPSMS.ST_STUDENT_DATADataTable();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();

            // bind student data to gridview
            student = resultService.getStudentDataBystuObj(stuDr, out msg);

            if (student != null && student.Count > 0)
            {
                btnMarkSave.Visible = true;
                gvstdResult.DataSource = student;
                gvstdResult.DataBind();

                // getting subject's Id list
                subList = resultService.getSubList(stuDr.GRADE_ID, out msg);

                // get the subject name from subject Id list
                string subjects = subList.SUBJECT_ID_LIST.ToString();
                subject = timeService.getAllSubjectName(subjects, out msg);

                // Add column of subject_name
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    this.gvstdResult.Columns[j + 3].HeaderText = subject.Rows[j]["SUBJECT_NAME"].ToString();
                    gvstdResult.DataBind();
                }

                for (int rowIndex = 0; rowIndex < student.Count; rowIndex++)
                {
                    int index = subject.Count + 1;
                    for (int colIndex = subject.Count + 3; colIndex < 9; colIndex++)
                    {
                        TextBox tb1 = new TextBox();
                        tb1 = (TextBox)(gvstdResult.Rows[rowIndex].FindControl("txtsubject" + index));
                        tb1.Enabled = false;
                        index++;
                    }
                }
                gvstdResult.Columns[9].Visible = false;
            }
            else
            {
                gvstdResult.DataSource = student;
                gvstdResult.DataBind();
            }  
        }

        protected void BtnMarkSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = System.IO.Path.GetFullPath(Server.MapPath("~/Exportfiles/StudentExamResult.xlsx"));
                if (Path.GetExtension(path) == ".xls")
                {
                    oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                }
                else if (Path.GetExtension(path) == ".xlsx")
                {
                    oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                }
                oledbConn.Open();
                OleDbCommand cmd = new OleDbCommand(); ;
                OleDbDataAdapter oleda = new OleDbDataAdapter();                
                DataTable dsDetail = new DataTable();
                cmd.Connection = oledbConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [STUDENT_ID], [STUDENT_NAME], [ROLL_NO]";
                for (int i = 0; i < subject.Count; i++)
                {
                    cmd.CommandText += ",";
                    cmd.CommandText += " [" + subject[i].SUBJECT_NAME + "] ";
                }
                cmd.CommandText += "FROM [Sheet1$]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(dsHed);
                for (int i = 0; i < subject.Count; i++)
                {
                    oleda.Fill(dsDetail);
                }                

                dsHed.Columns.Add(new DataColumn("EDU_YEAR", typeof(String)));
                dsHed.Columns.Add(new DataColumn("EXAM_MONTH", typeof(String)));
                dsHed.Columns.Add(new DataColumn("CRT_DT_TM", typeof(String)));
                dsHed.Columns.Add(new DataColumn("CRT_USER_ID", typeof(String)));
                dsHed.Columns.Add(new DataColumn("DEL_FLG", typeof(String)));
                for (int i = 0; i < dsHed.Rows.Count; i++)
                {
                    dsHed.Rows[i]["EDU_YEAR"] = ddlresyearlist.SelectedItem.Value;
                    dsHed.Rows[i]["EXAM_MONTH"] = ddlresmonthlist.SelectedItem.Value;
                    dsHed.Rows[i]["CRT_DT_TM"] = DateTime.Now;
                    dsHed.Rows[i]["CRT_USER_ID"] = loginUserId;
                    dsHed.Rows[i]["DEL_FLG"] = 0;
                }

                dbAccess dbAccess = new dbAccess();
                dbAccess.Open();
                SqlBulkCopy objbulk = new SqlBulkCopy(dbAccess.conn);
                objbulk.DestinationTableName = "ST_STUDENT_EXAM_HED";
                objbulk.ColumnMappings.Add("EDU_YEAR", "EDU_YEAR");
                objbulk.ColumnMappings.Add("STUDENT_ID", "STUDENT_ID");
                objbulk.ColumnMappings.Add("EXAM_MONTH", "EXAM_MONTH");
                objbulk.ColumnMappings.Add("CRT_DT_TM", "CRT_DT_TM");
                objbulk.ColumnMappings.Add("CRT_USER_ID", "CRT_USER_ID");
                objbulk.ColumnMappings.Add("DEL_FLG", "DEL_FLG");
                objbulk.WriteToServer(dsHed);
                
                dsDetail.Columns.Add(new DataColumn("EDU_YEAR", typeof(String)));
                dsDetail.Columns.Add(new DataColumn("RESULT_ID", typeof(String)));
                dsDetail.Columns.Add(new DataColumn("SUBJECT_ID", typeof(String)));
                dsDetail.Columns.Add(new DataColumn("MARK", typeof(String)));
                dsDetail.Columns.Add(new DataColumn("CRT_DT_TM", typeof(String)));
                dsDetail.Columns.Add(new DataColumn("CRT_USER_ID", typeof(String)));
                dsDetail.Columns.Add(new DataColumn("DEL_FLG", typeof(String)));

                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow exhed = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();
                int rowCount = 0;
                for (int i = 0; i < dsHed.Rows.Count; i++)
                {
                    exhed = resultService.getStdResult(dsHed.Rows[i]["STUDENT_ID"].ToString(), out msg);
                    for (int j = 0; j < subject.Rows.Count; j++)
                    {
                        dsDetail.Rows[rowCount]["EDU_YEAR"] = exhed.EDU_YEAR;
                        dsDetail.Rows[rowCount]["RESULT_ID"] = exhed.RESULT_ID;
                        dsDetail.Rows[rowCount]["CRT_DT_TM"] = DateTime.Now;
                        dsDetail.Rows[rowCount]["CRT_USER_ID"] = loginUserId;
                        dsDetail.Rows[rowCount]["DEL_FLG"] = 0;
                        if (subject.Rows[j]["SUBJECT_NAME"].Equals(dsHed.Columns[j + 3].ColumnName))
                        {
                            dsDetail.Rows[rowCount]["SUBJECT_ID"] = subject.Rows[j]["SUBJECT_ID"].ToString();
                            dsDetail.Rows[rowCount]["MARK"] = dsHed.Rows[i][j + 3].ToString();
                        }
                        rowCount++;
                    }
                }
                objbulk = new SqlBulkCopy(dbAccess.conn);
                objbulk.DestinationTableName = "ST_STUDENT_EXAM_DETAIL";
                objbulk.ColumnMappings.Add("EDU_YEAR", "EDU_YEAR");
                objbulk.ColumnMappings.Add("RESULT_ID", "RESULT_ID");
                objbulk.ColumnMappings.Add("SUBJECT_ID", "SUBJECT_ID");
                objbulk.ColumnMappings.Add("MARK", "MARK");
                objbulk.ColumnMappings.Add("CRT_DT_TM", "CRT_DT_TM");
                objbulk.ColumnMappings.Add("CRT_USER_ID", "CRT_USER_ID");
                objbulk.ColumnMappings.Add("DEL_FLG", "DEL_FLG");
                objbulk.WriteToServer(dsDetail);

                dsHed.Columns.Remove("EDU_YEAR");
                dsHed.Columns.Remove("EXAM_MONTH");
                dsHed.Columns.Remove("CRT_DT_TM");
                dsHed.Columns.Remove("CRT_USER_ID");
                dsHed.Columns.Remove("DEL_FLG");
                gvstdResult.DataSource = dsHed;
                gvstdResult.DataBind();
                dbAccess.Close();
            }
            catch
            {

            }
            finally
            {
                oledbConn.Close();
                resetForm();
            }
        }

        private void resetForm()
        {
            errresuyear.Text = " ";
            errresmonth.Text = " ";
            errresgrade.Text = " ";
            errresroom.Text = " ";

            ddlgradeList.SelectedIndex = 0;
            ddlresmonthlist.SelectedIndex = 0;
            ddlresyearlist.SelectedIndex = 0;
            ddlroomList.SelectedIndex = 0;
            msgSuccess.Visible = false;
            lblmsg.Text = " ";
            btnViewExcel.Enabled = false;
            btnMarkSave.Enabled = false;
            btnSave.Enabled = false;
        }

        protected void gvstdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvstdResult.PageIndex = e.NewPageIndex;
            gvstdResult.DataSource = dsHed;
            gvstdResult.DataBind();
        }
        
        private bool checkExistStudentResult(string eduYear,string month)
        {
            bool isResult = false;
            DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow stuExamHed = new DsPSMS.ST_STUDENT_EXAM_HEDDataTable().NewST_STUDENT_EXAM_HEDRow();

            if (eduYear != null && month != null)
            {
                stuExamHed.EDU_YEAR = eduYear;
                stuExamHed.EXAM_MONTH = month;
                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable ExamHed = resultService.getChkExamResultByHed(stuExamHed,out msg);
                if (ExamHed != null && ExamHed.Count > 0)
                {
                    isResult = true;
                }
                else
                {
                    isResult = false;
                }
            }
            return isResult;
        }

        private void showExitResultData(DataSet.DsPSMS.ST_STUDENT_EXAM_HEDDataTable ExamHed)
        {
            List<DataSet.DsPSMS.ST_STUDENT_DATARow> studentList = new List<DsPSMS.ST_STUDENT_DATARow>();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow examDetail = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            foreach (DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow rowHed in ExamHed.Rows)
            {
                DataSet.DsPSMS.ST_STUDENT_DATARow resStudent = resultService.getStudentById(rowHed.STUDENT_ID,out msg);
                if (resStudent!= null)
                {
                    studentList.Add(resStudent);
                }

                // getting subject's Id list
                subList = resultService.getSubList(resStudent.GRADE_ID, out msg);

                // get the subject name from subject Id list
                string subjects = subList.SUBJECT_ID_LIST.ToString();
                subject = timeService.getAllSubjectName(subjects, out msg);

                // Add column of subject_name
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    this.gvstdResult.Columns[j + 3].HeaderText = subject.Rows[j]["SUBJECT_NAME"].ToString();                 
                }   
            }

            gvstdResult.DataSource = studentList;
            gvstdResult.DataBind();

            for (int rowIndex = 0; rowIndex < studentList.Count; rowIndex++)
            {
                int index = subject.Count + 1;
                for (int colIndex = subject.Count + 3; colIndex < 9; colIndex++)
                {
                    TextBox tb1 = new TextBox();
                    tb1 = (TextBox)(gvstdResult.Rows[rowIndex].FindControl("txtsubject" + index));
                    tb1.Enabled = false;
                    index++;
                }
            }

            
            foreach (DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow rowHed in ExamHed.Rows)
            {
                int txtIndex = 1;
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    string subjectId = subject.Rows[j]["SUBJECT_ID"].ToString();
                    examDetail = resultService.getExamDetailkBysubresult(rowHed.RESULT_ID, int.Parse(subjectId));
                    
                    TextBox tb1 = new TextBox();
                    tb1 = (TextBox)(gvstdResult.Rows[indexLoop].FindControl("txtsubject" + txtIndex));
                    tb1.Text = Convert.ToString(examDetail.MARK);
                    txtIndex++;
                }
                indexLoop++;
            }
        }

        protected void btnResultUpdate_Click(object sender, EventArgs e)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow editStudent = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            DataSet.DsPSMS.ST_STUDENT_EXAM_DETAILRow examDetail = new DsPSMS.ST_STUDENT_EXAM_DETAILDataTable().NewST_STUDENT_EXAM_DETAILRow();
            LinkButton btn = (LinkButton)(sender);
            string studentId = btn.CommandName;

            if (studentId != null)
            {
                editStudent = resultService.getStudentById(studentId,out msg);
                subList = resultService.getSubList(editStudent.GRADE_ID, out msg);

                // get the subject name from subject Id list
                string subjects = subList.SUBJECT_ID_LIST.ToString();
                subject = timeService.getAllSubjectName(subjects, out msg);

                DataSet.DsPSMS.ST_STUDENT_EXAM_HEDRow ExamHed = resultService.getResultByHed(studentId,month,out msg);
                foreach (GridViewRow row in gvstdResult.Rows)
                {
                    int txtIndex = 1;
                    for (int j = 0; j < subject.Rows.Count; j++)
                    {
                        examDetail.RESULT_ID = ExamHed.RESULT_ID;
                        examDetail.SUBJECT_ID = subject.Rows[j]["SUBJECT_ID"].ToString();
                        examDetail.UPD_DT_TM = DateTime.Now;
                        examDetail.UPD_USER_ID = loginUserId;
                        TextBox tb1 = new TextBox();
                        tb1 = (TextBox)(gvstdResult.Rows[row.RowIndex].FindControl("txtsubject" + txtIndex));
                        examDetail.MARK = int.Parse(tb1.Text);
                        txtIndex++;

                        bool isEdit = resultService.updateStuExamDetail(examDetail,out msg);
                        if (isEdit)
                        {
                            lblmsg.Text = "Update Successfully Complete" + editStudent.STUDENT_NAME;
                        }
                        else
                        {
                            lblmsg.Text = "Not Complete Update Data" + editStudent.STUDENT_NAME;
                        }
                    }
                }
            }
        }

        protected bool ExportToExcel(DataSet.DsPSMS.ST_STUDENT_DATADataTable dt, DataSet.DsPSMS.ST_STUDENT_DATARow studr)
        {
            bool isOk = false;
            try
            {
                DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
                string path = Server.MapPath("Exportfiles\\");

                if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                {
                    Directory.CreateDirectory(path);
                }

                File.Delete(path + "StudentExamResult.xlsx"); // DELETE THE FILE BEFORE CREATING A NEW ONE.
                // ADD A WORKBOOK USING THE EXCEL APPLICATION.
                Excel.Application xlAppToExport = new Excel.Application();
                xlAppToExport.Workbooks.Add("");

                // ADD A WORKSHEET.
                Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
                xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

                // ROW ID FROM WHERE THE DATA STARTS SHOWING.
                int iRowCnt = 2;

                // SHOW THE HEADER.
                //xlWorkSheetToExport.Cells[1, 1] = "Student Exam Result Entry";

                Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Bold = true;
                range.EntireRow.Font.Size = 20;
                //xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;// MERGE CELLS OF THE HEADER.

                // SHOW COLUMNS ON THE TOP.
                xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "STUDENT_ID";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "STUDENT_NAME";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "ROLL_NO";

                // getting subject's Id list
                subList = resultService.getSubList(studr.GRADE_ID, out msg);

                // get the subject name from subject Id list
                string subjects = subList.SUBJECT_ID_LIST.ToString();
                subject = timeService.getAllSubjectName(subjects, out msg);

                // Add column of subject_name
                for (int j = 0; j < subject.Rows.Count; j++)
                {
                    xlWorkSheetToExport.Cells[iRowCnt - 1, j + 4] = subject.Rows[j]["SUBJECT_NAME"].ToString();
                }


                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    xlWorkSheetToExport.Cells[iRowCnt, 1].NumberFormat = "@";
                    xlWorkSheetToExport.Cells[iRowCnt, 1] = dt.Rows[i]["STUDENT_ID"].ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 2] = dt.Rows[i]["STUDENT_NAME"].ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 3] = dt.Rows[i]["ROLL_NO"].ToString();
                    iRowCnt = iRowCnt + 1;
                }

                // FINALLY, FORMAT THE EXCEL SHEET USING EXCEL'S AUTOFORMAT FUNCTION.
                Excel.Range range1 = xlAppToExport.ActiveCell.Worksheet.Cells[4, 1] as Excel.Range;
                range1.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

                // SAVE THE FILE IN A FOLDER.
                xlWorkSheetToExport.SaveAs(path + "StudentExamResult.xlsx");

                // CLEAR.
                xlAppToExport.Workbooks.Close();
                xlAppToExport.Quit();
                xlAppToExport = null;
                xlWorkSheetToExport = null;
                errData.Visible = false;
                msgSuccess.Visible = true;
                isOk = true;
            }
            catch
            {
                errData.Visible = true;
                msgSuccess.Visible = false;
            }

            return isOk;
        }

        // VIEW THE EXPORTED EXCEL DATA.
      protected void btnViewExcel_Click(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            string path = Server.MapPath("Exportfiles\\");
            try
            {
                // CHECK IF THE FOLDER EXISTS.
                if (Directory.Exists(path))
                {
                    // CHECK IF THE FILE EXISTS.
                    if (File.Exists(path + "StudentExamResult.xlsx"))
                    {
                        // SHOW (NOT DOWNLOAD) THE EXCEL FILE.
                        Excel.Application xlAppToView = new Excel.Application();
                        xlAppToView.Workbooks.Open(path + "StudentExamResult.xlsx");
                        xlAppToView.Visible = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                //
            }
        }

      protected void btnSearchRes_Click(object sender, EventArgs e)
      {
          DataSet.DsPSMS.ST_STUDENT_DATARow student = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
          if (checkValidation())
          {
              string eduyr = ddlresyearlist.SelectedItem.Value;
              month = ddlresmonthlist.SelectedItem.Value;
              bool chkExist = checkExistStudentResult(eduyr,month);

              if (chkExist)
              {
                  lblmsg.Text = "This data source is already exist !";
              }
              else
              {
                  btnSave.Enabled = true;
                  lblmsg.Text = "To export excel file ,please click 'Export File' button !";
              }
          }
      }
    }
}