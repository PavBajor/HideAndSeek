using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    class OutsideWithDoor : OutsideWithHidingPlace, IHasExteriorDoor
    {
        private string doorDescription;
        
        public OutsideWithDoor(bool hot, string name, string hidingPlaceName, string doorDescription) : base(hot, name, hidingPlaceName)
        {
            this.doorDescription = doorDescription;
        }

        public Location DoorLocation { get ; set; }

        public string DoorDescription { get { return doorDescription; } }

        public override string Description
        {
            get
            {
                return base.Description + "You see " + doorDescription + ".";
            }
        }




    }
}
