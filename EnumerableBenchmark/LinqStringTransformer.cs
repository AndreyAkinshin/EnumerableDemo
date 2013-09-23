using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EnumerableBenchmark
{
    public class LinqStringTransformer
    {
        readonly IDictionary<string, string> catalog = new Dictionary<string, string>
		{
			{"012345", "Car"},
			{"012346", "Bus"},
			{"012347", "Train"}
		};

        public LinqStringTransformer()
        {
            catalog.Add("%Date%", DateTime.Now.ToString("d"));
        }

        public IEnumerable<string> Transform(IEnumerable<string> strs)
        {
            return strs
                .Select(str => new StringBuilder(str))
                .Select(Transform);
        }

        private string Transform(StringBuilder stringBuilder)
        {
            foreach (var key in catalog.Keys)
                stringBuilder.Replace(key, catalog[key]);

            return stringBuilder.ToString();
        }
    }
}

