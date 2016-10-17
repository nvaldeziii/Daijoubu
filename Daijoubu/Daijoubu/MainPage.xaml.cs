using Daijoubu.AppLibrary;
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
            //DependencyService.Get<ISQLite>().DeleteUserDB();
            var japaneseDBO = DependencyService.Get<ISQLite>().GetJapaneseDBconnection();
                

            //save the japanese dictionary to local list
            japaneseDBO.CreateTable<tbl_kana>();
            japaneseDBO.CreateTable<tbl_vocabulary_N5>();

            JapaneseDatabase.Table_Vocabulary_N5 = japaneseDBO.Table<tbl_vocabulary_N5>().ToList();
            JapaneseDatabase.Table_Kana = japaneseDBO.Table<tbl_kana>().ToList();
            

            var userDBO = DependencyService.Get<ISQLite>().GetUserDBconnection();
            userDBO.CreateTable<tbl_us_cardknN5Dt>();
            userDBO.CreateTable<tbl_us_cardvbN5dt>();
            userDBO.CreateTable<tbl_user_settings>();



            var x = userDBO.Table<tbl_us_cardknN5Dt>().Count();
            userDBO.BeginTransaction();
            while (userDBO.Table<tbl_us_cardknN5Dt>().Count() < JapaneseDatabase.Table_Kana.Count)
            {
                userDBO.Execute("insert into tbl_us_cardknN5Dt values (null,0,0,0);");
            }
            while (userDBO.Table<tbl_us_cardvbN5dt>().Count() < JapaneseDatabase.Table_Kana.Count)
            {
                userDBO.Execute("insert into tbl_us_cardvbN5dt values (null,0,0,0);");
            }
            userDBO.Commit();

            UserDatabase.Table_UserKanaCardsN5 = userDBO.Table<tbl_us_cardknN5Dt>().ToList();
            UserDatabase.Table_UserVocabCardsN5 = userDBO.Table<tbl_us_cardvbN5dt>().ToList();
            UserDatabase.Table_UserSettings = userDBO.Table<tbl_user_settings>().ToList();

            int High = 5; //max card to review
            Queue<Card> tmpholder = new Queue<Card>();
            for(int i = 0; High != 0; i++)
            {
                UserDatabase.KanaCardQueueHigh = i;
                int numerator = UserDatabase.Table_UserKanaCardsN5[i].CorrectCount;
                int denominator = UserDatabase.Table_UserKanaCardsN5[i].MistakeCount;
                double percent = ((double)numerator) / (numerator + denominator);
                if (double.IsNaN(percent))
                {
                    percent = new double();
                    percent = 0;
                }

                //compute date vs correct items and mistakes 
                DateTime TimeDiff;
                try
                {
                    TimeDiff = Convert.ToDateTime(UserDatabase.Table_UserKanaCardsN5[i].LastView).AddMinutes(percent * 100);
                }catch
                {
                    TimeDiff = DateTime.Now;
                }
                if (percent < 80 || TimeDiff < DateTime.Now)
                {
                    Card NewCard = new Card();
                    NewCard.Id = UserDatabase.Table_UserKanaCardsN5[i].Id;
                    NewCard.MistakeCount = UserDatabase.Table_UserKanaCardsN5[i].MistakeCount;
                    NewCard.CorrectCount = UserDatabase.Table_UserKanaCardsN5[i].CorrectCount;
                    try
                    {
                        NewCard.LastView = Convert.ToDateTime(UserDatabase.Table_UserKanaCardsN5[i].LastView);
                    }
                    catch
                    {
                        NewCard.LastView = DateTime.Now;
                    }

                    tmpholder.Enqueue(NewCard);
                    High--;
                }
            }
            UserDatabase.KanaCardQueue = tmpholder;

            High = 5; //max card to review
            Queue<Card> tmpholder2 = new Queue<Card>();
            for (int i = 0; High != 0; i++)
            {
                UserDatabase.VocabularyCardQueueHigh = i;
                int numerator = UserDatabase.Table_UserKanaCardsN5[i].CorrectCount;
                int denominator = UserDatabase.Table_UserKanaCardsN5[i].MistakeCount;
                double percent = ((double)numerator) / (numerator + denominator);
                if (double.IsNaN(percent))
                {
                    percent = new double();
                    percent = 0;
                }

                DateTime time;
                try
                {
                    time = Convert.ToDateTime(UserDatabase.Table_UserVocabCardsN5[i].LastView);
                }
                catch { time = DateTime.Now; }


                DateTime TimeDiff = time.AddMinutes(percent * 100);

                if (percent < 80 || TimeDiff < DateTime.Now)
                {
                    Card NewCard = new Card();
                    NewCard.Id = UserDatabase.Table_UserVocabCardsN5[i].Id;
                    NewCard.MistakeCount = UserDatabase.Table_UserVocabCardsN5[i].MistakeCount;
                    NewCard.CorrectCount = UserDatabase.Table_UserVocabCardsN5[i].CorrectCount;
                    try
                    {
                        NewCard.LastView = Convert.ToDateTime(UserDatabase.Table_UserVocabCardsN5[i].LastView);
                    }
                    catch
                    {
                        NewCard.LastView = DateTime.Now;
                    }

                    tmpholder2.Enqueue(NewCard);
                    High--;
                }
            }
            UserDatabase.VocabularyCardQueue = tmpholder2;

        }

        
    }
}
