using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FileManager
{
    public abstract class MyFile : IFileAttributes
    {
        #region Fields And Properties
        const bool IS_HEB_SUPPORTED = true;
        protected readonly string _filePath;
        private static List<string> _paths = new List<string>();

        public string FilePath { get; set; }

        public int FileSize { get; private set; }

        public bool IsReadOnly { get; private set; }

        public bool IsArchived { get; private set; }

        public bool IsInfected { get; private set; } = false;
        #endregion

        protected MyFile(string path, int fileSize)
        {
            _filePath = path;
            FileSize = fileSize;
            _paths.Add(path);
            if (VirusScanner.IsFileInfected(this))
            {
                throw new InfectedFileDetectedException($"The file at {this.FilePath} has been infected with an Ebola and HIV hybrid!");
            }
        }

        #region Methods
        public abstract void PrintFiie();

        public static void SortFilesBySize(ref IEnumerable<MyFile> files)
        {
            files.OrderBy(x => x.FileSize);
        }

        public static void SortFilesByPath(ref IEnumerable<MyFile> files)
        {
            files.OrderBy(x => x.FilePath);

        }
        #endregion

        #region Overrides and Operators
        public override bool Equals(object obj)
        {
            // Using Pattern Maching, make sure you have an updated version of C#
            if (obj != null && obj is MyFile file)
                return this.FilePath == file.FilePath;
            else
                return false;
        }

        public static bool operator ==(MyFile file1, MyFile file2)
        {
            return file1.Equals(file2);
        }

        public static bool operator !=(MyFile file1, MyFile file2)
        {
            return !file1.Equals(file2);
        }

        public override int GetHashCode()
        {
            return this.FilePath.GetHashCode();
        }
        #endregion
    }

}
