using System.Threading;

namespace EnumerableBenchmark
{
    public class MockDataManager : IDataManager
    {
        public void Initialize()
        {
        }

        #region Read

        private int readCounter;
        private const int ReadSize = 5000000;
        private const int ReadTime = 0;

        private readonly string[] readData = new[]
            {
                "%Date% - 012345 drive fast",
                "%Date% - 012346 move people",
                "%Date% - 012347 move stuff"
            };

        public void ReadInit()
        {
            readCounter = 0;
        }

        public bool CanRead()
        {
            return readCounter < ReadSize;
        }

        public string ReadString()
        {
            Thread.Sleep(ReadTime);
            return readData[readCounter++ % readData.Length];
        }

        public void ReadDone()
        {
        }

        #endregion

        #region Write

        private const int WriteTime = 0;

        public void WriteInit()
        {
        }

        public void WriteString(string str)
        {
            Thread.Sleep(WriteTime);
        }

        public void WriteDone()
        {
        }

        #endregion
    }
}