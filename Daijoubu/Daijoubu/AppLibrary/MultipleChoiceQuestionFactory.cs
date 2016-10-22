using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    
    public class MultipleChoiceQuestionFactory
    {
        public enum QuestionType
        {
            Hiragana, Katakana, Romaji, VocabularyJP, VocabularyEN, VocabularyFUJP, VocabularyJPFU, VocabularyENFU, VocabularyFUEN
        };

        public int QuestionID { get; private set; }
        public string Question { get; private set; }
        public string[] Choices { get; private set; }
        public string Answer { get; private set; }
        Random random;

        public MultipleChoiceQuestionFactory()
        {
            random = new Random();
        }
        public void GenerateKanaQuestion(QuestionType type)
        {
            GenerateKanaQuestion(JapaneseDatabase.Table_Kana.Count, random.Next(0, JapaneseDatabase.Table_Kana.Count), type);
        }
        public void GenerateKanaQuestion(int high, int CardId, QuestionType type,int low = 0)
        {
            //if (high > JapaneseDatabase.Table_Kana.Count)
            //{
            //    throw new Exception("MultipleChoiceQuestionFactory->GenerateHiraganaQuestion() error");
            //}
            //tbl_kana kana = JapaneseDatabase.Table_Kana[rand.Next(0, high)];
            int cardindex = CardId > 0 ? CardId  - 1 : 0;
            tbl_kana kana;
            tbl_vocabulary_N5 vocabulary;
            QuestionID = CardId;
            do
            {
                switch (type)
                {
                    case QuestionType.Hiragana:
                        kana = JapaneseDatabase.Table_Kana[cardindex];
                        Question = kana.hiragana;
                        Answer = kana.romaji;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Kana[random.Next(low, high)].romaji; });
                        break;
                    case QuestionType.Katakana:
                        kana = JapaneseDatabase.Table_Kana[cardindex];
                        Question = kana.katakana;
                        Answer = kana.romaji;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Kana[random.Next(low, high)].romaji; });
                        break;
                    case QuestionType.Romaji:
                        kana = JapaneseDatabase.Table_Kana[cardindex];
                        Question = kana.romaji;
                        Answer = kana.hiragana;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Kana[random.Next(low, high)].hiragana; });
                        break;
                    case QuestionType.VocabularyJP:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N5[cardindex];
                        Question = vocabulary.kanji;
                        Answer = vocabulary.meaning;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N5[random.Next(low, high)].meaning; });
                        break;
                    case QuestionType.VocabularyEN:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N5[cardindex];
                        Question = vocabulary.meaning;
                        Answer = vocabulary.kanji;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N5[random.Next(low, high)].kanji; });
                        break;
                    case QuestionType.VocabularyJPFU:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N5[cardindex];
                        Question = vocabulary.kanji;
                        Answer = vocabulary.furigana;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N5[random.Next(low, high)].furigana; });
                        break;
                    case QuestionType.VocabularyFUJP:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N5[cardindex];
                        Question = vocabulary.furigana;
                        Answer = vocabulary.kanji;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N5[random.Next(low, high)].kanji; });
                        break;
                    case QuestionType.VocabularyFUEN:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N5[cardindex];
                        Question = vocabulary.furigana;
                        Answer = vocabulary.meaning;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N5[random.Next(low, high)].meaning; });
                        break;
                    case QuestionType.VocabularyENFU:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N5[cardindex];
                        Question = vocabulary.meaning;
                        Answer = vocabulary.furigana;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N5[random.Next(low, high)].furigana; });
                        break;
                    default:
                        throw new Exception("MultipleChoiceQuestionFactory->GenerateHiraganaQuestion(){switch_default} error");
                }
            } while (Question == "null");
        }

        public void GenerateChoices(Func<string> Choice)
        {
            Choices = new string[4];
            Choices[0] = Answer;
            for (int i = 1; i <= 3; i++)
            {
                string _Choice = Choice();

                for (int j = 0; j < i; j++)
                {
                    while ( _Choice == Choices[j])
                    {
                        j = 0;
                        _Choice = Choice();
                    }
                }

                Choices[i] = _Choice;
            }
        }

        private string MakeConsistentFuriganaEnding(string FuriganaEnding)
        {
            string ConsistentFurigana = (from y in JapaneseDatabase.Table_Vocabulary_N5 where y.furigana.EndsWith(FuriganaEnding) select y.furigana).First();
            return ConsistentFurigana;
        }

        private string MakeConsistentKanjiEnding(string FuriganaEnding)
        {
            string ConsistentFurigana = (from y in JapaneseDatabase.Table_Vocabulary_N5 where y.kanji.EndsWith(FuriganaEnding) select y.furigana).First();
            return ConsistentFurigana;
        }

       
    }
}
