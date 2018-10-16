using System;
using Xamarin.Forms;
using System.Diagnostics;


namespace Remind
{
    public class BasicListPage : ContentPage
    {
        public BasicListPage()
        {
            var listView = new ListView();
            listView.ItemsSource = new[] { "a", "b", "c" };

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
