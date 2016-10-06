using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class ReadingPage : ContentPage
    {
        public ReadingPage()
        {
            InitializeComponent();

            label_question.Text = "私 _ 名前は松本です";

            btn_choice1.Text = "い";
            btn_choice2.Text = "る";
            btn_choice3.Text = "の";
            btn_choice4.Text = "が";
        }
    }
}
