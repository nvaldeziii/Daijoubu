using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static Daijoubu.AppLibrary.Categories;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class MCCatSelectPage : ContentPage
    {
        public MCCatSelectPage()
        {
            InitializeComponent();
            InitializeClickEvents();
        }

        void InitializeClickEvents()
        {
            btn_hiragana_quiz.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.MultipleChoicePage(MultipleChoiceCategory.Hiragana));
                })
            });



            btn_katakana_quiz.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.MultipleChoicePage(MultipleChoiceCategory.Katakana));
                })
            });


            btn_vocabulary_quiz.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new QuizPages.MultipleChoicePage(MultipleChoiceCategory.Vocabulary));
                })
            });

        }
    }
}
