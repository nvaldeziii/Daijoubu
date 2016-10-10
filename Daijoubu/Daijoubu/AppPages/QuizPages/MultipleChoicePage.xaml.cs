using Daijoubu.AppModel;
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

            GenerateChoices();
            //btn_choice1.Text = "あつい";
            //btn_choice2.Text = "あたい";
            //btn_choice3.Text = "あまい";
            //btn_choice4.Text = "わるい";
        }

        public void GenerateChoices()
        {
            btn_choice1.Text = from y in JapaneseDatabase.Table_Kana where y.romaji == "a" select y;
            btn_choice2.Text = from y in JapaneseDatabase.Table_Kana where y.romaji == "ka" select y;
            btn_choice3.Text = from y in JapaneseDatabase.Table_Kana where y.romaji == "ga" select y;
            btn_choice4.Text = from y in JapaneseDatabase.Table_Kana where y.romaji == "sa" select y;
        }
    }
}
