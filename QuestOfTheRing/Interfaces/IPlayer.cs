using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    interface IPlayer
    {
        string Name { get; }
        int Hp { get; set; }
        int Exp { get; set; }
        int Gold { get; set; }
        int Strength { get; set; }

        void Details() { }


    }
}
