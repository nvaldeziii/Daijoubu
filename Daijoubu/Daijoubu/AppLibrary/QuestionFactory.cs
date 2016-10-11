using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public enum QuestionType
    {
        Hiragana, Katakana, Romaji
    };
    public class MultipleChoiceQuestionFactory
    {
        public string Question { get; private set; }
        public string[] Choices { get; private set; }
        public string Answer { get; private set; }
        Random rand;

        public MultipleChoiceQuestionFactory()
        {
            rand = new Random();
        }
        public void GenerateKanaQuestion(QuestionType type)
        {
            GenerateKanaQuestion(JapaneseDatabase.Table_Kana.Count, rand.Next(0, JapaneseDatabase.Table_Kana.Count), type);
        }
        public void GenerateKanaQuestion(int high, int CardId, QuestionType type)
        {
            if (high > JapaneseDatabase.Table_Kana.Count)
            {
                throw new Exception("MultipleChoiceQuestionFactory->GenerateHiraganaQuestion() error");
            }
            //tbl_kana kana = JapaneseDatabase.Table_Kana[rand.Next(0, high)];
            tbl_kana kana = JapaneseDatabase.Table_Kana[CardId];

            switch (type)
            {
                case QuestionType.Hiragana:
                    Question = kana.hiragana;
                    Answer = kana.romaji;
                    GenerateChoices(() => { return JapaneseDatabase.Table_Kana[rand.Next(0, high)].romaji; });
                    break;
                case QuestionType.Katakana:
                    Question = kana.katakana;
                    Answer = kana.romaji;
                    GenerateChoices(() => { return JapaneseDatabase.Table_Kana[rand.Next(0, high)].romaji; });
                    break;
                case QuestionType.Romaji:
                    Question = kana.romaji;
                    Answer = kana.hiragana;
                    GenerateChoices(() => { return JapaneseDatabase.Table_Kana[rand.Next(0, high)].hiragana; });
                    break;
                default:
                    throw new Exception("MultipleChoiceQuestionFactory->GenerateHiraganaQuestion(){switch_default} error");
            }
        }

        public void GenerateChoices(Func<string> Choice)
        {
            Choices = new string[4];
            Choices[0] = Answer;
            for (int i = 1; i <= 3; i++)
            {
                string _Choice;
                do
                {
                    _Choice = Choice();
                } while (_Choice == Answer);
                Choices[i] = _Choice;
            }
        }

    }
}
