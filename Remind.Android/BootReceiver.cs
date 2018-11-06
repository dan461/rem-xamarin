
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
using Java.Util;

namespace Remind.Droid
{
    [BroadcastReceiver]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action.Equals(Intent.ActionBootCompleted))
            {

                // https://stackoverflow.com/questions/36902667/how-to-schedule-notification-in-android
                // http://eggmetrics.com/xamarin-android-notifications-schedule/


                Toast.MakeText(context, "OnReceive in BootReceiver called", ToastLength.Long);
                context = Application.Context;
                var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
                var newIntent = new Intent(context, typeof(LocalNoteService_droid));
                var pending = PendingIntent.GetBroadcast(context, 0, newIntent, 0);

                // TODO for testing only. Will need to get the reminder times from somewhere
                var now = DateTime.Now;
                var showTime = now.AddSeconds(60.0);

                alarmManager.SetExact(AlarmType.RtcWakeup, showTime.Millisecond, pending);

            }
        }
    }
}
