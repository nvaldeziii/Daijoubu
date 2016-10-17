using Daijoubu.AppModel;
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

            btn_delete_data.Clicked += (o, e) =>
            {
                DependencyService.Get<Dependencies.ISQLite>().DeleteUserDB();
                UserDatabase.Table_UserSettings = DependencyService.Get<Dependencies.ISQLite>()
                                                    .GetUserDBconnection().Table<tbl_user_settings>().ToList();
            };
        }
    }
}
