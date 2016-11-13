using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.ProfilePages
{
    public partial class JLPTN4SelectorPage : ContentPage
    {
        public JLPTN4SelectorPage()
        {
            InitializeComponent();

            btn_vocabulary.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Vocabulary,false));
                })
            });

            btn_grammar.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AchivementPage(AppLibrary.Categories.GeneralType.Grammar, false));
                })
            });

            btn_assess.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AssesmentPage(false));
                })
            });
        }
    }
}
