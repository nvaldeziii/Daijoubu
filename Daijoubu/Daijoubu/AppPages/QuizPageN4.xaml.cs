using Daijoubu.AppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages
{
    public partial class QuizPageN4 : ContentPage
    {
        public QuizPageN4()
        {
            InitializeComponent();

            btn_multiple.Clicked += (o, e) =>
            {
                var page = new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Vocabulary);
                Navigation.PushAsync(page);
            };

            btn_listen.Clicked += (o, e) =>
            {
                var page = new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Vocabulary,true);
                Navigation.PushAsync(page);
            };

            btn_reading.Clicked += (o, e) =>
            {
                //var page = new QuizPages.ReadingPage();
                var page = new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Meaning);
                Navigation.PushAsync(page);
            };
        }
    }
}
