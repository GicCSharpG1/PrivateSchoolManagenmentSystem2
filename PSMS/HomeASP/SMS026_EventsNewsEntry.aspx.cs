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

namespace HomeASP
{
    public partial class _SMS026 : System.Web.UI.Page
    {
        string msg = "";
        static string EventPhotoPath;
        static string strFileName;
        EventsAndNewsEntryService service = new EventsAndNewsEntryService();
        DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable dt;
        DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable().NewST_EVENT_NEWS_HEDRow();
        string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                displayEventData();
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                staffpicture.ImageUrl = "~/Images/Profile.png";
            }

            else
            {
                if (FileUpload1.PostedFile != null)
                {
                    UploadAndDisplay();
                    staffpicture.ImageUrl = "~/Images/" + strFileName;
                    EventPhotoPath =strFileName;

                }
            }
            
            
            
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
        }
        private Boolean checkValidationForEvents()
        {
            Boolean isError = false;
            if (edate.Text.Trim().Length == 0)
            {
                 errSmsDa.Text = "Please Choose Date";
                errSmsDa.Visible = true;
                isError = true;
            }
            else
            {
                errSmsDa.Visible = false;
            }


            if (name.Text.Trim().Length == 0)
            {
                errSmsDa.Text = "Please Enter name";
                errSmsDa.Visible = true;
                isError = true;
            }
            else
            {
                errSmsDa.Visible = false;
            }


            if (News.Checked == false && Event.Checked == false)
            {
                //errType.Text = "Please check Type";
                //errType.Visible = true;
                isError = true;
            }
            else
            {
                //errType.Visible = false;
            }

            if (grade.SelectedIndex == 0)
            {
                errSmsDa.Text = "Please Choose Grade";
                errSmsDa.Visible = true;
                isError = true;
            }
            else
            {
                errSmsDa.Visible = false;
            }


            if (room.SelectedIndex == 0)
            {
                errSmsDa.Text = "Please Choose Room ";
                errSmsDa.Visible = true;
                isError = true;
            }
            else
            {
                errSmsDa.Visible = false;
            }

            if (enEducation.SelectedIndex == 0)
            {
                errSmsDa.Text = "Please Choose Year";
                errSmsDa.Visible = true;
                isError = true;
            }
            else
            {
                errSmsDa.Visible = false;
            }

            //if (imgUpload.HasFile == false)Hwp
            //{
            //   // errPhoto.Text = "Please Enter Photo";
            //    //errPhoto.Visible = true;
            //    isError = true;
            //}
            //else
            //{
            //   // errPhoto.Visible = false;

            //}
           
            return isError;
        }

        //protected bool Validation(DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        //{


        //  //  DsPSMS.ST_POSITION_MSTDataTable posMstDt = new DsPSMS.ST_POSITION_MSTDataTable();
        //    DsPSMS.ST_EVENT_NEWS_HEDDataTable evMstDt = new DsPSMS.ST_EVENT_NEWS_HEDDataTable();
        //    evMstDt = service.getENMstByOption(dr);
        //    if (evMstDt != null)
        //    {
        //        if (evMstDt.Rows.Count == 0)
        //            return false;
        //        else
        //            return true;
        //    }
        //    return false;
        //}


        protected bool SaEdValidation(DsPSMS.ST_EVENT_NEWS_HEDRow dr)
        {

            bool reFLag;
            DsPSMS.ST_EVENT_NEWS_HEDDataTable EvNewDt = new DsPSMS.ST_EVENT_NEWS_HEDDataTable();
            EvNewDt = service.getEventNNByOption(dr);
            if (EvNewDt != null)
            {
                reFLag = true;

                //if (EvNewDt.Rows.Count == 0)
                //    return false;
                //else
                //    return true;
            }

            //return false;
            else
            {
                reFLag = false;
            }

            return reFLag;
        }


        //save data
        protected void add_Click(object sender, EventArgs e)
        {

            dr = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable().NewST_EVENT_NEWS_HEDRow();

            if (!checkValidationForEvents())
            {



                if (add.Text.Equals("Save"))
                {
                    dr.EDU_YEAR = enEducation.SelectedItem.Value;
                    
                    dr.DATE = edate.Text;
                    dr.NAME = name.Text;
                    dr.GRADE_ID = grade.SelectedItem.Value;
                    dr.ROOM_ID = room.SelectedItem.Value;
                    if (News.Checked == true)
                    { dr.TYPE = "News"; }
                    if (Event.Checked == true)
                    { dr.TYPE = "Event"; }


                    dr.PHOTO_PATH = EventPhotoPath;
                    dr.CRT_DT_TM = DateTime.Now;
                    dr.CRT_USER_ID = this.userId;
                    service.saveEvent(dr, out msg);
                    errSmsRe.Text = msg;
                    add.Text = "Save";
                    LabelID.Text = "";

                    errSmsRe.Text = "Insert Successful";

                    edate.Text = String.Empty;
                    name.Text = String.Empty;
                    grade.SelectedIndex = 0;
                    room.SelectedIndex = 0;
                    enEducation.SelectedIndex = 0;
                    staffpicture.ImageUrl = "";
                    News.Checked = false;
                    Event.Checked = false;
                    displayEventData();
                   
                    
                }
                else if (add.Text.Equals("Edit"))
                {
                    dr.EDU_YEAR = enEducation.SelectedItem.Value;

                    dr.DATE = edate.Text;
                    dr.NAME = name.Text;
                    dr.GRADE_ID = grade.SelectedItem.Value;
                    dr.ROOM_ID = room.SelectedItem.Value;
                    if (News.Checked == true)
                    { dr.TYPE = "News"; }
                    if (Event.Checked == true)
                    { dr.TYPE = "Event"; }


                    dr.PHOTO_PATH = EventPhotoPath;

                    dr.ID = Convert.ToInt32(LabelID.Text);
                    dr.UPD_DT_TM = DateTime.Now;
                    dr.UPD_USER_ID = this.userId;
                    service.updateEvent(dr, out msg);
                    errSmsRe.Text = msg;

                    add.Text = "Save";
                    LabelID.Text = "";

                    errSmsRe.Text = "Update Successful";

                    edate.Text = String.Empty;
                    name.Text = String.Empty;
                    grade.SelectedIndex = 0;
                    room.SelectedIndex = 0;
                    enEducation.SelectedIndex = 0;
                    staffpicture.ImageUrl = "";
                    News.Checked = false;
                    Event.Checked = false;
                    displayEventData();
                    
                }

                else

                    errSmsRe.Text = "Record is already exist!!";
            }

                 
                 displayEventData();
            
                   
            
        }
       


        // for update
        protected void confirm_Click(object sender, EventArgs e)
        {

            add.Text = "Save";
            LabelID.Text = "";
           
            errSmsRe.Text = "";
         
            edate.Text = String.Empty;
            name.Text = String.Empty;
            grade.SelectedIndex = 0;
            room.SelectedIndex = 0;
            enEducation.SelectedIndex = 0;
            staffpicture.ImageUrl = "";
            News.Checked = false;
            Event.Checked = false;
            displayEventData();
        }




        private void displayEventData()
        {
            DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable resultDt = service.getAllEventData(out msg);
            gridViewEvent.DataSource = null;
            gridViewEvent.DataBind();
            if (resultDt != null)
            {
                gridViewEvent.DataSource = resultDt;
                gridViewEvent.DataBind();
            }

            else
            {
                gridViewEvent.DataSource = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable();
                gridViewEvent.DataBind();
            }
        }


        protected void EventNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                errSmsRe.Text = "";
                if (e.CommandName == "EditCol")
                {
                    btnConfirm.Enabled = true;
                    
                    enEducation.Text = gridViewEvent.Rows[index].Cells[0].Text;
                    LabelID.Text = gridViewEvent.Rows[index].Cells[1].Text;
                    edate.Text = gridViewEvent.Rows[index].Cells[2].Text;
                    name.Text = gridViewEvent.Rows[index].Cells[3].Text;
                    grade.Text = gridViewEvent.Rows[index].Cells[4].Text;
                    room.Text = gridViewEvent.Rows[index].Cells[5].Text;

                    
                    string strnew = gridViewEvent.Rows[index].Cells[6].Text;
                    if (strnew.Equals("News"))
                    {
                        News.Checked = true;
                    }

                    
                    string strEvent = gridViewEvent.Rows[index].Cells[6].Text;
                    if (strEvent.Equals("Event"))
                    {
                        Event.Checked = true;
                    }


                    EventPhotoPath = gridViewEvent.Rows[index].Cells[7].Text;
                    displayEventData();
                    
                    staffpicture.ImageUrl = EventPhotoPath;
                    
                    EventPhotoPath = staffpicture.ImageUrl;
                    
                        //AllErrSMS.Visible = false;
                        //strFileName = FileUpload1.FileName.ToString();
                        //string folderPath = Server.MapPath("~/Images/");
                        //string strPath = folderPath +EventPhotoPath;
                        //staffpicture.ImageUrl = strPath;
                        UploadAndDisplay2(EventPhotoPath);
                    
                        
                        
                       
                    
                    add.Text = "Edit";
                   
                }

                else if (e.CommandName == "DeleteCol")
                {
                    dr.ID = Convert.ToInt32(gridViewEvent.Rows[index].Cells[1].Text);
                    dr.NAME = gridViewEvent.Rows[index].Cells[3].Text;

                    //// to write for confirm message

                    service.deleteEvent(dr, out msg);
                    displayEventData();


                }
            }

            catch (Exception ee)
            {
                string message = ee.Message;
            }
        }



       

        protected void room_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayEventData();
        }
        public void UploadAndDisplay()
        {

            if (FileUpload1.HasFile)
            {
                //AllErrSMS.Visible = false;
                strFileName = FileUpload1.FileName.ToString();
                string folderPath = Server.MapPath("~/Images/");
                string strPath = folderPath + strFileName;
                FileUpload1.PostedFile.SaveAs(strPath);
                staffpicture.ImageUrl = "~/Images/" + strFileName;
            }
            else {
                
            }

        }
        public void UploadAndDisplay2(String path)
        {
            strFileName = path;
            string folderPath = Server.MapPath("~/Images/");
            string strPath = folderPath + strFileName;
            //FileUpload1.PostedFile.SaveAs(strPath);
            staffpicture.ImageUrl = "~/Images/" + strFileName;
        }

        //protected void photoUpload_Click(object sender, EventArgs e)hwp
        //{
        //    EventPhotoPath = imgUpload.FileName;
        //    if (imgUpload.PostedFile != null)
        //    {
        //        string extension = Path.GetExtension(EventPhotoPath);
        //        if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
        //        {
        //            Stream strm = imgUpload.PostedFile.InputStream;
        //            using (var image = System.Drawing.Image.FromStream(strm))
        //            {
        //                //Label2.Text = image.Size.ToString();
        //                int newWidth = 170;
        //                int newHeight = 170;

        //                if (image.Width >= newWidth && image.Height >= newHeight)
        //                {
        //                    errMessage.Visible = false;

        //                    int originWidth = image.Width;
        //                    int originHeight = image.Height;
        //                    //int ratio = originWidth % originHeight;
        //                    //int newHeight = newWidth / ratio;

        //                    if (originWidth > newWidth)
        //                    {
        //                        Decimal ratio = Math.Abs((Decimal)originWidth / (Decimal)newWidth);
        //                        originWidth = newWidth;
        //                        originHeight = (int)Math.Round((Decimal)(originHeight / ratio));
        //                    }

        //                    if (originHeight > newHeight)
        //                    {
        //                        Decimal ratio = Math.Abs((Decimal)originHeight / (Decimal)newHeight);
        //                        originHeight = newHeight;
        //                        originWidth = (int)Math.Round((Decimal)(originWidth / ratio));
        //                    }

        //                    var thumbImg = new Bitmap(originWidth, originHeight);
        //                    var thumbGraph = Graphics.FromImage(thumbImg);


        //                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        //                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        //                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //                    var imgRectangle = new Rectangle(0, 0, originWidth, originHeight);
        //                    thumbGraph.DrawImage(image, imgRectangle);

        //                    string targetPath = Server.MapPath(@"~/Images/") + EventPhotoPath;
        //                    thumbImg.Save(targetPath, image.RawFormat);

        //                    //Label3.Text = thumbImg.Size.ToString();
        //                    eventphoto.ImageUrl = "~/Images/" + EventPhotoPath;
        //                }
        //                else
        //                {
        //                    eventphoto.Visible = true;
        //                    //errphotosize.Text = "Input Image is too small. Please try again";
        //                }
        //            }


        //        }
        //    }

        //}

        protected void EventNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            displayEventData();
            gridViewEvent.PageIndex = e.NewPageIndex;
            gridViewEvent.DataBind();
        }

        protected void gridViewEvent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        


        

    }
}