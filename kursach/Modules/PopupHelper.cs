using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace kursach.Modules
{
    public static class PopupHelper
    {
        public static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.RegisterAttached("IsPopupOpen", typeof(bool), typeof(PopupHelper),
                new PropertyMetadata(false, OnIsPopupOpenChanged));

        public static bool GetIsPopupOpen(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPopupOpenProperty);
        }

        public static void SetIsPopupOpen(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPopupOpenProperty, value);
        }

        private static void OnIsPopupOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element)
            {
                bool isOpen = (bool)e.NewValue;
                Popup popup = FindPopup(element);
                if (popup != null)
                {
                    popup.IsOpen = isOpen;
                }
            }
        }

        private static Popup FindPopup(FrameworkElement element)
        {
            if (element.Parent is Popup popup)
            {
                return popup;
            }
            else if (element.Parent is FrameworkElement parent)
            {
                return FindPopup(parent);
            }
            else
            {
                return null;
            }
        }
    }
}
