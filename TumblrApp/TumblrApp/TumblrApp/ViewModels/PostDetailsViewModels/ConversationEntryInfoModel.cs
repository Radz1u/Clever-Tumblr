using TumblrApp.Web.DataModels;

namespace TumblrApp.ViewModels.PostDetailsViewModels
{
    public class ConversationEntryInfoModel:ConversationEntry
    {
        public bool IsOdd { get; set; }
        public ConversationEntryInfoModel(ConversationEntry data,bool isOdd)
        {
            Name = data.Name;
            Phrase = data.Phrase;
            Label = data.Label;
            IsOdd = isOdd;
        }
    }
}