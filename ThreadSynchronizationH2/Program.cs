using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronizationH2
{
    class Program
    {

        //static int number = 0;
        public static Fork[] forkArray = new Fork[5];
        
        public static List<int> buffer = new List<int>();

        static void Main(string[] args)
        {
            //Første opgave
            //ThreadPool.QueueUserWorkItem(AddByTwo, _lock);
            //ThreadPool.QueueUserWorkItem(MinusByOne, _lock);
            //Thread starThread = new Thread(WriteStars);
            //Thread fenceThread = new Thread(WriteFences);
            //starThread.Start();
            //fenceThread.Start();

            //Dining Philosophers
            //FillForkArray();
            //List<Philosopher> philosophList = new List<Philosopher>() {
            //    new Philosopher("Philosph 1", forkArray[0], forkArray[1]),
            //    new Philosopher("Philosph 2", forkArray[1], forkArray[2]),
            //    new Philosopher("Philosph 3", forkArray[2], forkArray[3]),
            //    new Philosopher("Philosph 4", forkArray[3], forkArray[4]),
            //    new Philosopher("Philosph 5", forkArray[4], forkArray[0])
            //};
            //for (int i = 0; i < philosophList.Count; i++)
            //{
            //    Thread thread = new Thread(philosophList[i].TakeFork);
            //    thread.Start();
            //}

            //Producer Consumer
            //Consumer consumer = new Consumer(buffer);
            //Producer producer = new Producer(buffer);
            //Thread consumerThread = new Thread(consumer.TakeGoods);
            //Thread producerThread = new Thread(producer.produceGood);
            //consumerThread.Start();
            //producerThread.Start();

            Console.ReadKey();
        }

        //static void AddByTwo(object _lock)
        //{
        //    while (true)
        //    {
        //        Monitor.Enter(_lock);
        //        number += 2;
        //        Console.WriteLine("Added by two, now number is at " + number);
        //        Thread.Sleep(1000);
        //        Monitor.Exit(_lock);
        //    }
        //}
        //static void MinusByOne(object _lock)
        //{
        //    while (true)
        //    {
        //        Monitor.Enter(_lock);
        //        number--;
        //        Console.WriteLine("Reduced by one, now number is at " + number);
        //        Thread.Sleep(1000);
        //        Monitor.Exit(_lock);
        //    }
        //}


        //static bool doStars = false;
        //static void WriteStars()
        //{
        //    while (true)
        //    {
        //        if (Monitor.TryEnter(_lock))
        //        {
        //            if (doStars)
        //            {
        //                for (int i = 0; i < 60; i++)
        //                {
        //                    Console.Write("*");
        //                }
        //                number += 60;
        //                Console.Write(" " + number + "\n");
        //                doStars = false;
        //                Monitor.Pulse(_lock);
        //                Monitor.Exit(_lock);
        //            }
        //            else
        //            {
        //                Monitor.Wait(_lock);
        //            }
        //        }
        //    }
        //}
        //static void WriteFences()
        //{
        //    while (true)
        //    {
        //        if (Monitor.TryEnter(_lock))
        //        {
        //            if (!doStars)
        //            {
        //                for (int i = 0; i < 60; i++)
        //                {
        //                    Console.Write("#");
        //                }
        //                number += 60;
        //                Console.Write(" " + number + "\n");
        //                doStars = true;
        //                Monitor.Pulse(_lock);
        //                Monitor.Exit(_lock);
        //            }
        //            else
        //            {
        //                Monitor.Wait(_lock);
        //            }
        //        }
        //    }
        //}


        //public static void FillForkArray()
        //{
        //    for (int i = 0; i < forkArray.Length; i++)
        //    {
        //        forkArray[i] = new Fork("Fork " + i);
        //    }
        //}
    }
}
