using System;
using Remind.Droid;
using Xamarin.Forms;
using Android.Support.V4.App;
using Android.Content;



[assembly: Dependency(typeof(LocalNoteService_droid))]


namespace Remind.Droid
{
    public class LocalNoteService_droid : LocalNoteService
    {
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "remind_location_notification";
        internal static readonly string COUNT_KEY = "count";

        public void TestNote(string title, string message)
        {
            // TODO add Intent for user tap, navigate to an Activity

            Context context = Android.App.Application.Context;

            var builder = new NotificationCompat.Builder(context, CHANNEL_ID)
                                                .SetSmallIcon(Resource.Drawable.icon)
                                                .SetContentTitle(title)
                                                .SetContentText(message)
                                                .SetWhen(30);


            var noteManager = NotificationManagerCompat.From(context);
            noteManager.Notify(NOTIFICATION_ID, builder.Build());



        }
    }
}
