using System;
using System.Collections.Generic;

namespace VendingMachine
{
   

    class Program
    {
        public static void AdminAddItem(List<char> list)
        {
            foreach (Item Item in Item.GetAllItems())
            {
                Console.WriteLine(Item.ToString());
            }
            Console.WriteLine("\nAdd an Item: ");
            bool b = false;

            Console.Write("Add an Item name: "); string Name = Console.ReadLine();
            Console.Write("Add an Item price: "); double Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Add an Item type: "); string Type = Console.ReadLine();
            Console.Write("Add an Item desc: "); string Desc = Console.ReadLine();
            b = Admin.AddItem(Name, Price, Type, Desc);
            if (b)
            {

                list.Add(Convert.ToChar(list.Count.ToString()));
                foreach (var item in list)
                {
                }
                Console.WriteLine("Item has been added.");
            }
            else
            {
                Console.WriteLine("Item has not been added.");
            }
        }
        private static void Main(string[] args)
        {
            List<char> Orders = new List<char>() { 'm', '1', '2', '3', '4', '5', '6' };
            char ItemNumber = ' ';
            User User = new User(1);
            bool HasEnoghMoney;
            while (true)
            {
                Console.WriteLine($"Press 'M' to insert Money... Press 0 to stop... your current credit is: {User.Credit}\n");
                foreach (Item Item in Item.GetAllItems())
                {
                    Console.WriteLine(Item.ToString());
                   

                }
                try
                {
                    ItemNumber = char.ToLower(Convert.ToChar(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input.");
                }
                if (ItemNumber == 'a')
                {
                    AdminAddItem(Orders);
                }
                else
                {
                    if (ItemNumber == '0')
                    {
                        break;
                    }
                    if (Orders.Contains(ItemNumber))
                    {
                        if (ItemNumber == 'm')
                        {
                            Console.WriteLine("Please Insert Money ... Allowed units: 1 JD, 5 JDs, 10 JD's");
                            try
                            {
                                double Credit = Convert.ToDouble(Console.ReadLine());
                                bool b = User.AddMoney(Credit);
                                if (b)
                                {
                                    Console.WriteLine($"{Credit} is inserted ... your current credit is {User.Credit} JD");
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            HasEnoghMoney = Machine.SelectAnItem(ItemNumber, User);
                            if (HasEnoghMoney)
                            {
                                User.AddToUserOrders(Item.GetItemById(ItemNumber));
                                Machine.DiscountPrice(ItemNumber, Item.GetItemById(ItemNumber).Price, User);
                                Console.WriteLine($"{Item.GetItemById(ItemNumber).Name} dropped");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, Not enough credit");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }
            Console.WriteLine("\n\n\n\n");
            foreach (Item Item in User.GetAllUserOrders())
            {
                Console.WriteLine(Item.ToString());
            }
            Console.WriteLine($"Your change is: {User.ReturnChange()}");
            Console.WriteLine("\n\n\n\n");

        }
    }
}
