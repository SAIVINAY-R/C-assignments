using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Assignment_3
{
    public class ItemList
    {
        private readonly IDictionary<string, int> _items = new Dictionary<string, int>();
        public int this[string index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }
        public void PrintItemsInList()
        {
            int i = 1;
            foreach (KeyValuePair<string, int> item in _items)
            {
                Console.WriteLine("\t{0}. {1} - {2}", i, item.Key, item.Value);
                i++;
            }
        }
        public int Count()
        {
            return _items.Count;
        }
        public string ItemAtIndex(int i)
        {
            return _items.Keys.ElementAt(i);
        }
        public bool TryAdd(string name, int price)
        {
            return _items.TryAdd(name, price);
        }
        public List<string> GetKeys()
        {
            return new List<string>(_items.Keys);
        }
        public IDictionary<string,int> GetItemsBelow(int price)
        {
            var result = _items.Where(i => i.Value < price).ToDictionary(x => x.Key, x => x.Value);
            return result;
        }
    }
}
