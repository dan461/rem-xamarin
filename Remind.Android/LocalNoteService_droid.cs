using System;
using Remind.Droid;
using Xamarin.Forms;
using Android.Support.V4.App;
using Android.Content;
using Android.App;
using Java.Util;

// Implements LocalNoteService DependencyService to schedule and publish Local Notifications. 


[assembly: Dependency(typeof(LocalNoteService_droid))]


namespace Remind.Droid
{
    [BroadcastReceiver]
    public class LocalNoteService_droid : BroadcastReceiver, LocalNoteService
    {
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "remind_location_notification";
        internal static readonly string COUNT_KEY = "count";

        private string NoteTitle = "";
        private string NoteMessage = "";

        public void TestNote(string title, string message)
        {
            // TODO add Intent for user tap, navigate to an Activity

            Context context = Android.App.Application.Context;

            NoteTitle = title;
            NoteMessage = message;

            var noteIntent = new Intent(context, typeof(LocalNoteService_droid));
            var pendingIntent = PendingIntent.GetBroadcast(context, 0, noteIntent, 0);

            var now = DateTime.Now;
            var showTime = now.AddSeconds(30.0);

            //var calendar = Calendar.Instance;
            //calendar.Set(CalendarField.Mi)
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.SetExact(AlarmType.ElapsedRealtimeWakeup, showTime.Millisecond, pendingIntent);
        }

        public override void OnReceive(Context context, Intent intent)
        {
            // Create the notification here so that it is not added to the Intent, avoiding Intent size limit issues
            CreateAndPublishNotification(context);
        }

        private void CreateAndPublishNotification(Context context)
        {
            var builder = new NotificationCompat.Builder(context, CHANNEL_ID)
                                                .SetSmallIcon(Resource.Drawable.icon)
                                                .SetContentTitle(NoteTitle)
                                                .SetContentText(NoteMessage);


            var noteManager = NotificationManagerCompat.From(context);
            noteManager.Notify(NOTIFICATION_ID, builder.Build());
        }

    }
}
