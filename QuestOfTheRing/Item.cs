using System.Collections.Generic;

namespace QuestOfTheRing.Creatures
{
    internal class Item
    {
        private string name;
        private int value;

        public static List<Item> ListOfItems = new List<Item>();

        public Item(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name { get => name; }
        public int Value { get => value; }

        public static Item GetRandomItem()
        {
            int i = RandomHelper.GetRandomNum(ListOfItems.Count);

            if (RandomHelper.GetRandomNum(1, 11) <= 2)
            {
                var item = ListOfItems[i];
                return item;
            }
            else
            {
                return null;
            }
        }

        public void RemoveItemFromList(Item item)
        {
            foreach (var element in ListOfItems)
            {
                if (element == item)
                {
                    ListOfItems.Remove(element);
                    break;
                }
            }
        }

        public static void AddItems()
        {
            ListOfItems.Clear();
            ListOfItems.Add(new Item("The Ring of Barahir", 100));
            ListOfItems.Add(new Item("Hithlain rope", 250));
            ListOfItems.Add(new Item("Barrow-blade", 150));
            ListOfItems.Add(new Item("Grond, Morgoth's great warhammer", 200));
            ListOfItems.Add(new Item("Ringil sword", 100));
            ListOfItems.Add(new Item("Mithril shirt", 250));
            ListOfItems.Add(new Item("Nenya The Ring of Water", 100));
            ListOfItems.Add(new Item("Anduril sword", 250));
            ListOfItems.Add(new Item("The Elfstone", 300));
            ListOfItems.Add(new Item("Nauglamir jewel", 300));
            ListOfItems.Add(new Item("The Arkenstone", 500));
            ListOfItems.Add(new Item("The Phial of Galadriel", 200));
            ListOfItems.Add(new Item("The Palanteri", 100));
        }
    }
}