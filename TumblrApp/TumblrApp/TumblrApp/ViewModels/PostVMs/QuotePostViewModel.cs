using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TumblrApp.Web.DataModels;

namespace TumblrApp.ViewModels.PostVMs
{
    public class QuotePostViewModel : BasePostViewModel
    {
        public QuotePostViewModel(QuotePostData data) : base(data)
        {
            if (string.IsNullOrWhiteSpace(data.Source))
                SubTitle = "cytat";
            else
                SubTitle = Regex.Replace(data.Source, @"<[^>]*>", string.Empty);

            Title = data.Content;
        }
    }
}
