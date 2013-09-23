namespace EnumerableBenchmark
{
    public interface IDataManager
    {
        void Initialize();

        void ReadInit();
        bool CanRead();
        string ReadString();
        void ReadDone();

        void WriteInit();
        void WriteString(string str);
        void WriteDone();
    }
}