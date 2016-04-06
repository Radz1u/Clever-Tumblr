using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrApp.Helpers;

namespace TumblrApp.Views
{
    public partial class BasePage: PhoneApplicationPage
    {
        public BasePage()
        {
            NinjectHelper.Inject(this);
        }
    }
}
