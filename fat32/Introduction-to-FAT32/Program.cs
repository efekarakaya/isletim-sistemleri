using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] fat32 = new int[100];

      int eof = -1;

      // Dosya: 1 -> 2 -> 3 -> 8 -> 52
      fat32[1] = 2;
      fat32[2] = 3;
      fat32[3] = 8;
      fat32[8] = 52;
      fat32[52] = eof;

      // int startingCluster = 1;
      // int pointer = startingCluster;
      // string address = "";
      // while (pointer != eof)
      // {
      //   Console.WriteLine(pointer);
      //   address += pointer + " -> ";
      //   pointer = fat32[pointer]; // fat32[52]
      // }

      Console.WriteLine(fat32[89]);
    }
  }
}