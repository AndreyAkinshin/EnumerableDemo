using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace EnumerableDemo.Good
{
	class MainClass
	{
		public static IEnumerable<string> ReadInput()
		{
			using (var file = File.OpenText("input.txt"))
			{
				while (!file.EndOfStream)
				{
					yield return file.ReadLine();
				}
			}
		}

		public static void WriteOutput(IEnumerable<string> strs)
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
			var input = ReadInput().Where(str=>str.Length > 5);
			var transformed = stringTransformer.Transform(input);
			WriteOutput(transformed);
			watch.Stop();
			Console.WriteLine("Elapsed seconds {0}", watch.Elapsed.TotalSeconds);
		}
	}
}
