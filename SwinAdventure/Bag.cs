using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        // fields
        private Inventory _inventory;

        // constructor
        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
        }

        // methods
        public GameObject Locate(string id)
        {

            if (AreYou(id))
                return this;

            // returns the item otherwise null if not found 
            return _inventory.Fetch(id);
        }

        // properties
        public override string FullDescription
        {
            get
            {
                string itemsDescription = string.Join("\n", Inventory.ItemList);
                return $"In the {Name}, you can see:\n{itemsDescription}";
            }
        }

        public Inventory Inventory { get => _inventory; }




    }
}
