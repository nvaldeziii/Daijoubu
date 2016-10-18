using Daijoubu.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public static class Computer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="High">Max Card to review</param>
        /// <returns></returns>
        public static Queue<Card> CreateQueue(List<AbstractCardTable> CardTable, int High = 5)
        {
            var queue = new Queue<Card>();

            for (int i = 0; High != 0; i++)
            {
                //UserDatabase.KanaCardQueueHigh = i;

                double percent = Computer.ForPercentage(CardTable[i].CorrectCount, CardTable[i].MistakeCount);
                DateTime LastView;
                try
                { LastView = Convert.ToDateTime(CardTable[i].LastView); }
                catch
                { LastView = DateTime.Now; }
                //compute date vs correct items and mistakes 
                if (Computer.ForQueuing(LastView, percent))
                {
                    Card NewCard = new Card();
                    NewCard.Id = CardTable[i].Id;
                    NewCard.MistakeCount = CardTable[i].MistakeCount;
                    NewCard.CorrectCount = CardTable[i].CorrectCount;
                    NewCard.LastView = LastView;

                    queue.Enqueue(NewCard);
                    High--;
                }
            }
            return queue;
        }
        public static double ForPercentage(int numerator, int denominator)
        {
            double percent = ((double)numerator) / ((double)numerator + (double)denominator);
            if (double.IsNaN(percent))
            {
                percent = new double();
                percent = 0;
            }
            return percent*100.0;
        }

        public static bool ForQueuing(DateTime LastView, double Percent)
        {
            DateTime TimeDiff;
            try
            {
                TimeDiff = LastView.AddMinutes(Percent * 100);
            }
            catch
            {
                TimeDiff = DateTime.Now;
            }
            var diff = TimeDiff < DateTime.Now;
            var percentdiff = (Percent < 80);
            return (percentdiff || diff);
        }
    }
}
