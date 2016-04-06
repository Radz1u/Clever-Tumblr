using Newtonsoft.Json;

namespace TumblrApp.Web.DataModels
{
    public class RegularPostData : PostDataBase
    {
        [JsonProperty("regular-title")]
        public string RegularTitle { get; set; }

        [JsonProperty("regular-body")]
        public string RegularBody { get; set; }
    }
}
