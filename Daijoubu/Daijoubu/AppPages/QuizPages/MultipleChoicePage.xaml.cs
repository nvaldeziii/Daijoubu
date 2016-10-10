using Daijoubu.AppModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class MultipleChoicePage : ContentPage
    {
        private string Answer;
        Settings Setting;

        public MultipleChoicePage()
        {
            InitializeComponent();

            btn_choice1.Clicked += CheckAnswer;
            btn_choice2.Clicked += CheckAnswer;
            btn_choice3.Clicked += CheckAnswer;
            btn_choice4.Clicked += CheckAnswer;

            Setting = new Settings();
            GenerateQuestion();
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            ButtonsEnabled(false);

            var user_ans = ((Button)(sender)).Text; 
            if(user_ans == Answer)
            {
                //correct answer
                this.BackgroundColor = Color.Green;
            }
            else
            {
                //wrong answer
                this.BackgroundColor = Color.Red;
            }

            Device.StartTimer(Setting.MultipleChoice.AnswerFeedBackDelay, () => {
                GenerateQuestion();
                return false;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="correct_ans">Should be romaji</param>
        public void GenerateChoices(string correct_ans)
        {
            Random rand = new Random();
            var random_num = rand.Next(0, JapaneseDatabase.Table_Kana.Count);

            string[] choices = new string[4];

            choices[0] = (from y in JapaneseDatabase.Table_Kana where y.romaji == correct_ans select y).First().romaji;
            choices[1] = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;
            choices[2] = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;
            choices[3] = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;

            Random rnd = new Random();
            choices = choices.OrderBy(x => rnd.Next()).ToArray();

            btn_choice1.Text = choices[0];
            btn_choice2.Text = choices[1];
            btn_choice3.Text = choices[2];
            btn_choice4.Text = choices[3];
        }

        public void GenerateQuestion()
        {
            this.BackgroundColor = Color.White;
            Random rand = new Random();

            tbl_kana kana = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)];

            label_question.Text = kana.hiragana;

            Answer = kana.romaji;
            GenerateChoices(Answer);

            ButtonsEnabled(true);
        }

        public void ButtonsEnabled(bool value)
        {
            btn_choice1.IsEnabled = value;
            btn_choice2.IsEnabled = value;
            btn_choice3.IsEnabled = value;
            btn_choice4.IsEnabled = value;
        }
    }

}
