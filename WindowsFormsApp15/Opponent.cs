using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    class Opponent
    {
        private Location myLocation;
        private Random myHidingPlace;

        public Opponent(Location startingPosition)
        {
            myLocation = startingPosition;
            myHidingPlace = new Random();

        }
        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor LocationWithDoor = myLocation as IHasExteriorDoor;
                if (myHidingPlace.Next(2)==1)
                {
                    myLocation = LocationWithDoor.DoorLocation;
                }
            }
            bool hidden = false;
            while (!hidden)
            {
                int rand = myHidingPlace.Next(myLocation.Exits.Length);
                myLocation = myLocation.Exits[rand];
                if (myLocation is IHidingPlace)
                {
                    hidden = true;
                }
            }
        }

        public bool Check(Location locationToCheck)
        {
            if (locationToCheck != myLocation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
