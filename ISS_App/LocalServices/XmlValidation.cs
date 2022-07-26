using ISS_App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Xml;

namespace ISS_App.POST
{
    public class XmlValidation
    {
        public static string XML_Validation(Person person,string endpoint)
        {
           
            List<Person> people = new List<Person>();
            people.Add(person);
            People peps = new People(people);
            Type[] knownTypes = new Type[] { typeof(Person) };
            DataContractSerializer serialize = new DataContractSerializer(typeof(People), knownTypes);
            MemoryStream data = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(data);
            serialize.WriteObject(writer, peps);
            writer.Close(); 

            byte[] dataForReg = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data.ToArray()));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Person/"+endpoint);
            request.Method = "POST";
            request.Accept = "application/xml";
            request.ContentType = "application/xml";
            Stream requestData = request.GetRequestStream();
            requestData.Write(dataForReg, 0, dataForReg.Length);
            requestData.Close();
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return response.StatusCode.ToString();

        }


    }
}