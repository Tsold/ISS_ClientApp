using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ISS_App.Model.Json
{
    public partial class AlbumPeople
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("entries")]
        public List<string> Entries { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }



    public partial class AlbumPeople
    {
        public static AlbumPeople FromJson(string json) => JsonConvert.DeserializeObject<AlbumPeople>(json, ISS_App.Model.Json.Converter.Settings);
    }

    public static class SerializePeople
    {
        public static string ToJson(this AlbumPeople self) => JsonConvert.SerializeObject(self, ISS_App.Model.Json.Converter.Settings);
    }


}

