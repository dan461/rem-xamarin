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
            bool useXaml = true;

            var tabsCs = new TabbedPage { Title = "Remindful" };

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzk1OTRAMzEzNjJlMzMyZTMwaVJ6MlNsMVV0WTM5ODFyQnpxY1hzbG1EaGlCb21MVHhpSUN5SzYvV1B5bz0=");

            if (useXaml)
            {
                tabsCs.Children.Add(new BasicListXaml { Title = "Reminders" });
                tabsCs.Children.Add(new NewNoteTableViewXaml { Title = "Create" });
                tabsCs.Children.Add(new BasicListXaml { Title = "Links" });
                tabsCs.Children.Add(new NoteCreationPage { Title = "Note Creation" });
            } else {
                tabsCs.Children.Add(new BasicListPage { Title = "Reminder" });
                tabsCs.Children.Add(new NewNoteTableView { Title = "Create" });
                tabsCs.Children.Add(new BasicListPage { Title = "Links" });
            }

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
