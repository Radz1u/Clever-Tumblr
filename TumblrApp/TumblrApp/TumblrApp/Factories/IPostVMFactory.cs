using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrApp.ViewModels.PostVMs;
using TumblrApp.Web.DataModels;

namespace TumblrApp.Factories
{
    public interface IPostVMFactory
    {
        IEnumerable<BasePostViewModel> GetVMs(IEnumerable<PostDataBase> data);
    }
}
