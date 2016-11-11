using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppLibrary
{
    public static class ListBuilder
    {
        public static List<AppModel.lv_binding_hp_notifications> HomePageNotifications()
        {
            double fontsize_multiplier = 3.5;
            List<AppModel.lv_binding_hp_notifications> _List = new List<AppModel.lv_binding_hp_notifications>();

            /*
             * Hiragana
             */
            for (int i = 0; i < UserDatabase.Table_UserKanaCardsN5.Count; i++)
            {
                var item = UserDatabase.Table_UserKanaCardsN5[i];
                var percentage = Computer.ForPercentage(item.CorrectCount, item.MistakeCount);
                if (percentage < 70 && (item.CorrectCount != 0 || item.MistakeCount != 0) )
                {
                    var Card = JapaneseDatabase.Table_Kana[i];
                    var tspan = Computer.NextQueingSpan(Convert.ToDateTime(item.LastView), item.CorrectCount, item.MistakeCount);

                    Color clockcolor = tspan.TotalSeconds < 0 ? clockcolor = Color.Red : Color.Default;

                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.hiragana,
                        Title = string.Format("💬: \"{0}\"", Card.romaji.ToUpper()),
                        Percent = percentage,
                        TableName = "Table_UserKanaCardsN5",
                        ItemID = item.Id,
                        Clock = Computer.SemanticTimespan(tspan),
                        ClockColor = clockcolor,
                        _tspan = tspan,
                        Subtitle = "",
                        _lastview = Computer.SemanticTimespan(Convert.ToDateTime(item.LastView)),
                        MainLabelFontSize = Computer.LabelFontSize(Card.hiragana.Length, fontsize_multiplier)
                    });
                }
            }

            /*
             * Katakana
             */
            for (int i = 0; i < UserDatabase.Table_UserKataKanaCardsN5.Count; i++)
            {
                var item = UserDatabase.Table_UserKataKanaCardsN5[i];
                var percentage = Computer.ForPercentage(item.CorrectCount, item.MistakeCount);
                if (percentage < 70 && (item.CorrectCount != 0 || item.MistakeCount != 0))
                {
                    var Card = JapaneseDatabase.Table_Kana[i];
                    var tspan = Computer.NextQueingSpan(Convert.ToDateTime(item.LastView), item.CorrectCount, item.MistakeCount);

                    Color clockcolor = tspan.TotalSeconds < 0 ? clockcolor = Color.Red : Color.Default;

                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.katakana,
                        Title = string.Format("💬: \"{0}\"", Card.romaji.ToUpper()),
                        Percent = percentage,
                        TableName = "Table_UserKataKanaCardsN5",
                        ItemID = item.Id,
                        Clock = Computer.SemanticTimespan(tspan),
                        ClockColor = clockcolor,
                        _tspan = tspan,
                        Subtitle = "",
                        _lastview = Computer.SemanticTimespan(Convert.ToDateTime(item.LastView)),
                        MainLabelFontSize = Computer.LabelFontSize(Card.katakana.Length, fontsize_multiplier)
                    });
                }
            }

            /*
             * Vocabulary N5
             */
            for (int i = 0; i < UserDatabase.Table_UserVocabCardsN5.Count; i++)
            {
                var item = UserDatabase.Table_UserVocabCardsN5[i];
                var percentage = Computer.ForPercentage(item.CorrectCount, item.MistakeCount);
                if (percentage < 70 && (item.CorrectCount != 0 || item.MistakeCount != 0))
                {
                    var Card = JapaneseDatabase.Table_Vocabulary_N5[i];
                    var tspan = Computer.NextQueingSpan(Convert.ToDateTime(item.LastView), item.CorrectCount, item.MistakeCount);

                    Color clockcolor = tspan.TotalSeconds < 0 ? clockcolor = Color.Red : Color.Default;
                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.kanji,
                        Title = string.Format("📖: \"{0}\"", Card.meaning),
                        Percent = percentage,
                        TableName = "Table_UserVocabCardsN5",
                        ItemID = item.Id,
                        Clock = Computer.SemanticTimespan(tspan),
                        ClockColor = clockcolor,
                        _tspan = tspan,
                        Subtitle = string.Format("💬: \"{0}\"", Card.furigana),
                        _lastview = Computer.SemanticTimespan(Convert.ToDateTime(item.LastView)),
                        MainLabelFontSize = Computer.LabelFontSize(Card.kanji.Length, fontsize_multiplier)
                    });
                }
            }

            /*
             * Vocabulary N4
             */
            for (int i = 0; i < UserDatabase.Table_UserVocabCardsN4.Count; i++)
            {
                var item = UserDatabase.Table_UserVocabCardsN4[i];
                var percentage = Computer.ForPercentage(item.CorrectCount, item.MistakeCount);
                if (percentage < 70 && (item.CorrectCount != 0 || item.MistakeCount != 0))
                {
                    var Card = JapaneseDatabase.Table_Vocabulary_N4[i];
                    var tspan = Computer.NextQueingSpan(Convert.ToDateTime(item.LastView), item.CorrectCount, item.MistakeCount);

                    Color clockcolor = tspan.TotalSeconds < 0 ? clockcolor = Color.Red : Color.Default;
                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.kanji,
                        Title = string.Format("📖: \"{0}\"", Card.meaning),
                        Percent = percentage,
                        TableName = "Table_UserVocabCardsN4",
                        ItemID = item.Id,
                        Clock = Computer.SemanticTimespan(tspan),
                        ClockColor = clockcolor,
                        _tspan = tspan,
                        Subtitle = string.Format("💬: \"{0}\"", Card.furigana),
                        _lastview = Computer.SemanticTimespan(Convert.ToDateTime(item.LastView)),
                        MainLabelFontSize = Computer.LabelFontSize(Card.kanji.Length, fontsize_multiplier)
                    });
                }
            }

            if(_List.Count == 0)
            {
                _List.Add(lv_binding_hp_notifications.Empty(fontsize_multiplier));
            }

            return new List<AppModel.lv_binding_hp_notifications>(_List.OrderBy(item => item._tspan));
        }


    }

}
