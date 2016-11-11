using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Daijoubu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //BarBackgroundColor = Color.FromHex("#38B4AB"),
            MainPage = new NavigationPage(new Daijoubu.SideMenuPage())
            {              
                BarBackgroundColor = Color.FromHex("#3B5998"),
                AutomationId = "auto_navigation"
               
            };
            MainPage.Padding = -50;
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
