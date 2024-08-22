using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        // fields
        private Inventory _inventory;

        // constructor
        public Player(string name, string desc) : base( new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        // properties
        public Inventory Inventory { get => _inventory; }

        public override string FullDescription { 
            get
            {
                string itemDescriptions = string.Join("\n", Inventory.ItemList);
                return "You are carrying:\n" + itemDescriptions;
            }
        }

        // methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            return _inventory.Fetch(id);

        }
    }
}
