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
                Navigation.PushAsync(new AppPages.ProfilePage());
            };

            SideMenuButton_Lessons.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.LessonsPage());
            };

            SideMenuButton_Settings.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.SettingsPage());
            };

            SideMenuButton_About.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.AboutPage());
            };

            SideMenuButton_Quiz.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.QuizPage());
            };

            SideMenuButton_QuizN4.Clicked += (o, e) => 
            {
                Navigation.PushAsync(new AppPages.QuizPageN4());
            };

        }
    }
}
