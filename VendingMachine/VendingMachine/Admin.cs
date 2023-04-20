using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    internal class Admin
    {

        private static Item Item;
        private static int ItemCount;
        static Admin()
        {
            ItemCount = 0;
        }
        public static bool AddItem(string Name, double Price, string ItemType, string ItemDesc)
        {
            if (!(Name == null || ItemType == null))
            {
                foreach (Item Item in Item.GetAllItems())
                {
                    if (Item.Name.Equals(Name) && Item.Type.Equals(ItemType))
                    {
                        return false;
                    }
                }
                Item = new Item(++ItemCount, Name, Price, ItemType, ItemDesc);
                Item.AddItem(Item);
                return true;
            }
            return false;
        }
        public static List<Item> Menu()
        {
            List<Item> list = new List<Item>();
            Item item1 = new Item(++ItemCount, "Coffee Latte", 2.00, "Hot Drinks", "AL-Ameed");
            Item item2 = new Item(++ItemCount, "Tuna Sandwich", 3.00, "Snacks", "Al-wardeh");
            Item item3 = new Item(++ItemCount, "Lays Chips", 1.00, "Snacks", "Katshab");
            Item item4 = new Item(++ItemCount, "Snicker", 1.00, "Snacks", "Medium size");
            Item item5 = new Item(++ItemCount, "Turkey Sandwich", 3.00, "Snacks", "Medium size");
            Item item6 = new Item(++ItemCount, "Peanuts", 2.00, "Snacks", "Smoked");
            list.Add(item1); list.Add(item2);
            list.Add(item3); list.Add(item4);
            list.Add(item5); list.Add(item6);
            return list;
        }

    }
}
