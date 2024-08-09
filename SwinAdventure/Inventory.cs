using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        // fields
        private List<Item> _items;


        // constructor
        public Inventory()
        {
        }

        // properties
        public List<string> ItemList 
        { 
            get
            {
                List<string> items = new List<string>();

                foreach (Item item in _items)
                {
                    items.Add("\t" + item.ShortDescription);
                }
                return items;
            } 
        }

        // methods
        public void Put(Item item)
        {
            _items.Add(item);
        }

        public Item Take(string id)
        {

            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }

            }
            return null;
        }

        public Item Fetch(string id)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].AreYou(id))
                {
                    Item item = _items[i];
                    _items.RemoveAt(i);
                    return item;
                }
            }
            return null;
        }



    }
}
