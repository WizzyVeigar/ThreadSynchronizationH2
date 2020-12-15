﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationH2
{
    class Producer
    {
        private List<int> buffer;

        public List<int> Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }

        public Producer(List<int> buffer)
        {
            Buffer = buffer;
        }
        Random random = new Random();

        public void produceGood()
        {
            while (true)
            {
                while (Buffer.Count <= 4)
                {
                    if (Monitor.TryEnter(Buffer))
                    {
                        while (Buffer.Count < 4)
                        {
                            Console.WriteLine("Added to the buffer");
                            Buffer.Add(random.Next(1, 10));
                        }
                        Monitor.Pulse(Buffer);
                        Monitor.Exit(Buffer);
                        Thread.Sleep(200);
                    }
                }
            }
        }
    }
}