using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static object obj1 = new object();
    static object obj2 = new object();

    static void Print1()
    {
      lock (obj1)
      {
        Console.WriteLine("{0} is acquired lock to obj1", Thread.CurrentThread.Name);
        lock (obj2)
        {
          Console.WriteLine("{0} is acquired lock to obj2", Thread.CurrentThread.Name);
        }
      }
    }

    static void Print2()
    {
      lock (obj2)
      {
        Console.WriteLine("{0} is acquired lock to obj2", Thread.CurrentThread.Name);
        lock (obj1)
        {
          Console.WriteLine("{0} is acquired lock to obj1", Thread.CurrentThread.Name);
        }
      }
    }

    static void Main(string[] args)
    {
      Thread thread1 = new Thread(Print1);
      thread1.Name = "Thread 1";
      thread1.Start();

      Thread thread2 = new Thread(Print2);
      thread2.Name = "Thread 2";
      thread2.Start();
    }
  }
}