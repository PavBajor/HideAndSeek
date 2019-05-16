using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15
{
    public class Outside : Location
    {
        private bool hot;
        public Outside(bool hot, string name)
            :base(name)
        {
            this.hot = hot; 
        }
        public override string Description
        {
            get
            {
                string newDescription = base.Description;
                if (hot)
                {
                    newDescription += " It is very hot here.";
                }
                return newDescription;
            }
        }
    }
}
