using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrApp.Helpers;

namespace TumblrApp.ViewModels
{
    public class BaseViewModel:GalaSoft.MvvmLight.ViewModelBase
    {
        public BaseViewModel()
        {
            NinjectHelper.Inject(this);
        }
    }
}
