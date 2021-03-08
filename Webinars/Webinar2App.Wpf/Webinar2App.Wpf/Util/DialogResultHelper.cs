using System.Windows;

namespace Webinar2App.Wpf.Util
{
    /// <summary>
    /// Class provides useful attached property DialogResult for view models
    /// </summary>
    public static class DialogResultHelper
    {
        // DialogResult
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogResultHelper),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
