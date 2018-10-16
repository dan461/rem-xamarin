using System;

using Xamarin.Forms;

namespace Remind
{
    public class NewNoteTableView : ContentPage
    {
        public NewNoteTableView()
        {
            this.Title = "Create";
            var table = new TableView() { Intent = TableIntent.Form };
            var root = new TableRoot();
            var section1 = new TableSection() { Title = "first section" };
            var section2 = new TableSection() { Title = "second section" };

            var textCell = new TextCell() { Text = "Create a new reminder", Detail = "Enter info below to create a new notification" };
            var entryCell = new EntryCell() { Placeholder = "Enter your reminder text" };
            var switchCell = new SwitchCell() { Text = "Select reminder mode" };

            section1.Add(textCell);
            section1.Add(entryCell);

            section2.Add(switchCell);

            table.Root = root;
            root.Add(section1);
            root.Add(section2);

            Content = table;
        }
    }
}

