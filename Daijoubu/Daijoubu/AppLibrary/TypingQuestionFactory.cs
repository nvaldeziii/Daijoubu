using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public class TypingQuestionFactory
    {
        public enum QuestionType
        {
             Sentence, VoicedKanji, Kanji, Meaning
        };

        public int QuestionId { get; private set; }
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public string Answer2 { get; private set; }
        Random random;

        public TypingQuestionFactory()
        {
            random = new Random();
        }

        public void GenerateQuestion(int CardId, QuestionType type)
        {
            tbl_vocabulary_N5 vocabulary;
            QuestionId = CardId;

            switch (type)
            {
                case QuestionType.Sentence:
                    throw new NotImplementedException();
                    //break;
                case QuestionType.VoicedKanji:
                    vocabulary = JapaneseDatabase.Table_Vocabulary_N5[CardId];
                    Question = vocabulary.kanji;
                    Answer = vocabulary.kanji;
                    Answer2 = vocabulary.furigana;
                    break;
                case QuestionType.Kanji:
                    vocabulary = JapaneseDatabase.Table_Vocabulary_N5[CardId];
                    Question = vocabulary.kanji;
                    Answer = Answer2 = vocabulary.furigana;
                    break;
                case QuestionType.Meaning:
                    vocabulary = JapaneseDatabase.Table_Vocabulary_N5[CardId];
                    Question = vocabulary.meaning;
                    Answer = vocabulary.kanji;
                    Answer2 = vocabulary.furigana;
                    break;
            }
        }
    }
}
