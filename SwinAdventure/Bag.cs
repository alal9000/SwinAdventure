using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bag : Item
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

            if (id == "me" || id == "container")
                return this;

            if (this._inventory.Fetch(id) != null)
                return this._inventory.Fetch(id);
            else
                return null;
        }

        // properties
        public override string FullDescription
        {
            get
            {
                return "In the " + this.Name + "you can see" + Inventory.ItemList;
            }
        }

        public Inventory Inventory { get => _inventory; }




    }
}
