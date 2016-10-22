using Daijoubu.AppLibrary;
using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Daijoubu.AppLibrary.Categories;

namespace Daijoubu.AppModel
{
    public static class DatabaseManipulator
    {

        public static int Update_User_KanaCard(MultipleChoiceCategory category, int count,int QuestionID,bool IsCorrect)
        {
            string FieldIfCorrect = IsCorrect ? "CorrectCount" : "MistakeCount";
            string tablename = "";
            switch (category)
            {
                case MultipleChoiceCategory.Hiragana:
                    tablename = "tbl_us_cardknN5Dt";
                    break;
                case MultipleChoiceCategory.Katakana:
                    tablename = "tbl_us_cardktknN5Dt";
                    break;
                case MultipleChoiceCategory.Vocabulary:
                    tablename = "tbl_us_cardvbN5dt";
                    break;
            }

            var query = string.Format("UPDATE {0} SET {1}={2},LastView=\"{3}\" WHERE Id=\"{4}\""
                , tablename
                , FieldIfCorrect
                , count
                , DateTime.Now.ToString()
                , QuestionID);

            return ExecuteNonQuery(query);
        }
        public static int ExecuteNonQuery(string nonquery)
        {
            int result;
            var SQLConnection = DependencyService.Get<ISQLite>().GetUserDBconnection();
            SQLConnection.BeginTransaction();
            result = SQLConnection.Execute(nonquery);
            SQLConnection.Commit();
            return result;
        }

        public static bool ResetUserData()
        {
            DependencyService.Get<Dependencies.ISQLite>().DeleteUserDB();
            var userDBO = DependencyService.Get<ISQLite>().GetUserDBconnection();
            userDBO.CreateTable<tbl_us_cardknN5Dt>();
            userDBO.CreateTable<tbl_us_cardktknN5Dt>();
            userDBO.CreateTable<tbl_us_cardvbN5dt>();
            userDBO.CreateTable<tbl_user_settings>();

            var kana_count = JapaneseDatabase.Table_Kana.Count;
            while (userDBO.Table<tbl_us_cardknN5Dt>().Count() < kana_count)
            {
                userDBO.Execute("insert into tbl_us_cardknN5Dt values (null,0,0,0);");
            }
            while (userDBO.Table<tbl_us_cardktknN5Dt>().Count() < kana_count)
            {
                userDBO.Execute("insert into tbl_us_cardktknN5Dt values (null,0,0,0);");
            }

            var vocab_count = JapaneseDatabase.Table_Vocabulary_N5.Count;
            while (userDBO.Table<tbl_us_cardvbN5dt>().Count() < vocab_count)
            {
                userDBO.Execute("insert into tbl_us_cardvbN5dt values (null,0,0,0);");
            }

            UserDatabase.Table_UserVocabCardsN5 = DependencyService.Get<Dependencies.ISQLite>()
                                                .GetUserDBconnection().Table<tbl_us_cardvbN5dt>().ToList();
            UserDatabase.Table_UserKanaCardsN5 = DependencyService.Get<Dependencies.ISQLite>()
                                                .GetUserDBconnection().Table<tbl_us_cardknN5Dt>().ToList();
            UserDatabase.Table_UserKataKanaCardsN5 = DependencyService.Get<Dependencies.ISQLite>()
                                                .GetUserDBconnection().Table<tbl_us_cardktknN5Dt>().ToList();

            return true;
        }
    }
}
