using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AnimApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AnimApp.Droid.Services.ToastTranslateDroid))]

namespace AnimApp.Droid.Services
{
    class ToastTranslateDroid : IToastTranslateService
    {
        public void DisplayTranslate(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}