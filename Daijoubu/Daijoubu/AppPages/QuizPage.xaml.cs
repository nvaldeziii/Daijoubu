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
                AppPages.QuizPages.MultipleChoicePage page = new AppPages.QuizPages.MultipleChoicePage();
                Navigation.PushAsync(page);
            };

            btn_listen.Clicked += (o, e) =>
            {
                AppPages.QuizPages.ListeningPage page = new AppPages.QuizPages.ListeningPage();
                Navigation.PushAsync(page);
            };

            btn_reading.Clicked += (o, e) =>
            {
                AppPages.QuizPages.ReadingPage page = new AppPages.QuizPages.ReadingPage();
                Navigation.PushAsync(page);
            };

            btn_typing.Clicked += (o, e) =>
            {
                AppPages.QuizPages.TypingPage page = new AppPages.QuizPages.TypingPage();
                Navigation.PushAsync(page);
            };


        }
    }
}
