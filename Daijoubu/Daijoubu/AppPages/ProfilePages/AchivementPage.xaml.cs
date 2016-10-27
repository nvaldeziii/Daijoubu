using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static Daijoubu.AppLibrary.Categories;

namespace Daijoubu.AppPages.ProfilePages
{
    public partial class AchivementPage : ContentPage
    {
        ObservableCollection<UserAchivements> UserCard_Kana;
        List<AbstractCardTable> GeneralTable;
        GeneralType _WordType;

        public AchivementPage(GeneralType WordType)
        {
            InitializeComponent();

            if (_WordType == GeneralType.Hiragana)
            {
                GeneralTable = UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>();
            }
            else if (_WordType == GeneralType.Katakana)
            {
                GeneralTable = UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>();
            }
            else if (_WordType == GeneralType.Katakana)
            {
                GeneralTable = UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>();
            }
            else
            {
                throw new Exception("achivement page.cs");
            }

            _WordType = WordType;
            UserCard_Kana = new ObservableCollection<UserAchivements>();

            bool checkCount = (GeneralTable.Count == JapaneseDatabase.Table_Kana.Count);

            for (int i = 0; i < GeneralTable.Count; i++)
            {
                DateTime _LastView;
                try
                {
                    _LastView = Convert.ToDateTime(GeneralTable[i].LastView);
                }
                catch { _LastView = DateTime.Now; }
                if (GeneralTable[i].CorrectCount != 0 || GeneralTable[i].MistakeCount != 0)
                {
                    string _item;
                    if(_WordType == GeneralType.Hiragana)
                    {
                        _item = JapaneseDatabase.Table_Kana[i].hiragana;
                    }
                    else if (_WordType == GeneralType.Katakana)
                    {
                        _item = JapaneseDatabase.Table_Kana[i].katakana;
                    }
                    else if (_WordType == GeneralType.Vocabulary)
                    {
                        _item = JapaneseDatabase.Table_Vocabulary_N5[i].kanji;
                    }
                    else
                    {
                        throw new Exception("achivement page.cs");
                    }
                    UserCard_Kana.Add(new UserAchivements
                    {
                        ItemID = JapaneseDatabase.Table_Kana[i].Id,
                        Item = _item,
                        Item2 = "null",
                        Correct = GeneralTable[i].CorrectCount,
                        Mistake = GeneralTable[i].MistakeCount,
                        LastView = GeneralTable[i].LastView,
                        Percent = Computer.ForPercentage(GeneralTable[i].CorrectCount, GeneralTable[i].MistakeCount),
                        NextQueue = Computer.NextQueingSpanToString(Computer.NextQueingSpan(_LastView, GeneralTable[i].CorrectCount, GeneralTable[i].MistakeCount))
                    });
                }


            }
            if(UserCard_Kana.Count == 0)
            {
                UserCard_Kana.Add(new UserAchivements
                {
                    ItemID = 0,
                    Item = "Empty",
                    Item2 = null,
                    Correct = 0,
                    Mistake = 0,
                    LastView = null,
                    Percent = 0,
                    NextQueue = null
                });
            }
            listview_achivements.HasUnevenRows = true;
            listview_achivements.ItemsSource = UserCard_Kana;
        }

        public class UserAchivements
        {
            public int ItemID { get; set; }
            public string Item { get; set; }
            public string Item2 { get; set; }
            public int Correct { get; set; }
            public int Mistake { get; set; }
            public string LastView { get; set; }
            public string NextQueue { get; set; }
            public double Percent { get; set; }

        }
    }


}
