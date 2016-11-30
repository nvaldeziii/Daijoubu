using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppModel
{
    public class tbl_lessons_kana
    {
        public int Id { get; set; }
        public string example { get; set; }
        public string sound { get; set; }
        public string mnemonic { get; set; }
    }

    public class tbl_lesson_hiragana : tbl_lessons_kana { }
    public class tbl_lesson_katakana : tbl_lessons_kana { }
}
