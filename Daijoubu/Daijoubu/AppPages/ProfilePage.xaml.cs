using Daijoubu.AppModel;
using Daijoubu.AppPages.ProfilePages;
using Daijoubu.Dependencies;
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

            btn_delete_data.Clicked += (o, e) =>
            {
                try
                {
                    DependencyService.Get<INotifications>().ToastDependency("Deleting please wait...");
                    DatabaseManipulator.ResetUserData();
                    DependencyService.Get<INotifications>().ToastDependency("User data deleted!");
                }
                catch
                {
                    DependencyService.Get<INotifications>().ToastDependency("An error has occured!");
                }

                
            };
        }
    }
}
