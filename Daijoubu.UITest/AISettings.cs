using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.UITest
{
    public class AISettings
    {
        public int Intellegence { get; set; }
        public int Delay { get; set; }

        public AISettings()
        {
            this.Intellegence = 95;
            this.Delay = 500;
        }
    }
}
