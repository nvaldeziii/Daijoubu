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
        public MultipleChoiceSettings MultipleChoice { get; set; }

        public void GetUserPreferences()
        {
            SetDefault(); //temporary
        }
        public void SetDefault()
        {
            MultipleChoice.AnswerFeedBackDelay = new TimeSpan(0, 0, 0, 1, 500);
            HapticFeedback = true;
        }
    }

    public class MultipleChoiceSettings
    {
        public TimeSpan AnswerFeedBackDelay;
    }

}
