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

        public static int KanaCardQueueHigh { get; set; }
        public static int VocabularyCardQueueHigh { get; set; }

        public static Queue<Card> KanaCardQueue { get; set; }
        public static Queue<Card> VocabularyCardQueue { get; set; }
    }
}
