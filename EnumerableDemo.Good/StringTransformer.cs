using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EnumerableDemo.Good
{
	public class StringTransformer
	{
		IDictionary<string, string> _catalog = new Dictionary<string, string>
		{
			{"012345", "Car"},
			{"012346", "Bus"},
			{"012347", "Train"}
		};

		public StringTransformer()
		{
			_catalog.Add("%Date%", DateTime.Now.ToString("d"));
		}

		public IEnumerable<string> Transform(IEnumerable<string> strs)
		{
			return strs
				.Select(str => new StringBuilder(str))
				.Select(Transform);
		}

		private string Transform(StringBuilder stringBuilder)
		{
			foreach (var key in _catalog.Keys)
			{
				stringBuilder.Replace(key, _catalog[key]);
			}

			return stringBuilder.ToString();
		}
	}
}

