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
            btn_hiragana_quiz.Clicked += (o, e) => {
                var page = new QuizPages.MultipleChoicePage(MultipleChoiceCategory.Hiragana);
                Navigation.PushAsync(page);
            };

            btn_katakana_quiz.Clicked += (o, e) => {
                var page = new QuizPages.MultipleChoicePage(MultipleChoiceCategory.Katakana);
                Navigation.PushAsync(page);
            };

            btn_vocabulary_quiz.Clicked += (o, e) => {
                var page = new QuizPages.MultipleChoicePage(MultipleChoiceCategory.Vocabulary);
                Navigation.PushAsync(page);
            };
        }
    }
}
