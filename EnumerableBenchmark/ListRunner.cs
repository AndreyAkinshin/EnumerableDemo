using System.Collections.Generic;

namespace EnumerableBenchmark
{
    public class ListRunner
    {
        public const int MaxSize = 5000000;

        private readonly IDataManager dataManager;

        public ListRunner(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IList<string> ReadInput()
        {
            dataManager.ReadInit();
            var list = new List<string>(MaxSize);
            while (dataManager.CanRead())
            {
                var str = dataManager.ReadString();
                if (str.Length <= 5)
                    continue;
                list.Add(str);
            }
            dataManager.ReadDone();
            return list;
        }

        public void WriteOutput(IList<string> strs)
        {
            dataManager.WriteInit();
            foreach (var str in strs)
                dataManager.WriteString(str);
            dataManager.WriteDone();
        }

        public void Run()
        {
            var stringTransformer = new ListStringTransformer();
            var input = ReadInput();
            var transformed = stringTransformer.Transform(input);
            WriteOutput(transformed);
        }
    }
}