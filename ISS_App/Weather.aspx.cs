using ISS_App.XmlUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISS_App
{
    public partial class Weather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Temp_Click(object sender, EventArgs e)
        {
            try
            {
                var city = TbCity.Text;
                string output = XmlRpc.SendXmlRpc(city,"getTempByCity");
                LblInfo.Text = output + " °C";
            }
            catch (Exception ex)
            {

                LblInfo.Text = "Invalid City" + ex.Message;
            }
           
        }
    }
}