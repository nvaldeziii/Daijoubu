using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Daijoubu.AppPages.ProfilePages
{
    public partial class AchivementPage : ContentPage
    {
        ObservableCollection<UserAchivements> UserCard_Kana;
        public AchivementPage()
        {
            InitializeComponent();

            var x = UserDatabase.Table_UserKanaCardsN5;

            UserCard_Kana = new ObservableCollection<UserAchivements>();

            bool checkCount = (UserDatabase.Table_UserKanaCardsN5.Count == JapaneseDatabase.Table_Kana.Count);

            for (int i = 0; i < UserDatabase.Table_UserKanaCardsN5.Count; i++)
            {
                DateTime _LastView;
                try
                {
                    _LastView = Convert.ToDateTime(UserDatabase.Table_UserKanaCardsN5[i].LastView);
                }
                catch { _LastView = DateTime.Now; }
                if (UserDatabase.Table_UserKanaCardsN5[i].CorrectCount != 0 || UserDatabase.Table_UserKanaCardsN5[i].MistakeCount != 0)
                {
                    UserCard_Kana.Add(new UserAchivements
                    {
                        ItemID = JapaneseDatabase.Table_Kana[i].Id,
                        Item = JapaneseDatabase.Table_Kana[i].hiragana,
                        Item2 = JapaneseDatabase.Table_Kana[i].katakana,
                        Correct = UserDatabase.Table_UserKanaCardsN5[i].CorrectCount,
                        Mistake = UserDatabase.Table_UserKanaCardsN5[i].MistakeCount,
                        LastView = UserDatabase.Table_UserKanaCardsN5[i].LastView,
                        Percent = Computer.ForPercentage(UserDatabase.Table_UserKanaCardsN5[i].CorrectCount, UserDatabase.Table_UserKanaCardsN5[i].MistakeCount),
                        NextQueue = Computer.NextQueingSpanToString(Computer.NextQueingSpan(_LastView, UserDatabase.Table_UserKanaCardsN5[i].CorrectCount, UserDatabase.Table_UserKanaCardsN5[i].MistakeCount))
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

        private class UserAchivements
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
