using Daijoubu.AppControls;
using Xamarin.Forms;

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

    public class CardAssessmentComparission
    {
        private readonly Color C_Red = Color.Red;
        private readonly Color C_Green = Color.Green;
        private readonly Color C_Normal = Color.Gray;

        public CardAssessmentComparission(CardAssesment ca, string key)
        {
            New = ca;
            Old = ThisApp.Assessments[key];

            //ThisApp.Assessments[key] = New;
        }
        public string Name { get; set; }
        public CardAssesment Old { get; set; }
        public CardAssesment New { get; set; }

        public Color TotalProficiencyColor {
            get {
                if (New.TotalProficiency > Old.TotalProficiency)
                {
                    return C_Green;
                }
                else if (New.TotalProficiency == Old.TotalProficiency)
                {
                    return C_Normal;
                }
                else return C_Red;
            }
        }
        public Color TotalFailedColor
        {
            get
            {
                if (New.TotalFailed > Old.TotalFailed)
                {
                    return C_Red;
                }
                else if (New.TotalFailed == Old.TotalFailed)
                {
                    return C_Normal;
                }
                else return C_Green;
            }
        }
        public Color TotalPassedColor
        {
            get
            {
                if (New.TotalPassed > Old.TotalPassed)
                {
                    return C_Green;
                }
                else if (New.TotalPassed == Old.TotalPassed)
                {
                    return C_Normal;
                }
                else return C_Red;
            }
        }
        public Color TotalReviewedColor
        {
            get
            {
                if (New.TotalReviewed > Old.TotalReviewed)
                {
                    return C_Green;
                }
                else if (New.TotalReviewed == Old.TotalReviewed)
                {
                    return C_Normal;
                }
                else return C_Red;
            }
        }
        public Color TotalItemsColor
        {
            get
            {
                if (New.TotalItems > Old.TotalItems)
                {
                    return C_Green;
                }
                else if (New.TotalItems == Old.TotalItems)
                {
                    return C_Normal;
                }
                else return C_Red;
            }
        }
    }
}
