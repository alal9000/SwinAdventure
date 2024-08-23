using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        // constructor
        public LookCommand() : base(new string[] { "look" })
        {
        }

        // concrete implementation from abstract base class
        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that";

            if(text[0].ToLower() != "look")
                return "Error in look input";

            if (text[1].ToLower() != "at")
                return "What do you want to look at?";

            IHaveInventory container;
            string itemId = text[2].ToLower();

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {                
                if (text[3].ToLower() != "in")
                    return "What do you want to look in?";

                container = FetchContainer(p, text[4].ToLower());

                if (container == null)
                    return $"I can't find the {text[4]}";              
            }

            return LookAtIn(itemId, container);
        }

        // Private method to fetch the container
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject containerObj = p.Locate(containerId);

            return containerObj as IHaveInventory;
        }

        // Private method to look at the item in the container
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject item = container.Locate(thingId);

            if (item != null)
                return item.FullDescription;

            return $"I can't find the {thingId}";
        }
    }
}
