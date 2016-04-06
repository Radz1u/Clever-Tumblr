using Ninject;
using TumblrApp.Helpers;
using TumblrApp.ViewModels.PostDetailsViewModels;

namespace TumblrApp.ViewModels
{
    public class ViewModelLocator
    {
        [Inject]
        public MainPageViewModel MainPageViewModel { get; set; }
        
        public ConversationPostDetailsPageViewModel ConversationPostDetailsViewModel { get { return new ConversationPostDetailsPageViewModel(); } }

        public ViewModelLocator()
        {
            NinjectHelper.Initialize();
            NinjectHelper.Inject(this);
        }
    }
}