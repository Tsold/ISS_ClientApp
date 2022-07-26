using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace ISS_App.XmlUtils
{
    public class XmlRpc
    {


        private static string XML_Path = HttpContext.Current.Server.MapPath("~/App_Data/Send.xml");
        public static string SendXmlRpc(string value,string proc)
        {

            string temp = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(XML_Path);
            doc.DocumentElement.ChildNodes[0].InnerText = "Main."+proc;
            doc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText = value;

            MemoryStream xmlStream = new MemoryStream();
            doc.Save(xmlStream);

            byte[] sendCity = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(xmlStream.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080");
            request.Method = "POST";
            request.Accept = "application.xml";
            request.ContentType = "application.xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(sendCity, 0, sendCity.Length);
            requestData.Close();


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseData = response.GetResponseStream();

            XmlDocument docAnswer = new XmlDocument();
            docAnswer.Load(responseData);

            temp = docAnswer.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText;

            return temp;
        }

   

    }
}