using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ISS_App.Model.Json
{
    public partial class AlbumInfo
    {
        public AlbumInfo(string album, string albumkey)
        {
            Album = album;
            Albumkey = albumkey;
        }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("albumkey")]
        public string Albumkey { get; set; }
    }

    public partial class AlbumInfoParse
    {
        public static AlbumInfo FromJson(string json) => JsonConvert.DeserializeObject<AlbumInfo>(json, ISS_App.Model.Json.Converter.Settings);

        public static List<AlbumInfo> FromJsonList(string json) => JsonConvert.DeserializeObject<List<AlbumInfo>>(json, ISS_App.Model.Json.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AlbumInfo self) => JsonConvert.SerializeObject(self, ISS_App.Model.Json.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}