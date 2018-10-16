using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace Remind
{
    public partial class BasicListXaml : ContentPage
    {
        public BasicListXaml()
        {
            InitializeComponent();

            this.BindingContext = new[] { "a", "b", "c" };
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e) {
            if (e == null) return; // has been set to null, dont process tap event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
