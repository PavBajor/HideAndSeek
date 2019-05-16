using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    public class Room : Location
    {
        private string decoration;
        public Room(string decoration, string name)
            :base(name)
        {
            this.decoration = decoration;
        }
        public override string Description
        {
            get
            {
                string description = "You are standing in the " + Name + "You can see exits to the following places: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1)
                    {
                        description += ",";
                    }
                }
                return base.Description + ". You see " + decoration + " here.";
            }
        }
    }
}
