using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    internal class User
    {

        public User(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public static double Credit { get; set; }
        private static List<Item> UserOrders = new List<Item>();
        public static bool AddMoney(double Credit1)
        {

            if (Credit1 < 0)
            {
                Console.WriteLine("Can not credit be negative.");
                return false;
            }
            else if (Credit1 == 1 || Credit1 == 5 || Credit1 == 10)
            {
                Credit += Credit1;
                Console.WriteLine("Money inserted successfully.");
                return true;
            }
            Console.WriteLine("Please insert money as in the list");
            return false;
          
        }
        public static void AddToUserOrders(Item item)
        {
            UserOrders.Add(item);
        }
        public static List<Item> GetAllUserOrders()
        {
            return UserOrders;
        }

        public static double ReturnChange()
        {
            return Credit;
        }
        public override string? ToString()
        {
            return $"Id: {Id}, Name: {Credit}";
        }

    }
}
