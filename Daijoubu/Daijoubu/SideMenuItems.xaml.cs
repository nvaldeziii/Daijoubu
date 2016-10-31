using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu
{
    public partial class SideMenuItems : ContentView
    {
        Settings setting;
        public SideMenuItems()
        {
            InitializeComponent();

            //this.Padding = 100;
            //this.BackgroundColor = Color.Yellow;
            setting = new Settings();

            var enableN4 = (setting.EnableN4 || setting.ForceEnableN4);
                SideMenuButton_QuizN4.IsEnabled = enableN4;
            

            InitializeClickEvents();
        }

        public void InitializeClickEvents()
        {
            
            SideMenuButton_Profile.Clicked += (o, e) =>
            {
                AppPages.ProfilePage page = new AppPages.ProfilePage();
                Navigation.PushAsync(page);
            };

            SideMenuButton_Settings.Clicked += (o, e) =>
            {
                AppPages.SettingsPage page = new AppPages.SettingsPage();
                Navigation.PushAsync(page);
            };

            SideMenuButton_About.Clicked += (o, e) =>
            {
                AppPages.AboutPage page = new AppPages.AboutPage();
                Navigation.PushAsync(page);
            };

            SideMenuButton_Quiz.Clicked += (o, e) =>
            {
                AppPages.QuizPage page = new AppPages.QuizPage();
                Navigation.PushAsync(page);
            };

            SideMenuButton_QuizN4.Clicked += (o, e) => {
                //n4 logic goes here
            };

        }
    }
}
