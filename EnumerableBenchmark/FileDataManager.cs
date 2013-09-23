using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnumerableBenchmark
{
    public class FileDataManager : IDataManager
    {
        private StreamReader reader;
        private StreamWriter writer;

        #region Initialize

        public void Initialize()
        {
            GenerateInput();
        }

        public static IEnumerable<string> GenerateSequence()
        {
            while (true)
            {
                yield return "%Date% - 012345 drive fast";
                yield return "%Date% - 012346 move people";
                yield return "%Date% - 012347 move stuff";
            }
        }

        public static void GenerateInput()
        {
            if (!File.Exists("input.txt"))
                using (var file = File.CreateText("input.txt"))
                    foreach (var str in GenerateSequence().Take(10000000))
                        file.WriteLine(str);
        }

        #endregion

        #region Read

        public void ReadInit()
        {
            reader = File.OpenText("input.txt");
        }

        public bool CanRead()
        {
            return !reader.EndOfStream;
        }

        public string ReadString()
        {
            return reader.ReadLine();
        }

        public void ReadDone()
        {
            reader.Close();
        }

        #endregion

        #region Write

        public void WriteInit()
        {
            writer = File.CreateText("output.txt");
        }

        public void WriteString(string str)
        {
            writer.WriteLine(str);
        }

        public void WriteDone()
        {
            writer.Close();
        }

        #endregion
    }
}