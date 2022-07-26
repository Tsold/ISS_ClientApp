using ISS_App.LocalServices;
using ISS_App.POST;
using ISS_App.XmlUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISS_App
{
    public partial class Soap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SoapApi_Click(object sender, EventArgs e)
        {
            
           LblInfo.Text = LocalApiHandler.SoapApi(int.Parse(TbID.Text));
        }

        protected void IsValid_Click(object sender, EventArgs e)
        {
            string output = XmlRpc.SendXmlRpc("","isValid");
            LblInfo.Text = output;
        }
    }
}