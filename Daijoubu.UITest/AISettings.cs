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

        public int ItemsToTake { get; set; }
        public int Delay { get; set; }

        public float DrawerLocationX { get; set; }
        public float DrawerLocationY { get; set; }

        public AISettings()
        {
            this.ItemsToTake = 10;
            this.Intellegence = 95;
            this.Delay = 1500;

            this.DrawerLocationX = 50.0f;
            this.DrawerLocationY = 115.0f;
        }
    }
}
