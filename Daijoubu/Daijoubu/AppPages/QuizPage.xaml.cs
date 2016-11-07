using Daijoubu.AppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages
{
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();
            InitializeEvents();
        }

        void InitializeEvents()
        {
            btn_multiple.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.MCCatSelectPage());
                })
            });


            btn_listen.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.ListeningPage());
                })
            });


            btn_reading.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.MultipleChoicePage(Categories.MultipleChoiceCategory.Meaning));
                })
            });

            btn_typing.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.TypingPage());
                })
            });


        }
    }
}
