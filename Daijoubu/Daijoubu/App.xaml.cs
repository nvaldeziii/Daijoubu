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

            MainPage = new NavigationPage(new Daijoubu.SideMenuPage())
            {
                BarBackgroundColor = Color.FromHex("#273442"),
                Padding = new Thickness(0,-50,0,0)
                
                
            };
            //MainPage.Padding = -50;
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
