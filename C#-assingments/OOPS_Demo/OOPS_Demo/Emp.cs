using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Demo
{
    public class Emp
    {

        private int bal;

        public int Bal
        {
            get { return bal; }
            set { bal = value; }
        }
        public Emp(int bal)
        {
               this.bal = bal;

        }
    }
}
