using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_3
{
    public class Customer
    {
        private readonly ItemList _Menu;
        public Customer(ItemList menu)
        {
            _Menu = menu;
        }

        public int PlaceAnOrder(int item, RestaurantManager manager)
        {
            if(item == -202)
            {
                return -1;
            }
            if(item < 1 || item > _Menu.Count())
            {
                return 0;
            }
            manager.ReceiveOrder(_Menu.ItemAtIndex(item - 1));
            return 1;
        }
    }
}
