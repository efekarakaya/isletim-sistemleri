using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static int isReceiving = 0;

    static void ReceiveMessage()
    {
      if (Interlocked.Exchange(ref isReceiving, 1) < 5)
      {
        Console.WriteLine("{0} is entered.", Thread.CurrentThread.Name);
        Thread.Sleep(3000);
        Interlocked.Exchange(ref isReceiving, isReceiving - 1);
        Console.WriteLine("{0} is exited.", Thread.CurrentThread.Name);
      }
      else
      {
        Console.WriteLine("{0} is not allowed to enter.", Thread.CurrentThread.Name);
      }
    }

    static void Main(string[] args)
    {
      for (int i = 0; i < 10; i++)
      {
        Thread thread = new Thread(ReceiveMessage);
        thread.Name = "Thread " + i;
        thread.Start();
      }
    }
  }
}