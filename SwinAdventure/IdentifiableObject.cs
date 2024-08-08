using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        // Fields
        private List<String> _identifiers;

        // Constructor
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();

            if (idents.Length != idents.Distinct().Count()) // validation
            {
                Console.WriteLine("The array has duplicates, try again!");
                return;
            }

            foreach (string id in idents) // add identifiers
            {
                _identifiers.Add(id.ToLower());
            }
        }

        // Properties
        public string FirstId
        {
            get { return _identifiers[0]; }
        }

        // Methods
        public bool AreYou(string id)
        {
            string idLower = id.ToLower();

            return _identifiers.Contains(idLower);

        }

        public void AddIdentifier(string id)
        {
            string idLower = id.ToLower();

            
            if (_identifiers.Contains(idLower)) // validation 
            {
                Console.WriteLine("There is already an identifier by this name!");
                return;
            }
                               
            _identifiers.Add(idLower);
        }

    }
}
