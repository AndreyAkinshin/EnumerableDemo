namespace EnumerableBenchmark
{
    public abstract class StrategyRunnerBase
    {
        private readonly IDataManager dataManager;

        protected StrategyRunnerBase(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        protected abstract string Transform(string str);

        public void Run()
        {
            dataManager.ReadInit();
            dataManager.WriteInit();
            while (dataManager.CanRead())
            {
                var str = dataManager.ReadString();
                str = Transform(str);
                dataManager.WriteString(str);
            }
            dataManager.ReadDone();
            dataManager.WriteDone();
        }
    }
}