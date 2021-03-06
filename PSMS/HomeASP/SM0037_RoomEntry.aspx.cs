﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using HomeASP.Service;
namespace HomeASP
{
    public partial class SM0037_RoomEntry : System.Web.UI.Page
    {
        string msg = "";
        string userId;
        static string updateId;
        DsPSMS.ST_ROOM_MSTDataTable roomData = new DsPSMS.ST_ROOM_MSTDataTable();
        DsPSMS.ST_ROOM_MSTRow roomRow = new DsPSMS.ST_ROOM_MSTDataTable().NewST_ROOM_MSTRow();
        RoomService roomService = new RoomService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            else
            {
                userId = "";
            }

           

            showRoomGv();
        }

        protected void showRoomGv()
        {
            roomData = roomService.getAllRoomMST();
            if (roomData != null && roomData.Rows.Count != 0)
            {
                gvRoomList.DataSource = roomData;
                gvRoomList.DataBind();
            }
            else
            {
                gvRoomList.DataSource = new DsPSMS.ST_ROOM_MSTDataTable();
                gvRoomList.DataBind();
            }
        }

        protected void gvRoomList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                alertMsg.Text = "";

                RoomErrorMessage.Visible = false;
                YearErrorMessage.Visible = false;
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "EditCol")
                {

                    RoomErrorMessage.Visible = false;
                    YearErrorMessage.Visible = false;
                    BtnRoomSave.Text = "Edit";
                    ddlRoomyearlist.Text = gvRoomList.Rows[index].Cells[0].Text;
                    updateId = gvRoomList.Rows[index].Cells[1].Text;
                    TxtRoomName.Text = gvRoomList.Rows[index].Cells[2].Text;

                }

                else if (e.CommandName == "DeleteCol")
                {
                    roomRow.ROOM_ID = Convert.ToInt32(gvRoomList.Rows[index].Cells[1].Text);
                    roomRow.ROOM_NAME = gvRoomList.Rows[index].Cells[2].Text;

                    //// to write for confirm message
                    roomService.removeRoomMST(roomRow, out msg);
                    alertMsg.Text = msg;
                    alertMsg.Visible = true;
                    showRoomGv();
                }
            }

            catch (Exception ee)
            {
                string message = ee.Message;
            }
        }

        protected void gvRoomList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showRoomGv();
            gvRoomList.PageIndex = e.NewPageIndex;
            gvRoomList.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RoomErrorMessage.Visible = false;
            YearErrorMessage.Visible = false;
            alertMsg.Visible = false;
            ResetForm();
        }

        protected void ResetForm()
        {
            ddlRoomyearlist.SelectedIndex = 0;
            TxtRoomName.Text = "";
            BtnRoomSave.Text = "Save";
            //alertMsg.Text = " ";
        }

        private bool ChkValidation(DsPSMS.ST_ROOM_MSTRow roomDr)
        {
            bool chkFlag;
              DataSet.DsPSMS.ST_ROOM_MSTDataTable result = roomService.isExistRoomData(roomDr);
                if (result != null && result.Rows.Count > 0)
                {
                    chkFlag = true;
                }
                else
                {
                    chkFlag = false;
                }
                return chkFlag;
        }

        protected void BtnRoomSave_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_ROOM_MSTDataTable roomData = new DsPSMS.ST_ROOM_MSTDataTable();
            DsPSMS.ST_ROOM_MSTRow roomRow = new DsPSMS.ST_ROOM_MSTDataTable().NewST_ROOM_MSTRow();

            roomRow.EDU_YEAR = ddlRoomyearlist.Text;
            roomRow.ROOM_NAME = TxtRoomName.Text;
            roomRow.CRT_DT_TM = DateTime.Now;
            roomRow.CRT_USER_ID = this.userId;

            String edu_y = ddlRoomyearlist.Text;
            String room_n = TxtRoomName.Text.Trim();
                


                if (BtnRoomSave.Text.Equals("Save"))
                {
                    alertMsg.Visible = false;

                    if (edu_y == "Select Year" && room_n == "")
                    {
                        RoomErrorMessage.Visible = true;
                        YearErrorMessage.Visible = true;

                    }

                    else if (edu_y == "Select Year")
                    {
                        RoomErrorMessage.Visible = false;
                        YearErrorMessage.Visible = true;

                    }


                    else if (room_n == "")
                    {
                        RoomErrorMessage.Visible = true;
                        YearErrorMessage.Visible = false;

                    }


                    else if (!ChkValidation(roomRow))
                    {
                        RoomErrorMessage.Visible = false;
                        YearErrorMessage.Visible = false;

                        roomService.SaveRoomMST(roomRow, out msg);
                        alertMsg.Text = msg;
                        alertMsg.Visible = true;
                        ResetForm();
                        showRoomGv();
                    }
                    else
                    {
                        alertMsg.Text = "Record is already exist!!";
                    }


                  
                    showRoomGv();
                }
                else
                {

                    if (edu_y == "Select Year" && room_n == "")
                    {
                        RoomErrorMessage.Visible = true;
                        YearErrorMessage.Visible = true;

                    }

                    else if (edu_y == "Select Year")
                    {
                        RoomErrorMessage.Visible = false;
                        YearErrorMessage.Visible = true;

                    }


                    else if (room_n == "")
                    {
                        RoomErrorMessage.Visible = true;
                        YearErrorMessage.Visible = false;

                    }
                    else if (!ChkValidation(roomRow))
                    {
                        RoomErrorMessage.Visible = false;
                        YearErrorMessage.Visible = false;

                        roomRow.ROOM_ID = int.Parse(updateId);
                        roomService.editRoomMST(roomRow, out msg);
                        alertMsg.Text = msg;
                        ResetForm();
                        showRoomGv();
                    }

                    else {

                        alertMsg.Text = "Record is already exist!!";
                    }

                    showRoomGv();

                }
            

        }

        protected void gvRoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}