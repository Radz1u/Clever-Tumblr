using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace TumblrApp.Web.DataModels
{
    public class FeedData
    {
        public UserData UserData { get; set; }

        [JsonProperty("posts-total")]
        public int PostsTotal { get; set; }

        [JsonProperty("Posts")]
        internal List<JObject> PostsInternal { get; set; }

        [JsonProperty("OtherPosts")]
        public List<PostDataBase> Posts
        {
            get { return PostsInternal.Select(x => PostDataFactory.CreateData(x)).ToList(); }
        }
    }
}
