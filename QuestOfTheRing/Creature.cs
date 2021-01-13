using System;
using System.Collections.Generic;
using System.Text;

namespace QuestOfTheRing
{
    abstract class Creature
    {
        private string name;
        public string Name { get => name; set => name = value; }
    }
}
