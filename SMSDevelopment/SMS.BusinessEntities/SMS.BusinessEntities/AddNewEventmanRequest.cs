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
    public class AddNewEventmanRequest
    {
        private eventAdmin _Event_Request = null;

        public eventAdmin Event_Request
        {
            get { return _Event_Request; }
            set { _Event_Request = value; }
        }
    }
}
