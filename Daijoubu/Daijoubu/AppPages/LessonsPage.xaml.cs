using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages
{
    public partial class LessonsPage : ContentPage
    {
        public LessonsPage()
        {
            InitializeComponent();

            btn_hiragana_lessons.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.ItemsPage(AppLibrary.Categories.Lessons.Hiragana, LessonProgress.Hiragana));
            };

            btn_katakana_lessons.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.ItemsPage(AppLibrary.Categories.Lessons.Katakana, LessonProgress.Katakana));
            };

            btn_n5vocab_lessons.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.ItemsPage(AppLibrary.Categories.Lessons.VocabularyN5, LessonProgress.VocabularyN5));
            };

            btn_n4vocab_lessons.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.ItemsPage(AppLibrary.Categories.Lessons.VocabularyN4, LessonProgress.VocabularyN4));
            };

            btn_n4grammar_lessons.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new AppPages.ItemsPage(AppLibrary.Categories.Lessons.SentencesN4, LessonProgress.GrammarN4));
            };
        }
    }
}
