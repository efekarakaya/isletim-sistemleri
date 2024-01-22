using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static Semaphore pool;

    static void Worker()
    {
      Console.WriteLine("{0} wants to enter to the Semaphore.", Thread.CurrentThread.Name);
      pool.WaitOne();
      Console.WriteLine("{0} is entered.", Thread.CurrentThread.Name);
      Thread.Sleep(3000);
      pool.Release();
      Console.WriteLine("{0} is released.", Thread.CurrentThread.Name);
    }

    static void Main(string[] args)
    {
      pool = new Semaphore(initialCount: 5, maximumCount: 5);

      for (int i = 0; i < 5; i++)
      {
        Thread thread = new Thread(Worker);
        thread.Name = "Thread " + i;
        thread.Start();
      }

      // pool.Release(releaseCount: 2);
    }
  }
}