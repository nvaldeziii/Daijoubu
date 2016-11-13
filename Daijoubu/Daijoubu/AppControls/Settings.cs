using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu
{
    public class Settings
    {
        public Settings()
        {
            MultipleChoice = new MultipleChoiceSettings();
            GetUserPreferences();
        }

        public static readonly double FontSizeMultiplier = 2.5;
        //public static readonly Color PageColorDefault = Color.FromHex("85E7E0");
        public static readonly Color PageColorDefault = Color.FromHex("cccccc");
        public static readonly Color ButtonColorDefault = Color.FromHex("595959");
        public static readonly Color PageColorCorrect = Color.FromHex("72EA65");
        public static readonly Color PageColorMistake = Color.FromHex("FD6E75");

        public static bool Greeted = false;

        public bool HapticFeedback { get; set; }
        public bool SpeakWords { get; set; }
        public MultipleChoiceSettings MultipleChoice { get; set; }

        public bool EnableN4 { get; set; }
        public bool ForceEnableN4 { get; set; }

        public void GetUserPreferences()
        {
            try
            {
                var _AnswerFeedBackDelay = Convert.ToInt32(UserDatabase.Table_UserSettings.Find(i => i.name == "AnswerFeedBackDelay").info);
                var _QuestionBufferCount = Convert.ToInt32(UserDatabase.Table_UserSettings.Find(i => i.name == "QuestionBufferCount").info);
                var _TypingQuizCorrectnessAdder = Convert.ToInt32(UserDatabase.Table_UserSettings.Find(i => i.name == "TypingQuizCorrectnessAdder").info);
                var _QueueCount = Convert.ToInt32(UserDatabase.Table_UserSettings.Find(i => i.name == "QueueCount").info);

                var _HapticFeedback = Convert.ToBoolean(UserDatabase.Table_UserSettings.Find(i => i.name == "HapticFeedback").info);
                var _SpeakWords = Convert.ToBoolean(UserDatabase.Table_UserSettings.Find(i => i.name == "SpeakWords").info);

                EnableN4 = Convert.ToBoolean(UserDatabase.Table_UserSettings.Find(i => i.name == "EnableN4").info);
                ForceEnableN4 = Convert.ToBoolean(UserDatabase.Table_UserSettings.Find(i => i.name == "ForceEnableN4").info);

                MultipleChoice.AnswerFeedBackDelay = new TimeSpan(0, 0, 0, 0, _AnswerFeedBackDelay);
                MultipleChoice.QuestionBufferCount = _QuestionBufferCount;
                MultipleChoice.TypingQuizCorrectnessAdder = _QuestionBufferCount;
                MultipleChoice.QueueCount = _QueueCount;

                HapticFeedback = _HapticFeedback;
                SpeakWords = _SpeakWords;
            }
            catch
            {
                SetDefault();
            }

        }

        public bool SaveCurrentConfig(ref double progress)
        {
            progress = 0;
            double current = 0;
            double total = 6 * 2;

            //save local
            UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "AnswerFeedBackDelay")].info = Convert.ToInt32(MultipleChoice.AnswerFeedBackDelay.TotalMilliseconds).ToString();
            progress = ++current / total;
            UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "QuestionBufferCount")].info = MultipleChoice.QuestionBufferCount.ToString();
            progress = ++current / total;
            UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "TypingQuizCorrectnessAdder")].info = MultipleChoice.TypingQuizCorrectnessAdder.ToString();
            progress = ++current / total;
            UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "QueueCount")].info = MultipleChoice.QueueCount.ToString();
            progress = ++current / total;

            UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "HapticFeedback")].info = HapticFeedback.ToString();
            progress = ++current / total;
            UserDatabase.Table_UserSettings[UserDatabase.Table_UserSettings.FindIndex(i => i.name == "SpeakWords")].info = SpeakWords.ToString();
            progress = ++current / total;

            //save db
            DatabaseManipulator.UpdateUserConfig("AnswerFeedBackDelay", Convert.ToInt32(MultipleChoice.AnswerFeedBackDelay.TotalMilliseconds).ToString());
            progress = ++current / total;
            DatabaseManipulator.UpdateUserConfig("QuestionBufferCount", MultipleChoice.QuestionBufferCount.ToString());
            progress = ++current / total;
            DatabaseManipulator.UpdateUserConfig("TypingQuizCorrectnessAdder", MultipleChoice.TypingQuizCorrectnessAdder.ToString());
            progress = ++current / total;
            DatabaseManipulator.UpdateUserConfig("QueueCount", MultipleChoice.QueueCount.ToString());
            progress = ++current / total;

            DatabaseManipulator.UpdateUserConfig("HapticFeedback", HapticFeedback.ToString());
            progress = ++current / total;
            DatabaseManipulator.UpdateUserConfig("SpeakWords", SpeakWords.ToString());
            progress = ++current / total;
            DatabaseManipulator.UpdateUserConfig("ForceEnableN4", ForceEnableN4.ToString());
            progress = ++current / total;

            return true;
        }

        public void SetDefault()
        {
            MultipleChoice.AnswerFeedBackDelay = new TimeSpan(0, 0, 0, 0, 1500);
            MultipleChoice.QuestionBufferCount = 5;
            MultipleChoice.TypingQuizCorrectnessAdder = 2;
            MultipleChoice.QueueCount = 5;

            HapticFeedback = true;
            SpeakWords = true;
        }
    }

    public static class SRSsettings
    {
        public static double PercentageMultiplier = 26.6667;
        public static double Multiplier = 1;

        public static double PercentageQuota = 50;
    }

    public class MultipleChoiceSettings
    {
        public TimeSpan AnswerFeedBackDelay;
        public int QuestionBufferCount { get; set; }
        public int QueueCount { get; set; }

        public int TypingQuizCorrectnessAdder { get; set; }
    }

}
