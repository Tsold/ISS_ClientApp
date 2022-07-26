using ISS_App.Model;
using ISS_App.POST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISS_App
{
    public partial class XsdXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInsertXSD_Click(object sender, EventArgs e)
        {
            if (TbName.Text == "" || TbSurname.Text == "" || TbGender.Text == "" || TbUrl.Text == "")
            {
                LblInfo.Text = "Fields cannot be empty";
            }
            else
            {

                try
                {
                    Person person = new Person(1, TbName.Text, TbSurname.Text, TbGender.Text, TbUrl.Text);
                    LblInfo.Text = XmlValidation.XML_Validation(person, "xml");
                }
                catch (Exception)
                {
                    LblInfo.Text = "Invalid XML";
                }

            }
        }
    }
}