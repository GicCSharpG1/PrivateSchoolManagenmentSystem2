using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;

namespace HomeASP
{
    public partial class SMS024 : System.Web.UI.Page
    {
        string msg = "";
        PositionService service = new PositionService();

        DsPSMS.ST_STAFF_DATARow dr = new DsPSMS.ST_STAFF_DATADataTable().NewST_STAFF_DATARow();
        StaffService stservice = new StaffService();

        DsPSMS.ST_STAFF_DATADataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            DsPSMS.ST_STAFF_DATADataTable resultDt = stservice.getAllStaffData(out msg);
            if (resultDt != null)
            {

                foreach (DataSet.DsPSMS.ST_STAFF_DATARow row in resultDt.Rows)
                {
                    DsPSMS.ST_POSITION_MSTRow sp = new DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();
                    sp.POSITION_ID = Convert.ToInt16(row.POSITION_ID);
                    DataSet.DsPSMS.ST_POSITION_MSTDataTable result = service.getPosMstById(sp);

                    row.POSITION_ID = result.Rows[0]["POSITION_NAME"].ToString();
                    //resultDt.Columns.Remove(resultDt.Columns[1]);
                    GridView1.DataSource = resultDt;
                    GridView1.DataBind();
                }

            }
        }
        protected void StaffList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void btnStaffDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string staffId = btn.CommandName;

            if (staffId != null)
            {
                Session["STAFF_ID"] = staffId;
                Response.Redirect("SMS025_StaffInfoDetail.aspx");
            }
        }



        protected void btnStaffUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string staffId = btn.CommandName;

            if (staffId != null)
            {
                Session["STAFF_ID"] = staffId;
                Response.Redirect("SMS023_StaffEntry.aspx");
            }
        }

        protected void btnStaffDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string staffId = btn.CommandName;

            if (staffId != null)
            {

                stservice.deleteStaff(staffId, out msg);
                DataTable ds = new DataTable();
                ds = null;
                GridView1.DataSource = ds;
                GridView1.DataBind();
                gridShow();
            }
        }
        protected void gridShow()
        {
            DsPSMS.ST_STAFF_DATADataTable show = new DsPSMS.ST_STAFF_DATADataTable();
            show = stservice.getAllStaffData(out msg);
            if (show != null && show.Rows.Count != 0)
            {
                foreach (DataSet.DsPSMS.ST_STAFF_DATARow row in show.Rows)
                {
                    DsPSMS.ST_POSITION_MSTRow sp = new DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();
                    sp.POSITION_ID = Convert.ToInt16(row.POSITION_ID);
                    DataSet.DsPSMS.ST_POSITION_MSTDataTable result = service.getPosMstById(sp);

                    row.POSITION_ID = result.Rows[0]["POSITION_NAME"].ToString();
                    // show.Columns.Remove(show.Columns[0]);
                    GridView1.DataSource = show;
                    GridView1.DataBind();
                }
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {

            string staffname = staffName.Text;
            string staffId = Staffid.Text;
            if (!staffname.Equals("") && !staffId.Equals(""))
            {

                DsPSMS.ST_STAFF_DATADataTable resultDt = stservice.selectStaffData(staffname, staffId);
                errSearch.Visible = false;
                if (resultDt != null)
                {

                    foreach (DataSet.DsPSMS.ST_STAFF_DATARow row in resultDt.Rows)
                    {
                        DsPSMS.ST_POSITION_MSTRow sp = new DsPSMS.ST_POSITION_MSTDataTable().NewST_POSITION_MSTRow();
                        sp.POSITION_ID = Convert.ToInt16(row.POSITION_ID);
                        DataSet.DsPSMS.ST_POSITION_MSTDataTable result = service.getPosMstById(sp);

                        row.POSITION_ID = result.Rows[0]["POSITION_NAME"].ToString();
                        //resultDt.Columns.Remove(resultDt.Columns[1]);
                        GridView1.DataSource = resultDt;
                        GridView1.DataBind();
                    }

                }

            }

            if (!staffname.Equals("") && staffId.Equals(""))
            {
                DsPSMS.ST_STAFF_DATADataTable resultDt = stservice.selectSNameOnly(staffname);
                errSearch.Visible = false;
                if (resultDt != null)
                {

                    GridView1.DataSource = resultDt;
                    GridView1.DataBind();
                }

            }


            if (staffname.Equals("") && !staffId.Equals(""))
            {
                errSearch.Visible = false;
                DsPSMS.ST_STAFF_DATADataTable resultDt = stservice.selectIdOnly(staffId);
                if (resultDt != null)
                {

                    GridView1.DataSource = resultDt;
                    GridView1.DataBind();
                }

            }


            if (staffname.Equals("") && staffId.Equals(""))
            {
                errSearch.Text = "Please Insert Name and ID !!";
                errSearch.Visible = true;
            }
        }

        protected void btnPrevious_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SMS023_StaffEntry.aspx");
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            gridShow();
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            staffName.Text = "";
            Staffid.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            //    lblSerial.Text = ((GridView1.PageIndex * GridView1.PageSize) + e.Row.RowIndex + 1).ToString();
            //}
            //}

        }


    }


}
