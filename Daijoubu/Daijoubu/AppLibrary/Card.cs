using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public class Card
    {
        public Card()
        {

        }

        public int Id { get; set; }
        public int CorrectCount { get; set; }
        public int MistakeCount { get; set; }
        public double LearnPercent { get { return ((double)CorrectCount / ((double)MistakeCount + (double)CorrectCount) ) * 100.0; } }
        public DateTime LastView { get; set; }
    }
}
