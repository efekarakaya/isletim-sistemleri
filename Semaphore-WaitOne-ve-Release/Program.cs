using System;
using System.Threading;

namespace yutup
{
  class WaitOneRelease
  {
    static int S = 5;

    static void WaitOne()
    {
      while (S <= 0) ;
      Interlocked.Add(ref S, -1);
    }

    static void Release()
    {
      Interlocked.Add(ref S, +1);
    }

    static void UploadImage()
    {
      Console.WriteLine("{0} wants to enter.", Thread.CurrentThread.Name);
      WaitOne();
      Console.WriteLine("{0} is entered.", Thread.CurrentThread.Name);
      Thread.Sleep(5000);
      Release();
      Console.WriteLine("{0} is released.", Thread.CurrentThread.Name);
    }

    static void Main(string[] args)
    {
      for (int i = 0; i < 20; i++)
      {
        Thread thread = new Thread(UploadImage);
        thread.Name = "Thread " + i;
        thread.Start();
      }
    }
  }
}