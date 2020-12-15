using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationH2
{
    class Philosopher
    {
        private Fork rightFork;
        public Fork RightFork
        {
            get { return rightFork; }
            set { rightFork = value; }
        }

        private Fork leftFork;
        public Fork LeftFork
        {
            get { return leftFork; }
            set { leftFork = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Philosopher(string name, Fork leftFork, Fork rightFork)
        {
            LeftFork = leftFork;
            RightFork = rightFork;
            Name = name;
        }


        Random rand = new Random();

        public void TakeFork()
        {
            while (true)
            {
                if (Monitor.TryEnter(LeftFork))
                {
                    if (Monitor.TryEnter(RightFork, 200))
                    {
                        Eat();
                        Monitor.Pulse(LeftFork);
                        Monitor.Pulse(RightFork);

                        Monitor.Exit(LeftFork);
                        Monitor.Exit(RightFork);
                    }
                    else
                    {
                        Monitor.Exit(LeftFork);
                    }
                }
            }
        }

        private void Eat()
        {
            Console.WriteLine(Name + " started eating with " + RightFork.ForkName + " and " + LeftFork.ForkName);
            Thread.Sleep(rand.Next(5, 50) * 100);
            Console.WriteLine(Name + " is done eating");
        }
    }
}
