using System.Threading.Tasks;
using TumblrApp.Web.DataModels;

namespace TumblrApp.Web.Services
{
    public interface IServerProxy
    {
        /// <summary>
        /// Get posts and profile data by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<FeedData> GetProfileData(string username);

        /// <summary>
        /// Get range of posts and profile data by username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="start">start index</param>
        /// <param name="count">count of post to get</param>
        /// <returns></returns>
        Task<FeedData> GetProfileData(string username, int start, int count);
    }
}
