﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SMS.BusinessEntities.Main;

namespace SMS.BusinessEntities
{
    [Serializable]
    public class AddNewTrainingRequest
    {
        private AddTraining _Training_Request = null;

        public AddTraining Training_Request
        {
            get { return _Training_Request; }
            set { _Training_Request = value; }
        }


    }
}
