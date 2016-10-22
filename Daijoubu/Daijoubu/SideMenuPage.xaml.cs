using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu
{
    public partial class SideMenuPage : MasterDetailPage
    {
        public SideMenuPage()
        {
            InitializeComponent();
            InitilizeClickEvents();
            //Set the side menu items
            
            SideMenuItems MenuItems = new SideMenuItems();
            SideMenuInstance.Content = MenuItems;
            
        } 

        private void InitilizeClickEvents()
        {
            
        }
    }
}
