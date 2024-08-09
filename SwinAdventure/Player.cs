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
        private Inventory _inventory;

        public Player(string name, string desc) : base( new string[] { "me", "inventory" }, name, desc)
        {
        }

        public Inventory Inventory { get => _inventory; }

        public override string FullDescription { get => "placeholder text"; }

        public GameObject Locate(string id)
        {
            return new Item(new string[] { "test1", "test2" }, "Aaron", "Mighty programmer");
        }


    }
}
