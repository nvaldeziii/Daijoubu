using Daijoubu.Dependencies;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages
{
    public partial class SettingsPage : ContentPage
    {
        public Settings setting;
        double progress;
        public SettingsPage()
        {
            InitializeComponent();
            
            setting = new Settings();
            InitializeValues();

            btn_save.Clicked += async (o, e) => {
                progress_saving.IsVisible = true;
                btn_Discard.IsEnabled = false;
                btn_save.IsEnabled = false;

                DependencyService.Get<INotifications>().ToastDependency("Saving Please wait...!");

                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 250), () => {
                    Task.Run(() => {
                      
                        progress_saving.ProgressTo(progress, 2000, Easing.Linear);
                    });
                    return progress_saving.IsVisible;
                });

                Saving();

                await progress_saving.ProgressTo(1, 1000, Easing.Linear);

                Thread.Sleep(2000);
                Device.StartTimer(new TimeSpan(0, 0, 0, 3, 250), () => {
                    progress_saving.IsVisible = false;
                    //lbl_prog_percent.IsVisible = false;
                    DependencyService.Get<INotifications>().ToastDependency("Saved!");
                    return false;
                });

            };
        }

        async void Saving()
        {
            await Task.Run(() =>
            {
                try
                {
                    progress = 0;
                    
                    setting.HapticFeedback = switch_HapticFeedback.IsToggled;
                    setting.MultipleChoice.AnswerFeedBackDelay = new TimeSpan(0,0,0,0, Convert.ToInt32(slider_AnswerFeedBackDelay.Value));

                    setting.SaveCurrentConfig(ref progress);
                }
                finally
                {
                }
                return false;
            });           
        }

        void InitializeValues()
        {
            switch_HapticFeedback.IsToggled = setting.HapticFeedback;
        
            slider_AnswerFeedBackDelay.Value = setting.MultipleChoice.AnswerFeedBackDelay.TotalSeconds * 1000;
        }
    }
}
