﻿using System;
using System.Collections.Generic;
using System.Linq;
using UserNotifications;
using Syncfusion.SfPicker.XForms.iOS;

using Foundation;
using UIKit;

namespace Remind.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Calabash.Start();
            global::Xamarin.Forms.Forms.Init();
            new SfPickerRenderer();
            LoadApplication(new App());
            GetUserAuth();

            return base.FinishedLaunching(app, options);
        }

        // Request permission from user for Local Notifications
        private void GetUserAuth()
        {
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) =>
            {
                // handle user approval 
            });

        }
    }
}
