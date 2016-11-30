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
        }
    }
}
