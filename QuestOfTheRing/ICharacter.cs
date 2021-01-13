using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    interface ICharacter
    {
        public int Hp { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }

        public void Details() { }
    }
}
