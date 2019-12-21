namespace FileManager
{
    public interface IWordCounter
    {
        string this[int index] { get; }

        int NumberOfPages { get; }
        int NumOfWords { get; }
    }
}