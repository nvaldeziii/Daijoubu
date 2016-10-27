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
        List<AbstractCardTable> GeneralKanaTable;
        GeneralType _WordType;

        public AchivementPage(GeneralType WordType)
        {
            InitializeComponent();

            if (_WordType == GeneralType.Hiragana)
            {
                GeneralKanaTable = UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>();
            }
            else if (_WordType == GeneralType.Katakana)
            {
                GeneralKanaTable = UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>();
            }
            else
            {
                throw new Exception("achivement page.cs");
            }

            _WordType = WordType;
            UserCard_Kana = new ObservableCollection<UserAchivements>();

            bool checkCount = (GeneralKanaTable.Count == JapaneseDatabase.Table_Kana.Count);

            for (int i = 0; i < GeneralKanaTable.Count; i++)
            {
                DateTime _LastView;
                try
                {
                    _LastView = Convert.ToDateTime(GeneralKanaTable[i].LastView);
                }
                catch { _LastView = DateTime.Now; }
                if (GeneralKanaTable[i].CorrectCount != 0 || GeneralKanaTable[i].MistakeCount != 0)
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
                    else
                    {
                        throw new Exception("achivement page.cs");
                    }
                    UserCard_Kana.Add(new UserAchivements
                    {
                        ItemID = JapaneseDatabase.Table_Kana[i].Id,
                        Item = _item,
                        Item2 = "null",
                        Correct = GeneralKanaTable[i].CorrectCount,
                        Mistake = GeneralKanaTable[i].MistakeCount,
                        LastView = GeneralKanaTable[i].LastView,
                        Percent = Computer.ForPercentage(UserDatabase.Table_UserKanaCardsN5[i].CorrectCount, GeneralKanaTable[i].MistakeCount),
                        NextQueue = Computer.NextQueingSpanToString(Computer.NextQueingSpan(_LastView, GeneralKanaTable[i].CorrectCount, GeneralKanaTable[i].MistakeCount))
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
