
using Daijoubu.AppLibrary;
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
        MultipleChoiceQuestionFactory QuestionFactory;
        Random random;
        public MultipleChoicePage()
        {
            InitializeComponent();
            random = new Random();
            QuestionFactory = new MultipleChoiceQuestionFactory();
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
                if (Setting.HapticFeedback)
                {
                    DependencyService.Get<Dependencies.INotifications>().Vibrate();
                }
            }

            Device.StartTimer(Setting.MultipleChoice.AnswerFeedBackDelay, () => {
                GenerateQuestion();
                return false;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void GenerateChoices(string[] choices)
        {
            //var random_num = rand.Next(0, JapaneseDatabase.Table_Kana.Count);

            //string[] choices = new string[4];

            //choices[0] = (from y in JapaneseDatabase.Table_Kana where y.romaji == correct_ans select y).First().romaji;
            //choices[1] = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;
            //choices[2] = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;
            //choices[3] = JapaneseDatabase.Table_Kana[rand.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;

            choices = choices.OrderBy(x => random.Next()).ToArray();

            btn_choice1.Text = choices[0];
            btn_choice2.Text = choices[1];
            btn_choice3.Text = choices[2];
            btn_choice4.Text = choices[3];
        }

        public void GenerateQuestion()
        {
            this.BackgroundColor = Color.White;

            //tbl_kana kana = JapaneseDatabase.Table_Kana[random.Next(0, JapaneseDatabase.Table_Kana.Count)];

            //label_question.Text = kana.hiragana;

            //Answer = kana.romaji;

            //string[] choices = new string[4];
            //choices[0] = Answer;
            //for (int i = 1; i <= 3; i++)
            //{
            //    choices[i] = JapaneseDatabase.Table_Kana[random.Next(0, JapaneseDatabase.Table_Kana.Count)].romaji;
            //}
            //GenerateChoices(choices);

            QuestionFactory.GenerateKanaQuestion(((QuestionType)random.Next(0, 3)));
            label_question.Text = QuestionFactory.Question;
            Answer = QuestionFactory.Answer;
            GenerateChoices(QuestionFactory.Choices);

            ButtonsEnabled(true);
        }

        public void ButtonsEnabled(bool value)
        {
            btn_choice1.IsEnabled = value;
            btn_choice2.IsEnabled = value;
            btn_choice3.IsEnabled = value;
            btn_choice4.IsEnabled = value;
        }

        private void HiraganaQuestion()
        {

        }

        private void KatanaQuestion()
        {

        }

        private void RomajiQuestion()
        {

        }

        private void JapaneseVocabularyQuestion()
        {

        }

        private void EnglishVocabularyQuestion()
        {

        }
    }

}
