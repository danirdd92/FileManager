using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public abstract class MyFile : IFileAttributes
    {
        const bool IS_HEB_SUPPORTED = true;
        protected readonly string _filePath;
        private  static List<string> _paths;

        public string FilePath { get; set; }

        public int FileSize { get; private set; }

        public bool IsReadOnly { get; private set; }

        public bool IsArchived { get; private set; }

        public bool IsInfected { get; private set; }

        public MyFile(string path)
        {
            _filePath = path;
        }


        public abstract void PrintFiie();


    }
}
