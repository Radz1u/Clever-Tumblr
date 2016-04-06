using GalaSoft.MvvmLight.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrApp.Factories;
using TumblrApp.ViewModels;
using TumblrApp.ViewModels.PostDetailsViewModels;
using TumblrApp.Web.Services;

namespace TumblrApp.Helpers
{
    public class NinjectHelper
    {
        private readonly static IKernel _kernel;

        static NinjectHelper()
        {
            _kernel = new StandardKernel();
        }

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize()
        {
            #region SERVICES
            _kernel.Bind<IServerProxy>().To<ServerProxy>().InSingletonScope();

            _kernel.Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            ConfigureNavigationService();
            
            #endregion

            #region FACTORIES
            _kernel.Bind<IPostVMFactory>().To<PostVMFactory>();
            #endregion

            #region VIEW MODELS
            _kernel.Bind<MainPageViewModel>().To<MainPageViewModel>().InSingletonScope();
            #endregion
        }

        private static void ConfigureNavigationService()
        {
            var service =(NavigationService) _kernel.Get<INavigationService>();

            service.Configure("ConversationDetailsView", new Uri("/Views/ConversationDetailsView.xaml",UriKind.RelativeOrAbsolute));
        }

        public static void Inject(Object obj)
        {
            _kernel.Inject(obj);
        }
    }
}
