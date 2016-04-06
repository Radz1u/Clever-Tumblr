using Newtonsoft.Json;

namespace TumblrApp.Web.DataModels
{
    public class QuotePostData:PostDataBase
    {
        [JsonProperty("quote-text")]
        public string Content { get; set; }
        
        [JsonProperty("quote-source")]
        public string Source { get; set; }
    }
}
