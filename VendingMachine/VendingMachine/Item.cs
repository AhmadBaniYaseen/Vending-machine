using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    internal class Item
    {

        private static List<Item> ItemList = Admin.Menu();
        public Item() { }
        public Item(int id, string name, double price, string type, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
            Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public static void AddItem(Item Item)
        {
            ItemList.Add(Item);
        }
        public static List<Item> GetAllItems()
        {
            return ItemList;
        }
        public override bool Equals(object? obj)
        {
            return obj is Item item &&
                   Name == item.Name &&
                   Type == item.Type;
        }
        public static Item GetItemById(char Id)
        {
            int IntId = (int)Char.GetNumericValue(Id);
            return (Item)ItemList[IntId - 1];
        }
        public override string? ToString()
        {
            if (this.Type.Equals("Hot Drinks"))
            {
                return $"{this.Id} - {this.Name}........   {this.Price} + 1(for cup and heating)  JD's\t";
            }
            return $"{this.Id} - {this.Name}........   {this.Price}   JD's\t";
        }
    }
}

