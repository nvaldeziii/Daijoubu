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

            btn_hiragana_achivements.Clicked += (o, e) => {
                Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Hiragana));
            };
            btn_katakana_achivements.Clicked += (o, e) => {
                Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Katakana));
            };

            btn_vocabulary_achivements.Clicked += (o, e) => {
                Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Vocabulary));
            };

            btn_delete_data.Clicked += (o, e) =>
            {
                progress_deletion.IsVisible = true;
                progress_deletion.PropertyChanged += Progress_deletion_PropertyChanged;

                btn_delete_data.IsEnabled = false;
                DependencyService.Get<INotifications>().ToastDependency("Deleting please wait...");

                Device.StartTimer(new TimeSpan(0,0,0,0,100), () =>
                {
                    try
                    {
                        DatabaseManipulator.ResetUserData(ref progress_deletion);
                        DependencyService.Get<INotifications>().ToastDependency("User data deleted!");
                        progress_deletion.Progress = 1;
                    }
                    catch
                    {
                        DependencyService.Get<INotifications>().ToastDependency("An error has occured!");
                    }
                    finally
                    {
                        progress_deletion.IsVisible = false;
                    }
                    return false;
                });         
            };
        }

        private void Progress_deletion_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            progress_deletion.ProgressTo(progress_deletion.Progress,900, Easing.Linear);
        }
    }
}
