using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationH2
{
    class Consumer
    {
        private List<int> buffer;

        public List<int> Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }

        public Consumer(List<int> buffer)
        {
            Buffer = buffer;
        }


        public void TakeGoods()
        {
            while (true)
            {
                while (Buffer.Count > 0)
                {
                    if (Monitor.TryEnter(Buffer))
                    {
                        Console.WriteLine("Removed from the buffer");
                        Buffer.RemoveAt(Buffer.Count - 1);
                        Monitor.Pulse(Buffer);
                        Monitor.Exit(Buffer);
                        Thread.Sleep(200);
                    }
                }
            }
        }

    }
}
