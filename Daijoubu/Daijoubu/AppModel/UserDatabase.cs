using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppModel
{
    public static class UserDatabase
    {
        public static List<tbl_user_card_kana_N5Data> Table_UserKanaCardsN5 { get; set; }
        public static List<tbl_user_card_vocab_N5data> Table_UserVocabCardsN5 { get; set; }
    }
}
