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
using log4net;
using log4net.Config;
using SMS.Services.DataService;
using System.Data.SqlClient;
using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;
using MKB.TimePicker;
using MKB.Exceptions;
using System.Text.RegularExpressions;
using System.IO;
using SMS.SMSAppUtilities;


namespace SMS.SMSAdmin
{
    public partial class NewSOPAdd : System.Web.UI.Page
    {
        //SqlConnection cn;
        AdminDAL a = new AdminDAL();
        DataAccessLayer dal = new DataAccessLayer();
        int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                    lblerror.Visible = false;
                    lblerr1.Visible = false;
                    lblerr2.Visible = false;
                    txtSOPID.Focus();
                    if (Session["ManagementRole"].ToString().ToLower() == "superuser")
                    {
                        if (Session["LCID"] != null)
                        {
                            getLocationNameById(Session["LCID"].ToString());
                        }
                        else
                        {
                            getLocationName();
                        }
                    }
                    else
                    {
                        getLocationNameById(Session["LCID"].ToString());
                    }
                    BindGridWithFilter();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }

        }
        private void getLocationIDByName(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
        }
        private string getLocationIDByName1(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_name", Name);
            DataTable dsLocationID = dal.executeprocedure("sp_GetLocationIDbyName", para, false);
            if (dsLocationID.Rows.Count > 0)
            {
                searchid.Text = dsLocationID.Rows[0][0].ToString().Trim();
            }
            return searchid.Text;
        }

        private void getLocationName()
        {
            ddllocation.Items.Clear();
            ddllocation.Items.Add("");
            SqlParameter[] para = new SqlParameter[0];
            DataTable dsLocation = dal.executeprocedure("sp_FillLocationName", para, false);
            if (dsLocation.Rows.Count > 0)
            {
                for (int k = 0; k < dsLocation.Rows.Count; k++)
                {
                    ddllocation.Items.Add(dsLocation.Rows[k][0].ToString().Trim());
                }
            }
        }

        private void getLocationNameById(string Name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Location_id", Name);
            DataTable dsLocationName = dal.executeprocedure("sp_getLocationNameByID", para, false);
            if (dsLocationName.Rows.Count > 0)
            {
                ddllocation.Items.Add(dsLocationName.Rows[0][0].ToString().Trim());
            }
        }

        protected void btnAddSOP_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                //String ZipRegex = "^[a-z A-Z 0-9]+$";
                //if (Regex.IsMatch(txtSOPID.Text, ZipRegex))
                //{                   
                    AddNewSOPRequest objAddSOP = new AddNewSOPRequest();
                    SOP ObjSOP = new SOP();
                    //String q = txtSOPID.Text;                   
                    //DataSet ds = dal.getdataset("select SOP_ID from SOP_Master ");
                   
                    //int count = ds.Tables[0].Rows.Count;
                    //if (count > 0)
                    //{
                    //    for (i = 0; i < count; i++)
                    //    {
                    //        String z = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    //        if (string.Equals(q, z, StringComparison.CurrentCultureIgnoreCase))
                    //        {
                    //            lblerror.Visible = true;
                    //            lblerror.Text = "SOP No. Already Exist ..!";
                    //            lblerr1.Visible = true;
                    //            throw new Exception();
                    //        }
                    //    }
                    //}
                    //Boolean verify = true;
                    //String q1 = txtgenerate.Text;                    
                    //DataSet ds5 = dal.getdataset("select NRICno from UserInformation");
                    
                    //int count1 = ds5.Tables[0].Rows.Count;
                    //for (i = 0; i < count1; i++)
                    //{
                    //    String z1 = ds5.Tables[0].Rows[i].ItemArray[0].ToString();
                    //    if (string.Equals(q1, z1, StringComparison.CurrentCultureIgnoreCase))
                    //    {
                    //        getLocationIDByName(ddllocation.Text.Trim());
                    //        ObjSOP.SOP_ID = txtSOPID.Text;
                              ObjSOP.SOP_Title = txtSOPtitle.Text;
                    //        ObjSOP.SOP_Subject = txtSOPsubject.Text;
                              ObjSOP.Date_From = DateTime.Now;
                    //        ObjSOP.Created_By = txtgenerate.Text;
                              ObjSOP.Location = getLocationIDByName1(searchid.Text);

                              if (txtImagePath.HasFile)
                              {
                                  string path = Server.MapPath("~/FileUpload/");
                                  txtImagePath.PostedFile.SaveAs(path + txtImagePath.FileName);
                                  ObjSOP.ImagePathName = txtImagePath.FileName;
                              }
                              AdminBLL ws = new AdminBLL();
                              ws.AddUserSOP(ObjSOP);
                    //        verify = false;
                              lblerror.Visible = true;
                              lblerror.Text = "Insert Successfully ..!";
                    //        clearall();
                    //        BindGridWithFilter();
                    //       // HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    //       // Server.Transfer("AlertUpdateComplete.aspx");
                    //    }
                    //}
                   //if(verify)                    
                   // {
                   //   lblerror.Visible = true;
                   //   lblerror.Text = "Invalid NRIC/FIN No. ..!";
                   //   lblerr2.Visible = true;
                   // }                  
                //}
                //else
                //{
                //    lblerror.Visible = true;
                //    lblerror.Text = "Invalid SOP No. ..!";
                //    lblerr1.Visible = true;
                //}
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }



        protected void btnClearSOPAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                Server.Transfer("SOPAdmin.aspx");
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void clearall()
        {
            txtSOPID.Text = "";
            txtSOPtitle.Text = "";
            txtSOPsubject.Text = "";
           // txtgenerate.Text = "";
        }


        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchid.Text = ddllocation.Text;
        }
        protected void gvSOP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //JS for delete btn
                    ImageButton Delete = (ImageButton)e.Row.FindControl("btnDelete");
                    Delete.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure to delete this record?')");
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    gvSOPTable.Columns[0].FooterText = "Total Records: 20";
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        protected void gvSOP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                string _BTId = Convert.ToString(e.CommandArgument);

                //if (e.CommandName == "EditRow")
                //{
                //    HttpContext.Current.Items.Add(ContextKeys.CTX_UPDATE_URL, Request.Url.ToString());
                //    HttpContext.Current.Items.Add(ContextKeys.CTX_BT_ID, _BTId);
                //    Server.Transfer("SOPUpdate.aspx");
                //}
                if (e.CommandName == "DeleteRow")
                {
                    DeleteSOP(_BTId);
                }
            }


            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        private void DeleteSOP(string argSOPId)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!string.IsNullOrEmpty(argSOPId))
                {
                    AdminBLL ws = new AdminBLL();
                    AdminDAL w = new AdminDAL();
                    SqlConnection conn = new SqlConnection();
                    conn = w.getconnection();

                    DeleteSOPRequest _req = new DeleteSOPRequest();

                    _req.SOP_ID = argSOPId.ToString();
                    string id = argSOPId.ToString();

                    string query = "select top 1 ImagePathName from SOP_Master name where SOP_ID='" + id + "'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader rd = cmd.ExecuteReader();
                    string s = string.Empty;
                    while (rd.Read())
                    {
                        s = rd.GetValue(0).ToString();
                    }
                    FileInfo TheFile = new FileInfo(MapPath("../FileUpload/") + "\\" + s);
                    if (TheFile.Exists)
                    {
                        File.Delete(MapPath("../FileUpload/") + "\\" + s);
                    }

                    ws.DeleteSOP(_req);
                   // HttpContext.Current.Items.Add(ContextKeys.CTX_COMPLETE, "DELETE");
                   // Server.Transfer("AlertUpdateComplete.aspx");
                    BindGridWithFilter();
                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }


        protected void gvSOP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (e.NewPageIndex >= 0)
                {
                    gvSOPTable.PageIndex = e.NewPageIndex;

                }
            }

            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void BindGridWithFilter()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                getLocationIDByName(ddllocation.Text.Trim());
                AdminBLL ws = new AdminBLL();
                GetSOPData objReq = new GetSOPData();
                if (ddllocation.Text.ToString() == "")
                {

                }
                else 
                {
                    objReq.WhereClause = " Where Location = '" + searchid.Text + "' ";
                }
                 
                GetSOPDataResponse ret = ws.GetSOPData(objReq);
                int pageSize = ContextKeys.GRID_PAGE_SIZE;
                gvSOPTable.PageSize = pageSize;
                gvSOPTable.DataSource = ret.SOPNo;
                gvSOPTable.DataBind();

               // ShowHide();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

    }
}
