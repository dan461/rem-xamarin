using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Remind
{
    public partial class NoteTestXaml : ContentPage
    {
        public NoteTestXaml()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            DependencyService.Get<LocalNoteService>().TestNote("iOS Test", "Reminder test");
        }
    }
}
