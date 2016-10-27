using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public static class ListBuilder
    {
        public static ObservableCollection<AppModel.lv_binding_hp_notifications> HomePageNotifications()
        {
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
                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.hiragana,
                        Title = "Study this card",
                        Percent = percentage.ToString(),
                        TableName = "Table_UserKanaCardsN5",
                        ItemID = item.Id,
                        Clock = Computer.NextQueingSpanToString(tspan),
                        _tspan = tspan,
                        Subtitle = "Sample subs"
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
                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.katakana,
                        Title = "Study this card",
                        Percent = percentage.ToString(),
                        TableName = "Table_UserKataKanaCardsN5",
                        ItemID = item.Id,
                        Clock = Computer.NextQueingSpanToString(tspan),
                        _tspan = tspan,
                        Subtitle = "Sample subs"
                    });
                }
            }

            /*
             * Vocabulary
             */
            for (int i = 0; i < UserDatabase.Table_UserVocabCardsN5.Count; i++)
            {
                var item = UserDatabase.Table_UserVocabCardsN5[i];
                var percentage = Computer.ForPercentage(item.CorrectCount, item.MistakeCount);
                if (percentage < 70 && (item.CorrectCount != 0 || item.MistakeCount != 0))
                {
                    var Card = JapaneseDatabase.Table_Vocabulary_N5[i];
                    var tspan = Computer.NextQueingSpan(Convert.ToDateTime(item.LastView), item.CorrectCount, item.MistakeCount);
                    _List.Add(new lv_binding_hp_notifications
                    {
                        MainLabel = Card.kanji,
                        Title = Card.meaning,
                        Percent = percentage.ToString(),
                        TableName = "Table_UserVocabCardsN5",
                        ItemID = item.Id,
                        Clock = Computer.NextQueingSpanToString(tspan),
                        _tspan = tspan,
                        Subtitle = Card.furigana
                    });
                }
            }

            return new ObservableCollection<AppModel.lv_binding_hp_notifications>(_List.OrderBy(item => item._tspan));
        }


    }

}
