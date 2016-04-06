using Newtonsoft.Json;

namespace TumblrApp.Web.DataModels
{
    public class VideoPostData : PostDataBase
    {
        [JsonProperty("video-source")]
        public string VideoSource { get; set; }

        [JsonProperty("video-player")]
        public string VideoPlayer { get; set; }

        [JsonProperty("video-caption")]
        public string VideoCaption { get; set; }
    }
}
