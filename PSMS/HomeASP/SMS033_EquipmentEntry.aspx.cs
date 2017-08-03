using System;
using System.Data;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS033 : System.Web.UI.Page
    {
        string msg;
        string userId = "";
        static int updateId;
        EquipmentService equipService = new EquipmentService();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DsPSMS.ST_EQUIPMENT_MSTDataTable equipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            showGd();   // binding data to datagridview
            if (!IsPostBack)
            {
                equipMstDt = equipService.getAllEquipMST(out msg);

                if (equipMstDt != null && equipMstDt.Rows.Count != 0)
                {
                    CoboEquipName.DataSource = equipMstDt;
                    CoboEquipName.DataTextField = "EQUIPMENT_NAME";
                    CoboEquipName.DataValueField = "EQUIPMENT_ID";
                    CoboEquipName.DataBind();
                }
            }
            if (Session["LOGIN_USER_ID"] != null)
            {
                userId = (string)(Session["LOGIN_USER_ID"] ?? "  ");
            }
        }

        protected void showGd()
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable equipDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            //binding Equipment data to datagridview
            equipDt = equipService.getAllEquipData(out msg);
            if (equipDt != null && equipDt.Rows.Count != 0)
            {
                foreach (DataSet.DsPSMS.ST_EQUIPMENT_DATARow row in equipDt.Rows)
                {
                    int id;
                    string equvalue = null;

                    if (row.EQUIPMENT_ID != null)
                    {
                        id = int.Parse(row.EQUIPMENT_ID);
                        DataSet.DsPSMS.ST_EQUIPMENT_MSTRow equipment = equipService.getEquipDataById(id,out msg);
                        equvalue = equipment.EQUIPMENT_NAME;
                        row.EQUIPMENT_ID = equvalue;
                    }
                }

                EqpList.DataSource = equipDt;
                EqpList.DataBind();
            }
            else
            {
                EqpList.DataSource = new DsPSMS.ST_EQUIPMENT_DATADataTable();
                EqpList.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable equipDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();

            if (checkValidation())
            {
                equipDr.EDU_YEAR = CoboYear1.Text;
                equipDr.EQUIPMENT_ID = CoboEquipName.Text;
                equipDr.DATE = Convert.ToDateTime(EqpDate.Text);

                if (BtnSave.Text.Equals("Save"))
                {
                   
                    //equipDr.QUANTITY =TxtQty.Text;
                    equipDr.TYPE = TxtType.Text;
                    equipDr.REMARK = TxtRemark.Text;
                    equipDr.CRT_DT_TM = DateTime.Now;
                    equipDr.CRT_USER_ID = this.userId;
                    equipDr.UPD_DT_TM = DateTime.Now;
                    equipDr.UPD_USER_ID = "";
                    int result;
                    if (int.TryParse(TxtQty.Text, out result))
                    {
                        equipDr.QUANTITY = TxtQty.Text;
                        if (checkExitRecord(equipDr))
                        {
                          //  errorSeach.Text = "Already Exist ! Please choose other data !";
                        }

                        else
                        {
                 //           errExitmsg.Text = " ";
                            equipService.SaveEquipmentData(equipDr, out msg);
                            alertMsg.Text = msg;
                            errQty.Visible = false;
                            resetForm();    
                        }
                    }
                    else
                    {
                         errQty.Text = "Only Numbers Allowed!";
                    }
                   

                }
                else
                {
                    equipDr.ID = updateId;
                    equipDr.QUANTITY = TxtQty.Text;
                    equipDr.TYPE = TxtType.Text;
                    equipDr.REMARK = TxtRemark.Text;
                    equipDr.UPD_DT_TM = DateTime.Now;
                    equipDr.UPD_USER_ID = this.userId;
                    equipService.editEquipmentData(equipDr, out msg);
                    BtnSave.Text = "Save";

                }
                showGd();
                
            }
           
        }


        public bool checkValidation()
        {
            bool chkFlag = true;
            if(CoboYear1.SelectedIndex == 0 && CoboEquipName.SelectedIndex == 0 && EqpDate.Text.Trim().Length == 0 && TxtQty.Text.Trim().Length == 0 && TxtRemark.Text.Trim().Length == 0)
            {
                errorSeach.Text = "Please enter all data!";
                errorSeach.Visible = true;
                chkFlag = false;
            }
            
            else if(CoboYear1.SelectedIndex == 0 || CoboEquipName.SelectedIndex == 0 || EqpDate.Text.Trim().Length == 0 || TxtQty.Text.Trim().Length == 0 || TxtRemark.Text.Trim().Length == 0)
            {
                errorSeach.Text = "Please fill all data!";
                alertMsg.Visible = false;
                errorSeach.Visible = true;
                chkFlag = false;
            }
            
            else{
                 errorSeach.Visible = false;
            }
           
            return chkFlag;
        }

        protected void removeErrorMsg(object sender, EventArgs e)
        {
     //       errQty.Visible = false ;
        }

        protected void EqpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EqpList.PageIndex = e.NewPageIndex;
            EqpList.DataBind();
        }

        protected void resetForm()
        {
            CoboYear1.SelectedIndex = 0;
            EqpDate.Text = "";
            TxtQty.Text = "";
            TxtType.Text = "";
            TxtRemark.Text = "";
            CoboEquipName.SelectedIndex = 0;
      //      errYear.Text = " ";
      //      errEqN.Text = " ";
     //       errDate.Text = " ";
     //       errQty.Text = " ";
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            resetForm();
            showGd();
       //     errExitmsg.Text = " ";
        }

        protected void btnEquipmentEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnEdit = (LinkButton)(sender);
            string equipmentId = btnEdit.CommandName;
            if (equipmentId != null)
            {
                updateId = int.Parse(equipmentId);
                DataSet.DsPSMS.ST_EQUIPMENT_DATARow equipment = equipService.getUpdateEquipmentById(updateId, out msg);
                CoboYear1.SelectedIndex = CoboYear1.Items.IndexOf(CoboYear1.Items.FindByValue(equipment.EDU_YEAR));
                CoboEquipName.SelectedIndex = CoboEquipName.Items.IndexOf(CoboEquipName.Items.FindByValue(equipment.EQUIPMENT_ID));
                EqpDate.Text = Convert.ToString(equipment.DATE); 
                TxtQty.Text = equipment.QUANTITY;
                TxtType.Text = equipment.TYPE;
                TxtRemark.Text = equipment.REMARK;
                BtnSave.Text = "Edit";
                
            }
            
        }

        protected void btnEquipmentDelete_Click(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)(sender);
            string equipmentId = btnDelete.CommandName;
            if (equipmentId != null)
            {
                int deleteId = int.Parse(equipmentId);
                DataSet.DsPSMS.ST_EQUIPMENT_DATARow equipment = equipService.getUpdateEquipmentById(deleteId, out msg);
                equipService.removeEquipmentData(equipment, out msg);
                showGd();
            }
        }

        private bool checkExitRecord(DataSet.DsPSMS.ST_EQUIPMENT_DATARow drr)
        {
            bool alreadyExist = false;
            
            DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable result = equipService.isExistEquipmentData(drr);
            if (result != null && result.Rows.Count > 0)
            {
                alreadyExist = true;
            }
            else
            {
                alreadyExist = false;
            }
            
            return alreadyExist;
         

        }
    }
}