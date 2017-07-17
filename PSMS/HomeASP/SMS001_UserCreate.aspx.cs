using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DbAccess;
using System.Data.SqlClient;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS001 : System.Web.UI.Page
    {
        String tbname = "ST_USER_MST";
        private string msg = "";
        UserEntryService service = new UserEntryService();
        DataSet.DsPSMS.ST_USER_MSTRow userRow = new DataSet.DsPSMS.ST_USER_MSTDataTable().NewST_USER_MSTRow();
        static string loginUserId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            if (!IsPostBack)
            {
                txtUname.Text = "";
                txtPassword.Text = "";
                txtCpassword.Text = "";
            }
            if (Session["LOGIN_USER_ID"] != null)
            {
                loginUserId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            userRow.USER_NAME = txtUname.Text;
            userRow.PASSWORD = txtPassword.Text;
            userRow.USER_TYPE = ddlUserLevel.Text;
            userRow.CRT_DT_TM = DateTime.Now;
            userRow.CRT_USER_ID = loginUserId;
            userRow.DEL_FLG = 0;

            bool isOk = service.saveUser(userRow, tbname, out msg);
            DisplayUser();
        }

        private void DisplayUser()
        {
            DataSet.DsPSMS.ST_USER_MSTDataTable resultDt = service.getAllUsers(out msg);

            if (resultDt != null)
            {
                GridViewUser.DataSource = resultDt;
                GridViewUser.DataBind();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUname.Text = "";
            txtPassword.Text = "";
            txtCpassword.Text = "";
            ddlUserLevel.SelectedIndex = 0;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            msg = "";
            userRow.USER_NAME = txtUname.Text;
            userRow.PASSWORD = txtPassword.Text;
            userRow.USER_TYPE = ddlUserLevel.Text;
            userRow.USER_ID = Convert.ToInt16(btnUpdate.CommandName);
            userRow.UPD_USER_ID = loginUserId;
            userRow.UPD_DT_TM = DateTime.Now;
            bool isOk = service.updateUser(userRow, out msg);
            DisplayUser();
            txtUname.Text = "";
            txtPassword.Attributes["value"] = "";
            txtCpassword.Attributes["value"] = "";
            ddlUserLevel.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int deleteUserId = Convert.ToInt16(btn.CommandName);
            userRow = new DataSet.DsPSMS.ST_USER_MSTDataTable().NewST_USER_MSTRow();
            userRow.USER_ID = deleteUserId;
            userRow.DEL_FLG = 1;
            bool isOk = service.deleteUser(deleteUserId, out msg);
            DisplayUser();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            DisplayUser();
        }

        //protected override void Render(System.Web.UI.HtmlTextWriter textWriter)
        //{
        //    foreach (GridViewRow gvRow in GridViewUser.Rows)
        //    {
        //        if (gvRow.RowType == DataControlRowType.DataRow)
        //        {
        //            gvRow.Attributes["onmouseover"] =
        //               "this.style.cursor='hand';";
        //            gvRow.Attributes["onmouseout"] =
        //               "this.style.textDecoration='none';";
        //            gvRow.Attributes["onclick"] =
        //             ClientScript.GetPostBackClientHyperlink(GridViewUser, "Select$" + gvRow.RowIndex, true);
        //        }
        //    }
        //    base.Render(textWriter);
        //}

        //protected void GridViewSelected(object sender, EventArgs e)
        //{

        //    txtUname.Text = GridViewUser.SelectedRow.Cells[1].Text;
        //    txtPassword.Text = GridViewUser.SelectedRow.Cells[2].Text;
        //   // DropDownList.Text = GridViewUser.SelectedRow.Cells[3].Text;
        //}

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            LinkButton btn = (LinkButton)(sender);
            int editUserId = Convert.ToInt16(btn.CommandName);
            btnUpdate.CommandName = btn.CommandName;
            userRow = new DataSet.DsPSMS.ST_USER_MSTDataTable().NewST_USER_MSTRow();
            DataSet.DsPSMS.ST_USER_MSTDataTable userData = service.getUserById(editUserId, out msg);

            txtUname.Text = userData.Rows[0]["USER_NAME"].ToString();
            txtPassword.Attributes.Add("value", userData.Rows[0]["PASSWORD"].ToString());
            txtCpassword.Attributes.Add("value", userData.Rows[0]["PASSWORD"].ToString());
            if (userData.Rows[0]["USER_TYPE"].Equals("User"))
                ddlUserLevel.SelectedIndex = 1;
            else
                ddlUserLevel.SelectedIndex = 2;
        }

        protected void GridViewUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUser.PageIndex = e.NewPageIndex;
            DisplayUser();
            GridViewUser.DataBind();
        }
    }
}
