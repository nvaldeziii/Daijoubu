
using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Daijoubu.AppLibrary.Categories;

namespace Daijoubu.AppPages.QuizPages
{
    public partial class MultipleChoicePage : ContentPage, IQuiz
    {
        private string Answer;
        private bool IsCorrect;

        Settings Setting;
        MultipleChoiceQuestionFactory QuestionFactory;
        Random random;
        Card CurrentQuestion;
        MultipleChoiceCategory QuizCategory;
        public MultipleChoicePage(MultipleChoiceCategory category)
        {
            InitializeComponent();

            FontChanger();
            btn_choice1.MinimumHeightRequest = Device.GetNamedSize(NamedSize.Large, typeof(Button)) * Settings.FontSizeMultiplier;
            btn_choice2.MinimumHeightRequest = Device.GetNamedSize(NamedSize.Large, typeof(Button)) * Settings.FontSizeMultiplier;
            btn_choice3.MinimumHeightRequest = Device.GetNamedSize(NamedSize.Large, typeof(Button)) * Settings.FontSizeMultiplier;
            btn_choice4.MinimumHeightRequest = Device.GetNamedSize(NamedSize.Large, typeof(Button)) * Settings.FontSizeMultiplier;

            random = new Random();
            QuizCategory = category;
            QuestionFactory = new MultipleChoiceQuestionFactory();
            btn_choice1.Clicked += CheckAnswer;
            btn_choice2.Clicked += CheckAnswer;
            btn_choice3.Clicked += CheckAnswer;
            btn_choice4.Clicked += CheckAnswer;

            Setting = new Settings();

            EnableInterfaces(false);

            Device.StartTimer(Setting.MultipleChoice.AnswerFeedBackDelay, () =>
            {
                GenerateQuestion(QuizCategory);
                return false;
            });
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            CheckAnswer(((Button)(sender)).Text);
            if (!IsCorrect)
            {
                if (btn_choice1.Text == QuestionFactory.Answer)
                {
                    btn_choice1.BackgroundColor = Settings.PageColorCorrect;
                }
                else if (btn_choice2.Text == QuestionFactory.Answer)
                {
                    btn_choice2.BackgroundColor = Settings.PageColorCorrect;
                }
                else if (btn_choice3.Text == QuestionFactory.Answer)
                {
                    btn_choice3.BackgroundColor = Settings.PageColorCorrect;
                }
                else if (btn_choice4.Text == QuestionFactory.Answer)
                {
                    btn_choice4.BackgroundColor = Settings.PageColorCorrect;
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

        public bool GenerateQuestion(MultipleChoiceCategory category)
        {
            bool Threshold = false;
            MultipleChoiceQuestionFactory.QuestionType nextnum;
            Queue<Card> TMPQueueHolder;
            if (category == MultipleChoiceCategory.Hiragana)
            {
                nextnum = MultipleChoiceQuestionFactory.QuestionType.Hiragana;
                TMPQueueHolder = UserDatabase.KanaCardQueue;
            }
            else if (category == MultipleChoiceCategory.Katakana)
            {
                nextnum = MultipleChoiceQuestionFactory.QuestionType.Katakana;
                TMPQueueHolder = UserDatabase.KataKanaCardQueue;
            }
            else if (category == MultipleChoiceCategory.Vocabulary)
            {
                nextnum = ((MultipleChoiceQuestionFactory.QuestionType)random.Next(5, 7));
                TMPQueueHolder = UserDatabase.VocabularyCardQueue;
            }
            else if (category == MultipleChoiceCategory.Meaning)
            {
                nextnum = ((MultipleChoiceQuestionFactory.QuestionType)random.Next(3, 4));
                TMPQueueHolder = UserDatabase.VocabularyCardQueue;
            }
            else
            {
                throw new Exception("MultipleChoicePage->GenerateQuestion->QuestionType");
            }

            this.BackgroundColor = Settings.PageColorDefault;

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
                QuestionFactory.GenerateKanaQuestion(CurrentQuestion.Id + 5, CurrentQuestion.Id, nextnum);
            }
            catch
            {
                QuestionFactory.GenerateKanaQuestion(CurrentQuestion.Id, CurrentQuestion.Id, nextnum);
            }
            label_question.Text = QuestionFactory.Question;

            Answer = QuestionFactory.Answer;
            GenerateChoices(QuestionFactory.Choices);

            lbl_debug_ans.Text = QuestionFactory.Answer;
            lbl_debug_txt.Text = string.Format("[DEBUG] Question Id: {0}", CurrentQuestion.Id);
            lbl_percent.Text = string.Format("Learn ratio: {0:0.00}%", CurrentQuestion.LearnPercent);
            RefreshItemInfo();

            EnableInterfaces(true);
            SaveQueue(TMPQueueHolder);
            //prepare for next queue

            //font change
            this.FontChanger();

            return Threshold;
        }

        private Queue<Card> ReplenishQueue()
        {
            if (QuizCategory == MultipleChoiceCategory.Hiragana)
            {
                return UserDatabase.KanaCardQueue = Computer.CreateQueue(UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>());
            }
            else if (QuizCategory == MultipleChoiceCategory.Katakana)
            {
                return UserDatabase.KataKanaCardQueue = Computer.CreateQueue(UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>());
            }
            else if (QuizCategory == MultipleChoiceCategory.Vocabulary || QuizCategory == MultipleChoiceCategory.Meaning)
            {
                return UserDatabase.VocabularyCardQueue = Computer.CreateQueue(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>());
            }
            else
            {
                throw new Exception("MultipleChoicePage->GenerateQuestion->replenish");
            }
        }

        private void SaveQueue(Queue<Card> tmpqueue)
        {
            if (QuizCategory == MultipleChoiceCategory.Hiragana)
            {
                UserDatabase.KanaCardQueue = tmpqueue;
            }
            else if (QuizCategory == MultipleChoiceCategory.Katakana)
            {
                UserDatabase.KataKanaCardQueue = tmpqueue;
            }
            else if (QuizCategory == MultipleChoiceCategory.Vocabulary || QuizCategory == MultipleChoiceCategory.Meaning)
            {
                UserDatabase.VocabularyCardQueue = tmpqueue;
            }
            else
            {
                throw new Exception("MultipleChoicePage->GenerateQuestion->savequeue");
            }
        }

        public void CheckAnswer(string user_ans)
        {
            EnableInterfaces(false);
            if (user_ans == Answer)
            {
                //correct answer
                this.BackgroundColor = Settings.PageColorCorrect;
                IsCorrect = true;

                CurrentQuestion.CorrectCount++;
                CurrentQuestion.LastView = DateTime.Now;
                //save to sql
                DatabaseManipulator.Update_User_KanaCardN5(QuizCategory, CurrentQuestion.CorrectCount, CurrentQuestion.Id, IsCorrect);
            }
            else
            {
                //wrong answer
                this.BackgroundColor = Settings.PageColorMistake;
                IsCorrect = false;
                CurrentQuestion.MistakeCount++;
                CurrentQuestion.LastView = DateTime.Now;

                //save to sql
                DatabaseManipulator.Update_User_KanaCardN5(QuizCategory, CurrentQuestion.MistakeCount, CurrentQuestion.Id, IsCorrect);

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
            else if (QuizCategory == MultipleChoiceCategory.Vocabulary || QuizCategory == MultipleChoiceCategory.Meaning)
            {
                UserDatabase.Table_UserVocabCardsN5[cardIndex].CorrectCount = CurrentQuestion.CorrectCount;
                UserDatabase.Table_UserVocabCardsN5[cardIndex].MistakeCount = CurrentQuestion.MistakeCount;
                UserDatabase.Table_UserVocabCardsN5[cardIndex].LastView = CurrentQuestion.LastView.ToString();
            }

            //Show timespan
            RefreshItemInfo();




            Device.StartTimer(Setting.MultipleChoice.AnswerFeedBackDelay, () =>
            {
                GenerateQuestion(QuizCategory);
                return false;
            });
        }

        private void RefreshItemInfo()
        {
            TimeSpan span = Computer.NextQueingSpan(CurrentQuestion.LastView, CurrentQuestion.CorrectCount, CurrentQuestion.MistakeCount);
            lbl_nextview.Text = Computer.NextQueingSpanToString(span);
            lbl_percent.Text = string.Format("Learn ratio: {0}%", CurrentQuestion.LearnPercent);
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
                     btn_choice4.BackgroundColor = Settings.ButtonColorDefault;
            }
        }

        public void SetQuestionFontSize()
        {
            //label_question.FontSize =;
        }

        protected override bool OnBackButtonPressed()
        {
            //Navigation.PopAsync();
            //Navigation.PushAsync(new ProfilePages.AssesmentPage());
            Navigation.PushModalAsync(new ProfilePages.AssesmentPage
            {
                Padding = 0
            });
            return false;
        }

        void FontChanger()
        {
            if (label_question.Text.Length > 3)
            {
                label_question.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) * Settings.FontSizeMultiplier;
            }
            else
            {
                label_question.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * Settings.FontSizeMultiplier;
            }

            
            btn_choice1.FontSize = Computer.AnswerButtonFontSize(btn_choice1.Text.Length, Settings.FontSizeMultiplier);
            btn_choice2.FontSize = Computer.AnswerButtonFontSize(btn_choice2.Text.Length, Settings.FontSizeMultiplier);
            btn_choice3.FontSize = Computer.AnswerButtonFontSize(btn_choice3.Text.Length, Settings.FontSizeMultiplier);
            btn_choice4.FontSize = Computer.AnswerButtonFontSize(btn_choice4.Text.Length, Settings.FontSizeMultiplier);
        }

    }

}
