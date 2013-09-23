using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableBenchmark
{
    public class StrategyRunner : StrategyRunnerBase
    {
        readonly IDictionary<string, string> catalog = new Dictionary<string, string>
		{
			{"012345", "Car"},
			{"012346", "Bus"},
			{"012347", "Train"}
		};

        public StrategyRunner(IDataManager dataManager)
            : base(dataManager)
        {
            catalog.Add("%Date%", DateTime.Now.ToString("d"));
        }

        protected override string Transform(string str)
        {
            var builder = new StringBuilder(str);
            foreach (var key in catalog.Keys)
                builder.Replace(key, catalog[key]);
            return builder.ToString();
        }
    }
}