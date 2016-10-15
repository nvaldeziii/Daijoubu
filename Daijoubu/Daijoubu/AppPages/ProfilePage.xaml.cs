using Daijoubu.AppPages.ProfilePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            btn_achivements.Clicked += (o, e) => {
                Navigation.PushAsync(new AchivementPage());
            };
        }
    }
}
