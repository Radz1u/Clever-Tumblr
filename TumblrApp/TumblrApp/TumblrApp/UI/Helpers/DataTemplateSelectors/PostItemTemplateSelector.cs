using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TumblrApp.ViewModels.PostVMs;

namespace TumblrApp.UI.Helpers.DataTemplateSelectors
{
    public class PostItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate QuotePostDataTemplate { get; set; }
        public DataTemplate ConversationPostDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return GetDataTemplate((dynamic)item);
        }

        private DataTemplate GetDataTemplate(QuotePostViewModel model)
        {
            return QuotePostDataTemplate;
        }

        private DataTemplate GetDataTemplate(ConversationPostViewModel model)
        {
            return ConversationPostDataTemplate;
        }

        private DataTemplate GetDataTemplate(object data)
        {
            return null;
        }
    }
}
