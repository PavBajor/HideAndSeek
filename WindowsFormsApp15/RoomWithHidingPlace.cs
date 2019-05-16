using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    public class RoomWithHidingPlace : Room, IHidingPlace
    {
        private string hidingPlaceName;

        public RoomWithHidingPlace(string decoration, string name, string hidingPlaceName) :base(decoration, name)
        {
            this.hidingPlaceName = hidingPlaceName;
        }

        public string HidingPlaceName
        {
            get
            {
                return hidingPlaceName;
            }
        }
    }
}
