
using System.Collections.Generic;

namespace Daijoubu.AppModel
{
    static class JapaneseDatabase
    {
        public static List<tbl_kana> Table_Kana { get; set; }
        public static List<tbl_grammar_N5> Table_Grammar_N5 { get; set; }
        public static List<tbl_grammar_N4> Table_Grammar_N4 { get; set; }
        public static List<tbl_vocabulary_N5> Table_Vocabulary_N5 { get; set; }
        public static List<tbl_vocabulary_N4> Table_Vocabulary_N4 { get; set; }

        public static List<tbl_lesson_hiragana> Table_Lesson_Hiragana { get; set; }
        public static List<tbl_lesson_katakana> Table_Lesson_Katakana { get; set; }

        public static readonly string HIRAGANA_ARRAY = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわゐを";
    }
}
