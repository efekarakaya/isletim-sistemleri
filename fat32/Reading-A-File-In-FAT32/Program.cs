using System;
using System.Threading;

namespace yutup
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] fat32 = new int[100];
      string[] hdd = new string[100];

      int eof = -1;

      // Dosya: 1 -> 2 -> 3 -> 8 -> 52
      fat32[1] = 2;
      fat32[2] = 3;
      fat32[3] = 8;
      fat32[8] = 52;
      fat32[52] = eof;

      // .txt -> Merhaba, bu bir FAT32 videosudur.
      hdd[1] = "Merhaba,";
      hdd[2] = " bu";
      hdd[3] = " bir";
      hdd[8] = " FAT32 videosudur.";

      // Dosya 2: 53 -> 22 -> 23 -> 4 -> 99 -> 7
      fat32[53] = 22;
      fat32[22] = 23;
      fat32[23] = 4;
      fat32[4] = 99;
      fat32[99] = 7;
      fat32[7] = eof;

      // .txt -> Bu bizim ikinci metin dosyamız.
      hdd[53] = "Bu";
      hdd[22] = " bizim";
      hdd[23] = " ikinci";
      hdd[4] = " metin";
      hdd[99] = " dosyamız.";

      int startingCluster = 53;
      int pointer = startingCluster;
      string data = "";

      if (fat32[pointer] == 0)
      {
        Console.WriteLine("Cluster is empty.");
        return;
      }

      while (pointer != eof)
      {
        data += hdd[pointer];
        pointer = fat32[pointer]; // fat32[52]
      }

      Console.WriteLine(data);
    }
  }
}