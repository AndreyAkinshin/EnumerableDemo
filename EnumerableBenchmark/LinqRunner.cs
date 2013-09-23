using System.Collections.Generic;
using System.Linq;

namespace EnumerableBenchmark
{
    public class LinqRunner
    {
        private readonly IDataManager dataManager;

        public LinqRunner(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<string> ReadInput()
        {
            dataManager.ReadInit();
            while (dataManager.CanRead())
                yield return dataManager.ReadString();
            dataManager.ReadDone();
        }

        public void WriteOutput(IEnumerable<string> strs)
        {
            dataManager.WriteInit();
            foreach (var str in strs)
                dataManager.WriteString(str);
            dataManager.WriteDone();
        }

        public void Run()
        {
            var stringTransformer = new LinqStringTransformer();
            var input = ReadInput().Where(str => str.Length > 5);
            var transformed = stringTransformer.Transform(input);
            WriteOutput(transformed);
        }
    }
}