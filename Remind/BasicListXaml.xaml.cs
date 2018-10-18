using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Remind
{
    public partial class BasicListXaml : ContentPage
    {
       ObservableCollection<Reminder> Reminders = new ObservableCollection<Reminder>();
        public BasicListXaml()
        {
            InitializeComponent();
            //this.BindingContext = new[] { "a1", "b1", "c1" };
            Reminder rem1 = new Reminder("Reminder 1!", "grateful", DateTime.Today);
            Reminder rem2 = new Reminder("Reminder 2!", "grateful", DateTime.Today);
            Reminders.Add(rem1);
            Reminders.Add(rem2);
            this.BindingContext = Reminders;
            //this.SetBinding();
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e) {
            if (e == null) return; // has been set to null, dont process tap event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
