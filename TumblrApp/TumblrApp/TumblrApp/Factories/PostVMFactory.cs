using Ninject;
using System;
using System.Collections.Generic;
using TumblrApp.Helpers;
using TumblrApp.ViewModels.PostVMs;
using TumblrApp.Web.DataModels;
using TumblrApp.Web.Services;

namespace TumblrApp.Factories
{
    public class PostVMFactory : IPostVMFactory
    {

        public IEnumerable<BasePostViewModel> GetVMs(IEnumerable<PostDataBase> data)
        {
            List<BasePostViewModel> vms = new List<BasePostViewModel>();

            foreach (var item in data)
            {
                var vm = CreateVM((dynamic)item);

                if (vm != null)
                    vms.Add(vm);
            }

            return vms;
        }

        private QuotePostViewModel CreateVM(QuotePostData data)
        {
            return new QuotePostViewModel(data);
        }

        private ConversationPostViewModel CreateVM(ConversationPostData data)
        {
            return new ConversationPostViewModel(data);
        }

        private BasePostViewModel CreateVM(PostDataBase data)
        {
            return null;
        }
    }
}
