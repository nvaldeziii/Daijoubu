using Daijoubu.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppModel
{
    public static class DatabaseManipulator
    {

        public static int Update_User_KanaCard(int count,int QuestionID,bool IsCorrect)
        {
            string FieldIfCorrect = IsCorrect ? "CorrectCount" : "MistakeCount";

            var query = string.Format("UPDATE tbl_us_cardknN5Dt SET {0}={1},LastView=\"{2}\" WHERE Id=\"{3}\""
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
    }
}
