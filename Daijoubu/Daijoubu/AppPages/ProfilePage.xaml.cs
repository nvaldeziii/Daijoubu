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
                UserDatabase.Table_UserVocabCardsN5 = DependencyService.Get<Dependencies.ISQLite>()
                                                    .GetUserDBconnection().Table<tbl_us_cardvbN5dt>().ToList();
                UserDatabase.Table_UserKanaCardsN5 = DependencyService.Get<Dependencies.ISQLite>()
                                                    .GetUserDBconnection().Table<tbl_us_cardknN5Dt>().ToList();
            };
        }
    }
}
