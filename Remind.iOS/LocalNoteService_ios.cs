using System;
using UserNotifications;
using Remind.iOS;
using Xamarin.Forms;

[assembly: Dependency (typeof (LocalNoteService_ios))]

namespace Remind.iOS
{
    public class LocalNoteService_ios : LocalNoteService
    {
        public void TestNote(string title, string message)
        {
            // TODO add this check further up the line, so that the user can't create reminders unless approved
            if (CheckApproval() == true)
            {
                var content = new UNMutableNotificationContent();
                content.Title = title;
                content.Body = message;
                content.Badge = 1;

                var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(15, false);
                var requestID = "testRequest";
                var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

                UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                    if (err != null)
                    {
                        // Do something with error...
                    }
                });
            }
        }

        private bool CheckApproval()
        {
            var approved = true;
            UNUserNotificationCenter.Current.GetNotificationSettings((settings) =>
            {
                approved = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });

            return approved;
        }
    }
}
