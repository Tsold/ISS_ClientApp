using ISS_App.Model;
using ISS_App.Model.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISS_App.LocalServices
{
    public class LocalApiHandler
    {

        public static People GetPeople()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Person");
            request.Accept = "application/xml";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream data = response.GetResponseStream();


            Type[] knownTypes = new Type[] { typeof(Person) };
            DataContractSerializer deserialize = new DataContractSerializer(typeof(People), knownTypes);
            People peps = (People)deserialize.ReadObject(data);
            return peps;
        }



        public static async Task<List<AlbumInfo>> GetAlbumInfoAsync()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/Album");
            return AlbumInfoParse.FromJsonList(await response.Content.ReadAsStringAsync());

        }

        public static string DeleteAlbum(string id)
        {
            HttpWebRequest zahtjev = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Album/" + id);
            zahtjev.Method = "DELETE";


            string message = "";
            HttpWebResponse response = (HttpWebResponse)zahtjev.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                message = reader.ReadToEnd();
            }

            return message;
        }



        public static async Task<string> SendAlbumInfoAsync(AlbumInfo album)
        {
            string payload = JsonConvert.SerializeObject(album);

            var client = new HttpClient();
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/Album/insert", content);


            return response.StatusCode.ToString();

        }



        public static string SoapApi(int id)
        {

            HttpWebRequest zahtjev = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/Person/soap/" + id);
            zahtjev.Method = "GET";


            string message = "";
            HttpWebResponse response = (HttpWebResponse)zahtjev.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                message = reader.ReadToEnd();
            }
            return message;

        }
 
    }
}