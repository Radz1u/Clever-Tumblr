using GalaSoft.MvvmLight.Threading;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrApp.ViewModels.PostVMs;
using TumblrApp.Web.DataModels;

namespace TumblrApp.ViewModels.PostDetailsViewModels
{
    public class ConversationPostDetailsPageViewModel : BaseViewModel
    {
        [Inject]
        public MainPageViewModel MainPageViewModel { get; set; }

        private List<ConversationEntryInfoModel> _collection;
        public List<ConversationEntryInfoModel> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged("Collection");
            }
        }

        public void Load()
        {
            _collection = new List<ConversationEntryInfoModel>();

            var entries = ((ConversationPostViewModel)MainPageViewModel.SelectedItem).ConversationEntires;

            var isOdd = false;

            foreach (var entry in entries)
            {
                _collection.Add(new ConversationEntryInfoModel(entry, isOdd));
                isOdd = !isOdd;
            }

            DispatcherHelper.CheckBeginInvokeOnUI(() => RaisePropertyChanged("Collection"));
        }

    }
}
