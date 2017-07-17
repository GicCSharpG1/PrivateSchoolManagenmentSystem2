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
    public partial class SMS005 : System.Web.UI.Page
    {
        StudentInfoService stuservice = new StudentInfoService();
        public SMS005()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            picturebox.ImageUrl = "~/Images/school.jpg";

            DsPSMS.ST_STUDENT_DATARow studetail = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
           
            if (Session["STUDENT_ID"] != null)
            {
                string stuDetailId= (string)(Session["STUDENT_ID"] ?? " ");
                rebindStudentData(stuDetailId);
            }


            //studetail = stuservice.searchIdNaEdGd(studetail);

            //if (studetail != null)
            //{
            //    lblClass.Text = studetail.EDU_YEAR;
            //    lblID.Text = studetail.STUDENT_ID;
            //    lblName.Text = studetail.STUDENT_NAME;
            //    lblRoll.Text = studetail.ROLL_NO;
            //    lblGender.Text = studetail.GENDER;
            //    lbldob.Text = studetail.DOB;
            //    //picturebox.Text = studetail.PHOTO_PATH;
            //    picturebox.ImageUrl = "~/Images/" + studetail.PHOTO_PATH;
            //    lblPhone.Text = studetail.PHONE;
            //    lblNrc.Text = studetail.NRC_NO;
            //    lblPwd.Text = studetail.PASSWORD;
            //    lblGrade.Text = studetail.GRADE_ID;
            //    lblRoom.Text = studetail.ROOM_ID;
            //    lblFather.Text = studetail.FATHER_NAME;
            //    lblMother.Text = studetail.MOTHER_NAME;
            //    lblAddress.Text = studetail.ADDRESS;
            //    lblCphone.Text = studetail.CONTACT_PHONE;
            //    lblEmail.Text = studetail.EMAIL;
            //    lblCashtype.Text = studetail.CASH_TYPE1;
            //    lblCashMonth.Text = studetail.CASH_TYPE2;
            //}
        }


        protected void btnedit_Click(object sender, EventArgs e)
        {
            Session["EDU_YEAR"] = lblClass.Text;
            Session["STUDENT_ID"] = lblID.Text;
            Session["STUDENT_NAME"] = lblName.Text;
            Session["ROLL_NO"] = lblRoll.Text;
            Session["GENDER"] = lblGender.Text;
            
            Session["PHOTO_PATH"] = picturebox.ImageUrl;
            Session["DOB"] = lbldob.Text;
            Session["PHONE"] = lblPhone.Text;
            Session["NRC_NO"] = lblNrc.Text;
            Session["PASSWORD"] = lblPwd.Text;
            Session["GRADE_ID"] = lblGrade.Text;
            Session["ROOM_ID"] = lblRoom.Text;
            Session["CASH_TYPE1"] = lblCashtype.Text;
            Session["CASH_TYPE2"] = lblCashMonth.Text;
            Session["FATHER_NAME"] = lblFather.Text;
            Session["MOTHER_NAME"] = lblMother.Text;
            Session["ADDRESS"] = lblAddress.Text;
            Session["CONTACT_PHONE"] = lblCphone.Text;
            Session["EMAIL"] = lblEmail.Text;
            
            Response.Redirect("SMS003_StudentEntry.aspx");

        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS004_StudentList.aspx");

        }

        private void rebindStudentData(string stuId)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable stuDt = stuservice.getStudentDataById(stuId);
            DataSet.DsPSMS.ST_STUDENT_DATARow studetail = stuDt[0];
            
            lblClass.Text = studetail.EDU_YEAR;
            lblID.Text = studetail.STUDENT_ID;
            lblName.Text = studetail.STUDENT_NAME;
            lblRoll.Text = studetail.ROLL_NO;
            lblGender.Text = studetail.GENDER;
            lbldob.Text = studetail.DOB;
            //picturebox.Text = studetail.PHOTO_PATH;
            picturebox.ImageUrl = "~/Images/" + studetail.PHOTO_PATH;
            lblPhone.Text = studetail.PHONE;
            lblNrc.Text = studetail.NRC_NO;
            lblPwd.Text = studetail.PASSWORD;
            lblGrade.Text = studetail.GRADE_ID.ToString();
            lblRoom.Text = studetail.ROOM_ID;
            lblFather.Text = studetail.FATHER_NAME;
            lblMother.Text = studetail.MOTHER_NAME;
            lblAddress.Text = studetail.ADDRESS;
            lblCphone.Text = studetail.CONTACT_PHONE;
            lblEmail.Text = studetail.EMAIL;
            lblCashtype.Text = studetail.CASH_TYPE1;
            lblCashMonth.Text = studetail.CASH_TYPE2;
        }
    }
}