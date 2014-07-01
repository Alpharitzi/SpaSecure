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
using System.Text.RegularExpressions;

using SMS.BusinessEntities;
using SMS.BusinessEntities.Main;
using SMS.Services.BusinessServices;

namespace SMS.Operations
{
    public partial class AssignmentVisit : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {
                if (!IsPostBack)
                {
                   
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        protected void btnAssignmentAdd_Click(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            try
            {                
                    SqlParameter[] para = new SqlParameter[24];
                    para[0] = new SqlParameter("@strTo", txtTo.Text.Trim());
                    para[1] = new SqlParameter("@strSubmittedBy", txtsubmittedby.Text.Trim());
                    para[2] = new SqlParameter("@strNameOfAssignment",  txtNameofAssignment.Text.Trim());
                    para[3] = new SqlParameter("@dtmDateVisit", DateTime.Now);
                    para[4] = new SqlParameter("@strInCharge", txtIC.Text.Trim());
                    para[5] = new SqlParameter("@strGuards1", txtGuard1.Text.Trim());

                    para[6] = new SqlParameter("@strDressing", txtdressing.Text.Trim());
                    para[7] = new SqlParameter("@strAppearance", txtappearance.Text.Trim());
                    para[8] = new SqlParameter("@strHaircut", txthaircut.Text.Trim());
                    para[9] = new SqlParameter("@strAlertness", ddrAlertness.SelectedValue);
                    para[10] = new SqlParameter("@strDeployment", ddrDeployment.SelectedValue);
                    para[11] = new SqlParameter("@strGeneralPerformance", ddrgeneralPerformance.SelectedValue);
                    para[12] = new SqlParameter("@strOtherMatters", txtotherMatters.Text.Trim());
                    para[13] = new SqlParameter("@strConclussion", txtconclustion.Text.Trim());
                    para[14] = new SqlParameter("@strRecommendation", txtrecommendation.Text.Trim());


                    para[15] = new SqlParameter("@strGuards2", txtGuard2.Text.Trim());
                    para[16] = new SqlParameter("@strGuards3", txtGuard3.Text.Trim());
                    para[17] = new SqlParameter("@strGuards4", txtGuard4.Text.Trim());
                    para[18] = new SqlParameter("@strGuards5", txtGuard5.Text.Trim());
                    para[19] = new SqlParameter("@strGuards6", txtGuard6.Text.Trim());
                    para[20] = new SqlParameter("@strGuards7", txtGuard7.Text.Trim());
                    para[21] = new SqlParameter("@strGuards8", txtGuard8.Text.Trim());
                    para[22] = new SqlParameter("@strGuards9", txtGuard9.Text.Trim());
                    para[23] = new SqlParameter("@strGuards10", txtGuard10.Text.Trim());

                    dal.executeprocedure("sp_InsertAssignmentVisit", para);                  
                    HttpContext.Current.Items.Add("COMPLETE", "INSERT");
                    Server.Transfer("../SMSAdmin/AlertUpdateComplete.aspx");
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
                if (!IsPostBack)
                {
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        private void clearAll()
        {
            txtappearance.Text = "";
            txtconclustion.Text = "";
            txtdatefrom.Text = "";
            txtdressing.Text = "";
            txtGuard1.Text = "";
            txtGuard10.Text = "";
            txtGuard2.Text = "";

            txtGuard3.Text = "";
            txtGuard4.Text = "";
            txtGuard5.Text = "";
            txtGuard6.Text = "";
            txtGuard7.Text = "";
            txtGuard8.Text = "";
            txtGuard9.Text = "";
            txthaircut.Text = "";
            txtIC.Text = "";
            txtNameofAssignment.Text = "";
            txtotherMatters.Text = "";

           txtrecommendation.Text = "";
           txtsubmittedby.Text = "";
           txtTo.Text = "";
           ddrAlertness.Text = "";
           ddrDeployment.Text = "";
           ddrgeneralPerformance.Text = "";
           
        }





    }
}