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
            btn_multiple.Clicked += (o, e) =>
            {
                var page = new QuizPages.MCCatSelectPage();
                Navigation.PushAsync(page);
            };

            btn_listen.Clicked += (o, e) =>
            {
                var page = new QuizPages.ListeningPage();
                Navigation.PushAsync(page);
            };

            btn_reading.Clicked += (o, e) =>
            {
                //var page = new QuizPages.ReadingPage();
                var page = new QuizPages.MultipleChoicePage(Categories.MultipleChoiceCategory.Meaning);
                Navigation.PushAsync(page);
            };

            btn_typing.Clicked += (o, e) =>
            {
                var page = new QuizPages.TypingPage();
                Navigation.PushAsync(page);
            };

            btn_n5quizimage.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    DisplayAlert("Alert", "You Cliked the image", "K fine!");
                })
            });

        }
    }
}
