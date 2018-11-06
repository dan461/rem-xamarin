using System;
using Remind.Droid;
using Xamarin.Forms;
using Android.Support.V4.App;
using Android.Content;
using Android.App;
using Android.OS;
using Java.Util;
using Android.Widget;
using Android.Content.PM;


// Implements LocalNoteService DependencyService to schedule and publish Local Notifications. 


[assembly: Dependency(typeof(LocalNoteService_droid))]


namespace Remind.Droid
{
    [BroadcastReceiver]
    public class LocalNoteService_droid : BroadcastReceiver, LocalNoteService
    {
        static readonly int NOTIFICATION_ID = 1000;
        //static readonly string CHANNEL_ID = "remind_location_notification";
        internal static readonly string COUNT_KEY = "count";
        static readonly string NOTIFICATION_TITLE = "com.nedware.Remind.NOTE_TITLE";
        static readonly string NOTIFICATION_MESSAGE = "com.nedware.Remind.NOTE_MESSAGE";

        public void TestNote(string title, string message)
        {
            // TODO add Intent for user tap, navigate to an Activity

            Context context = Android.App.Application.Context;

            var noteIntent = new Intent(context, typeof(LocalNoteService_droid));
            // TODO look into why the string extra has to be a string literal
            noteIntent.PutExtra(NOTIFICATION_TITLE, "" + title);
            noteIntent.PutExtra(NOTIFICATION_MESSAGE, "" + message);
            var pendingIntent = PendingIntent.GetBroadcast(context, 0, noteIntent, 0);

            var now = DateTime.Now;
            var showTime = now.AddSeconds(30.0);

            //var calendar = Calendar.Instance;
            //calendar.Set(CalendarField.Mi)
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.SetExact(AlarmType.ElapsedRealtimeWakeup, showTime.Millisecond, pendingIntent);


            // Enabling BootReceiver.cs to automatically restart when device is rebooted
            var bootReceiver = new ComponentName(context, Java.Lang.Class.FromType(typeof(BootReceiver)).Name);
            var packageManager = context.PackageManager;
            packageManager.SetComponentEnabledSetting(bootReceiver, ComponentEnabledState.Enabled, ComponentEnableOption.DontKillApp);
        }

        public void SetSpecificReminder(string title, string message, DateTime dateTime)
        {
            Context context = Android.App.Application.Context;

            var noteIntent = new Intent(context, typeof(LocalNoteService_droid));
            // TODO look into why the string extra has to be a string literal
            noteIntent.PutExtra(NOTIFICATION_TITLE, "" + title);
            noteIntent.PutExtra(NOTIFICATION_MESSAGE, "" + message);
            var pendingIntent = PendingIntent.GetBroadcast(context, 0, noteIntent, 0);

            Calendar cal = Calendar.GetInstance(Java.Util.TimeZone.Default, Locale.Us);
            cal.Set(CalendarField.Date, dateTime.Day);
            cal.Set(CalendarField.HourOfDay, dateTime.Hour);
            cal.Set(CalendarField.Minute, dateTime.Minute);
            cal.Set(CalendarField.Second, dateTime.Second);

            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            // TODO use Set or SetExact here?
            //alarmManager.Set(AlarmType.Rtc, cal.TimeInMillis, pendingIntent);
            alarmManager.SetExact(AlarmType.Rtc, cal.TimeInMillis, pendingIntent);
        }


        public override void OnReceive(Context context, Intent intent)
        {

            // Create the notification here so that it is not added to the Intent, avoiding Intent size limit issues
            var title = intent.GetStringExtra(NOTIFICATION_TITLE);
            var message = intent.GetStringExtra(NOTIFICATION_MESSAGE);
            CreateAndPublishNotification(context, title, message);
        }

        private void CreateAndPublishNotification(Context context, string title, string message)
        {
            // TODO get string for channel id from resources folder
            var channelID = context.Resources.GetString(Resource.String.channel_ID);
            var builder = new NotificationCompat.Builder(context, channelID)
                                                .SetSmallIcon(Resource.Drawable.icon)
                                                .SetContentTitle(title)
                                                .SetContentText(message);


            var noteManager = NotificationManagerCompat.From(context);
            noteManager.Notify(NOTIFICATION_ID, builder.Build());
        }

    }
}
