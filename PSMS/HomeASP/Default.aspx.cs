using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;

namespace HomeASP
{
    public partial class _Default : Page
    {
        UserEntryService service = new UserEntryService();
        DataSet.DsPSMS.ST_USER_MSTRow stdRow = null;
        String msg = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMsg.Visible = false;
            Session.Remove("LOGIN_USER_ID");
            Session.Remove("LOGIN_USER_NAME");
            Session.Remove("LOGIN_USER_LEVEL");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            stdRow = new DataSet.DsPSMS.ST_USER_MSTDataTable().NewST_USER_MSTRow();
            stdRow.USER_NAME = userName.Text;
            stdRow.PASSWORD = password.Text;
            DataSet.DsPSMS.ST_USER_MSTRow result = service.getUserId(stdRow, out msg);
            if (result != null)
            {
                Session["LOGIN_USER_ID"] = result.USER_ID.ToString();
                Session["LOGIN_USER_NAME"] = result.USER_NAME.ToString();
                Session["LOGIN_USER_LEVEL"] = result.USER_TYPE.ToString();
                Response.Redirect("~/AdminHome.aspx");
            }
            else
                errorMsg.Visible = true;
        }
    }
}