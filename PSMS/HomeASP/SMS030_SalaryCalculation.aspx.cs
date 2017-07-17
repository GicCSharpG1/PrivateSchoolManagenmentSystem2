using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Data;
using HomeASP.DbAccess;
using Excel = Microsoft.Office.Interop.Excel;

namespace HomeASP
{
    public partial class SMS030 : System.Web.UI.Page
    {
        SalaryCalculationService salarySerivce = new SalaryCalculationService();
        
        private string msg = "";
        static int reFlag = 0;
        string userId = "";
        OleDbConnection oledbConn;
        static DataTable ds = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            displayGridData(0);
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow subList = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            string path = Server.MapPath("Exportfiles\\");

            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            File.Delete(path + "Salary.xlsx"); // DELETE THE FILE BEFORE CREATING A NEW ONE.
            // ADD A WORKBOOK USING THE EXCEL APPLICATION.
            Excel.Application xlAppToExport = new Excel.Application();
            xlAppToExport.Workbooks.Add("");

            // ADD A WORKSHEET.
            Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
            xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

            // ROW ID FROM WHERE THE DATA STARTS SHOWING.
            int iRowCnt = 2;

            Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
            range.EntireRow.Font.Name = "Calibri";
            range.EntireRow.Font.Bold = true;
            range.EntireRow.Font.Size = 20;
            //xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;// MERGE CELLS OF THE HEADER.

            // SHOW COLUMNS ON THE TOP.
            xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "ID";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "NAME";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "SALARY";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "LEAVE DAYS";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "LEAVE AMOUNT";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 6] = "LATE TIMES";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 7] = "LATE AMOUNT";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 8] = "OT AMOUNT";


            if (reFlag == 0)
            {
                DataSet.DsPSMS.ST_STAFF_DATADataTable teachers = salarySerivce.getStaffData(1,out msg);
                dt = teachers;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    xlWorkSheetToExport.Cells[iRowCnt, 1] = dt.Rows[i]["TEACHER_ID"].ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 2] = dt.Rows[i]["TEACHER_NAME"].ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 3] = dt.Rows[i]["SALARY"].ToString();
                    iRowCnt = iRowCnt + 1;
                }
                
            }
            else
            {
                DataSet.DsPSMS.ST_STAFF_DATADataTable staffs = salarySerivce.getStaffData(2,out msg);
                dt = staffs;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    xlWorkSheetToExport.Cells[iRowCnt, 1] = dt.Rows[i]["STAFF_ID"].ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 2] = dt.Rows[i]["STAFF_NAME"].ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 3] = dt.Rows[i]["SALARY"].ToString();
                    iRowCnt = iRowCnt + 1;
                }
            }
            // FINALLY, FORMAT THE EXCEL SHEET USING EXCEL'S AUTOFORMAT FUNCTION.
            Excel.Range range1 = xlAppToExport.ActiveCell.Worksheet.Cells[4, 1] as Excel.Range;
            range1.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatList2);

            // SAVE THE FILE IN A FOLDER.
            xlWorkSheetToExport.SaveAs(path + "Salary.xlsx");

            // CLEAR.
            xlAppToExport.Workbooks.Close();
            xlAppToExport.Quit();
            xlAppToExport = null;
            xlWorkSheetToExport = null;
            lblsalarybtnclick.Text = "Excel create successful ! To open file ,click 'Open File' button";
            btnViewExcel.Enabled = true;
            btnMarkSave.Enabled = true;
        }

        // VIEW THE EXPORTED EXCEL DATA.
        protected void btnViewExcel_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("Exportfiles\\");
            try
            {
                // CHECK IF THE FOLDER EXISTS.
                if (Directory.Exists(path))
                {
                    // CHECK IF THE FILE EXISTS.
                    if (File.Exists(path + "Salary.xlsx"))
                    {
                        // SHOW (NOT DOWNLOAD) THE EXCEL FILE.
                        Excel.Application xlAppToView = new Excel.Application();
                        xlAppToView.Workbooks.Open(path + "Salary.xlsx");
                        xlAppToView.Visible = true;
                    }
                }
            }
            catch
            {
                //
            }
        }

        protected void BtnSalarySave_Click(object sender, EventArgs e)
        {
            try
                {
                    string path = System.IO.Path.GetFullPath(Server.MapPath("~/Exportfiles/Salary.xlsx"));

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
                    cmd.Connection = oledbConn;
                    cmd.CommandType = CommandType.Text;                

                    cmd.CommandText = "SELECT [ID], [NAME], [SALARY], [LEAVE DAYS], [LEAVE AMOUNT], [LATE TIMES], [LATE AMOUNT], [OT AMOUNT] FROM [Sheet1$]";
                    oleda = new OleDbDataAdapter(cmd);
                    oleda.Fill(ds);

                    ds.Columns.Add(new DataColumn("EDU_YEAR", typeof(String)));
                    ds.Columns.Add(new DataColumn("YEAR", typeof(String)));
                    ds.Columns.Add(new DataColumn("MONTH", typeof(String)));
                    ds.Columns.Add(new DataColumn("STAFF_ID", typeof(String)));
                    ds.Columns.Add(new DataColumn("SALARY_AMOUNT", typeof(String)));
                    ds.Columns.Add(new DataColumn("REMARK", typeof(String)));
                    ds.Columns.Add(new DataColumn("CRT_DT_TM", typeof(String)));
                    ds.Columns.Add(new DataColumn("CRT_USER_ID", typeof(String)));
                    ds.Columns.Add(new DataColumn("DEL_FLG", typeof(String)));
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        ds.Rows[i]["EDU_YEAR"] = ddleduyearlist.SelectedItem.Value;
                        ds.Rows[i]["YEAR"] = DateTime.Now.Year;
                        ds.Rows[i]["MONTH"] = ddlmonthList.SelectedItem.Value;
                        ds.Rows[i]["STAFF_ID"] = ds.Rows[i]["ID"].ToString();

                        DataSet.DsPSMS.ST_SALARYRow salary = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();
                        salary.LEAVE_TIMES = Convert.ToInt32(ds.Rows[i]["LEAVE DAYS"]);
                        salary.LEAVE_AMOUNT = Convert.ToInt32(ds.Rows[i]["LEAVE AMOUNT"]);
                        salary.LATE_TIMES = Convert.ToInt32(ds.Rows[i]["LATE TIMES"]);
                        salary.LATE_AMOUNT = Convert.ToInt32(ds.Rows[i]["LATE AMOUNT"]);
                        salary.OT_AMOUNT = Convert.ToInt32(ds.Rows[i]["OT AMOUNT"]);
                        string salaryAMT = ds.Rows[i]["SALARY"].ToString();
                        ds.Rows[i]["SALARY_AMOUNT"] = calculateSalary(salary, salaryAMT);

                        ds.Rows[i]["REMARK"] = reFlag;
                        ds.Rows[i]["CRT_DT_TM"] = DateTime.Now;
                        ds.Rows[i]["CRT_USER_ID"] = userId;
                        ds.Rows[i]["DEL_FLG"] = 0;
                    }

                    dbAccess dbAccess = new dbAccess();  
                    dbAccess.Open();
                    SqlBulkCopy objbulk = new SqlBulkCopy(dbAccess.conn);
                    objbulk.DestinationTableName = "ST_SALARY";
                    //Mapping Table column    
                    objbulk.ColumnMappings.Add("EDU_YEAR", "EDU_YEAR");                    
                    objbulk.ColumnMappings.Add("YEAR", "YEAR");
                    objbulk.ColumnMappings.Add("MONTH", "MONTH");
                    objbulk.ColumnMappings.Add("STAFF_ID", "STAFF_ID");
                    objbulk.ColumnMappings.Add("LEAVE DAYS", "LEAVE_TIMES");
                    objbulk.ColumnMappings.Add("LEAVE AMOUNT", "LEAVE_AMOUNT");
                    objbulk.ColumnMappings.Add("LATE TIMES", "LATE_TIMES");
                    objbulk.ColumnMappings.Add("LATE AMOUNT", "LATE_AMOUNT");
                    objbulk.ColumnMappings.Add("OT AMOUNT", "OT_AMOUNT");
                    objbulk.ColumnMappings.Add("SALARY_AMOUNT", "SALARY_AMOUNT");
                    objbulk.ColumnMappings.Add("REMARK", "REMARK");
                    objbulk.ColumnMappings.Add("CRT_DT_TM", "CRT_DT_TM");
                    objbulk.ColumnMappings.Add("CRT_USER_ID", "CRT_USER_ID");
                    //objbulk.ColumnMappings.Add("DEL_FLG", "DEL_FLG");
                    objbulk.WriteToServer(ds);
                    dbAccess.Close();

                    ds.Columns.Remove("EDU_YEAR");
                    ds.Columns.Remove("YEAR");
                    ds.Columns.Remove("MONTH");
                    ds.Columns.Remove("STAFF_ID");
                    ds.Columns.Remove("REMARK");
                    ds.Columns.Remove("CRT_DT_TM");
                    ds.Columns.Remove("CRT_USER_ID");
                    ds.Columns.Remove("DEL_FLG");
                    gvsalarylist.DataSource = ds.DefaultView;
                    gvsalarylist.DataBind();
                }
                catch
                {
                    //lblError.Text = ex.ToString();
                }
                finally
                {
                    oledbConn.Close();
                }
        }// close of method GemerateExceLData

        protected void btnsalarycal_Click(object sender, EventArgs e)
        {
            string month = ddlmonthList.SelectedItem.Value;
            string staffType = ddltypelist.SelectedItem.Value;
            if (staffType.Equals("Teacher"))
            {
                reFlag = 0;//TEACHER
                DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month,reFlag);
                if (chkSalary.Count > 0)
                {
                    bool isDelete = salarySerivce.deleteSalaryData(month, reFlag);
                }
                saveSalaryData();
            }
            else
            {
                reFlag = 1;//STAFF
                DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month, reFlag);
                if (chkSalary.Count > 0)
                {
                    bool isDelete = salarySerivce.deleteSalaryData(month, reFlag);
                }
                saveSalaryData();
            }
            gvsalarylist.AllowPaging = true;
        }

        protected int calculateSalary(DataSet.DsPSMS.ST_SALARYRow temp,string salaryATM)
        {
            int resultAmt=0;
            if (temp != null)
            {
                resultAmt = int.Parse(salaryATM);

                if (temp.LEAVE_AMOUNT != 0)
                {
                    int leave = temp.LEAVE_TIMES * temp.LEAVE_AMOUNT;
                    resultAmt -= leave;
                }

                if (temp.LATE_AMOUNT != 0)
                {
                    int late = temp.LATE_TIMES * temp.LATE_AMOUNT;
                    resultAmt -= late;
                }

                if (temp.OT_AMOUNT != 0)
                {
                    resultAmt += temp.OT_AMOUNT;
                }
            }
            return resultAmt;
        }

        private void displayGridData(int reFlag)
        {
            string month = ddlmonthList.SelectedItem.Value; 
            DataSet.DsPSMS.ST_SALARYDataTable salarys = salarySerivce.getSalaryByMonthRemark(month, reFlag);
            //string[] idLists =new string Array();
            if (salarys.Count > 0)
            {
                gvsalarylist.DataSource = salarys;
                
                salarys.Columns.Remove(salarys.Columns["EDU_YEAR"]);
                salarys.Columns.Remove(salarys.Columns["CRT_DT_TM"]);
                salarys.Columns.Remove(salarys.Columns["CRT_USER_ID"]);
                salarys.Columns.Remove(salarys.Columns["UPD_DT_TM"]);
                salarys.Columns.Remove(salarys.Columns["UPD_USER_ID"]);
                //salarys.Columns.Remove(salarys.Columns["REMARK"]);

                foreach (DataSet.DsPSMS.ST_SALARYRow row in salarys.Rows)
                {
                    if (reFlag == 0 )
                    {
                        DataSet.DsPSMS.ST_TEACHER_DATARow teacher = salarySerivce.getTeacherByid(int.Parse(row.STAFF_ID));
                        if (teacher != null)
                        {
                            row.STAFF_ID = teacher.TEACHER_NAME;  
                        }
                    }
                    else
                    {
                        DataSet.DsPSMS.ST_STAFF_DATARow staff = salarySerivce.getStaffIdByid(int.Parse(row.STAFF_ID));
                        if (staff != null)
                        {
                            row.STAFF_ID = staff.STAFF_NAME;
                        }
                    }

                    //idLists.Add(Convert.ToString(row.SALARY_ID));
                }

                //gvsalarylist.DataKeys = idLists;
                gvsalarylist.DataBind();
                //bindSalaryDatatxt(salarys);
                gvsalarylist.HeaderRow.Cells[1].Text = "ID";
                gvsalarylist.HeaderRow.Cells[4].Text = "Staff";
                gvsalarylist.HeaderRow.Cells[5].Text = "Leave Days";
                gvsalarylist.HeaderRow.Cells[6].Text = "leave Amount";
                gvsalarylist.HeaderRow.Cells[7].Text = "late Time";
                gvsalarylist.HeaderRow.Cells[8].Text = "late Amount";
                gvsalarylist.HeaderRow.Cells[9].Text = "OT Amount";
                gvsalarylist.HeaderRow.Cells[10].Text = "Salary";
                
            }
        }

        protected void bindSalaryDatatxt(DataSet.DsPSMS.ST_SALARYDataTable salarys)
        {
            int j = 0;
            foreach (GridViewRow row in gvsalarylist.Rows)
            {
                TextBox tb1 = new TextBox();
                tb1 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[3].FindControl("txtLeaveTime"));
                //tb1 = (TextBox)(row.FindControl("txtLeaveTime"));
                tb1.Text = salarys.Rows[j]["LEAVE_TIMES"].ToString();

                TextBox tb2 = new TextBox();
                tb2 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[4].FindControl("txtLeaveAmt"));
                tb2.Text = salarys.Rows[j]["LEAVE_AMOUNT"].ToString();

                TextBox tb3 = new TextBox();
                tb3 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[5].FindControl("txtlateTime"));
                tb3.Text = salarys.Rows[j]["LATE_TIMES"].ToString();

                TextBox tb4 = new TextBox();
                tb4 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[6].FindControl("txtLateAmt"));
                tb4.Text = salarys.Rows[j]["LATE_AMOUNT"].ToString();

                TextBox tb5 = new TextBox();
                tb5 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[7].FindControl("txtOtAmt"));
                tb5.Text = salarys.Rows[j]["OT_AMOUNT"].ToString();

                j++;
            }
        }

        protected void saveSalaryData()
        {
            bool isOk = false;
            //gvsalarylist.AllowPaging = false;
            //gvsalarylist.DataBind();
            foreach (GridViewRow row in gvsalarylist.Rows)
            {
                DataSet.DsPSMS.ST_SALARYRow salary = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();

                salary.STAFF_ID = gvsalarylist.Rows[row.RowIndex].Cells[0].Text;
                string salaryAMT = gvsalarylist.Rows[row.RowIndex].Cells[2].Text;
                salary.EDU_YEAR = ddleduyearlist.SelectedItem.Value;
                TextBox tb1 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[3].FindControl("txtLeaveTime"));
                salary.LEAVE_TIMES = int.Parse(tb1.Text);

                TextBox tb2 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[4].FindControl("txtLeaveAmt"));
                salary.LEAVE_AMOUNT = int.Parse(tb2.Text);

                TextBox tb3 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[5].FindControl("txtlateTime"));
                salary.LATE_TIMES = int.Parse(tb3.Text);


                TextBox tb4 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[6].FindControl("txtLateAmt"));
                salary.LATE_AMOUNT = int.Parse(tb4.Text);

                TextBox tb5 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[7].FindControl("txtOtAmt"));
                salary.OT_AMOUNT = int.Parse(tb5.Text);
                salary.REMARK =Convert.ToString(reFlag);
                salary.SALARY_AMOUNT = calculateSalary(salary, salaryAMT);
                salary.MONTH = ddlmonthList.SelectedItem.Value;
                salary.CRT_DT_TM = DateTime.Now;
                salary.CRT_USER_ID = this.userId;

                isOk = salarySerivce.saveSalaryData(salary, out msg);
            }
        }

        protected void btnsalarysearch_Click(object sender, EventArgs e)
        {
            if (ddlmonthList.SelectedIndex == 0)
            {
                lblerrorsalary.Visible = true;
            }
            else
            {
            }
        }

        protected void gvsalarylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsalarylist.PageIndex = e.NewPageIndex;
            gvsalarylist.DataSource = ds.DefaultView;
            gvsalarylist.DataBind();
        }

        protected void btnSearchSarlary_Click(object sender, EventArgs e)
        {
            string month = ddlmonthList.SelectedItem.Value;
            string staffType = ddltypelist.SelectedItem.Value;
            lblerrorsalary.Visible = false;
            if (staffType.Equals("Teacher"))
            {
                reFlag = 0;
            }
            else
            {
                reFlag = 1;
            }

            DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month, reFlag);
            if (chkSalary.Count > 0)
            {
                lblsalarybtnclick.Text = "This data source is already exist ! ";
            }
            else
            {
                btnExportSalary.Enabled = true;
                lblsalarybtnclick.Text = "To export excel file ,please click 'Export File' button !";
            }
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM0037_SalaryCalculationDisplay.aspx");
        }
    }
}