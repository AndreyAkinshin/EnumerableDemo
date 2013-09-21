using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnumerableDemo.InputGenerator
{
    class MainClass
    {
        public static IEnumerable<string> Generate()
        {
            while (true)
            {
                yield return "%Date% - 012345 drive fast";
                yield return "%Date% - 012346 move people";
                yield return "%Date% - 012347 move stuff";
            }
        }

        public static void Main(string[] args)
        {
            using (var file = File.CreateText("input.txt"))
            {
                var generatedStrings = Generate().Take(1000000000);
                foreach (var str in generatedStrings)
                {
                    file.WriteLine(str);
                }
            }
        }
    }
}
