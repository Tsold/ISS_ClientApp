using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISS_App.Model.Json
{

    public partial class RecognizePerson
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("photos")]
        public List<Photo> photo { get; set; }
    }

    public partial class Photo
    {


        [JsonProperty("tags")]
        public List<Tag> tag { get; set; }

    }

    public partial class Tag
    {


        [JsonProperty("uids")]
        public List<Uid> Uids { get; set; }
    }



    public partial class Uid
    {
        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("prediction")]
        public string Prediction { get; set; }

    }

    public partial class RecognizePerson
    {
        public static RecognizePerson FromJson(string json) => JsonConvert.DeserializeObject<RecognizePerson>(json, ISS_App.Model.Json.Converter.Settings);
    }

    public static class Serializee
    {
        public static string ToJson(this RecognizePerson self) => JsonConvert.SerializeObject(self, ISS_App.Model.Json.Converter.Settings);
    }


    
}

