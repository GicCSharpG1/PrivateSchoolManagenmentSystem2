using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;


namespace HomeASP
{
    public partial class SMS004 : System.Web.UI.Page
    {
        StudentInfoService stuentry = new StudentInfoService();
        CommonService cmSer = new CommonService();
        // DsPSMS.ST_STUDENT_DATADataTable show = new DsPSMS.ST_STUDENT_DATADataTable();
        //  string userid = "";
        string msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            showgrid();
            if (stulistgrade.Items.Count == 0)
            {
                bindStudentGrade();
                stulistgrade.Items.Insert(0, new ListItem("Select Grade", "0"));
            }

            if (!IsPostBack)
            {
                if (Session["EDU_YEAR"] != null)
                {
                    comboYear.Text = (string)(Session["EDU_YEAR"] ?? "  ");
                    Session.Remove("EDU_YEAR");
                }
                if (Session["GRADE_ID"] != null)
                {
                    stulistgrade.SelectedItem.Value = (string)(Session["GRADE_ID"] ?? "  ");
                    Session.Remove("GRADE_ID");
                }
                btnSearch_Click(sender, e);
            }
         
        }

        public void bindStudentGrade()
        {
            msg = "aaa";
            stulistgrade.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable stugrades = cmSer.getAllGrade();
            stulistgrade.DataSource = stugrades;
            stulistgrade.DataTextField = "GRADE_NAME";
            stulistgrade.DataValueField = "GRADE_ID";
            stulistgrade.DataBind();
        }

      
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_DATARow stuDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            stuDr.GRADE_ID = int.Parse(stulistgrade.SelectedItem.Value);
            //int gradeid = int.Parse(stulistgrade.SelectedItem.Value);
            stuDr.EDU_YEAR = comboYear.SelectedItem.Value;
            //string eduyearid = comboYear.SelectedItem.Value;
            stuDr.STUDENT_NAME = searchstuname.Text;
            //string name = searchstuname.Text;

            if (!stuDr.STUDENT_NAME.Equals(""))
            {
                if (!stuDr.GRADE_ID.Equals(0) && !stuDr.EDU_YEAR.Equals("Select Year"))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);
                    displayGrid(stuData);
                }


                if (!stuDr.GRADE_ID.Equals(0) && stuDr.EDU_YEAR.Equals("Select Year"))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);
                    displayGrid(stuData);
                }


                if (!stuDr.EDU_YEAR.Equals("Select Year") && stuDr.GRADE_ID.Equals(0))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);
                    displayGrid(stuData);
                }



                if (stuDr.GRADE_ID.Equals(0) && stuDr.EDU_YEAR.Equals("Select Year"))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);
                    displayGrid(stuData);
                }

            }
            else
            {
                if (!stuDr.GRADE_ID.Equals(0) && !stuDr.EDU_YEAR.Equals("Select Year"))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);
                    displayGrid(stuData);
                }



                if (!stuDr.GRADE_ID.Equals(0) && stuDr.EDU_YEAR.Equals("Select Year"))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);
                    displayGrid(stuData);
                }


                if (!stuDr.EDU_YEAR.Equals("Select Year") && stuDr.GRADE_ID.Equals(0))
                {
                    DsPSMS.ST_STUDENT_DATADataTable stuData = stuentry.getDataOption(stuDr);

                    displayGrid(stuData);
                }
            }
        }

        protected void showgrid()
        {
            DsPSMS.ST_STUDENT_DATADataTable show = new DsPSMS.ST_STUDENT_DATADataTable();
            show = stuentry.getAllData(out msg);
            if (show != null && show.Rows.Count != 0)
            {

                GridView1.DataSource = show;
                GridView1.DataBind();
            }

        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            Session["STUDENT_ID"] = null;
            Response.Redirect("SMS003_StudentEntry.aspx");
        }

        protected void displayGrid(DsPSMS.ST_STUDENT_DATADataTable student)
        {
            if (student != null)
            {
                GridView1.DataSource = student;
                GridView1.DataBind();
            }
        }

        protected void displaygyearGrid(DsPSMS.ST_STUDENT_DATADataTable studentgyear)
        {
            if (studentgyear != null)
            {
                GridView1.DataSource = studentgyear;
                GridView1.DataBind();
            }
        }

        protected void StuList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string studentId = btn.CommandName;

            if(studentId != null)
            {
                Session["STUDENT_ID"] = studentId;

                Response.Redirect("SMS003_StudentEntry.aspx");
            }
        }

        protected void btnStudentDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string studentId = btn.CommandName;

            if (studentId != null)
            {
                Session["STUDENT_ID"] = studentId;
                Session["EDU_YEAR"] = comboYear.Text;
                Session["GRADE_ID"] = stulistgrade.SelectedItem.Value;
                Response.Redirect("SMS005_StudentDetail.aspx");
            }
        }

        protected void btnStudentDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string studentId = btn.CommandName;

            if (studentId != null)
            {

                stuentry.removedata(studentId, out msg);
                DataTable ds = new DataTable();
                ds = null;
                GridView1.DataSource = ds;
                GridView1.DataBind();
                showgrid();
            }
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            showgrid();
        }


    }
}