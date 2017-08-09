using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Linq;

namespace HomeASP
{
    public partial class SMS002 : System.Web.UI.Page
    {
        private string msg = "";
        GradeSubjectService service = new GradeSubjectService();
        DataSet.DsPSMS.ST_GRADE_MSTRow gradeRow = null;
        DataSet.DsPSMS.ST_SUBJECT_MSTRow subjectRow = null;
        DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow gradeSubjectRow = null;
        static string loginUserId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGradeListCombo();

            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            if (gradeList.Items.Count == 0)
            {
                gradeList.Enabled = false;
            }
            if (gridViewGrade.Rows.Count == 0)
            {
                gridViewGrade.DataSource = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
                gridViewGrade.DataBind();
            }
            if (gridViewSubject.Rows.Count == 0)
            {
                gridViewSubject.DataSource = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
                gridViewSubject.DataBind();
            }
            if (gradeSubjectGridView.Rows.Count == 0)
            {
                gradeSubjectGridView.DataSource = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
                gradeSubjectGridView.DataBind();
            }
           
        }

        private Boolean checkValidationForGrade()
        {
            Boolean isError = false;
            if (gradeId.Text.Trim().Length == 0 || gradeName.Text.Trim().Length == 0 || eduYearGrade.SelectedIndex == 0 || price.Text.Trim().Length == 0)
            {
                errgrade1.Visible = true;
                isError = true;
            }
            else
            {
                errgrade1.Visible = false;
            }
            
            return isError;
        }

        protected void gridViewGrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            displayGradeData();
            gridViewGrade.PageIndex = e.NewPageIndex;
            gridViewGrade.DataBind();
        }

        protected void gridViewSubject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            displaySubjectData();
            gridViewSubject.PageIndex = e.NewPageIndex;
            gridViewSubject.DataBind();
        }

        protected void gridViewGradeSubject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            displayGradeSubjectData();
            gradeSubjectGridView.PageIndex = e.NewPageIndex;
            gradeSubjectGridView.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            if (!checkValidationForGrade())
            {
                if (btnAdd.Text.Equals("Save"))
                {
                    msg = "";
                    gradeRow.CRT_USER_ID = loginUserId;
                    gradeRow.CRT_DT_TM = DateTime.Now;
                    gradeRow.DEL_FLG = 0;
                    gradeRow.GRADE_ID = Convert.ToInt16(gradeId.Text);
                    gradeRow.GRADE_NAME = gradeName.Text;
                    gradeRow.EDU_YEAR = eduYearGrade.Text;
                    gradeRow.MONTHLY_FEE = Convert.ToInt32(price.Text);
                    DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeData = service.selectGradeByID(gradeRow, out msg);

                    if (gradeData != null && gradeData.Rows.Count > 0)
                    {

                        //  ModelState.AddModelError(string.Empty, "Data already exists for this Grade!");
                        //string script = "alert(\"Data already exists for this ID!\");";
                        //ScriptManager.RegisterStartupScript(this, GetType(),
                        //                      "ServerControlScript", script, true);
                        Label1.Visible = true;
                    }
                    else
                    {
                       
                        service.saveGrade(gradeRow, out msg);

                        //Response.Write("<script>alert('Save Successfully!')</script>");
                    }
                }
                else if (btnAdd.Text.Equals("Update"))
                {
                    gradeRow.UPD_USER_ID = loginUserId;
                    gradeRow.UPD_DT_TM = DateTime.Now;
                    gradeRow.GRADE_NAME = gradeName.Text;
                    gradeRow.GRADE_ID = Convert.ToInt32(gradeId.Text);
                    gradeRow.EDU_YEAR = eduYearGrade.Text;
                    gradeRow.MONTHLY_FEE = Convert.ToInt32(price.Text);
                    service.updateGrade(gradeRow, out msg);
                    //Response.Write("<script>alert('Update Successfully!')</script>");

                    btnAdd.Text = "Save";
                    gradeId.Enabled = true;
                    btnShowAll.Enabled = true;
                }
                displayGradeData();
                FillGradeListCombo();
                eduYearGrade.SelectedIndex = 0;
                gradeId.Text = "";
                gradeName.Text = "";
                price.Text = "";
            }
        }

        private void displayGradeData()
        {
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.getAllGradeData(out msg);
            gridViewGrade.DataSource = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            gridViewGrade.DataBind();
            if (resultDt != null)
            {
                gridViewGrade.DataSource = resultDt;
                gridViewGrade.DataBind();
            }
            errgrade1.Visible = false;
            Label1.Visible = false;
        }

        void FillGradeListCombo()
        {
            gradeList.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.getAllGradeData(out msg);
            if (resultDt != null)
            {
                gradeList.DataSource = resultDt;
                gradeList.DataTextField = "GRADE_NAME";
                gradeList.DataValueField = "GRADE_ID";
                gradeList.DataBind();
                gradeList.Items.Insert(0, "Select Grade");
                gradeList.Enabled = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editGradeId = btn.CommandName;
            gradeId.Text = editGradeId;
            gradeId.Enabled = false;

            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            if (editGradeId != null)
                gradeRow.GRADE_ID = int.Parse(editGradeId);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeData = service.selectGradeByID(gradeRow, out msg);
            gradeName.Text = gradeData.Rows[0]["GRADE_NAME"].ToString();
            price.Text = gradeData.Rows[0]["MONTHLY_FEE"].ToString();
            eduYearGrade.Text = gradeData.Rows[0]["EDU_YEAR"].ToString();

            btnAdd.Text = "Update";
            btnShowAll.Enabled = false;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            displayGradeData();
            FillGradeListCombo();
            // errEduYear1.Visible = false;
            // errGradeId.Visible = false;
            // errGradeName.Visible = false;
            // errPrice.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editGradeId = btn.CommandName;
            msg = "";
            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            gradeRow.GRADE_ID = int.Parse(editGradeId);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.selectGradeByID(gradeRow, out msg);

            if (resultDt != null && resultDt.Rows.Count > 0)
            {
                service.deleteGrade(gradeRow, out msg);
                displayGradeData();
            }
        }

        private Boolean checkValidationForSubject()
        {
            Boolean isError = false;
            if (subjectId.Text.Trim().Length == 0 || subjectName.Text.Trim().Length == 0 || eduYearSubject.SelectedIndex == 0)
            {
                Label5.Visible = true;
                isError = true;
            }
            else
            {
                Label5.Visible = false;
            }
          
            return isError;
        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            if (!checkValidationForSubject())
            {
                if (subjectAdd.Text.Equals("Save"))
                {
                    msg = "";
                    subjectRow.CRT_USER_ID = loginUserId;
                    subjectRow.CRT_DT_TM = DateTime.Now;
                    subjectRow.DEL_FLG = 0;
                    subjectRow.SUBJECT_ID = Convert.ToInt32(subjectId.Text);
                    subjectRow.SUBJECT_NAME = subjectName.Text;
                    subjectRow.EDU_YEAR = eduYearSubject.Text;
                    DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjectData = service.selectSubjectByIDWithNOflag(subjectRow, out msg);

                    if (subjectData != null && subjectData.Rows.Count > 0)
                    {
                        //ModelState.AddModelError(string.Empty, "Data already exists for this Subject!");
                        //string script = "alert(\"Data already exists for this ID!\");";
                        //ScriptManager.RegisterStartupScript(this, GetType(),
                        //                      "ServerControlScript", script, true);
                        Label6.Visible = true;
                    }
                    else
                    {
                        service.saveSubject(subjectRow, out msg);
                        //Response.Write("<script>alert('Save Successfully!')</script>");
                    }
                }
                else if (subjectAdd.Text.Equals("Update"))
                {
                    subjectRow.UPD_USER_ID = loginUserId;
                    subjectRow.UPD_DT_TM = DateTime.Now;
                    subjectRow.DEL_FLG = 0;
                    subjectRow.SUBJECT_NAME = subjectName.Text;
                    subjectRow.SUBJECT_ID = Convert.ToInt32(subjectId.Text);
                    subjectRow.EDU_YEAR = eduYearSubject.Text;
                    service.updateSubject(subjectRow, out msg);
                    //Response.Write("<script>alert('Update Successfully!')</script>");

                    subjectAdd.Text = "Save";
                    subjectId.Enabled = true;
                    subjectShowAll.Enabled = true;
                }
                displaySubjectData();
                displaySubjectInGridView();
                subjectId.Text = "";
                subjectName.Text = "";
                eduYearSubject.SelectedIndex = 0;
            }
        }

        private void displaySubjectData()
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable resultDt = service.getAllSubjectData(out msg);
            gridViewSubject.DataSource = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            gridViewSubject.DataBind();
            if (resultDt != null)
            {
                gridViewSubject.DataSource = resultDt;
                gridViewSubject.DataBind();
            }
        }

        private void displaySubjectInGridView()
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable resultDt = service.getAllSubjectData(out msg);
            if (resultDt != null)
            {
                subjectGridView.DataSource = resultDt;
                subjectGridView.DataBind();
            }
            Label5.Visible = false;
            Label6.Visible = false;
        }

        protected void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editSubjectId = btn.CommandName;
            subjectId.Text = editSubjectId;
            subjectId.Enabled = false;

            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            if (editSubjectId != null)
                subjectRow.SUBJECT_ID = Convert.ToInt32(editSubjectId);
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjectData = service.selectSubjectByID(subjectRow, out msg);
            subjectName.Text = subjectData.Rows[0]["SUBJECT_NAME"].ToString();
            eduYearSubject.Text = subjectData.Rows[0]["EDU_YEAR"].ToString();

            subjectAdd.Text = "Update";
            subjectShowAll.Enabled = false;
        }

        protected void btnSelectSubject_Click(object sender, EventArgs e)
        {
            displaySubjectData();
            displaySubjectInGridView();
            // errEduYear2.Visible = false;
            //  errSubjectId.Visible = false;
            //  errSubjectName.Visible = false;
        }

        protected void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editSubjectId = btn.CommandName;
            msg = "";
            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            subjectRow.SUBJECT_ID = Convert.ToInt32(editSubjectId);
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjectData = service.selectSubjectByID(subjectRow, out msg);

            if (subjectData != null && subjectData.Rows.Count > 0)
            {
                service.deleteSubject(subjectRow, out msg);
                displaySubjectData();
                displaySubjectInGridView();
            }
        }

        protected void btnAddGradeSubject_Click(object sender, EventArgs e)
        {
            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            if (!checkValidationForGradeSubject())
            {
                if (gradeSubjectAdd.Text.Equals("Save"))
                {
                    msg = "";
                    gradeSubjectRow.CRT_USER_ID = loginUserId;
                    gradeSubjectRow.CRT_DT_TM = DateTime.Now;
                    gradeSubjectRow.DEL_FLG = 0;
                    gradeSubjectRow.ID = Convert.ToInt32(gradeSubjectId.Text);
                    gradeSubjectRow.GRADE_ID = gradeList.Text;
                    gradeSubjectRow.EDU_YEAR = eduYearGradeSubject.Text;

                    string subjectId = getSubjectIdList();
                    DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.selectGradeSubjectByIDWithNOflate(gradeSubjectRow, out msg);

                    if (resultDt != null && resultDt.Rows.Count > 0)
                    {
                        // ModelState.AddModelError(string.Empty, "Data already exists for this Grade and Subject!");
                        //string script = "alert(\"Data already exists for this ID!\");";
                        //ScriptManager.RegisterStartupScript(this, GetType(),
                        //                      "ServerControlScript", script, true);
                        Label8.Visible = true;
                        errorSubandGrade.Visible = false;
                        errSubjectList.Visible = false;
                      
                    }
                    else
                    {
                        service.saveGradeSubject(gradeSubjectRow, subjectId, out msg);
                        //Response.Write("<script>alert('Save Successfully!')</script>");
                    }
                }
                else if (gradeSubjectAdd.Text.Equals("Update"))
                {
                    gradeSubjectRow.UPD_USER_ID = loginUserId;
                    gradeSubjectRow.UPD_DT_TM = DateTime.Now;
                    gradeSubjectRow.DEL_FLG = 0;
                    gradeSubjectRow.ID = Convert.ToInt32(gradeSubjectId.Text);
                    gradeSubjectRow.GRADE_ID = gradeList.Text;
                    gradeSubjectRow.EDU_YEAR = eduYearGradeSubject.Text;
                    gradeSubjectRow.SUBJECT_ID_LIST = getSubjectIdList();
                    service.updateGradeSubject(gradeSubjectRow, out msg);
                    //Response.Write("<script>alert('Update Successfully!')</script>");

                    gradeSubjectAdd.Text = "Save";
                    gradeSubjectId.Enabled = true;
                    gradeSubjectShowAll.Enabled = true;
                }
                displayGradeSubjectData();
                gradeSubjectId.Text = "";
                eduYearGradeSubject.SelectedIndex = 0;
                gradeList.SelectedIndex = 0;
                foreach (GridViewRow row in subjectGridView.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("selectedSubject");
                    if (chk != null && chk.Checked)
                    {
                        chk.Checked = false;
                    }
                }
            }
        }

        private Boolean checkValidationForGradeSubject()
        {
            Boolean isError = false;
            if (gradeSubjectId.Text.Trim().Length == 0 || gradeList.SelectedIndex == 0 || eduYearGradeSubject.SelectedIndex == 0)
            {
                  errorSubandGrade.Visible = true;
                isError = true;
            }
           
            int count = 0;
            foreach (GridViewRow row in subjectGridView.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("selectedSubject");
                if (chk != null && chk.Checked == false)
                {
                    count++;
                }
            }
            if (count == subjectGridView.Rows.Count)
            {
                errorSubandGrade.Visible = true;
            }
            return isError;
        }

        private string getSubjectIdList()
        {
            string subjectId = null;
            int rowCount = 0;
            foreach (GridViewRow row in subjectGridView.Rows)
            {
                rowCount++;
                CheckBox chk = (CheckBox)row.FindControl("selectedSubject");
                if (chk != null && chk.Checked)
                {
                    subjectId += row.Cells[2].Text;
                    subjectId += ",";
                }
                if (rowCount == subjectGridView.Rows.Count)
                {
                    subjectId = subjectId.Substring(0, subjectId.Length - 1);
                }
            }
            return subjectId;
        }

        private void displayGradeSubjectData()
        {
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.getAllGradeSubjectData(out msg);
            gradeSubjectGridView.DataSource = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            gradeSubjectGridView.DataBind();

            if (resultDt != null)
            {
                BoundField subjectNameList = new BoundField();
                subjectNameList.HeaderText = "Subject";

                foreach (DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow row in resultDt.Rows)
                {
                    string subjectIdList = null;
                    string subjectName = null;
                    if (row.SUBJECT_ID_LIST != null)
                    {
                        subjectIdList = row.SUBJECT_ID_LIST.ToString();
                    }

                    DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subject = service.getAllSubjectName(subjectIdList, out msg);
                    if (subject != null)
                    {
                        foreach (DataSet.DsPSMS.ST_SUBJECT_MSTRow subjectRow in subject.Rows)
                        {
                            subjectName += subjectRow.SUBJECT_NAME.ToString();
                            subjectName += ",";
                        }
                        subjectName = subjectName.Substring(0, subjectName.Length - 1);

                        row.SUBJECT_ID_LIST = subjectName;

                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
                      grade.GRADE_ID = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTDataTable result = service.selectGradeByID(grade, out msg);
                        row.GRADE_ID = result.Rows[0]["GRADE_NAME"].ToString();
                    }
                }
                gradeSubjectGridView.DataSource = resultDt;

                gradeSubjectGridView.DataBind();

            }
            errorSubandGrade.Visible = false;
            Label8.Visible = false;
        }

        protected void btnUpdateGradeSubject_Click(object sender, EventArgs e)
        {
            int j = 0;
            string[] values = new string[6];
            string inSubId = "";
            string[] inSubIdArr = new string[30];
            LinkButton btn = (LinkButton)(sender);
            string editId = btn.CommandName;
            gradeSubjectId.Text = editId;
            gradeSubjectId.Enabled = false;

            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            if (editId != null)
                gradeSubjectRow.ID = Convert.ToInt32(editId);
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable subjectGradeData = service.selectGradeSubjectByID(gradeSubjectRow, out msg);
            eduYearGradeSubject.Text = subjectGradeData.Rows[0]["EDU_YEAR"].ToString();
            gradeList.Text = subjectGradeData.Rows[0]["GRADE_ID"].ToString();
            // dgv3.Text = dgv4.Rows[rowindex].Cells[2].Value.ToString();
          //  for (j = 0; j <= subjectGridView.Rows.Count - 2; j++)
          //  {
               
          //Boolean value=  Convert.ToBoolean(subjectGridView.Rows[j].Cells[0].Text) ;
          //  }

          //  if (gradeSubjectGridView.Rows.Count == 0)
          //  {
          //      string script = "alert(\"Data does not exit!\");";
          //      ScriptManager.RegisterStartupScript(this, GetType(),
          //                                      "ServerControlScript", script, true);

          //  }
          //  else
          //  {

          //      int index = gradeSubjectGridView.SelectedIndex;
          //      string allSub = gradeSubjectGridView.Rows[index].Cells[3].Text.ToString();


          //      values = allSub.Split(',');
          //      // for(int x =0 ; x <= values.Length ; x++) 
          //      //{
          //      //MessageBox.Show("TTTTTTTTTTTTest !!!!!!!" + values[x]);
          //      //}
          //      for (int i = 0; i <= values.Length - 1; i++)
          //      {
          //          for (j = 0; j <= subjectGridView.Rows.Count - 2; j++)
          //          {
          //              String ss = values[i];
          //              if (subjectGridView.Rows[j].Cells[1].Text.ToString() == ss) { }
                        
          //          }

          //      }
          //  }
                gradeSubjectAdd.Text = "Update";
                gradeSubjectShowAll.Enabled = false;
            
        }
        protected void btnSelectGradeSubject_Click(object sender, EventArgs e)
        {
            displayGradeSubjectData();
            //  errEduYear3.Visible = false;
            //  errGradeSubjectId.Visible = false;
            //  errGradeList.Visible = false;
           
        }

        protected void btnDeleteGradeSubject_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editId = btn.CommandName;
            msg = "";
            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();

            gradeSubjectRow.ID = Convert.ToInt32(editId);
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.selectGradeSubjectByID(gradeSubjectRow, out msg);

            if (resultDt != null && resultDt.Rows.Count > 0)
            {
                service.deleteGradeSubject(gradeSubjectRow, out msg);
                displayGradeSubjectData();
            }
        }

        protected void gradeSubjectGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gradeSubjectGridView_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}