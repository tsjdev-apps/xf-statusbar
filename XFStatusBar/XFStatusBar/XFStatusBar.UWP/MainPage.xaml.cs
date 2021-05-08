using Windows.UI.ViewManagement;
using Xamarin.Forms.Platform.UWP;

namespace XFStatusBar.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new XFStatusBar.App());

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Xamarin.Forms.Color.FromHex("#CC0000").ToWindowsColor();
        }
    }
}
