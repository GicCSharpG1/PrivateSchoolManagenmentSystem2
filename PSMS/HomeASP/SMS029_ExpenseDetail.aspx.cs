using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS029 : System.Web.UI.Page
    {

        DsPSMS.ST_EXP_DETAILRow expDetDr = new DsPSMS.ST_EXP_DETAILDataTable().NewST_EXP_DETAILRow();
        ExpanseService expService = new ExpanseService();
        string msg = "";
        int index;
        string amount;
        string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            { BtnConfirm.Enabled = false; }
            errSMS.Visible = false;
           txtExpIDVal.Enabled = false;
           ErroRYear.Visible = false;

            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
            if (Session["EXP_ID"] != null)
            {
                txtExpIDVal.Text = (string)(Session["EXP_ID"] ?? "  ");
            }
            if (Session["EDU_YEAR"] != null)
            {
                CoboYear.Text = (string)(Session["EDU_YEAR"] ?? "  ");
            }
            showExpHedGv();
        }

        protected bool Validation(DsPSMS.ST_EXP_DETAILRow dr)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            expDetDt = expService.getExpDetDataByOption(dr, out msg);
            if (expDetDt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "DetailCol")
                {

                }
                else if (e.CommandName == "EditCol")
                {
                    BtnConfirm.Enabled = true;
                    BtnPay.Enabled = false;
                    errNum.Visible = false;
                    //txtExpIDVal.Text = expDetList.Rows[index].Cells[0].Text;
                   
                    if (expDetList.Rows[index].Cells[1].Text == "&nbsp;")
                    {

                        TxtExpSubTitle.Text = "";
                    }
                    else {
                        TxtExpSubTitle.Text = expDetList.Rows[index].Cells[1].Text;
                    
                    }
                    TxtAmt.Text = expDetList.Rows[index].Cells[2].Text;
                    temp.Text = expDetList.Rows[index].Cells[0].Text;
                }

                else if (e.CommandName == "DeleteCol")
                {

                    expDetDr.EXP_ID = Convert.ToInt16(expDetList.Rows[index].Cells[0].Text);
                    expDetDr.EXP_SUB_TITLE = expDetList.Rows[index].Cells[1].Text;
                    expDetDr.AMOUNT = expDetList.Rows[index].Cells[2].Text;
                    expService.deleteExpDet(expDetDr, out msg);
                    errNum.Text = msg;
                    errNum.Visible = true;
                    DataTable ds = new DataTable();
                    ds = null;
                    expDetList.DataSource = ds;
                    expDetList.DataBind();

                    showExpHedGv();
                }
            }
            catch
            {
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            expDetDr.EXP_ID = Convert.ToInt16(txtExpIDVal.Text);
            expDetDr.EXP_SUB_TITLE = TxtExpSubTitle.Text;
            expDetDr.AMOUNT = TxtAmt.Text;
            expDetDr.CRT_DT_TM = DateTime.Now;
            expDetDr.CRT_USER_ID = this.userId;
            expDetDr.UPD_DT_TM = DateTime.Now;
            expDetDr.UPD_USER_ID = "";
            expDetDr.DEL_FLG = 0;
            int result;
            String error_y;
            String error_a;
            error_y = CoboYear.Text;
            error_a = TxtAmt.Text;

            if (error_y == "Choose Education Year" && error_a == "")
            {
                ErroRYear.Visible = true;
                errNum.Text = "Add Amount";
                errNum.Visible = true;


            }

            else if(error_a==""){

                ErroRYear.Visible = false;

                errNum.Text = "Add Amount";
                errNum.Visible = true;
            }
            else if (error_y == "Choose Education Year")
            {

                ErroRYear.Visible = true;

                errNum.Visible = false;
            }



            else
            {
                if (int.TryParse(TxtAmt.Text, out result))
                {
                    if (Validation(expDetDr) != true)
                    {
                        expService.SaveExpDetInfo(expDetDr, out msg);
                        CoboYear.Text = null ;
                        TxtAmt.Text = "";
                        TxtExpSubTitle.Text = "";
                        errNum.Text = msg;
                        errNum.Visible = true;
                        showExpHedGv();
                    }
                    else
                    {
                        errSMS.Text = "This record already exist in this vouncher!!!";
                        errSMS.Visible = true;
                        showExpHedGv();
                    }
                }


                else
                {
                    errNum.Text = "Please Enter Number only!!";
                }
            }
        }

        protected void showExpHedGv()
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            if (txtExpIDVal.Text.Trim().Length != 0)
            {
                int expId = Convert.ToInt32(txtExpIDVal.Text);
                expDetDt = expService.getExpDetDataById(expId, out msg);
                if (expDetDt != null)
                {
                    expDetDt.Columns.Remove(expDetDt.Columns[4]);
                    expDetDt.Columns.Remove(expDetDt.Columns[4]);
                    expDetDt.Columns.Remove(expDetDt.Columns[4]);
                    expDetDt.Columns.Remove(expDetDt.Columns[4]);
                    expDetList.DataSource = expDetDt;
                    expDetList.DataBind();
                }
                else
                {
                    expDetList.DataSource = expDetDt;
                    expDetList.DataBind();
                }
            }
            else
            {
                expDetList.DataSource = expDetDt;
                expDetList.DataBind();
            }

        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(temp.Text);
            expDetDr.EXP_ID = Convert.ToInt16(txtExpIDVal.Text);
            expDetDr.EXP_SUB_TITLE = TxtExpSubTitle.Text;
            expDetDr.AMOUNT = TxtAmt.Text;
            expDetDr.UPD_DT_TM = DateTime.Now;
            expDetDr.UPD_USER_ID = this.userId;

            String error_y;
            String error_a;
            error_y = CoboYear.Text;
            error_a = TxtAmt.Text;

            if (error_y == "Choose Education Year" && error_a == "")
            {
                ErroRYear.Visible = true;
                errNum.Text = "Add Amount";
                errNum.Visible = true;
               

            }

            else if (error_a == "")
            {

                ErroRYear.Visible = false;

                errNum.Text = "Add Amount";
                errNum.Visible = true;
            }
            else if (error_y == "Choose Education Year")
            {

                ErroRYear.Visible = true;

                errNum.Visible = false;
            }


            else
            {
                if (Validation(expDetDr) != true)
                {
                    expService.updateExpDetInfo(expDetDr, id, out msg);
                    showExpHedGv();
                    errNum.Text = msg;
                    errNum.Visible = true;
                    BtnPay.Enabled = true;
                    BtnConfirm.Enabled = false;
                    CoboYear.Text = null;
                    TxtExpSubTitle.Text = "";
                    TxtAmt.Text = "";
                }
                     
                else
                {
                    errSMS.Text = "This record already exist in this vouncher!!!";
                    showExpHedGv();
                }
               
            }
            
        }

        protected void expDetList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void expDetList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            showExpHedGv();
              expDetList.PageIndex=e.NewPageIndex;
           expDetList.DataBind();
        }


    }
}