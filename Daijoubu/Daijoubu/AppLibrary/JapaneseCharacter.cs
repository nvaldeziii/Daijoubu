using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public static class JapaneseCharacter
    {
        public static char[] Hiragana
        {
            get
            {
                return ("あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわゐゑをんっ").ToCharArray();
            }
        }
    }
}
