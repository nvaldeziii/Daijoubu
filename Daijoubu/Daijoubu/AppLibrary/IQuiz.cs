using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daijoubu.AppLibrary
{
    interface IQuiz
    {
        void CheckAnswer(int user_answer);
        void GenerateQuestion();
        void EnableInterfaces(bool value);
    }
}
