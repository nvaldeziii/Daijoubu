using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    public class CardAssesment
    {
        public double TotalProficiency { get; set; }
        public int TotalFailed { get; set; }       
        public int TotalPassed { get; set; }
        public int TotalReviewed { get; set; }
        public int TotalItems { get; set; }

        public CardAssesment()
        {
            TotalProficiency = 0;
            TotalFailed = 0;
            TotalPassed = 0;
            TotalReviewed = 0;
            TotalItems = 0;
        }

        public double FinalAssesment
        {
            get
            {
                return Computer.ForPercentage(TotalPassed, TotalFailed);
            }
        }
    }
}
