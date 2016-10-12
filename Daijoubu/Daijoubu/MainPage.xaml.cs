using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.Padding = -50;
            var japaneseDBO = DependencyService.Get<ISQLite>().GetConnection();
            var userDBO = DependencyService.Get<ISQLite>().GetConnection("userdb.db3");

            //save the japanese dictionary to local list
            japaneseDBO.CreateTable<tbl_kana>();
            japaneseDBO.CreateTable<tbl_vocabulary_N5>();
            japaneseDBO.TableChanged += JapaneseDBO_TableChanged;

            JapaneseDatabase.Table_Vocabulary_N5 = japaneseDBO.Table<tbl_vocabulary_N5>().ToList();
            JapaneseDatabase.Table_Kana = japaneseDBO.Table<tbl_kana>().ToList();

            userDBO.TableChanged += UserDBO_TableChanged;
            UserDatabase.Table_UserKanaCardsN5 = userDBO.Table<tbl_user_card_kana_N5Data>().ToList();

        }

        private void JapaneseDBO_TableChanged(object sender, SQLite.NotifyTableChangedEventArgs e)
        {
            if ((e.GetType().Equals(typeof(tbl_user_card_kana_N5Data))))
            {
                JapaneseDatabase.Table_Vocabulary_N5 = ((SQLite.SQLiteConnection)(sender)).Table<tbl_vocabulary_N5>().ToList();
            }else if ((e.GetType().Equals(typeof(tbl_kana))))
            {
                JapaneseDatabase.Table_Kana = ((SQLite.SQLiteConnection)(sender)).Table<tbl_kana>().ToList();
            }
        }

        private void UserDBO_TableChanged(object sender, SQLite.NotifyTableChangedEventArgs e)
        {
            if((e.GetType().Equals(typeof(tbl_user_card_kana_N5Data))))
            {
                UserDatabase.Table_UserKanaCardsN5 = ((SQLite.SQLiteConnection)(sender)).Table<tbl_user_card_kana_N5Data>().ToList();
            }
        }
    }
}
