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
        private int[] buffer;

        public int[] Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }

        public Consumer(int[] buffer)
        {
            Buffer = buffer;
        }



        public void TakeGoods()
        {
            while (true)
            {
                Monitor.Enter(Buffer);

                while (Program.bufferCurrent == 0)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Consumer waiting");
                    Monitor.Wait(buffer);
                }

                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Removed from the buffer");
                for (int i = 0; i < Buffer.Length; i++)
                {
                    if (Buffer[i] != 0)
                    {
                        Buffer[i] = 0;
                        i = Buffer.Length + 1;
                        Program.bufferCurrent--;
                    }
                }
                Monitor.Pulse(Buffer);
                Monitor.Exit(Buffer);
                Thread.Sleep(1000);
            }
        }

    }
}
