using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        private string doorDescription;
        private Location doorLocation;
        public RoomWithDoor(string decoration, string name, string hidingPlaceName, string doorDescription) : base(decoration, name, hidingPlaceName)
        {
            this.doorDescription = doorDescription;
        }
               

        public Location DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }

        public string DoorDescription { get { return doorDescription; }  }
    }
}
