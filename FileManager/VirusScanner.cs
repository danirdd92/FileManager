using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public static class VirusScanner
    {
        private static  int _infectedFileSize;

        public static int InfectedFileSize
        {
            get { return _infectedFileSize; }
            private set { _infectedFileSize = value; }
        }

        static VirusScanner()
        {
            _infectedFileSize = ConfigurationManager.GetValue();
        }

        public static bool IsFileInfected(MyFile file)
        {
            return file.FileSize == _infectedFileSize;
        }
    }
}
