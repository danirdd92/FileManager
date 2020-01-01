using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class WordFile : MyFile, IWordCounter
    {
        #region Properties And Index
        public string Text { get; }

        public int NumOfWords
        {
            get
            {
                int counter = 0;
                foreach (var character in Text)
                {
                    if (character.Equals(' ') || character.Equals(null))
                        counter++;
                }
                return counter;
            }
        }
        public int NumberOfPages
        {
            get
            {
                return (int)(NumOfWords / 10);
            }
        }

        public string this[int index]
        {
            get
            {
                if (index > 0 && index <= NumOfWords)
                {
                    return TrimWord(Text, index);
                }
                else
                {
                    throw new IndexOutOfRangeException("You tried to read a word outside of text bounds");
                }

            }

        }
        #endregion

        public WordFile(string text, string filePath, int fileSize) : base(filePath, fileSize)
        {
            Text = text;
        }

        #region Methods
        public override void PrintFiie()
        {
            for (int i = 1; i <= NumOfWords + 1; i++)
            {
                Console.WriteLine(TrimWord(Text, i));
            }
        }

        private string TrimWord(string text, int index)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            foreach (var c in text)
            {
                if (c.Equals(' ') || c.Equals(null))
                {
                    counter++;
                }
                if (counter > index)
                {
                    break;
                }
                if (counter == index && c != ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region Overrides and Operators
        public override bool Equals(object obj)
        {
            // Using Pattern Maching, make sure you have an updated version of C#
            if (obj != null && obj is WordFile file)
                return this.Text == file.Text;
            else
                return false;
        }

        public static bool operator ==(WordFile file1, WordFile file2)
        {
            return file1.Equals(file2);
        }

        public static bool operator !=(WordFile file1, WordFile file2)
        {
            return !file1.Equals(file2);
        }

        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }

        public static WordFile operator +(WordFile file1, WordFile file2)
        {
            bool isBigger = file1.FilePath.Length > file2.FilePath.Length;

            if (isBigger)
            {
               return  new WordFile(file1.Text + " " + file2.Text,
                                          file1.FilePath + ".mrg",
                                          file1.FileSize + file2.FileSize);
            }
            else
            {
                return new WordFile(file1.Text + " " + file2.Text,
                                          file2.FilePath + ".mrg",
                                          file1.FileSize + file2.FileSize);
            }
        }
        #endregion
    }
}
