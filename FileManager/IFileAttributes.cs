namespace FileManager
{
    public interface IFileAttributes
    {
        string FilePath { get; }
        int FileSize { get; }
        bool IsArchived { get; }
        bool IsInfected { get; }
        bool IsReadOnly { get; }
    }
}