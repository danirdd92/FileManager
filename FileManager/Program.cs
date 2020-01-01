using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FileManager
{
    public static class Program
    {
        static void Main(string[] args)
        {
            WordFile file = new WordFile("This is a test to check how many times the word test has been said", "test", 778);

            file.GetSpecificWordCount("test");
          




        }
    }
}
