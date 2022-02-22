using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_3
{
    public class RestaurantManager
    {
        private readonly ItemList _Menu;
        private readonly List<string> _orders = new List<string>();

        public RestaurantManager(ItemList menu)
        {
            _Menu = menu;
        }

        public void ReceiveOrder(string order)
        {
            _orders.Add(order);
        }

        public int OrderCount()
        {
            return _orders.Count;
        }

        public bool AddItemToMenu(string name, int price)
        {
            return _Menu.TryAdd(name, price);
        }
        public string GetLast5Orders()
        {
            var count = this.OrderCount();
            if (count < 1)
            {
                return "202 Error";
            }
            else if (count > 5)
            {
                count = 5;
            }
            foreach (var item in _orders.TakeLast(count).ToList())
            {
                Console.WriteLine(item);
            }

            return "202 Ok";
            
        }

        public string GetTheMostPopularItem()
        {
            if (_orders.Count < 1)
            {
                return "203 Error";
            }
            Console.WriteLine(_orders.Max());
            return "203 Ok";
        }
        public string GetTheItemWithHighestRevenue()
        {
            if (_orders.Count < 1)
            {
                return "204 Error";
               
            }
            else
            {
                var itemWithHighestRevenue = _Menu.GetKeys()[0];
                foreach (var key in _Menu.GetKeys())
                {
                    int revenue1 = _orders.FindAll(i => i == key).Count * _Menu[key];
                    int revenue2 = _orders.FindAll(i => i == itemWithHighestRevenue).Count * _Menu[itemWithHighestRevenue];

                    if (revenue1 > revenue2)
                    {
                        itemWithHighestRevenue = key;
                    }
                }

                Console.WriteLine(itemWithHighestRevenue);
                return "204 Ok";
            }
        }
        public string GetItemsBelowThePrice(int price)
        {
            var items = _Menu.GetItemsBelow(price);
            if (items.Count() < 1)
            {
                return "205 Error";
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
                return "205 Ok";
            }

        }

    }
}
