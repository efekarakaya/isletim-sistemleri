using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static int total = 0;
    static int doneThread = 0;

    static object obj = new object();
    static object obj2 = new object();

    static void Increment()
    {
      for (int i = 0; i < 10000000; i++)
      {
        lock (obj)
        {
          total++;
        }
      }
      lock (obj2)
      {
        doneThread++;
      }
    }

    static void Main(string[] args)
    {
      for (int i = 0; i < 10; i++)
      {
        Thread thread = new Thread(Increment);
        thread.Start();
        thread.Name = "Thread " + i;
      }

      while (doneThread < 10) ;

      Console.WriteLine(total);
    }
  }
}