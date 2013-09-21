using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableDemo.Bad
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

		public IList<string> Transform(IList<string> strs)
		{
			var list = new List<string>();

			foreach (var item in strs)
			{
				var builder = new StringBuilder(item);
				foreach (var key in _catalog.Keys)
				{
					builder.Replace(key, _catalog[key]);
				}
				list.Add(builder.ToString());
			}

			return list;
		}
	}
}

