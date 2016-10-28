using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu
{
    public class Settings
    {
        public Settings()
        {
            MultipleChoice = new MultipleChoiceSettings();
            GetUserPreferences();
        }

        public bool HapticFeedback { get; set; }
        public bool SpeakWords { get; set; }
        public MultipleChoiceSettings MultipleChoice { get; set; }

        public void GetUserPreferences()
        {
            SetDefault(); //temporary
        }
        public void SetDefault()
        {
            MultipleChoice.AnswerFeedBackDelay = new TimeSpan(0, 0, 0, 1, 500);
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
