using BenchmarkDotNet;

namespace EnumerableBenchmark
{
    class Program
    {
        static void Main()
        {
            var dataManager = CreateDataManager();
            dataManager.Initialize();
            var listRunner = new ListRunner(dataManager);
            var linqRunner = new LinqRunner(dataManager);
            var strategyRunner = new StrategyRunner(dataManager);

            BenchmarkSettings.Instance.DetailedMode = true;
            var competition = new BenchmarkCompetition();
            competition.AddTask("List", listRunner.Run);
            competition.AddTask("LINQ", linqRunner.Run);
            competition.AddTask("Strategy", strategyRunner.Run);
            competition.Run();
        }

        private static IDataManager CreateDataManager()
        {
            return new MockDataManager();
        }
    }
}
