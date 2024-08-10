using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        // fields
        private string _description;
        private string _name;

        // constructor
        public GameObject(string[] idents, string name, string desc) : base(idents)
        {
            _description = desc;
            _name = name;
        }

        // properties
        public string Name { get { return _name; } }
        public string ShortDescription { get { return _name + " (" + FirstId + ")"; } }
        public virtual string FullDescription { get { return _description; } }
    }
}
