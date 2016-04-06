using System;
using System.Windows;

namespace TumblrApp.UI.Helpers
{
    public static class VisualTreeHelper
    {
        public static T FindElement<T>(FrameworkElement obj, string name)
        {
            DependencyObject dep = obj as DependencyObject;
            T ret = default(T);

            if (dep != null)
            {
                int childcount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(dep);
                for (int i = 0; i < childcount; i++)
                {
                    DependencyObject childDep = System.Windows.Media.VisualTreeHelper.GetChild(dep, i);
                    FrameworkElement child = childDep as FrameworkElement;

                    if (child.GetType() == typeof(T) && child.Name == name)
                    {
                        ret = (T)Convert.ChangeType(child, typeof(T));
                        break;
                    }

                    ret = FindElement<T>(child, name);
                    if (ret != null)
                        break;
                }
            }
            return ret;
        }
    }
}
