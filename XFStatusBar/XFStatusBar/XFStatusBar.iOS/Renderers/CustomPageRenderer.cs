using Foundation;
using System;
using System.Diagnostics;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFStatusBar.iOS.Renderers;

[assembly: ExportRenderer(typeof(ContentPage), typeof(CustomPageRenderer))]
namespace XFStatusBar.iOS.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            try
            {
                UpdateStatusBarColor();
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"{GetType().Name} | {nameof(OnElementChanged)} | {ex}");
            }
        }

        private void UpdateStatusBarColor()
        {
            var statusBar = GetStatusBar();
            statusBar.BackgroundColor = Color.FromHex("#CC0000").ToUIColor();
        }

        private UIView GetStatusBar()
        {
            UIView statusBar;

            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                var customTag = 12456789;
                var window = UIApplication.SharedApplication.Windows.FirstOrDefault();

                statusBar = window.ViewWithTag(customTag);

                if (statusBar == null)
                {
                    statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame)
                    {
                        Tag = customTag
                    };

                    window.AddSubview(statusBar);
                }
            }
            else
            {
                statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            }

            return statusBar;
        }
    }
}