using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    internal class Machine
    {
        private static Item Item1 = new Item();
        public static bool SelectAnItem(char ItemNumber, User User)
        {
            int IntItemNumber = (int)Char.GetNumericValue(ItemNumber);
            foreach (Item Item in Item.GetAllItems())
            {
                if (Item.Id == IntItemNumber)
                {
                    Item1 = Item;
                    break;
                }
            }
            if (Item1.Id == 1)
            {
                if (User.Credit >= Item1.Price + 1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (User.Credit >= Item1.Price)
                {
                    return true;
                }
                return false;
            }

        }

        public static bool DiscountPrice(char ItemNumber, double Price, User User)
        {
            int IntItemNumber = (int)Char.GetNumericValue(ItemNumber);
            if (Item1.Type.Equals("Hot Drinks"))
            {
                User.Credit -= Price + 1;
                return true;
            }
            User.Credit -= Price;
            return false;
        }


    }
}
