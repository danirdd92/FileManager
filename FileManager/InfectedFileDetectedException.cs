using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class InfectedFileDetectedException : Exception
    {
        public InfectedFileDetectedException(string message) : base(message)
        {
        }

        public InfectedFileDetectedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}