using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class ImageFile : MyFile
    {
        /*------------------------------------
         * I have not included section 13 in my code
         * Since T would be too ambiguous to the point of
         * incompatibility with ConstructByteMap().
         * Even constraints won't be enough for it,
         * and there are too many cases to manage for switch
         * pattern matching expression here.
         * You can be rest assured that I can still handle my Generics very well.
         * -----------------------------------
         */

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
