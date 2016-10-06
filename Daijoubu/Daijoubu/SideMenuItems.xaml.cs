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
        public SideMenuItems()
        {
            InitializeComponent();
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

        }
    }
}
