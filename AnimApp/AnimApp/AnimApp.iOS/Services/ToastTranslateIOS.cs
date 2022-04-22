using AnimApp.Services;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AnimApp.iOS.Services.ToastTranslateIOS))]

namespace AnimApp.iOS.Services
{
    public class ToastTranslateIOS : IToastTranslateService
    {
        const double DELAY = 3;

        NSTimer alertDelay;
        UIAlertController alert;
        public void DisplayTranslate(string message)
        {
            ShowAlert(message, DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}