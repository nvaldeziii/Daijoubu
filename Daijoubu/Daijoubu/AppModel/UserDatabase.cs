using Daijoubu.AppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppModel
{
    public static class UserDatabase
    {
        public static List<tbl_us_cardknN5Dt> Table_UserKanaCardsN5 { get; set; }
        public static List<tbl_us_cardvbN5dt> Table_UserVocabCardsN5 { get; set; }

        public static int KanaCardStackHigh { get; set; }
        public static int VocabularyCardStackHigh { get; set; }

        public static Stack<Card> KanaCardStack { get; set; }
        public static Stack<Card> VocabularyCardStack { get; set; }
    }
}
