using System;
namespace Remind
{
    public class Reminder
    {
        public string DisplayText { get; set; }
        public string type { get; set; }
        public DateTime displayTime { get; set; }

        public Reminder(string text, string noteType, DateTime when)
        {
            DisplayText = text;
            type = noteType;
            displayTime = when;
        }
    }
}
