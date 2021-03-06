﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using SMS.Services.DataService;

using log4net;
using log4net.Config;

using SMS.BusinessEntities.Authorization;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using SMS.Services.DALUtilities;

using SMS.SMSAppUtilities;
using SMS.BusinessEntities;

namespace SMS.SuperVisor
{
    public partial class UpdateAlert : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {

                lblerr.Visible = false;
                lblerr1.Visible = false;
                lblErrMsg.Visible = false;

                String iBTID = string.Empty;
                if (!IsPostBack)
                    {
                        if (HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL] != null)
                        {
                            string strURL = HttpContext.Current.Items[ContextKeys.CTX_UPDATE_URL].ToString();
                            //((SMSmaster)this.Master).FilterContent(strURL, btnsave.ID, SMSAppUtilities.SMSAppEnums.ContentType.Update);
                        }
                        if (HttpContext.Current.Items[ContextKeys.CTX_BT_ID] != null)
                        {
                            iBTID = iBTID = HttpContext.Current.Items[ContextKeys.CTX_BT_ID].ToString();
                        }
                        fillAlert();
                        fillDepartment();
                        fillLocation();
                        PopulatePageCntrls(iBTID);
                       
                    }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        #region PrivateMethod


        private void fillLocation()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add(" ");
            DataSet dsdepartment = dal.getdataset("select Location_name from location order by Location_name Asc");
            if (dsdepartment.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsdepartment.Tables[0].Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsdepartment.Tables[0].Rows[k][0].ToString());
                }
            }
        }


        private void fillAlert()
        {
            ddlAlertreason.Items.Clear();
            ddlAlertreason.Items.Add(" ");
            string ID = "alerttype";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt1 = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
           
           // DataSet dsAlert = dal.getdataset("select Description from log where ID='alerttype'");
            if (dt1.Rows.Count > 0)
            {
                for (int k = 0; k < dt1.Rows.Count; k++)
                {
                    ddlAlertreason.Items.Add(dt1.Rows[k][0].ToString());
                }
            }
        }
        private void fillDepartment()
        {
            ddlRole0.Items.Clear();
            ddlRole0.Items.Add(" ");
            string ID = "departmentname";
            SqlParameter[] para1 = new SqlParameter[1];
            para1[0] = new SqlParameter("@ID", ID);
            DataTable dt = dal.executeprocedure("sp_getLogvaluebyID", para1, true);
           
           // DataSet dsdepartment = dal.getdataset("select Description from log where ID='departmentname'");
            if (dt.Rows.Count > 0)
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    ddlRole0.Items.Add(dt.Rows[k][0].ToString());
                }
            }
        }
        private string locationId(string locName)
        {
            string h = string.Empty;
            DataSet dsid = dal.getdataset("select Location_id from location where Location_name ='" + locName + "'");
            if (dsid.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsid.Tables[0].Rows.Count; k++)
                {
                    h = dsid.Tables[0].Rows[k][0].ToString();
                    return h;
                }
            }
            return h;
        }

        private string getlocnamebyid(string id)
        {
            string L = string.Empty;
            DataSet dsLname = dal.getdataset("select Location_name from location where Location_id ='" + id + "'");
            if (dsLname.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsLname.Tables[0].Rows.Count; k++)
                {
                    L = dsLname.Tables[0].Rows[k][0].ToString();
                    return L;
                }
            }
            return L;
        }


        #endregion


        private void PopulatePageCntrls(String argsBGID)
        {
            Int32 iCount = 0;
            GetAlertDataResponse ret = null;

            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AdminBLL objAdminBLL = new AdminBLL();
                GetAlertData objGetBillingTableRequest = new GetAlertData();

                objGetBillingTableRequest.Alert_ID = argsBGID.ToString();
                objGetBillingTableRequest.WhereClause = " where Alert_ID='" + argsBGID.ToString() + "'";

                ret = objAdminBLL.GetAlertData(objGetBillingTableRequest);
                hdnBTID.Value = ret.Alert_ID[iCount].Alert_ID.ToString();

                ddllocation.Text = getlocnamebyid(ret.Alert_ID[iCount].Location_id.ToString());

                txtAlertid.Text = ret.Alert_ID[iCount].Alert_ID.ToString();
                txtP_name.Text = ret.Alert_ID[iCount].P_Name.ToString();
                txtP_NricNo.Text = ret.Alert_ID[iCount].P_NRIC_no.ToString();
                txtP_Passport.Text = ret.Alert_ID[iCount].P_Passport.ToString();

                ddlAlertreason.Text = ret.Alert_ID[iCount].Alert_Type.ToString();
                txtname.Text = ret.Alert_ID[iCount].AlertBy_Name.ToString();
                txtbynric.Text = ret.Alert_ID[iCount].AlertBy_NRICNo.ToString();
                txtphone.Text = ret.Alert_ID[iCount].AlertContNo.ToString();
                ddlRole0.Text = ret.Alert_ID[iCount].AlertDepartment.ToString();
                txtdesignation.Text = ret.Alert_ID[iCount].AlertDesignation.ToString();
                txtmessage.Text = ret.Alert_ID[iCount].Comment.ToString();

            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                AlertHandlingUser objAlert_Data = new AlertHandlingUser();
                AdminBLL ws = new AdminBLL();


                    objAlert_Data.Location_id = locationId(ddllocation.Text.Trim());
                    objAlert_Data.Alert_ID =txtAlertid.Text.Trim();
                    objAlert_Data.Alert_Type = ddlAlertreason.Text.Trim();

                    objAlert_Data.P_Name = txtP_name.Text.Trim();
                    objAlert_Data.P_Nationality = txtnationality.Text.Trim();
                    objAlert_Data.P_NRIC_no = txtP_NricNo.Text.Trim();
                    objAlert_Data.P_Passport = txtP_Passport.Text.Trim();
                    
                    objAlert_Data.V_Color = "";
                    objAlert_Data.V_OwnerName = "";
                    objAlert_Data.V_OwnerNricNo = "";
                    objAlert_Data.V_Type = "";

                    objAlert_Data.AlertBy_Name = txtname.Text.Trim();

                    objAlert_Data.AlertBy_NRICNo = txtbynric.Text.Trim();
                    objAlert_Data.AlertContNo = txtphone.Text.Trim();
                    objAlert_Data.AlertDepartment = ddlRole0.Text.Trim();
                    objAlert_Data.AlertDesignation = txtdesignation.Text.Trim();
                    objAlert_Data.Comment = txtmessage.Text.Trim();

                    objAlert_Data.Date_From = Convert.ToDateTime(DateTime.Now);

                    ws.Updatalert(objAlert_Data);
                    HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "UPDATE");
                    Server.Transfer("..//SMSADMIN//AlertUpdateComplete.aspx");
               
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("..//SuperVisor//AdminAlert.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

      

       









    }
}
