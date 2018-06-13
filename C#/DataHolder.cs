using Program360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program360
{
    class DataHolder
    {
        public Point me;
        public Point nemesis;
        public int me_taxes;
        public int their_taxes;

        public DataHolder(Point me, Point nem, int me_tax, int their_tax)
        {
            this.me = me;
            this.nemesis = nem;
            this.me_taxes = me_tax;
            this.their_taxes = their_tax;
        }

        public int Difference()
        {
            return this.me_taxes - this.their_taxes;
        }

        public String ToString()
        {
            return this.me.ToString() + " " + this.nemesis.ToString() + (this.me_taxes - this.their_taxes);
        }
    }
}
