using Daijoubu.AppLibrary;
using Daijoubu.AppModel;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu
{
    
    public partial class MainPage : ContentPage
    {
        ObservableCollection<lv_binding_hp_notifications> ListViewNotifications;
        Settings setting;

        public MainPage()
        {
            InitializeComponent();  
            //this.Padding = -50;
            
            ApplicationInitialization();

            ListViewNotifications = new ObservableCollection<lv_binding_hp_notifications>( ListBuilder.HomePageNotifications());
            listview_homepage_notifications.HasUnevenRows = true;
            listview_homepage_notifications.ItemsSource = ListViewNotifications;

        }

        protected override void OnAppearing()
        {
            ListViewNotifications = new ObservableCollection<lv_binding_hp_notifications>(ListBuilder.HomePageNotifications());
            listview_homepage_notifications.ItemsSource = ListViewNotifications;
            base.OnAppearing();       
        }


        void ApplicationInitialization()
        {
            
            
            //DependencyService.Get<ISQLite>().DeleteUserDB();
            var japaneseDBO = DependencyService.Get<ISQLite>().GetJapaneseDBconnection();


            //save the japanese dictionary to local list
            japaneseDBO.CreateTable<tbl_kana>();
            japaneseDBO.CreateTable<tbl_vocabulary_N5>();

            JapaneseDatabase.Table_Vocabulary_N5 = japaneseDBO.Table<tbl_vocabulary_N5>().ToList();
            JapaneseDatabase.Table_Kana = japaneseDBO.Table<tbl_kana>().ToList();


            var userDBO = DependencyService.Get<ISQLite>().GetUserDBconnection();
            userDBO.CreateTable<tbl_us_cardknN5Dt>();
            userDBO.CreateTable<tbl_us_cardktknN5Dt>();
            userDBO.CreateTable<tbl_us_cardvbN5dt>();
            userDBO.CreateTable<tbl_user_settings>();

            userDBO.BeginTransaction();
            while (userDBO.Table<tbl_us_cardknN5Dt>().Count() < JapaneseDatabase.Table_Kana.Count)
            {
                userDBO.Execute("insert into tbl_us_cardknN5Dt values (null,0,0,0);");
            }
            while (userDBO.Table<tbl_us_cardktknN5Dt>().Count() < JapaneseDatabase.Table_Kana.Count)
            {
                userDBO.Execute("insert into tbl_us_cardktknN5Dt values (null,0,0,0);");
            }
            while (userDBO.Table<tbl_us_cardvbN5dt>().Count() < JapaneseDatabase.Table_Vocabulary_N5.Count)
            {
                userDBO.Execute("insert into tbl_us_cardvbN5dt values (null,0,0,0);");
            }
            userDBO.Commit();


            UserDatabase.Table_UserKanaCardsN5 = userDBO.Table<tbl_us_cardknN5Dt>().ToList();
            UserDatabase.Table_UserKataKanaCardsN5 = userDBO.Table<tbl_us_cardktknN5Dt>().ToList();
            UserDatabase.Table_UserVocabCardsN5 = userDBO.Table<tbl_us_cardvbN5dt>().ToList();
            UserDatabase.Table_UserSettings = userDBO.Table<tbl_user_settings>().ToList();

            //only init settings if db is loaded
            setting = new Settings();

            UserDatabase.KanaCardQueue = Computer.CreateQueue(UserDatabase.Table_UserKanaCardsN5.ToList<AbstractCardTable>(), setting.MultipleChoice.QueueCount);
            UserDatabase.KataKanaCardQueue = Computer.CreateQueue(UserDatabase.Table_UserKataKanaCardsN5.ToList<AbstractCardTable>(), setting.MultipleChoice.QueueCount);
            UserDatabase.VocabularyCardQueue = Computer.CreateQueue(UserDatabase.Table_UserVocabCardsN5.ToList<AbstractCardTable>(), setting.MultipleChoice.QueueCount);

        }


    }
}
