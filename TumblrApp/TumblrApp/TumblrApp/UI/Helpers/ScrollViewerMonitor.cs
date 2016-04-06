using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Threading;

namespace TumblrApp.UI.Helpers
{
    public class ScrollViewerMonitor
    {
        public static DependencyProperty AtEndCommandProperty = DependencyProperty.RegisterAttached("AtEndCommand", typeof(ICommand), typeof(ScrollViewerMonitor), new PropertyMetadata(new PropertyChangedCallback(ScrollViewerMonitor.OnAtEndCommandChanged)));

        static ScrollViewerMonitor()
        {
        }

        public static ICommand GetAtEndCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ScrollViewerMonitor.AtEndCommandProperty);
        }

        public static void SetAtEndCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ScrollViewerMonitor.AtEndCommandProperty, (object)value);
        }

        public static void OnAtEndCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = (FrameworkElement)d;
            if (frameworkElement == null)
                return;
            frameworkElement.Loaded -= new RoutedEventHandler(ScrollViewerMonitor.ElementLoaded);
            frameworkElement.Loaded += new RoutedEventHandler(ScrollViewerMonitor.ElementLoaded);
        }

        private static void ElementLoaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            element.Loaded -= new RoutedEventHandler(ScrollViewerMonitor.ElementLoaded);
            ScrollViewer scrollViewer = VisualTreeHelperExtensions.FindFirstElementInVisualTree<ScrollViewer>((DependencyObject)element);

            if (scrollViewer == null) return;
            //throw new InvalidOperationException("ScrollViewer not found.");
            DependencyPropertyListener propertyListener = new DependencyPropertyListener();
            propertyListener.Changed += (EventHandler<BindingChangedEventArgs>)delegate
            {
                if (scrollViewer.ScrollableHeight == 0) return;

                if ((scrollViewer.ScrollableHeight - scrollViewer.VerticalOffset) > 0.6) //0.4 stopped working either and is too small //0.15 doesn't work in World category (why ???)
                    return;

                //if ( < )
                //    return;
                ICommand atEndCommand = ScrollViewerMonitor.GetAtEndCommand((DependencyObject)element);
                if (atEndCommand == null)
                    return;
                ThreadPool.QueueUserWorkItem((k) =>
                {
                    atEndCommand.Execute((object)null);
                });
            };
            Binding binding = new Binding("VerticalOffset")
            {
                Source = (object)scrollViewer,
                Mode= BindingMode.OneWay
            };
            propertyListener.Attach((FrameworkElement)scrollViewer, binding);
        }
    }
}
