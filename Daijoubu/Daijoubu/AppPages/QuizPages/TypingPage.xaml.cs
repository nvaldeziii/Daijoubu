using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static Daijoubu.AppLibrary.Categories;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class TypingPage : ContentPage
    {
        private string Answer;
        private bool IsCorrect;

        Settings Setting;
        MultipleChoiceQuestionFactory QuestionFactory;
        Random random;
        Card CurrentQuestion;
        MultipleChoiceCategory QuizCategory;

        private static Color PageColorDefault = Color.FromHex("273442");
        private static Color ButtonColorDefault = Color.FromHex("655338");
        private static Color PageColorCorrect = Color.Green;
        private static Color PageColorMistake = Color.Red;

        public TypingPage()
        {
            InitializeComponent();

            QuizCategory = MultipleChoiceCategory.Vocabulary;

            QuestionFactory = new MultipleChoiceQuestionFactory();
            random = new Random();
            Setting = new Settings();
            this.GenerateQuestion(QuizCategory);
            //label_question.Text = "日曜日";

            btn_submit.Clicked += (o, e) =>
            {
                CheckAnswer(textentry_answer.Text);
                textentry_answer.Text = "";
            };
        }

       

        public bool CheckAnswer(string user_ans)
        {
            EnableInterfaces(false);
            if (user_ans.Trim() == Answer.Trim())
            {
                //correct answer
                this.BackgroundColor = PageColorCorrect;
                IsCorrect = true;

                CurrentQuestion.CorrectCount += Setting.MultipleChoice.TypingQuizCorrectnessAdder; // add two to correcness on typing

                //save to sql
                DatabaseManipulator.Update_User_KanaCard(QuizCategory, CurrentQuestion.CorrectCount, CurrentQuestion.Id, IsCorrect);
            }
            else
            {
                //wrong answer
                this.BackgroundColor = PageColorMistake;
                IsCorrect = false;
                CurrentQuestion.MistakeCount++;
                CurrentQuestion.LastView = DateTime.Now;

                //save to sql
                DatabaseManipulator.Update_User_KanaCard(QuizCategory, CurrentQuestion.MistakeCount, CurrentQuestion.Id, IsCorrect);

                if (Setting.HapticFeedback)
                {
                    DependencyService.Get<Dependencies.INotifications>().Vibrate();
                }
            }

            var cardIndex = CurrentQuestion.Id - 1;
            if (QuizCategory == MultipleChoiceCategory.Hiragana)
            {
                UserDatabase.Table_UserKanaCardsN5[cardIndex].CorrectCount = CurrentQuestion.CorrectCount;
                UserDatabase.Table_UserKanaCardsN5[cardIndex].MistakeCount = CurrentQuestion.MistakeCount;
                UserDatabase.Table_UserKanaCardsN5[cardIndex].LastView = CurrentQuestion.LastView.ToString();
            }
            else if (QuizCategory == MultipleChoiceCategory.Katakana)
            {
                UserDatabase.Table_UserKataKanaCardsN5[cardIndex].CorrectCount = CurrentQuestion.CorrectCount;
                UserDatabase.Table_UserKataKanaCardsN5[cardIndex].MistakeCount = CurrentQuestion.MistakeCount;
                UserDatabase.Table_UserKataKanaCardsN5[cardIndex].LastView = CurrentQuestion.LastView.ToString();
            }
            else if (QuizCategory == MultipleChoiceCategory.Vocabulary)
            {
                UserDatabase.Table_UserVocabCardsN5[cardIndex].CorrectCount = CurrentQuestion.CorrectCount;
                UserDatabase.Table_UserVocabCardsN5[cardIndex].MistakeCount = CurrentQuestion.MistakeCount;
                UserDatabase.Table_UserVocabCardsN5[cardIndex].LastView = CurrentQuestion.LastView.ToString();
            }

            //Show timespan
            //RefreshItemInfo();

            Device.StartTimer(Setting.MultipleChoice.AnswerFeedBackDelay, () =>
            {
                GenerateQuestion(QuizCategory);
                return false;
            });

            if (!IsCorrect)
            {
                //what to do when incorrect answer
                this.BackgroundColor = PageColorMistake;
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

            return IsCorrect;
        }

        public bool GenerateQuestion(MultipleChoiceCategory category)
        {
            bool Threshold = false;
            MultipleChoiceQuestionFactory.QuestionType nextnum;
            Queue<Card> TMPQueueHolder;

            if (category == MultipleChoiceCategory.Vocabulary)
            {
                nextnum = ((MultipleChoiceQuestionFactory.QuestionType.VocabularyJPFU));
                TMPQueueHolder = UserDatabase.VocabularyCardQueue;
            }
            else
            {
                throw new Exception("TypingPage->GenerateQuestion->QuestionType");
            }

            this.BackgroundColor = PageColorDefault;

            if (!(TMPQueueHolder.Count > 0))
            {
                Threshold = true;
                TMPQueueHolder = ReplenishQueue();
            }

            //0 ,3 is kana
            //3 , 9 is vocabs
            CurrentQuestion = TMPQueueHolder.Dequeue();

            try
            {
                QuestionFactory.GenerateKanaQuestion(CurrentQuestion.Id + Setting.MultipleChoice.QuestionBufferCount, CurrentQuestion.Id, nextnum);
            }
            catch
            {
                QuestionFactory.GenerateKanaQuestion(CurrentQuestion.Id, CurrentQuestion.Id, nextnum);
            }
            label_question.Text = QuestionFactory.Question;
            Answer = QuestionFactory.Answer;

            //GenerateChoices(QuestionFactory.Choices);

            //lbl_debug_txt.Text = string.Format("[DEBUG] Question Id: {0}", CurrentQuestion.Id);
            //lbl_percent.Text = string.Format("Learn ratio: {0}%", CurrentQuestion.LearnPercent);
            //RefreshItemInfo();

            EnableInterfaces(true);
            SaveQueue(TMPQueueHolder);
            //prepare for next queue



            return Threshold;
        }

        private Queue<Card> ReplenishQueue()
        {
            return UserDatabase.VocabularyCardQueue = Computer.CreateQueue(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>());
        }

        private void SaveQueue(Queue<Card> tmpqueue)
        {
            if (QuizCategory == MultipleChoiceCategory.Vocabulary)
            {
                UserDatabase.VocabularyCardQueue = tmpqueue;
            }
            else
            {
                throw new Exception("TypingPage->GenerateQuestion->savequeue");
            }
        }

        public void EnableInterfaces(bool value)
        {
            btn_submit.IsEnabled = value;
        }
    }
}
