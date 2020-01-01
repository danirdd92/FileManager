using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class ImageFile : MyFile
    {
        public ImageFile(int[,] bytes, string filepath, int fileSize) : base(filepath, fileSize)
        {
            ByteMap = bytes;
            ConstructByteMap(ByteMap);
        }

        public int[,] ByteMap { get; }

        public override void PrintFiie()
        {
            for (int i = 0; i < ByteMap.GetLength(0); i++)
            {
                for (int j = 0; j < ByteMap.GetLength(1); j++)
                {
                    Console.WriteLine(ByteMap[i,j]);
                }
            }
        }

        private int[,] ConstructByteMap(int[,] byteArr)
        {
            Random rnd = new Random();
            for (int i = 0; i < byteArr.GetLength(0); i++)
            {
                for (int j = 0; j < byteArr.GetLength(1); j++)
                {
                    byteArr[i, j] = rnd.Next(256);
                }
            }
            return byteArr;
        }
    }
}
