using System;
using Windows.UI.Xaml.Controls;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace Testudo
{
    public sealed partial class Settings : SettingsFlyout
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private void BrowserButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            try
            {
                MainPage.Current.SetUrl(new Uri(BrowserUrl.Text));
                BrowerError.Text = "";
            }
            catch (FormatException)
            {
                BrowerError.Text = "Not a valid URL.";
            }
        }

    }
}
