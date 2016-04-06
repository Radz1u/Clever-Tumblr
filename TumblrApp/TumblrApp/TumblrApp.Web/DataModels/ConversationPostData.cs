using Newtonsoft.Json;
using System.Collections.Generic;

namespace TumblrApp.Web.DataModels
{
    public class ConversationPostData:PostDataBase
    {
        [JsonProperty("conversation-title")]
        public string Title { get; set; }
        
        public IEnumerable<ConversationEntry> Conversation { get; set; }
    }
}
