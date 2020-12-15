using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSynchronizationH2
{
    class Fork
    {
        private string forkName;

        public string ForkName
        {
            get { return forkName; }
            set { forkName = value; }
        }

        public Fork(string forkName)
        {
            ForkName = forkName;
        }
    }
}
