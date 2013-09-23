using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableBenchmark
{
	public class ListStringTransformer
	{
	    readonly IDictionary<string, string> catalog = new Dictionary<string, string>
		{
			{"012345", "Car"},
			{"012346", "Bus"},
			{"012347", "Train"}
		};

		public ListStringTransformer()
		{
			catalog.Add("%Date%", DateTime.Now.ToString("d"));
		}

		public IList<string> Transform(IList<string> strs)
		{
			var list = new List<string>(ListRunner.MaxSize);

			foreach (var item in strs)
			{
				var builder = new StringBuilder(item);
				foreach (var key in catalog.Keys)
				{
					builder.Replace(key, catalog[key]);
				}
				list.Add(builder.ToString());
			}

			return list;
		}
	}
}

