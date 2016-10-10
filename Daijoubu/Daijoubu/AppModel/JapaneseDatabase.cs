using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppModel
{
    static class JapaneseDatabase
    {
        public static List<tbl_kana> Table_Kana { get; set; }
        public static List<tbl_grammar_N5> Table_Grammar_N5 { get; set; }
        public static List<tbl_grammar_N4> Table_Grammar_N4 { get; set; }
        public static List<tbl_vocabulary_N5> Table_Vocabulary_N5 { get; set; }
        public static List<tbl_vocabulary_N4> Table_Vocabularu_N4 { get; set; }
    }
}
