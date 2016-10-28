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

            //List<AbstractCardTable> CardTable = TheCardTable.OrderBy(i => (Computer.));

            for (int i = 0; High != 0; i++)
            {
                //UserDatabase.KanaCardQueueHigh = i;
                DateTime LastView;
                try
                { LastView = Convert.ToDateTime(CardTable[i].LastView); }
                catch
                { LastView = DateTime.Now; }
                //compute date vs correct items and mistakes 
                if (Computer.ForQueuing(LastView, CardTable[i].CorrectCount, CardTable[i].MistakeCount))
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
        public static DateTime NextQueuing2(DateTime LastView, int correct, int mistake)
        {
            DateTime TimeDiff;
            
            mistake = mistake <= 0 ? 1 : mistake;
            correct = correct <= 0 ? 1 : correct;


            double number = (13.3333 * Math.Pow(correct, 2) * (correct + (3 * mistake)) / (correct + mistake));
            double fixed_multiplier = .4;////////////////////////////////////////////////////////////////////////////
            try
            {
                double _minutes = number * fixed_multiplier;
                TimeDiff = LastView.AddMinutes(_minutes);
            }
            catch
            {
                TimeDiff = DateTime.Now;
            }
            return TimeDiff;
        }
        public static DateTime NextQueuing(DateTime LastView, int correct,int mistake)
        {
            DateTime TimeDiff;
            
            double _Percent = ForPercentage( correct,  mistake);
            mistake = mistake <= 0 ? 1 : mistake;
            correct = correct <= 0 ? 1 : correct;
            _Percent = _Percent <= 0 ? 1 : _Percent;

            double _multiplier = ((double)correct + (mistake * 3.0)) / (correct * 1.5);
            double fixed_multiplier = .4;////////////////////////////////////////////////////////////////////////////
            try
            {
                double _minutes = _Percent * fixed_multiplier * _multiplier;
                //double number = ( SRSsettings.PercentageMultiplier * (correct + (3*mistake)) ) / (correct + mistake);
                TimeDiff = LastView.AddMinutes(_minutes);

                _minutes *= SRSsettings.Multiplier;
                TimeDiff = LastView.AddMinutes(_minutes);
            }
            catch
            {
                TimeDiff = DateTime.Now;
            }
            return TimeDiff;
        }
        public static TimeSpan NextQueingSpan(DateTime LastView, int correct, int mistake)
        {
            var nextq = NextQueuing(LastView, correct, mistake);
            TimeSpan span = (nextq - DateTime.Now);
            return span;
        }

        public static string NextQueingSpanToString(TimeSpan span)
        {
            string result = "";
            if (Math.Abs(span.Days) > 0)
            {
                result = String.Format("{0}d, {1}hr, {2}m, {3}s",
                    span.Days, span.Hours, span.Minutes, span.Seconds);
            }else if (Math.Abs(span.Hours) > 0)
            {
                result = String.Format("{0}h, {1}m, {2}s",
                    span.Hours, span.Minutes, span.Seconds);
            }
            else if (Math.Abs(span.Minutes) > 0)
            {
                result = String.Format("{0}m, {1}s",
                    span.Minutes, span.Seconds);
            }else
            {
                result = String.Format("{0}s",
                    span.Seconds);
            }
            return result;
        }

        public static bool ForQueuing(DateTime LastView, int correct, int mistake)
        {
            var TimeDiff = NextQueingSpan( LastView, correct, mistake);

            var timelapse = TimeDiff.TotalSeconds <= 0;
            var percentdiff = (ForPercentage(correct, mistake) < SRSsettings.PercentageQuota);///////////////////////////////////////////////////////////////////////////
            return (percentdiff || timelapse);
        }
    }
}
