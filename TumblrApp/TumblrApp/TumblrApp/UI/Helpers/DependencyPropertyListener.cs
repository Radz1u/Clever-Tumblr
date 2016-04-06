using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TumblrApp.UI.Helpers
{
    public class BindingChangedEventArgs : EventArgs
    {
        public DependencyPropertyChangedEventArgs EventArgs { get; private set; }

        public BindingChangedEventArgs(DependencyPropertyChangedEventArgs e)
        {
            this.EventArgs = e;
        }
    }

    public class DependencyPropertyListener
    {
        private readonly DependencyProperty property;
        private static int index;
        private FrameworkElement target;
        public event EventHandler<BindingChangedEventArgs> Changed;

        public DependencyPropertyListener()
        {
            this.property = DependencyProperty.RegisterAttached("DependencyPropertyListener" + (object)DependencyPropertyListener.index++, typeof(object), typeof(DependencyPropertyListener), new PropertyMetadata((object)null, new PropertyChangedCallback(this.HandleValueChanged)));
        }

        public void Attach(FrameworkElement element, Binding binding)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if (this.target != null)
                throw new InvalidOperationException("Cannot attach an already attached listener");
            this.target = element;
            this.target.SetBinding(this.property, binding);
        }

        public void Detach()
        {
            this.target.ClearValue(this.property);
            this.target = (FrameworkElement)null;
        }

        private void HandleValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Changed == null)
                return;
            this.Changed((object)this, new BindingChangedEventArgs(e));
        }
    }
}

