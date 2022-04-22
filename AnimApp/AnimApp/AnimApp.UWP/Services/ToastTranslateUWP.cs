using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using AnimApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AnimApp.UWP.Services.ToastTranslateUWP))]

namespace AnimApp.UWP.Services
{
    public class ToastTranslateUWP : IToastTranslateService
    {
        private const double DELAY = 3;
        public void DisplayTranslate(string message)
        {
            ShowMessage(message, DELAY);
        }
        private void ShowMessage(string message, double duration)
        {
            var label = new TextBlock
            {
                Text = message,
                //Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            //var style = new Style { TargetType = typeof(FlyoutPresenter) };
            //style.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(Windows.UI.Colors.Black)));
            //style.Setters.Add(new Setter(FrameworkElement.MaxHeightProperty, 1));
            var flyout = new Flyout
            {
                Content = label,
                Placement = FlyoutPlacementMode.Full,
                //FlyoutPresenterStyle = style,
            };

            flyout.ShowAt(Window.Current.Content as FrameworkElement);

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(duration) };
            timer.Tick += (sender, e) => {
                timer.Stop();
                flyout.Hide();
            };
            timer.Start();
        }
    }
}
