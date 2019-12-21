using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class WordFile : MyFile, IWordCounter
    {
        public WordFile(string text, string filePath) : base(filePath)
        {
            Text = text;
        }

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
    }
}
