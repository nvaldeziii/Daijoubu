
using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class MultipleChoicePage : ContentPage , IQuiz
    {
        private string Answer;
        private bool IsCorrect;

        Settings Setting;
        MultipleChoiceQuestionFactory QuestionFactory;
        Random random;
        Card CurrentQuestion;

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
            CheckAnswer(((Button)(sender)).Text);
            if (!IsCorrect)
            {
                if(btn_choice1.Text == QuestionFactory.Answer)
                {
                    btn_choice1.BackgroundColor = Color.Green;
                }else if (btn_choice2.Text == QuestionFactory.Answer)
                {
                    btn_choice2.BackgroundColor = Color.Green;
                }
                else if (btn_choice3.Text == QuestionFactory.Answer)
                {
                    btn_choice3.BackgroundColor = Color.Green;
                }
                else if (btn_choice4.Text == QuestionFactory.Answer)
                {
                    btn_choice4.BackgroundColor = Color.Green;
                }
            }

            if (Setting.SpeakWords)
            {
                string ToSpeak = "";

                if (!JapaneseCharacter.ContainsAlphabet(QuestionFactory.Answer))
                {
                    ToSpeak = QuestionFactory.Answer;
                    DependencyService.Get<Dependencies.ITextToSpeech>().Speak(ToSpeak);
                }
                else if (!JapaneseCharacter.ContainsAlphabet(QuestionFactory.Question))
                {
                    ToSpeak = QuestionFactory.Question;
                    DependencyService.Get<Dependencies.ITextToSpeech>().Speak(ToSpeak);
                }          
            }
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

            //0 ,3 is kana
            //3 , 9 is vocabs
            CurrentQuestion = UserDatabase.KanaCardQueue.Pop();
            QuestionFactory.GenerateKanaQuestion(UserDatabase.KanaCardQueueHigh, CurrentQuestion.Id, ((MultipleChoiceQuestionFactory.QuestionType)random.Next(0, 3)));
            label_question.Text = QuestionFactory.Question;
            Answer = QuestionFactory.Answer;
            GenerateChoices(QuestionFactory.Choices);

            EnableInterfaces(true);
        }

        public void CheckAnswer(string user_answer)
        {
            EnableInterfaces(false);
            if (user_answer == Answer)
            {
                //correct answer
                this.BackgroundColor = Color.Green;
                IsCorrect = true;

                CurrentQuestion.CorrectCount++;
                //todo: save to sql
                //

                var SQLConnection = DependencyService.Get<ISQLite>().GetUserDBconnection();
                SQLConnection.BeginTransaction();
                SQLConnection.Execute(string.Format("UPDATE tbl_us_cardknN5Dt SET CorrectCount={0},LastView=\"{1}\""
                    , CurrentQuestion.CorrectCount
                    , CurrentQuestion.LastView));
                SQLConnection.Commit();
            }
            else
            {
                //wrong answer
                this.BackgroundColor = Color.Red;
                IsCorrect = false;
                CurrentQuestion.MistakeCount++;
                CurrentQuestion.LastView = DateTime.Now;
                //todo: save to sql
                //

                UserDatabase.KanaCardQueue.Push(CurrentQuestion);
                var SQLConnection = DependencyService.Get<ISQLite>().GetUserDBconnection();
                SQLConnection.BeginTransaction();
                SQLConnection.Execute(string.Format("UPDATE tbl_us_cardknN5Dt SET MistakeCount={0},LastView=\"{1}\""
                    , CurrentQuestion.MistakeCount
                    , CurrentQuestion.LastView));
                SQLConnection.Commit();

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

        public void EnableInterfaces(bool value)
        {
            btn_choice1.IsEnabled = value;
            btn_choice2.IsEnabled = value;
            btn_choice3.IsEnabled = value;
            btn_choice4.IsEnabled = value;

            if (value == true)
            {
                btn_choice1.BackgroundColor =
                     btn_choice2.BackgroundColor =
                     btn_choice3.BackgroundColor =
                     btn_choice4.BackgroundColor = Color.Gray;
            }
        }
    }

}
