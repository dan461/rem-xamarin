using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Remind.Droid
{
    [Activity(Label = "Remind", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            CreateNoteChannel();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        void CreateNoteChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Note channels only required for API 26+
                return;
            }

            var channelName = Resources.GetString(Resource.String.channel_name);
            var channelDesc = GetString(Resource.String.channel_description);
            var channelID = GetString(Resource.String.channel_ID);
            var channel = new NotificationChannel(channelID, channelName, NotificationImportance.Default)
            {
                Description = channelDesc
            };

            var notificationsManager = (NotificationManager)GetSystemService(NotificationService);
            notificationsManager.CreateNotificationChannel(channel);

        }
    }
}