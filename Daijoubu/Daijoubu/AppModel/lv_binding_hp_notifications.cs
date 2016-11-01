using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daijoubu.AppModel
{
    public class lv_binding_hp_notifications
    {
        public string MainLabel { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Clock { get; set; }
        public double Percent { get; set; }

        public Color ClockColor { get; set; }

        public TimeSpan _tspan { get; set; }
        public string _lastview { get; set; }
        public string TableName { get; set; }
        public int ItemID { get; set; }
    }
}
