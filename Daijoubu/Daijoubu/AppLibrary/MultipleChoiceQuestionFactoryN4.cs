using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public class MultipleChoiceQuestionFactoryN4 : MultipleChoiceQuestionFactory
    {
        public new int QuestionID { get; private set; }
        public new string Question { get; private set; }
        public new string[] Choices { get; private set; }
        public new string Answer { get; private set; }
        Random random;

        public MultipleChoiceQuestionFactoryN4() : base()
        {
            random = new Random();
        }

        public override void GenerateKanaQuestion(int high, int CardId, QuestionType type, int low = 0)
        {
            int cardindex = CardId > 0 ? CardId - 1 : 0;
            tbl_vocabulary_N4 vocabulary;
            tbl_grammar_N4 grammar;
            QuestionID = CardId;
            do
            {
                switch (type)
                {
                    case QuestionType.VocabularyJP:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N4[cardindex];
                        Question = vocabulary.kanji;
                        Answer = vocabulary.meaning;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N4[random.Next(low, high)].meaning; });
                        break;
                    case QuestionType.VocabularyEN:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N4[cardindex];
                        Question = vocabulary.meaning;
                        Answer = vocabulary.kanji;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N4[random.Next(low, high)].kanji; });
                        break;
                    case QuestionType.VocabularyJPFU:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N4[cardindex];
                        Question = vocabulary.kanji;
                        Answer = vocabulary.furigana;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N4[random.Next(low, high)].furigana; });
                        break;
                    case QuestionType.VocabularyFUJP:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N4[cardindex];
                        Question = vocabulary.furigana;
                        Answer = vocabulary.kanji;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N4[random.Next(low, high)].kanji; });
                        break;
                    case QuestionType.VocabularyFUEN:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N4[cardindex];
                        Question = vocabulary.furigana;
                        Answer = vocabulary.meaning;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N4[random.Next(low, high)].meaning; });
                        break;
                    case QuestionType.VocabularyENFU:
                        vocabulary = JapaneseDatabase.Table_Vocabulary_N4[cardindex];
                        Question = vocabulary.meaning;
                        Answer = vocabulary.furigana;
                        GenerateChoices(() => { return JapaneseDatabase.Table_Vocabulary_N4[random.Next(low, high)].furigana; });
                        break;
                    case QuestionType.Grammar:
                        grammar = JapaneseDatabase.Table_Grammar_N4[cardindex];
                        var _x = GetGrammarSentence(grammar.sentence_jp);
                        Question = _x[0];
                        Answer = _x[1];
                        GenerateChoices(() => {
                            return JapaneseDatabase.HIRAGANA_ARRAY[random.Next(0, JapaneseDatabase.HIRAGANA_ARRAY.Length)].ToString();
                        });
                        break;
                    default:
                        throw new Exception("MultipleChoiceQuestionFactory->GenerateHiraganaQuestion(){switch_default} error");
                }
            } while (Question.ToLower() == "null" || Answer.ToLower() == "null");
        }

        string[] GetGrammarSentence(string jpsen)
        {
            jpsen = jpsen.Replace("_", "");
            int min = 0x3040;
            int max = 0x309F;
            string[] result = new string[2];

            List<char> hiragana = new List<char>();
            List<int> index = new List<int>();

            for (int i = 0; i < jpsen.Length; i++)
            {
                    if(jpsen[i] >= min && jpsen[i] <= max)
                    {
                        hiragana.Add(jpsen[i]);
                        index.Add(i);
                    }
            }
            //last resort so no error
            if(hiragana.Count == 0)
            {
                hiragana.Add(jpsen[0]);
                index.Add(0);
            }

            int result_index = new Random().Next(0, hiragana.Count);
            var result_sen = jpsen.ToCharArray();
            result_sen[index[result_index]] = '_';
            result[0] = "";
            foreach (var i in result_sen)
            {
                result[0] += i;
            }

            result[1] = hiragana[result_index].ToString();

            return result;
        }

        public new void GenerateChoices(Func<string> Choice)
        {
            Choices = new string[4];
            Choices[0] = Answer;
            for (int i = 1; i <= 3; i++)
            {
                string _Choice = Choice();

                for (int j = 0; j < i; j++)
                {
                    while (_Choice == Choices[j] || _Choice.ToLower() == "null")
                    {
                        j = 0;
                        _Choice = Choice();
                    }
                }

                Choices[i] = _Choice;
            }
        }
    }
}
