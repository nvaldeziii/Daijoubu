using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.ProfilePages
{
    public partial class JLPTN5SelectorPage : ContentPage
    {
        public JLPTN5SelectorPage()
        {
            InitializeComponent();

            btn_hiragana_achivements.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Hiragana));
                })
            });

            btn_katakana_achivements.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Katakana));
                })
            });

            btn_vocabulary_achivements.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Vocabulary));
                })
            });

            btn_assess.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AssesmentPage());
                })
            });
        }
    }
}
