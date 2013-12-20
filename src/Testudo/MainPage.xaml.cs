using System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Testudo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public MainPage()
        {
            this.InitializeComponent();
            Current = this;

            Browser.Navigate(new Uri("http://xkiab7.axshare.com/home.html"));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SettingsPane.GetForCurrentView().CommandsRequested -= onCommandsRequested;
        }

        /// <summary>
        /// Handler for the CommandsRequested event. Add custom SettingsCommands here.
        /// </summary>
        /// <param name="e">Event data that includes a vector of commands (ApplicationCommands)</param>
        void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs e)
        {
            SettingsCommand defaultsCommand = new SettingsCommand("general", "General",
                (handler) =>
                {
                    // Settings is defined in "Settings.xaml"
                    Settings sf = new Settings();
                    sf.Show();
                });
            e.Request.ApplicationCommands.Add(defaultsCommand);
        }


        public void SetUrl(Uri url)
        {
            try
            {
                Browser.Navigate(url);
            }
            catch (Exception)
            {
                // Hack: Being a bad boy!
            }
        }
    }
}
