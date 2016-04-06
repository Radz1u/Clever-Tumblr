using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TumblrApp.Factories;
using TumblrApp.ViewModels.PostVMs;
using TumblrApp.Web.DataModels;
using TumblrApp.Web.Services;

namespace TumblrApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region FIELDS
        private const int POSTS_PER_REQUEST = 20;

        private int _loadedPosts = 0;

        private int _totalPosts = 0;
        #endregion

        #region PROPERTIES
        private string _query;
        public string Query
        {
            get { return string.IsNullOrWhiteSpace(_query) ? "demo" : _query; }
            set
            {
                _query = value;
                RaisePropertyChanged("Query");
            }
        }

        private BasePostViewModel _selectedItem;
        public BasePostViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;

                if (_selectedItem != null && _selectedItem.NavigateToDetailsCommand.CanExecute(null))
                    _selectedItem.NavigateToDetailsCommand.Execute(null);

                RaisePropertyChanged("SelectedItem");
            }
        }


        private ObservableCollection<BasePostViewModel> _posts;
        public ObservableCollection<BasePostViewModel> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                RaisePropertyChanged("Posts");
            }
        }
        #endregion

        #region INJECTED PROPERTIES
        [Inject]
        public IServerProxy Proxy { get; set; }

        [Inject]
        public IPostVMFactory PostVMFactory { get; set; }
        #endregion

        #region COMMAND
        public ICommand SearchCommand { get; private set; }
        public ICommand LoadMoreCommand { get; private set; }
        #endregion

        public MainPageViewModel() : base()
        {
            _query = "demo";
            SearchCommand = new RelayCommand(SearchCmdCallback);
            LoadMoreCommand = new RelayCommand(LoadMoreCmdCallback);
        }

        #region COMMAND's CALLBACKS
        private async void LoadMoreCmdCallback()
        {
            if (_totalPosts <= _loadedPosts)
            { return; }

            var postToLoad = POSTS_PER_REQUEST;

            if (_totalPosts < (_loadedPosts + postToLoad))
                postToLoad = _totalPosts - _loadedPosts;

            var postData = await Proxy.GetProfileData(Query, _loadedPosts, postToLoad);

            _totalPosts = postData.PostsTotal;

            _loadedPosts += postToLoad;

            if (_totalPosts <= _loadedPosts)
                _loadedPosts = _totalPosts;

            LoadCollection(postData.Posts);
        }

        private async void SearchCmdCallback()
        {
            var postData = await Proxy.GetProfileData(Query, 0, POSTS_PER_REQUEST);

            _totalPosts = postData.PostsTotal;

            if (_totalPosts <= POSTS_PER_REQUEST)
                _loadedPosts = _totalPosts;
            else
                _loadedPosts = POSTS_PER_REQUEST;

            _posts = new ObservableCollection<BasePostViewModel>();

            LoadCollection(postData.Posts);
        }
        #endregion

        private void LoadCollection(List<PostDataBase> data)
        {
            var postVMs = PostVMFactory.GetVMs(data);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                foreach (var postVM in postVMs)
                    Posts.Add(postVM);

                RaisePropertyChanged("Posts");
            });

        }
    }
}
