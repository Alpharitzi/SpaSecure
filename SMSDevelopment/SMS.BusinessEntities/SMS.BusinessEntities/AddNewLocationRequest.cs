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
    public class AddNewLocationRequest
    {
        private LocationData _Location_Request = null;

        public LocationData Location_Request
        {
            get { return _Location_Request; }
            set { _Location_Request = value; }
        }
    }
}
