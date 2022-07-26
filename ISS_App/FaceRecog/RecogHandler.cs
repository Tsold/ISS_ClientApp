using ISS_App.Model;
using ISS_App.Model.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ISS_App.FaceRecog
{
    public class RecogHandler
    {

        private const string ApiAccessKey = "API KEY";
        private const string ApiAdress = "lambda-face-recognition.p.rapidapi.com";

        public static async Task<AlbumInfo> CreateAlbumAsync(string AlbumName)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://lambda-face-recognition.p.rapidapi.com/album"),
                Headers =
    {
        { "x-rapidapi-host", ApiAdress },
        { "x-rapidapi-key", ApiAccessKey },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "album", AlbumName},
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return AlbumInfoParse.FromJson(await response.Content.ReadAsStringAsync());

            }

        }




        public static async Task<string> InsertIntoAlbumAsync(People peps, AlbumInfo album)
        {
            StringBuilder info = new StringBuilder();
          
            foreach (Person p in peps.people)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://lambda-face-recognition.p.rapidapi.com/album_train"),
                    Headers =
    {
        { "x-rapidapi-host", ApiAdress },
        { "x-rapidapi-key", ApiAccessKey },
    },
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "album", album.Album },
        { "albumkey", album.Albumkey },
        { "entryid", p.Name+p.Surname },
        { "urls", p.PictureUrl },
    }),
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    info.Append(body + "\n");

                }

            }

            return info.ToString();
        }


        public static async Task<string> RebuildAlbumAsync(AlbumInfo album)
        {

       
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://lambda-face-recognition.p.rapidapi.com/album_rebuild?album=" + album.Album + "&albumkey=" + album.Albumkey),
                Headers =
    {
         { "x-rapidapi-host", ApiAdress },
        { "x-rapidapi-key", ApiAccessKey },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }

        }

        public static async Task<AlbumPeople> ViewALbumAsync(AlbumInfo album)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://lambda-face-recognition.p.rapidapi.com/album?album=" + album.Album + "&albumkey=" + album.Albumkey),
                Headers =
    {
        { "x-rapidapi-host", ApiAdress },
        { "x-rapidapi-key", ApiAccessKey },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return AlbumPeople.FromJson(await response.Content.ReadAsStringAsync());
            }


        }


        public static async Task<RecognizePerson> RecognizeUrlPerson(string Url, AlbumInfo album)
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://lambda-face-recognition.p.rapidapi.com/recognize"),
                Headers =
    {
          { "x-rapidapi-host", ApiAdress },
        { "x-rapidapi-key", ApiAccessKey },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "album", album.Album },
        { "albumkey", album.Albumkey },
        { "urls", Url },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return RecognizePerson.FromJson(await response.Content.ReadAsStringAsync());

            }

        }
    }
}