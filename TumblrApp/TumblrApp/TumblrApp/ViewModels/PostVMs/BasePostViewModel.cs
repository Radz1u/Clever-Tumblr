using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using TumblrApp.Web.DataModels;

namespace TumblrApp.ViewModels.PostVMs
{
    public class BasePostViewModel : BaseViewModel
    {

        private DateTime _date;

        public string Date
        {
            get
            {
                return _date.ToString("dd-MM-yyyy");
            }
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }

        public ICommand NavigateToDetailsCommand { get; private set; }

        public BasePostViewModel(PostDataBase data) : base()
        {
            _date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            _date = _date.AddSeconds(data.UnixTimeStamp).ToLocalTime();

            NavigateToDetailsCommand = new RelayCommand(NavigateToDetailsCmdCallback);
        }

        protected virtual void NavigateToDetailsCmdCallback() {

        }
    }
}