using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;


namespace Remind
{
    public class BasicListPage : ContentPage
    {
        //ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
        public BasicListPage()
        {
            var listView = new ListView();
            listView.ItemsSource = new[] { "Reminder 1", "Reminder 2", "Reminder 3" };

            //reminders.Add(new Reminder("Reminder 1", "grateful", DateTime.Today) { });
            //reminders.Add(new Reminder("Reminder 2", "grateful", DateTime.Today) { });
            //listView.ItemsSource = reminders;

            // using ItemTapped
            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                Debug.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null; // de-select row
            };

            // if using ItemSelected
            listView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null) return;
                Debug.WriteLine("Selected: " + e.SelectedItem);
                ((ListView)sender).SelectedItem = null; // deselect row
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
    }
}
