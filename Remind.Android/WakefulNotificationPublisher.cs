
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
using Android.Support.V4.App;

namespace Remind.Droid
{
    [BroadcastReceiver]
    public class WakefulNotificationPublisher : BroadcastReceiver
    {
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "remind_location_notification";

        public override void OnReceive(Context context, Intent intent)
        {
            //Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
            //Context context = Android.App.Application.Context;

            var builder = new NotificationCompat.Builder(context, CHANNEL_ID)
                                                .SetSmallIcon(Resource.Drawable.icon)
                                                .SetContentTitle("Test")
                                                .SetContentText("NOTE TEST")
                                                .SetWhen(30);


            var noteManager = NotificationManagerCompat.From(context);
            noteManager.Notify(NOTIFICATION_ID, builder.Build());
        }
    }
}
