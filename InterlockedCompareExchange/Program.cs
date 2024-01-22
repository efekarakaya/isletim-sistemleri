using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static int count = 0;

    static void Increment()
    {
      Console.WriteLine("{0} is entered.", Thread.CurrentThread.Name);
      int current, updated;

      for (int i = 0; i < 10000; i++)
      {
        do
        {
          current = count;
          updated = current + 1;
          Console.WriteLine("{0} is trying to updated.", Thread.CurrentThread.Name);
        } while (Interlocked.CompareExchange(ref count, updated, current) != current);
        Console.WriteLine("{0} updated count from {1} to {2}", Thread.CurrentThread.Name, current, count);
      }
    }

    static void Main(string[] args)
    {
      for (int i = 0; i < 8; i++)
      {
        Thread thread = new Thread(Increment);
        thread.Name = "Thread " + i;
        thread.Start();
      }
    }
  }
}