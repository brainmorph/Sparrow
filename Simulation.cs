using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    internal class Simulation
    {
        private EOM eom = new EOM();

        public void Run()
        {
            while (true)
            {
                eom.FixedUpdate();
            }
        }
    }
}
