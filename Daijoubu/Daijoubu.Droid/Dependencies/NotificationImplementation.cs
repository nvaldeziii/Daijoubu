using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Acr.Notifications;
using Daijoubu.Droid.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationImplementation))]
namespace Daijoubu.Droid.Dependencies
{
    class NotificationImplementation : Daijoubu.Dependencies.INotifications
    {
        public void Vibrate(int miliseconds = 300)
        {
            Notifications.Instance.Vibrate(miliseconds);
        }
    }
}