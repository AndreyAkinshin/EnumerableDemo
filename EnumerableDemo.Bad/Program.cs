using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace EnumerableDemo.Bad
{
	class MainClass
	{
		public static IList<string> ReadInput()
		{
			var list = new List<string>();
			using (var file = File.OpenText("input.txt"))
			{
				while (!file.EndOfStream)
				{
					var str = file.ReadLine();
					if (str.Length <= 5)
					{
						continue;
					}

					list.Add(str);
				}
			}

			return list;
		}

		public static void WriteOutput(IList<string> strs)
		{
			using (var file = File.CreateText("output.txt"))
			{
				foreach (var str in strs)
				{
					file.WriteLine(str);
				}
			}
		}

		public static void Main(string[] args)
		{
			var watch = new Stopwatch();
			watch.Start();
			var stringTransformer = new StringTransformer();
			var input = ReadInput();
			var transformed = stringTransformer.Transform(input);
			WriteOutput(transformed);
			watch.Stop();
			Console.WriteLine("Elapsed seconds {0}", watch.Elapsed.TotalSeconds);
		}
	}
}
