using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_3
{
    public class RestaurantManager
    {
        private readonly ItemList _menu;
        private readonly List<string> _orders = new List<string>();

        public RestaurantManager(ItemList menu)
        {
            _menu = menu;
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
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new IOException();
            }
            if (_menu.TryAdd(name, price) == false)
            {
                Console.WriteLine("Item already exists");
                return false;
            }
            return true;
        }
        public List<string> GetLast5Orders()
        {
            var count = this.OrderCount();
            if (count < 1)
            {
                Console.WriteLine("No past orders in the Order History");
                return null;
            }
            else if (count > 5)
            {
                count = 5;
            }
            return _orders.TakeLast(count).ToList();
        }

        public string GetTheMostPopularItem()
        {
            if (_orders.Count < 1)
            {
                return "No past orders in the Order History";
            }
            return _orders.Max();
        }
        public string GetTheItemWithHighestRevenue()
        {
            if (_orders.Count < 1)
            {
                return "No past orders in the Order History";          
            }
            else
            {
                var itemWithHighestRevenue = _menu.GetKeys()[0];
                foreach (var key in _menu.GetKeys())
                {
                    int revenue1 = _orders.FindAll(i => i == key).Count * _menu[key];
                    int revenue2 = _orders.FindAll(i => i == itemWithHighestRevenue).Count * _menu[itemWithHighestRevenue];

                    if (revenue1 > revenue2)
                    {
                        itemWithHighestRevenue = key;
                    }
                }

                return itemWithHighestRevenue;
            }
        }
        public IDictionary<string, int> GetItemsBelowThePrice(int price)
        {
            var items = _menu.GetItemsBelow(price);
            if (items.Count() < 1)
            {
                Console.WriteLine("No Item below the price {0}", price);
                return null;
            }
            else
            {
                return items;
            }

        }

    }
}
