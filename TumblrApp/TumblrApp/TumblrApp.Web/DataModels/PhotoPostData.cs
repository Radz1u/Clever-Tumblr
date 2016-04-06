using Newtonsoft.Json;

namespace TumblrApp.Web.DataModels
{
    public class PhotoPostData :PostDataBase
    {
        [JsonProperty("photo-caption")]
        public string PhoyoCaption { get; set; }

        [JsonProperty("photo-url-1280")]
        public string PhoyoUrl1280 { get; set; }

        [JsonProperty("photo-url-400")]
        public string PhoyoUrl400 { get; set; }
    }
}
