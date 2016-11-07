using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class ListeningPage : ContentPage, IQuiz
    {
        private string ToSpeak;
        bool correct;
        TypingQuestionFactory QuestionFactory;
        Settings Setting;
        Random random;

        private static Color PageColorDefault = Settings.PageColorDefault;
        private static Color ButtonColorDefault = Settings.ButtonColorDefault;
        private static Color PageColorCorrect = Settings.PageColorCorrect;
        private static Color PageColorMistake = Settings.PageColorMistake;

        public ListeningPage()
        {
            InitializeComponent();
            InitializeEvents();

            lbl_correct_ans.IsVisible = false;
            btn_submit.Clicked += (object sender, EventArgs e) =>
            {
                CheckAnswer(edittext_tts_input.Text);
            };

            edittext_tts_input.Completed += (s, e) => {
                CheckAnswer(edittext_tts_input.Text);
            };

            QuestionFactory = new TypingQuestionFactory();
            Setting = new Settings();
            random = new Random();
            ToSpeak = "";

            GenerateQuestion();
        }

        void InitializeEvents()
        {
            this.img_speaker.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    DependencyService.Get<ITextToSpeech>().Speak(ToSpeak);
                }),
                NumberOfTapsRequired = 1
            });

        }


        public void CheckAnswer(int id)
        {
            if (correct)
            {
                //change data in id
            }
        }

        public void CheckAnswer(string user_answer)
        {
            EnableInterfaces(false);

            if (user_answer == QuestionFactory.Answer)
            {
                //correct answer
                correct = true;
                this.BackgroundColor = PageColorCorrect;
            }
            else
            {
                //wrong answer
                this.BackgroundColor = PageColorMistake;
                if (Setting.HapticFeedback)
                {
                    DependencyService.Get<Dependencies.INotifications>().Vibrate();
                }
            }

            lbl_correct_ans.Text = string.Format("{0}", QuestionFactory.Answer);

            Device.StartTimer(Setting.MultipleChoice.AnswerFeedBackDelay, () => {
                GenerateQuestion();
                return false;
            });
        }

        public void GenerateQuestion()
        {
            correct = false;
            edittext_tts_input.Text = "";
            this.BackgroundColor = PageColorDefault;

            QuestionFactory.GenerateQuestion(
                random.Next(0, JapaneseDatabase.Table_Vocabulary_N5.Count),
                TypingQuestionFactory.QuestionType.VoicedKanji); // this should not be random

            ToSpeak = QuestionFactory.Question;
            DependencyService.Get<Dependencies.ITextToSpeech>().Speak(ToSpeak);
            EnableInterfaces(true);
        }

        public void EnableInterfaces(bool value)
        {
            btn_submit.IsEnabled = value;
            edittext_tts_input.IsEnabled = value;
            lbl_correct_ans.IsVisible = !value;
        }

        protected override bool OnBackButtonPressed()
        {
            //Navigation.PopAsync();
            //Navigation.PushAsync(new ProfilePages.AssesmentPage());
            Navigation.PushModalAsync(new ProfilePages.AssesmentPage {
                Padding = 0
            });
            return false;
        }
    }
}
