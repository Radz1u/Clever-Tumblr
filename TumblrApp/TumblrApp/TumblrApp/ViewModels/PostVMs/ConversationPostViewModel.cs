using GalaSoft.MvvmLight.Views;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using TumblrApp.Web.DataModels;

namespace TumblrApp.ViewModels.PostVMs
{
    public class ConversationPostViewModel : BasePostViewModel
    {
        private readonly ConversationPostData _data;

        [Inject]
        public INavigationService NavigationService { get; set; }

        public IEnumerable<ConversationEntry> ConversationEntires { get { return _data.Conversation; } }

        public ConversationPostViewModel(ConversationPostData data) : base(data)
        {
            _data = data;

            if(data.Conversation!=null && data.Conversation.Any())
            {
                var firstPhrase = data.Conversation.First().Phrase;

                    SubTitle = firstPhrase;

                var users= data.Conversation.GroupBy(x => x.Name).Select(x => x.Key);

                Title = "Konwersacja pomiędzy: ";

                foreach (var user in users)
                    Title += user + ", ";

                Title = Title.Substring(0, Title.Count() - 2);
                
            }
        }

        protected override void NavigateToDetailsCmdCallback()
        {
            NavigationService.NavigateTo("ConversationDetailsView",_data);
        }
    }
}
