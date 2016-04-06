using System.Windows;
using TumblrApp.ViewModels.PostDetailsViewModels;

namespace TumblrApp.Views
{
    public partial class ConversationDetailsView : BasePage
    {
        public ConversationDetailsView():base()
        {
            InitializeComponent();
            Loaded += ConversationDetailsView_Loaded;
        }

        private void ConversationDetailsView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ConversationPostDetailsPageViewModel;

            if (vm != null)
                vm.Load();
        }
    }
}