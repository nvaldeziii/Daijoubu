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
                UserCard_Kana.Add(new UserAchivements
                {
                    Item = JapaneseDatabase.Table_Kana[i].hiragana,
                    Item2 = JapaneseDatabase.Table_Kana[i].katakana,
                    Correct = UserDatabase.Table_UserKanaCardsN5[i].CorrectCount,
                    Mistake = UserDatabase.Table_UserKanaCardsN5[i].MistakeCount,
                    LastView = UserDatabase.Table_UserKanaCardsN5[i].LastView
                });

                
            }
            listview_achivements.HasUnevenRows = true;
            listview_achivements.ItemsSource = UserCard_Kana;
        }

        private class UserAchivements
        {
            public string Item { get; set; }
            public string Item2 { get; set; }
            public int Correct { get; set; }
            public int Mistake { get; set; }
            public string LastView { get; set; }

        }
    }


}
