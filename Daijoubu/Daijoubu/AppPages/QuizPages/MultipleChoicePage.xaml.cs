using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class MultipleChoicePage : ContentPage
    {
        public MultipleChoicePage()
        {
            InitializeComponent();

            label_question.Text = "暑い";

            btn_choice1.Text = "あつい";
            btn_choice2.Text = "あたい";
            btn_choice3.Text = "あまい";
            btn_choice4.Text = "わるい";
        }
    }
}
