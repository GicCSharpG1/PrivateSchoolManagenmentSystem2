using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HomeASP.Service;
using HomeASP.DataSet;
using System.Drawing.Printing;


namespace HomeASP
{
    public partial class SMS025 : System.Web.UI.Page
    {
        private string msg = "";
        StaffService service = new StaffService();
        public string result = "";
        public string labelResult = "";
        

        //DataSet.DsPSMS.ST_STAFF_DATADataTable dt;
        //DataSet.DsPSMS.ST_STAFF_DATARow dr;
        string userId = "";

        string speci;
        DsPSMS.ST_POSITION_MSTDataTable pt = new DsPSMS.ST_POSITION_MSTDataTable();
        DsPSMS.ST_STAFF_DATADataTable dt = new DsPSMS.ST_STAFF_DATADataTable();
        DsPSMS.ST_STAFF_DATARow stDr = new DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();
        DsPSMS.ST_POSITION_MSTRow sp = new DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();

        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/Images/school.jpg";

           

            if (Session["STAFF_ID"] != null)
            {
                string staffDetailId = (string)(Session["STAFF_ID"] ?? " ");
                stDr.STAFF_ID = staffDetailId;
                rebindStaffData(stDr);
            }
            

            
        }

        private void rebindStaffData(DsPSMS.ST_STAFF_DATARow stDr)
        {
            DataSet.DsPSMS.ST_STAFF_DATADataTable stuDt = new DsPSMS.ST_STAFF_DATADataTable();
            stuDt = service.selectStaffByID(stDr);
            DataSet.DsPSMS.ST_STAFF_DATARow staffdetail = stuDt[0];
            lblEduYear.Text = staffdetail.EDU_YEAR;
            lblStaffName.Text = staffdetail.STAFF_NAME;
            lblstaffID.Text = staffdetail.STAFF_ID;

            string s = staffdetail.POSITION_ID;
            sp = service.getselectedPosition(s, out msg);
            lblPosition.Text = sp.POSITION_NAME;

            lblPhone.Text = staffdetail.PHONE;
            lblEducation.Text = staffdetail.EDUCATION;
            lblSalary.Text =Convert.ToString( staffdetail.SALARY);
            lblNRC.Text = staffdetail.NRC_NO;
            lblAddress.Text = staffdetail.ADDRESS;
            lblGender.Text = staffdetail.GENDER;
            lblStatus.Text = staffdetail.MARRIED_STATUS;
            Image1.ImageUrl = "~/Images/" + staffdetail.PHOTO_PATH;
            lblDOB.Text = staffdetail.DOB;
            
           // lblClass.Text = studetail.EDU_YEAR;
           // lblID.Text = studetail.STUDENT_ID;
           // lblName.Text = studetail.STUDENT_NAME;
           // lblRoll.Text = studetail.ROLL_NO;
           // lblGender.Text = studetail.GENDER;
           // lbldob.Text = studetail.DOB;
           // picturebox.Text = studetail.PHOTO_PATH;
           // picturebox.ImageUrl = "~/Images/" + studetail.PHOTO_PATH;
           // lblPhone.Text = studetail.PHONE;
           // lblNrc.Text = studetail.NRC_NO;
            
           // lblGrade.Text = studetail.GRADE_ID;
            
           // lblMother.Text = studetail.MOTHER_NAME;
           // lblAddress.Text = studetail.ADDRESS;

           //lblstaffID.Text=service
           
            
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            //Response.Redirect("SMS024_StaffList.aspx");
            Response.Redirect("SMS024_StaffList.aspx");

        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Session["EDU_YEAR"] = lblEduYear.Text;

            Session["STAFF_ID"] = lblstaffID.Text;
            Session["STAFF_NAME"] = lblStaffName.Text;
            Session["POSITION_ID"] = lblPosition.Text;
            Session["GENDER"] = lblGender.Text;
            Session["MARRIED_STATUS"] = lblStatus.Text;
            Session["EDUCATION"] = lblEducation.Text;
            Session["PHOTO_PATH"] = Image1.ImageUrl;
            Session["DOB"] = lblDOB.Text;
            Session["PHONE"] = lblPhone.Text;
            Session["SALARY"] = lblSalary.Text;
            Session["NRC_NO"] = lblNRC.Text;
           
            Session["ADDRESS"] = lblAddress.Text;
            
            Response.Redirect("SMS023_StaffEntry.aspx");

        }
    }
}













