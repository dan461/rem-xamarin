using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;

using Xamarin.Forms;

namespace Remind
{
    public partial class NoteCreationPage : ContentPage
    {
        private DateTime SelectedDateTime { get; set; }

        public NoteCreationPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            DateTime reminderTime = DateTimePicker.SelectedDateTime;
            DependencyService.Get<LocalNoteService>().SetSpecificReminder("Be Grateful", "Find something good.", reminderTime);
        }

        private void ShowDatePicker(object sender, EventArgs args)
        {
            DateTimePicker.IsOpen = !DateTimePicker.IsOpen;
        }

        void Handle_OkButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
        {

        }

        private void ShowTimePicker(object sender, EventArgs args)
        {
            TimePicker.IsVisible = !TimePicker.IsVisible;
        }

        private void SetRandomReminder(object sender, EventArgs args)
        {
            DateTime today = DateTime.Today;
            var rando = new RandomTimeGenerator();
            var hourMin = rando.RandomHourMinute(20, 21, 10, 20);
            DateTime newTime = new DateTime(today.Year, today.Month, today.Day, hourMin[0], hourMin[1], 0);
            DependencyService.Get<LocalNoteService>().SetSpecificReminder("Be Grateful", "Find something good.", newTime);



            //int loops = 0;
            //while (loops < 30)
            //{
            //    var hourMin = rando.RandomHourMinute();
            //    Console.WriteLine("Hour: {0}, Min: {1}", hourMin[0], hourMin[1]);
            //    loops++;
            //}
        }


    }
}
