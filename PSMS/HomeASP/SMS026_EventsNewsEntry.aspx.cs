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
    public partial class SMS026 : System.Web.UI.Page
    {
        string msg = "";
        static string EventPhotoPath;
        EventsAndNewsEntryService service = new EventsAndNewsEntryService();
        DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable dt;
        DataSet.DsPSMS.ST_EVENT_NEWS_HEDRow dr = new DataSet.DsPSMS.ST_EVENT_NEWS_HEDDataTable().NewST_EVENT_NEWS_HEDRow();
        string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            eventphoto.ImageUrl = "~/Images/" + EventPhotoPath;
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            displayEventData();
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
                errDate.Text = "Please enter Date";
                errDate.Visible = true;
                isError = true;
            }
            else
            {
                errDate.Visible = false;
            }


            if (name.Text.Trim().Length == 0)
            {
                errName.Text = "Please enter Name";
                errName.Visible = true;
                isError = true;
            }
            else
            {
                errName.Visible = false;
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
                errgrade.Text = "Please Choose Grade";
                errgrade.Visible = true;
                isError = true;
            }
            else
            {
                errgrade.Visible = false;
            }


            if (room.SelectedIndex == 0)
            {
                errRoom.Text = "Please Choose Room ";
                errRoom.Visible = true;
                isError = true;
            }
            else
            {
                errRoom.Visible = false;
            }

            if (enEducation.SelectedIndex == 0)
            {
                errEduYear.Text = "Please Choose Year";
                errEduYear.Visible = true;
                isError = true;
            }
            else
            {
                errEduYear.Visible = false;
            }

            if (imgUpload.HasFile == false)
            {
               // errPhoto.Text = "Please Enter Photo";
                //errPhoto.Visible = true;
                isError = true;
            }
            else
            {
               // errPhoto.Visible = false;

            }
           
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
                    alertMsg.Text = msg;
                    
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
                    alertMsg.Text = msg;
                    
                }

                else

                    alertMsg.Text = "Record is already exist!!";
            }

                 
                 displayEventData();
            
                   
            
        }
       


        // for update
        protected void confirm_Click(object sender, EventArgs e)
        {

            add.Text = "Save";
            LabelID.Text = "";
           
            alertMsg.Text = "";
         
            edate.Text = String.Empty;
            name.Text = String.Empty;
            grade.SelectedIndex = 0;
            room.SelectedIndex = 0;
            enEducation.SelectedIndex = 0;
            eventphoto.ImageUrl = "";
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
                alertMsg.Text = "";
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
                    eventphoto.ImageUrl = "~/Images/" + EventPhotoPath;
                    add.Text = "Edit";
                    displayEventData();
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

        protected void photoUpload_Click(object sender, EventArgs e)
        {
            EventPhotoPath = imgUpload.FileName;
            if (imgUpload.PostedFile != null)
            {
                string extension = Path.GetExtension(EventPhotoPath);
                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                {
                    Stream strm = imgUpload.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        //Label2.Text = image.Size.ToString();
                        int newWidth = 170;
                        int newHeight = 170;

                        if (image.Width >= newWidth && image.Height >= newHeight)
                        {
                            errMessage.Visible = false;

                            int originWidth = image.Width;
                            int originHeight = image.Height;
                            //int ratio = originWidth % originHeight;
                            //int newHeight = newWidth / ratio;

                            if (originWidth > newWidth)
                            {
                                Decimal ratio = Math.Abs((Decimal)originWidth / (Decimal)newWidth);
                                originWidth = newWidth;
                                originHeight = (int)Math.Round((Decimal)(originHeight / ratio));
                            }

                            if (originHeight > newHeight)
                            {
                                Decimal ratio = Math.Abs((Decimal)originHeight / (Decimal)newHeight);
                                originHeight = newHeight;
                                originWidth = (int)Math.Round((Decimal)(originWidth / ratio));
                            }

                            var thumbImg = new Bitmap(originWidth, originHeight);
                            var thumbGraph = Graphics.FromImage(thumbImg);


                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imgRectangle = new Rectangle(0, 0, originWidth, originHeight);
                            thumbGraph.DrawImage(image, imgRectangle);

                            string targetPath = Server.MapPath(@"~/Images/") + EventPhotoPath;
                            thumbImg.Save(targetPath, image.RawFormat);

                            //Label3.Text = thumbImg.Size.ToString();
                            eventphoto.ImageUrl = "~/Images/" + EventPhotoPath;
                        }
                        else
                        {
                            eventphoto.Visible = true;
                            //errphotosize.Text = "Input Image is too small. Please try again";
                        }
                    }


                }
            }

        }

        protected void EventNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            displayEventData();
            gridViewEvent.PageIndex = e.NewPageIndex;
            gridViewEvent.DataBind();
        }

        

    }
}