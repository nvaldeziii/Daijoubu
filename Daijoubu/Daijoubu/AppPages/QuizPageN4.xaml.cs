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
                Navigation.PushAsync(new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Vocabulary));
            };
            btn_reading.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Vocabulary, true));
            };
            btn_grammar.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Meaning));
            };

            /////////////////////////////////////////////////////////////////////////////////
            //btn_multiple.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() =>
            //    {
            //        Navigation.PushAsync(new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Vocabulary));
            //    })
            //});
                

            //btn_reading.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() =>
            //    {
            //        Navigation.PushAsync(new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Vocabulary,true));
            //    })
            //});

            //btn_grammar.GestureRecognizers.Add(new TapGestureRecognizer
            //{
            //    Command = new Command(() =>
            //    {
            //        Navigation.PushAsync(new QuizPages.MultipleChoicePageN4(Categories.MultipleChoiceCategory.Meaning));
            //    })
            //});
        }
    }
}
