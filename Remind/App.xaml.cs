using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Remind
{
    public partial class App : Application
    {
        public App()
        {
            //InitializeComponent();

            var tabsCs = new TabbedPage { Title = "Remindful" };
            tabsCs.Children.Add(new BasicListPage { Title = "Basic" });

            MainPage = tabsCs;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
