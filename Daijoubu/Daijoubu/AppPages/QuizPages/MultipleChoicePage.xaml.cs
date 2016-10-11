
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

        public void GenerateChoices(string[] choices)
        {
            choices = choices.OrderBy(x => random.Next()).ToArray();

            btn_choice1.Text = choices[0];
            btn_choice2.Text = choices[1];
            btn_choice3.Text = choices[2];
            btn_choice4.Text = choices[3];
        }

        public void GenerateQuestion()
        {
            this.BackgroundColor = Color.White;

            QuestionFactory.GenerateKanaQuestion(((MultipleChoiceQuestionFactory.QuestionType)random.Next(0, 9))); // this should not be random
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

        private void JapaneseVocabularyQuestion()
        {

        }

        private void EnglishVocabularyQuestion()
        {

        }
    }

}
