using Daijoubu.AppModel;
using Daijoubu.AppPages.ProfilePages;
using Daijoubu.Dependencies;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppPages
{
    public partial class ProfilePage : ContentPage
    {
        double _progress;
        double progress { get { return _progress * 100; } set { _progress = value; } }
        public ProfilePage()
        {
            InitializeComponent();
            progress = 0;

            btn_n5.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new JLPTN5SelectorPage());
                })
            });
                
               
            btn_n4.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new JLPTN4SelectorPage());
                })
            });

            btn_delete_data.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command( async () =>
                {
                   
                    var confirm_delete = await DisplayAlert("Confirm", "Are you sure you want to delete your data?", "Yes", "No");
                    if (confirm_delete)
                    {
                        progress_deletion.IsVisible = true;
                        lbl_prog_percent.IsVisible = true;
                        progress = 0;

                        btn_delete_data.IsEnabled = false;
                        DependencyService.Get<INotifications>().ToastDependency("Deleting please wait...");

                        Device.StartTimer(new TimeSpan(0, 0, 0, 0, 250), () =>
                        {

                            Task.Run(() =>
                            {
                                //progress_deletion.ProgressTo(progress_deletion.Progress, 2000, Easing.Linear);
                                progress_deletion.ProgressTo(_progress, 2000, Easing.Linear);
                            });
                            return progress_deletion.IsVisible;
                        });

                        await Task.Run(() =>
                        {
                            try
                            {

                                DatabaseManipulator.ResetUserData(ref _progress);
                                //DependencyService.Get<INotifications>().ToastDependency("User data deleted!");
                            }
                            catch
                            {
                                //DependencyService.Get<INotifications>().ToastDependency("An error has occured!");
                            }
                            finally
                            {

                                //progress_deletion.IsVisible = false;
                                //DependencyService.Get<INotifications>().ToastDependency("Done!");
                            }
                            return false;
                        });

                        await progress_deletion.ProgressTo(1, 1000, Easing.Linear);

                        Device.StartTimer(new TimeSpan(0, 0, 0, 3, 250), () =>
                        {
                            progress_deletion.IsVisible = false;
                            lbl_prog_percent.IsVisible = false;
                            DisplayAlert("Deleted!", "User achievements have been deleted", "OK");
                            return false;
                        });
                    }
                })
            });
                
                
                
        }
    }
}
