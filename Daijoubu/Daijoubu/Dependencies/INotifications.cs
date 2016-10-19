using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.Dependencies
{
    public interface INotifications
    {
        void Vibrate(int miliseconds = 100);
        void ToastDependency(string message);
    }
}
