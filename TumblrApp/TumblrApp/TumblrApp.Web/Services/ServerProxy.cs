using Clever.Win.Tumblr.Services;
using System.Threading.Tasks;
using TumblrApp.Web.DataModels;
using System;

namespace TumblrApp.Web.Services
{
    public class ServerProxy : IServerProxy
    {
        private const int MAXIMUM_ITEM_PER_PAGE = 50;
        private const string PROFILE_URL = "http://www.{0}.tumblr.com/api/read/json";

        public async Task<FeedData> GetProfileData(string user)
        {
            return await WebRequestWrapper.GetAsync<FeedData>(string.Format(PROFILE_URL, user));
        }

        public async Task<FeedData> GetProfileData(string user, int start, int count)
        {
            var numParam = count;

            if (numParam > MAXIMUM_ITEM_PER_PAGE)
                numParam = MAXIMUM_ITEM_PER_PAGE;

            var startParam = start;

            if (startParam < 0)
                startParam = 0;
            var url = PROFILE_URL + "?start={1}&num={2}";
            return await WebRequestWrapper.GetAsync<FeedData>(string.Format(url, user, startParam, numParam));
        }
    }
}
