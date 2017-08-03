using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;
using System.Drawing;
namespace HomeASP
{
    public partial class SMS003 : Page
    {
        string msg = "";
        static string strFileName;
        static string userId = "";
        static int delFlag = 0;
        StudentInfoService stuentry = new StudentInfoService();
        CommonService cmSer = new CommonService();
        RoomService roSer = new RoomService();
        DataSet.DsPSMS.ST_STUDENT_DATARow dr;
        DataSet.DsPSMS.ST_STUDENT_DATADataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            studentpicture.ImageUrl = "~/Images/Profile.png";

            if (grade.Items.Count == 0)
            {
                bindStudentGrade();
                grade.Items.Insert(0, new ListItem("Select Grade", "0"));
            }
            if (roomid.Items.Count == 0)
            {
                bindStudentRoom();
                roomid.Items.Insert(0, new ListItem("Select Room", "0"));
            }
            if (FileUpload1.PostedFile != null)
            {
                UploadAndDisplay();
                studentpicture.ImageUrl = "~/Images/" + strFileName;
                
            }
            
            if (!IsPostBack)
            {
                DsPSMS.ST_STUDENT_DATARow stuentryupdate = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
               
                if (Session["LOGIN_USER_ID"] != null)
                {
                    userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
                }
                if (Session["STUDENT_ID"] != null)
                {
                    string studentId = (string)(Session["STUDENT_ID"] ?? " ");
                    rebindStudentData(studentId);
                }
                if (Session["PHOTO_PATH"] != null)
                {
                    studentpicture.ImageUrl = (string)(Session["PHOTO_PATH"] ?? " ");

                }
                
                
            }
        }


        public void bindStudentGrade()
        {
            msg = "aaa";
            grade.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable stugrades = cmSer.getAllGrade();
            grade.DataSource = stugrades;
            grade.DataTextField = "GRADE_NAME";
            grade.DataValueField = "GRADE_ID";
            grade.DataBind();
        }

        public void bindStudentRoom()
        {
            roomid.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable stuRoom = roSer.getAllRoomMST();
            roomid.DataSource = stuRoom;
            roomid.DataTextField = "ROOM_NAME";
            roomid.DataValueField = "ROOM_ID";
            roomid.DataBind();
        }


        // Saving data
        protected void saved_Click(object sender, EventArgs e)
        {

            dr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            //dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();

            if (!checkValidation())
            {
                string edu = education.SelectedItem.Value;
                dr.EDU_YEAR = edu;

                if (checkID().Equals(true))

                { dr.STUDENT_ID = Convert.ToString(stuid.Text); }

                dr.STUDENT_NAME = stuname.Text;

                dr.ROLL_NO = rollno.Text;

                if (Female.Checked == true)
                { dr.GENDER = "Female"; }

                if (Male.Checked == true)
                { dr.GENDER = "Male"; }

                if (studentpicture.ImageUrl == "~/Images/Profile.png")
                {
                    AllErrSMS.Text = "Please insert photo !!";
                    AllErrSMS.Visible = true;
                }
                else
                {
                    if (checkPhoto().Equals(true))

                    { dr.PHOTO_PATH = strFileName; }
                    else
                    {
                        AllErrSMS.Text = "Your Photo is already exist !!";
                        AllErrSMS.Visible = true;
                    }
                }

                if (checkAge().Equals(true))
                {
                    dr.DOB = dob.Text;
                }
                

                if (stuphone.Text.Trim().Length != 0)
                {
                    dr.PHONE = stuphone.Text;
                }
                else
                {
                    dr.PHONE = " - ";
                }

                if (nrcno.Text.Trim().Length != 0)
                { dr.NRC_NO = nrcno.Text; }
                else
                { dr.NRC_NO = " - "; }

                if (password.Text.Trim().Length != 0)
                { dr.PASSWORD = password.Text; }
                else
                { dr.PASSWORD = "-"; }

                dr.GRADE_ID = int.Parse(grade.SelectedItem.Value);
                
                dr.ROOM_ID = roomid.SelectedItem.Value;

                dr.CASH_TYPE1 = cashtype.SelectedItem.Value;

                if (cashtype.SelectedIndex == 2)
                {
                    if (firstmonth.Checked == true)
                        dr.CASH_TYPE2 = "1";
                    if (thirdmonth.Checked == true)
                        dr.CASH_TYPE2 = "3";
                    if (fourmonth.Checked == true)
                        dr.CASH_TYPE2 = "4";
                }
                else
                    dr.CASH_TYPE2 = "-";

                dr.FATHER_NAME = father.Text;

                dr.MOTHER_NAME = mother.Text;

                dr.ADDRESS = address.Text;

                dr.CONTACT_PHONE = contactPhno.Text;

                bool isOk = isValidEmail(email.Text);
                if (email.Text.Trim().Length != 0)
                {
                    if (isOk == true)
                    {
                        dr.EMAIL = email.Text;
                    }
                    else
                    {
                        AllErrSMS.Text = "Enter valid email!!";
                        AllErrSMS.Visible = true;
                    }
                }
                else
                { dr.EMAIL = " - "; }

                dr.CRT_DT_TM = DateTime.Now;
                dr.CRT_USER_ID = userId;


                if (checkAge().Equals(true) && isValidEmail(email.Text).Equals(true) && checkID().Equals(true) && (studentpicture.ImageUrl != "~/Images/Profile.png" && checkPhoto().Equals(true)))
                {
                    bool result = stuentry.saveData(dr, "ST_STUDENT_DATA", out msg);

                    AllErrSMS.Text = "Your Entry is Save Successfully !!";
                    AllErrSMS.Visible = true;
                }
            }
        }

        protected Boolean checkValidation()
        {
            bool checksign = false;



            if (education.SelectedIndex == 0 && stuid.Text.Trim().Length == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && Male.Checked == false && Female.Checked == false && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0 && email.Text.Trim().Length == 0 && password.Text.Trim().Length == 0 && stuphone.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please enter all student info !!";
                AllErrSMS.Visible = true;
                checksign = true;
            }
            if (education.SelectedIndex != 0 && stuid.Text.Trim().Length != 0 && stuname.Text.Trim().Length != 0 && rollno.Text.Trim().Length != 0 && Male.Checked == true && Female.Checked == true && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
            {
               
                AllErrSMS.Visible = false;
              
            }
            if (education.SelectedIndex == 0 && stuid.Text.Trim().Length == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && Male.Checked == false && Female.Checked == false && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please enter all star student info !!";
                AllErrSMS.Visible = true;
                checksign = true;
            }
            if (education.SelectedIndex == 0 || stuid.Text.Trim().Length == 0 || stuname.Text.Trim().Length == 0 || rollno.Text.Trim().Length == 0 || (Male.Checked == false && Female.Checked == false) || dob.Text.Trim().Length == 0 || grade.SelectedIndex == 0 || roomid.SelectedIndex == 0 || cashtype.SelectedIndex == 0 || father.Text.Trim().Length == 0 || mother.Text.Trim().Length == 0 || address.Text.Trim().Length == 0 || contactPhno.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please enter all star student info !!";
                AllErrSMS.Visible = true;
                checksign = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (stuid.Text.Trim().Length != 0 )
            {
                if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }

                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Education, Name & Roll No. !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Education & Name !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length != 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Education !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }



                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length != 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length != 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex != 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                        
            }
            else
            {




                if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Id, Education, Name & Roll No. !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Id, Education & Name !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length != 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Id & Education !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex != 0 && stuname.Text.Trim().Length != 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length != 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter Id !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length != 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length != 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length != 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length != 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex != 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex != 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex != 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length != 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == true || Female.Checked == true) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length != 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex == 0 && stuname.Text.Trim().Length != 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
                else if (education.SelectedIndex != 0 && stuname.Text.Trim().Length == 0 && rollno.Text.Trim().Length == 0 && (Male.Checked == false && Female.Checked == false) && dob.Text.Trim().Length == 0 && grade.SelectedIndex == 0 && roomid.SelectedIndex == 0 && cashtype.SelectedIndex == 0 && father.Text.Trim().Length == 0 && mother.Text.Trim().Length == 0 && address.Text.Trim().Length == 0 && contactPhno.Text.Trim().Length == 0)
                {
                    AllErrSMS.Text = "Please enter all Data !!";
                    AllErrSMS.Visible = true;
                    checksign = true;
                }
            }


            
            return checksign;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            dr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            //dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();

            if (!checkValidation())
            {
                string edu = education.SelectedItem.Value;
                dr.EDU_YEAR = edu;
                
                dr.STUDENT_ID = Convert.ToString(stuid.Text); 

                dr.STUDENT_NAME = stuname.Text;

                dr.ROLL_NO = rollno.Text;

                if (Female.Checked == true)
                { dr.GENDER = "Female"; }

                if (Male.Checked == true)
                { dr.GENDER = "Male"; }

                string upFile = (string)(Session["PHOTO_PATH"] ?? " ");
                if (strFileName ==null)
                {
                    dr.PHOTO_PATH = studentpicture.ImageUrl;
                }
                else
                {
                    if (!upFile.Equals(strFileName))
                    {
                       // string str = UploadAndDisplay();
                        if (checkPhoto().Equals(true))
                        { dr.PHOTO_PATH = strFileName; }
                        else
                        {
                            AllErrSMS.Text = "Your Photo is already exist !!";
                            AllErrSMS.Visible = true;
                    
                        }
                    }
                    else
                    {
                        dr.PHOTO_PATH = upFile;
                    }
                }
                //dr[5] = strFileName;
                if (checkAge())
                { dr.DOB = dob.Text; }

                if (stuphone.Text.Trim().Length != 0)
                { dr.PHONE = stuphone.Text; }
                else
                { dr.PHONE = " - "; }

                if (nrcno.Text.Trim().Length != 0)
                {
                    dr.NRC_NO = nrcno.Text;
                }
                else
                {
                    dr.NRC_NO = " - ";
                }

                if (password.Text.Trim().Length != 0)

                { dr.PASSWORD = password.Text; }
                else
                { dr.PASSWORD = " - "; }
                dr.GRADE_ID = int.Parse(grade.SelectedItem.Value);

                dr.ROOM_ID = roomid.SelectedItem.Value;

                dr.CASH_TYPE1 = cashtype.SelectedItem.Value;

                if (cashtype.Text == "Monthly")
                {
                    if (firstmonth.Checked == true)
                        dr.CASH_TYPE2 = "1";
                    if (thirdmonth.Checked == true)
                        dr.CASH_TYPE2 = "3";
                    if (fourmonth.Checked == true)
                        dr.CASH_TYPE2 = "4";
                }
                else
                { dr.CASH_TYPE2 = "-"; }

                dr.FATHER_NAME = father.Text;

                dr.MOTHER_NAME = mother.Text;

                dr.ADDRESS = address.Text;

                dr.CONTACT_PHONE = contactPhno.Text;

                bool isOk = isValidEmail(email.Text);
                if (email.Text != null)
                {
                    if (isOk == true)
                    {
                        dr.EMAIL = email.Text;
                    }
                    else
                    {
                        AllErrSMS.Text = "Enter valid email!!";
                        AllErrSMS.Visible = true;
                    }
                }
                else
                { dr.EMAIL = " - "; }

                dr.UPD_DT_TM = DateTime.Now;
                // dr[23] = delFlag;

                // bool result = stuentry.saveData(dr, "ST_STUDENT_DATA", out msg);
                if (checkAge().Equals(true) && isValidEmail(email.Text).Equals(true) && checkPhoto().Equals(true))
                {
                    bool result = stuentry.updatedata(this.dr, out msg);
                    AllErrSMS.Text = "Your Update is Save Successfully !!";
                    AllErrSMS.Visible = true;
                }
            }
        }

        protected void showlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS004_StudentList.aspx");
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            education.SelectedIndex = 0;
            grade.SelectedIndex = 0;
            cashtype.SelectedIndex = 0;
            stuname.Text = String.Empty;
            stuid.Text = String.Empty;
            stuid.Enabled = true;
            roomid.SelectedIndex = 0;
            rollno.Text = String.Empty;
            father.Text = String.Empty;
            mother.Text = String.Empty;
            contactPhno.Text = String.Empty;
            email.Text = String.Empty;
            password.Text = String.Empty;
            stuphone.Text = String.Empty;
            dob.Text = String.Empty;
            address.Text = String.Empty;
            studentpicture.ImageUrl = "~/Images/Profile.png";
            nrcno.Text = String.Empty;
            firstmonth.Checked = false;
            thirdmonth.Checked = false;
            fourmonth.Checked = false;
            Male.Checked = false;
            Female.Checked = false;
            save.Visible = true;
            AllErrSMS.Visible = false;
        }

       


        private void rebindStudentData(string stuId)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable stuDt = stuentry.getStudentDataById(stuId);
            DataSet.DsPSMS.ST_STUDENT_DATARow editStudent = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            editStudent = stuDt[0];
            education.SelectedIndex = education.Items.IndexOf(education.Items.FindByValue(editStudent.EDU_YEAR));

            stuid.Text = editStudent.STUDENT_ID;

            stuname.Text = editStudent.STUDENT_NAME;

            rollno.Text = editStudent.ROLL_NO;

            string genderss = editStudent.GENDER.ToString();

            if (genderss.Equals("Female"))
            {
                Female.Checked = true;
            }
            if (genderss.Equals("Male"))
            {
                Male.Checked = true;
            }

            studentpicture.ImageUrl = "~/Images/" + editStudent.PHOTO_PATH;

            dob.Text = editStudent.DOB;

            stuphone.Text = editStudent.PHONE;

            nrcno.Text = editStudent.NRC_NO;

            password.Text = editStudent.PASSWORD;

            grade.SelectedIndex = grade.Items.IndexOf(grade.Items.FindByValue(editStudent.GRADE_ID.ToString()));

            roomid.SelectedIndex = roomid.Items.IndexOf(roomid.Items.FindByValue(editStudent.ROOM_ID.ToString()));
            //roomid.Text = editStudent.ROOM_ID;

            father.Text = editStudent.FATHER_NAME;

            mother.Text = editStudent.MOTHER_NAME;

            address.Text = editStudent.ADDRESS;

            contactPhno.Text = editStudent.CONTACT_PHONE;

            email.Text = editStudent.EMAIL;

            cashtype.SelectedIndex = cashtype.Items.IndexOf(cashtype.Items.FindByValue(editStudent.CASH_TYPE1));
            string cashType2 = editStudent.CASH_TYPE2;

            if (cashType2.Equals("1"))
            { firstmonth.Checked = true; }
            if (cashType2.Equals("3"))
            { thirdmonth.Checked = true; }
            if (cashType2.Equals("4"))
            { fourmonth.Checked = true; }
            stuid.Enabled = false;
            save.Visible = false;
        }

        protected void cashtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cashtype.SelectedValue.Equals("Annually"))
            {
                firstmonth.Enabled = false;
                thirdmonth.Enabled = false;
                fourmonth.Enabled = false;
            }
            else if (cashtype.SelectedValue.Equals("Monthly"))
            {
                firstmonth.Enabled = true;
                thirdmonth.Enabled = true;
                fourmonth.Enabled = true;
            }
        }

        
        public void UploadAndDisplay()
        {

             string strPath = "";
             if (FileUpload1.HasFile)
             {
                 AllErrSMS.Visible = false;
                 strFileName = FileUpload1.FileName.ToString();
                 string folderPath = Server.MapPath("~/Images/");
                 strPath = folderPath + strFileName;
                 FileUpload1.PostedFile.SaveAs(strPath);
                 studentpicture.ImageUrl = "~/Images/" + strFileName;
                
             }
             
             
        }

        public bool checkAge()
        {
            string currentYear = DateTime.Now.Year.ToString();
            
            string currentGrade = grade.SelectedItem.Value;

            string[] AgeVal = dob.Text.Split('/');
            string bdYear = AgeVal[2].ToString();

            int bdMonth =Convert.ToInt16( AgeVal[0]);

            int Age = Convert.ToInt16((currentYear)) - Convert.ToInt16((bdYear));

            int month = 5;

            if (grade.SelectedItem.Value == "1" && Age >= 6)
                return true;
            else if (grade.SelectedItem.Value == "2" && Age >= 7)
                return true;
            else if (grade.SelectedItem.Value == "3" && Age >= 8)
                return true;
            else if (grade.SelectedItem.Value == "4" && Age >= 9)
                return true;
            else if (grade.SelectedItem.Value == "5" && Age >= 10)
                return true;
            else if (grade.SelectedItem.Value == "6" && Age >= 11)
                return true;
            else if (grade.SelectedItem.Value == "7" && Age >= 12)
                return true;
            else if (grade.SelectedItem.Value == "8" && Age >= 13)
                return true;
            else if (grade.SelectedItem.Value == "9" && Age >= 14)
                return true;
            else if (grade.SelectedItem.Value == "10" && Age >= 15)
                return true;
            else
            {
                AllErrSMS.Text = "Student should suitable age!! ";
                AllErrSMS.Visible = true;
                return false;
            }

            
        }

        public bool isValidEmail(string email)
        {
            try
            {
                var emailChecked = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                AllErrSMS.Text = "Enter valid email !!";
                AllErrSMS.Visible = true;
                return false;
            }
        }

        public bool checkID()
        {
            bool check = false;
            string studentId = stuid.Text;
            DsPSMS.ST_STUDENT_DATADataTable drID = stuentry.getStudentDataById(studentId);
            if (drID.Rows.Count > 0)
            {
                AllErrSMS.Text = "Student ID is already exist !!";
                AllErrSMS.Visible = true;
                check = false;
            }
            else if (drID.Rows.Count == 0)

            { check = true; }

            return check;
        }

        public bool checkPhoto()
        {
            bool check=false;
            string photo = strFileName;
            
            DsPSMS.ST_STUDENT_DATADataTable drPhoto = stuentry.SearchPhoto(photo);
            if (drPhoto.Rows.Count > 0)
            {
                AllErrSMS.Text = "Photo is already exist !!";
                AllErrSMS.Visible = true;
                check = false;
            }
            else if (drPhoto.Rows.Count == 0)
            {
                check = true;
            }
            return check;


        }

       

       
    }
}



