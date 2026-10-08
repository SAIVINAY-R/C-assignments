using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_3
{
    public class Customer
    {
        private readonly ItemList _menu;
        public Customer(ItemList menu)
        {
            _menu = menu;
        }

        public int PlaceAnOrder(int item, RestaurantManager manager)
        {
            if(item == -1)
            {
                Console.WriteLine("\nThere are no items to order!");
                return -1;
            }
            if(item < 1 || item > _menu.Count())
            {
                Console.WriteLine("\nInvalid Item");
                return 0;
            }
            manager.ReceiveOrder(_menu.ItemAtIndex(item - 1));
            return 1;
        }
    }
}
