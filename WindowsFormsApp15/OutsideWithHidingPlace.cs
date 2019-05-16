using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    public class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        private string hidingPlaceName;


        public OutsideWithHidingPlace(bool hot, string name, string hidingPlaceName) :base(hot, name)
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
