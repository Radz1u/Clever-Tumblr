using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrApp.Web.DataModels;

namespace TumblrApp.Web
{
    public class PostDataFactory
    {
        public static PostDataBase CreateData(JObject data)
        {
            string type = data.Root["type"].Value<string>();

            switch (type)
            {
                case "audio": { return data.ToObject<AudioPostData>(); }
                case "photo": { return data.ToObject<PhotoPostData>(); }
                case "video": { return data.ToObject<VideoPostData>(); }
                case "regular": { return data.ToObject<RegularPostData>(); }
                case "quote": { return data.ToObject<QuotePostData>(); }
                case "conversation": { return data.ToObject<ConversationPostData>(); }
                default: { return data.ToObject<PostDataBase>(); }
            }

        }

    }
}
