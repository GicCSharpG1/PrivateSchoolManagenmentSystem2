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
using System.Globalization;


namespace HomeASP
{
    public partial class SMS023 : System.Web.UI.Page
    {
        string msg = "";
        static string userId = "";
        static string strFileName;
        DsPSMS.ST_EXP_HEDDataTable ExpHedDt = new DsPSMS.ST_EXP_HEDDataTable();
        DsPSMS.ST_EXP_HEDRow expHedDr = new DsPSMS.ST_EXP_HEDDataTable().NewST_EXP_HEDRow();
        ExpanseService expService = new ExpanseService();

        //StaffEntryService service = new StaffEntryService();
        StaffService service = new StaffService();
        PositionService pService = new PositionService();
        DataSet.DsPSMS.ST_STAFF_DATADataTable dt;
        DataSet.DsPSMS.ST_STAFF_DATARow dr=new DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();

        protected void Page_Load(object sender, EventArgs e)
        {
            AllErrSMS.Visible = false;
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            staffpicture.ImageUrl = "~/Images/" + strFileName;

            if (FileUpload1.PostedFile != null)
            {
                UploadAndDisplay();
                staffpicture.ImageUrl = "~/Images/" + strFileName;

            }

            if (!IsPostBack)
            {
                
                staffpicture.ImageUrl = " ~/Images/" + strFileName;
                if (posID.Items.Count == 0)
                {
                    FillPositionListCombo();
                }

                if (Session["LOGIN_USER_ID"] != null)
                {
                    userId = (string)(Session["LOGIN_USER_ID"] ?? " ");
                   
                }
                if (Session["STAFF_ID"] != null)
                {
                    string staffId = (string)(Session["STAFF_ID"] ?? " ");
                    dr.STAFF_ID = staffId;
                    rebindStaffData(dr);
                }

                
            }
        }

        private Boolean checkValidationForPosition()
        {
            Boolean isError = false;
            if (stfID.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (stfname.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (posID.SelectedIndex == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (staffEduYear.SelectedIndex == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (Male.Checked == false && Female.Checked == false)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }


            if (dob.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (nrcno.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (Single.Checked == false && Married.Checked == false)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (education.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (phone.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (address.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }

            if (salary.Text.Trim().Length == 0)
            {
                AllErrSMS.Text = "Please input require field!";
                AllErrSMS.Visible = true;
                isError = true;
            }
            else
            {
                AllErrSMS.Visible = false;
            }
            return isError;
        }



        protected void BtnSave_Click(object sender, EventArgs e)
        {
            dr = new DataSet.DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();
            
           
            if (!checkValidationForPosition())
            {
                
                string edu = staffEduYear.SelectedItem.Value;
                dr[0] = edu;
                dr[1] = Convert.ToString(stfID.Text);
                dr[2] = posID.SelectedItem.Value;
                dr[3] = stfname.Text;
                if (Female.Checked == true)
                { dr[4] = "Female"; }
                if (Male.Checked == true)
                { dr[4] = "Male"; }

                dr[5] = phone.Text;
                //DateTime Test;
               // if (DateTime.TryParseExact(dob.Text, "MM/dd/yyyy", null, DateTimeStyles.None, out Test) == true)
                  //  Response.Write("Date OK");
                //else
                   // Response.Write("Date Not OK");
   
               dr[6] = dob.Text;
                
                         
                dr[7] = nrcno.Text;
                if (Single.Checked == true)
                { dr[8] = "Single"; }
                if (Married.Checked == true)
                { dr[8] = "Single"; }

                dr[9] = address.Text;
                dr[10] = education.Text;

                dr[11] = strFileName;
                dr[12] = salary.Text; 
                
                dr[13] = DateTime.Now;               
                dr[14] = userId;
                dr[17] = 0;
                bool result = service.saveStaff(dr, out msg);


                AllErrSMS.Text = "Your Entry is Successful!!";
                AllErrSMS.Visible = true;
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dr = new DataSet.DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();
            if (!checkValidationForPosition())
            {
                 string edu = staffEduYear.SelectedItem.Value;
                dr[0] = edu;
                dr[1] = Convert.ToString(stfID.Text);
                dr[2] = posID.SelectedItem.Value;
                dr[3] = stfname.Text;
                if (Female.Checked == true)
                { dr[4] = "Female"; }
                if (Male.Checked == true)
                { dr[4] = "Male"; }

                dr[5] = phone.Text;
                dr[6] = dob.Text;
                dr[7] = nrcno.Text;
                if (Single.Checked == true)
                { dr[8] = "Single"; }
                if (Married.Checked == true)
                { dr[8] = "Single"; }

                dr[9] = address.Text;
                dr[10] = education.Text;

                //dr[11] =staffFile;

                string upFile = (string)(Session["PHOTO_PATH"] ?? " ");
                if (strFileName == "")
                {
                    dr.PHOTO_PATH = upFile;
                }
                else
                {
                    if (!upFile.Equals(strFileName))
                    {
                        //string str = getFilePath();
                        dr.PHOTO_PATH = strFileName;
                    }
                    else
                    {
                        dr.PHOTO_PATH = upFile;
                    }
                }
                dr[12] = salary.Text;
                dr[13] = DateTime.Now;
                dr[14] = "";
               
                bool result = service.updateStaff(this.dr, out msg);


                AllErrSMS.Text = "Your Update is Successfull!!";
                AllErrSMS.Visible = true;
            }
        }
                
                     
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            stfname.Text = String.Empty;
            stfID.Text = String.Empty;
            posID.SelectedIndex = 0;
            dob.Text = String.Empty;
            nrcno.Text = String.Empty;
            education.Text = String.Empty;
            phone.Text = String.Empty;
            address.Text = String.Empty;
            salary.Text = String.Empty;
            posID.SelectedIndex = 0;
            staffEduYear.SelectedIndex = 0;
            staffpicture.ImageUrl = "~/Images/Profile.png";
            Male.Checked = false;
            Female.Checked = false;
            Single.Checked = false;
            Married.Checked = false;
           
            add.Visible = true;

        }

      void FillPositionListCombo()
       {
            posID.Items.Clear();
            DataSet.DsPSMS.ST_POSITION_MSTDataTable resultDt = pService.getAllPosMst(out msg);


                posID.DataSource = resultDt;
                posID.DataTextField = "POSITION_NAME";
                posID.DataValueField = "POSITION_ID";
                posID.DataBind();
                
                posID.Items.Insert(0, new ListItem("Choose Position", "0"));
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
                staffpicture.ImageUrl = "~/Images/" + strFileName;
            }

        }


        private void rebindStaffData(DataSet.DsPSMS.ST_STAFF_DATARow dr)
       {
           DataSet.DsPSMS.ST_STAFF_DATADataTable staDt = new DsPSMS.ST_STAFF_DATADataTable();
           staDt = service.selectStaffByID(dr);
           DataSet.DsPSMS.ST_STAFF_DATARow editStaff = staDt[0];
           staffEduYear.SelectedIndex = staffEduYear.Items.IndexOf(staffEduYear.Items.FindByValue(editStaff.EDU_YEAR));
           stfID.Text = editStaff.STAFF_ID;
           stfname.Text = editStaff.STAFF_NAME;
           string gender = editStaff.GENDER;
                     
            if (gender.Equals("Female"))
           {
               Female.Checked = true;
           }
           else
           {
               Male.Checked = true;
           }

            string Msingle = editStaff.MARRIED_STATUS;
            if (Msingle.Equals("Single"))
            {
                Single.Checked = true;
            }
            else
            {
                Married.Checked = true;
            }

            posID.SelectedIndex = posID.Items.IndexOf(posID.Items.FindByValue(editStaff.POSITION_ID));

            staffpicture.ImageUrl = "~/Images/" + editStaff.PHOTO_PATH;
            dob.Text = editStaff.DOB;
            phone.Text = editStaff.PHONE;
            education.Text = editStaff.EDUCATION;
           nrcno.Text = editStaff.NRC_NO;
                      
           address.Text = editStaff.ADDRESS;

           salary.Text = Convert.ToString(editStaff.SALARY);
           update.Enabled = true; 
           add.Visible = false;
     }



       protected void showStafflist_Click(object sender, EventArgs e)
       {
           Response.Redirect("SMS024_StaffList.aspx");

       }
       
    }
}