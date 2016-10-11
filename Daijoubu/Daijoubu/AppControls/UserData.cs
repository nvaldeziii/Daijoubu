using Daijoubu.AppLibrary;
using System.Collections.Generic;

namespace Daijoubu
{
    public class UserData
    {
        public UserData()
        {
            KanaCardsData = new List<Card>();
            VocabularyCardsData = new List<Card>();

            KanaCardStack = new Stack<Card>();
            VocabularyCardStack = new Stack<Card>();
        }
        public List<Card> KanaCardsData { get; set; }
        public List<Card> VocabularyCardsData { get; set; }

        public Stack<Card> KanaCardStack { get; set; }
        public Stack<Card> VocabularyCardStack { get; set; }


    }

   
}
