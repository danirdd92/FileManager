using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public bool IsInfected { get; private set; } = false;

        protected MyFile(string path, int fileSize)
        {
            _filePath = path;
            FileSize = fileSize;

            if (VirusScanner.IsFileInfected(this))
            {
                throw new InfectedFileDetectedException($"The file at {this.FilePath} has been infected with an Ebola and HIV hybrid!");
            }
        }

        public abstract void PrintFiie();

        public static void SortFilesBySize(ref IEnumerable<MyFile> files)
        {
            files.OrderBy(x => x.FileSize);
        }

        public static void SortFilesByPath(ref IEnumerable<MyFile> files)
        {
            files.OrderBy(x => x.FilePath);

        }
    }

}
