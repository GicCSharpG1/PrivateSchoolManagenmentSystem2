using System;
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
    public partial class SM0037_PositionEntry : System.Web.UI.Page
    {
        string msg = "";
        string userId;

       
        DsPSMS.ST_POSITION_MSTDataTable posMstDt = new DsPSMS.ST_POSITION_MSTDataTable();
        DsPSMS.ST_POSITION_MSTRow posMstRow = new DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();
        PositionService posService = new PositionService();

        protected void Page_Load(object sender, EventArgs e)
        {
            showPosGrid();
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            else
            {
                userId = "";
            }
        }

        protected bool Validation(DsPSMS.ST_POSITION_MSTRow dr)
        {
            DsPSMS.ST_POSITION_MSTDataTable posMstDt= new DsPSMS.ST_POSITION_MSTDataTable();
            posMstDt = posService.getPosMstByOption(dr);
            if(posMstDt != null)
            {
                if(posMstDt.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            return false;
         }
                
        protected void showPosGrid()
        {
           
            posMstDt = posService.getAllPosMst(out msg);
            if (posMstDt != null && posMstDt.Rows.Count != 0)
            {
                PosMstList.DataSource = posMstDt;
                PosMstList.DataBind();
            }
            else
            {
                PosMstList.DataSource = posMstDt;
                PosMstList.DataBind();
            }
        }

        protected void PosList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                alertMsg.Text = "";
                if (e.CommandName == "EditCol")
                {
                    poEducation.Text = PosMstList.Rows[index].Cells[0].Text;
                    LabelID.Text = PosMstList.Rows[index].Cells[1].Text;
                    poName.Text = PosMstList.Rows[index].Cells[2].Text;
                    BtnEquipSave.Text = "Edit";
                }

                else if (e.CommandName == "DeleteCol")
                {
                    posMstRow.POSITION_ID = Convert.ToInt32(PosMstList.Rows[index].Cells[1].Text);
                    posMstRow.POSITION_NAME = PosMstList.Rows[index].Cells[2].Text;

                    //// to write for confirm message
                    
                    posService.removePosMst(posMstRow, out msg);
                    showPosGrid();

                    
                }
            }

            catch (Exception ee)
            {
                string message = ee.Message;
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            

            DsPSMS.ST_POSITION_MSTDataTable posDt = new DsPSMS.ST_POSITION_MSTDataTable();
            DsPSMS.ST_POSITION_MSTRow posDr = new DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();

            posDr.EDU_YEAR = poEducation.SelectedItem.Value;
            posDr.POSITION_NAME = poName.Text;

            

            if (Validation(posDr) != true)
            {
                if (BtnEquipSave.Text.Equals("Save"))
                {
                    posDr.CRT_DT_TM = DateTime.Now;
                    posDr.CRT_USER_ID = this.userId;
                    posDr.UPD_DT_TM = DateTime.Now;
                    posDr.UPD_USER_ID = this.userId;
                    posService.SavePositionMST(posDr, out msg);
                    alertMsg.Text = msg;
                }
                else
                {
                    posDr.POSITION_ID = Convert.ToInt32(LabelID.Text);
                    posDr.UPD_DT_TM = DateTime.Now;
                    posDr.UPD_USER_ID = this.userId;
                    posService.editPositionMST(posDr, out msg);
                } 
            }
            else
                alertMsg.Text = "Record is already exist!!";

            showPosGrid();
        }


        protected void confirm_Click(object sender, EventArgs e)
        {
            BtnEquipSave.Text = "Save";
            LabelID.Text = "";
            poEducation.SelectedIndex = 0;
            poName.Text = "";
            alertMsg.Text = "";
            showPosGrid();
        }

        protected void PosList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showPosGrid();
            PosMstList.PageIndex = e.NewPageIndex;
            PosMstList.DataBind();
        }


    }
        
}
  
