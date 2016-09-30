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
            SideMenuButton_Settings.Clicked += (o, e) =>
            {
                AppPages.SettingsPage settings_page = new AppPages.SettingsPage();
                Navigation.PushAsync(settings_page);
            };
        }
    }
}
