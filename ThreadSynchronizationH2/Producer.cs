using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationH2
{
    class Producer
    {
        private int[] buffer;

        public int[] Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }


        public Producer(int[] buffer)
        {
            Buffer = buffer;
        }
        Random random = new Random();

        public void produceGood()
        {
            while (true)
            {
                Monitor.Enter(Buffer);

                while (Program.bufferCurrent > Buffer.Length)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Producer waiting");
                    Monitor.Wait(buffer);
                }

                for (int i = 0; i < Buffer.Length; i++)
                {
                    if (Buffer[i] == 0)
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Added to the buffer");
                        Buffer[i] = random.Next(1, 10);
                        i = Buffer.Length + 1;
                        Program.bufferCurrent++;
                    }
                }
                Monitor.Pulse(Buffer);
                Monitor.Exit(Buffer);
            }
        }
    }
}
