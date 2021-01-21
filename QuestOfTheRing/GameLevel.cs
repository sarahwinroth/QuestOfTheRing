using System.Collections.Generic;

namespace QuestOfTheRing
{
    internal class GameLevel
    {
        private int level = 1;
        private string place;
        private string levelNote;

        public static List<string> listOfPlaces = new List<string>();
        public static List<string> listOfNotes = new List<string>();

        public int Level { get => level; set => level = value; }
        public string Place { get => place; set => place = value; }
        public string LevelNote { get => levelNote; set => levelNote = value; }

        public void AddLevelData()
        {
            listOfNotes.Add("Beware of any former hobbit-like beings that may have been corrupted by the Ring. \nThey will bite off your finger, given the opportunity.");
            listOfNotes.Add("At no point during your journey should you put on the Ring. \nIf you do, Sauron will find you and swiftly kill you.");
            listOfNotes.Add("The One Ring can easily corrupt a weak mind. You must not succumb to the ring’s temptations.");
            listOfNotes.Add("The weather in the Misty Mountains can be treacherous. Beware of avalanches.");
            listOfNotes.Add("Avoid all orcs and trolls. Trolls, specifically, are very hard to kill.");
            listOfNotes.Add("Elrond will tell you that the safest way to get Mordor is via the River of Anduin.");
            listOfNotes.Add("Nazgul will try to kill you so that they may obtain the One Ring. \nAvoid main roads at all costs.");
            listOfNotes.Add("Minas Morgul is the home of the Witch King. Do not enter Minas Morgul, go around it.");
            listOfNotes.Add("The Black Gate is an extremely dangerous place and is home to armies and the Mouth of Sauron. \nAvoid it at all costs.");
            listOfNotes.Add("The Mouth of Sauron is an extremely powerful sorcerer. Avoid him at all costs.");

            listOfPlaces.Add("The Shire, Hobbiton");
            listOfPlaces.Add("Bree");
            listOfPlaces.Add("Rivendell");
            listOfPlaces.Add("Misty Mountains");
            listOfPlaces.Add("Mines Of Moria");
            listOfPlaces.Add("Realm of Lothlórien");
            listOfPlaces.Add("Isengard");
            listOfPlaces.Add("Minas Morgul");
            listOfPlaces.Add("The Black Gate");
            listOfPlaces.Add("Mount Doom, Mordor");
        }

        public void GetLevelInfo()
        {
            Place = listOfPlaces[level - 1];
            LevelNote = listOfNotes[level - 1];
        }

        public bool IfLastLevel()
        {
            if (level == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}