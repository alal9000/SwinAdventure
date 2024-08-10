using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class Player : GameObject
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
            if (id == "me" || id == "inventory")
                return this;

            if (this._inventory.Fetch(id) != null)
                return this._inventory.Fetch(id);           
            else
                return null;

        }

    }
}
