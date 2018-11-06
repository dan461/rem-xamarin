using System;
namespace Remind
{
    public interface LocalNoteService
    {
        void TestNote(string title, string message);
        void SetSpecificReminder(string title, string message, DateTime dateTime);
    }
}
