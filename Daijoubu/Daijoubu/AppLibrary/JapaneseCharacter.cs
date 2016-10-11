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

        public static char[] Alphabet
        {
            get
            {
                return ("abcdefghijklmnopqrstuvwxyz").ToCharArray();
            }
        }

        public static bool ContainsAlphabet(string input)
        {
            foreach (char c in input)
            {
                foreach (char i in Alphabet)
                {
                    if (c == i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
