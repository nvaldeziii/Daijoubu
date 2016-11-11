using Daijoubu.AppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppControls
{
    public static class ThisApp
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public static Dictionary<string,CardAssesment> Assessments { get; set; }

        public static double TotalJLPTN5 { get; set; }
        public static double TotalJLPTN4 { get; set; }
    }
}
