using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_8___Hash_Dict
{
    class Program
    {
        static Random rand;
        static Program() => rand = new Random();
        static void Main(string[] args)
        {
            HashSet<Thing> hash = new HashSet<Thing>();
            List<Thing> list = new List<Thing>();
            int count = 10000;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Thing.Reset();
            watch.Start();
            for (int i = 0; i < count; ++i)
                list.Add(new Thing(RandString(), rand.Next(100)));
            watch.Stop();
            Console.WriteLine($"List Load:{watch.ElapsedMilliseconds}");
            Console.WriteLine($"Equals:{Thing.EqualsCount} GetHash:{Thing.HashCount}");
            watch.Reset();

            Thing.Reset();
            watch.Start();
            for (int i = 0; i < count; ++i)
                hash.Add(new Thing(RandString(), rand.Next(100)));
            watch.Stop();
            Console.WriteLine($"Hash Load:{watch.ElapsedMilliseconds}");
            Console.WriteLine($"Equals:{Thing.EqualsCount} GetHash:{Thing.HashCount}");
            watch.Reset();

            Dictionary<string, Thing> dict = 
                new Dictionary<string, Thing>();

            dict.Add("Larry", new Thing("Lawrence", 22));
            dict.Add("Moe", new Thing("Maurice", 26));
            dict.Add("Curley", new Thing("Harold", 19));
            dict.Add("Shemp", new Thing("Samuel", 19));
           // dict.Add("Curley", new Thing("Brenda", 12));
            dict.Add("Shemp2", new Thing("Samuel", 19));

            foreach (KeyValuePair<string,Thing> kvp in dict)
            {
                Console.WriteLine($"Key: {kvp.Key}");
                Console.WriteLine($"Value: {kvp.Value}");
            }

            Console.ReadKey();
        }

        static public void  PrintVals(IEnumerable<Thing> container)
        {
            foreach (Thing t in container)
                Console.WriteLine(t);
        }

        static public string RandString()
        {
            StringBuilder sb = new StringBuilder("");
            int numchars = rand.Next(3,6);
            for (int i = 0; i < numchars; ++i)
                sb.Append('a' + rand.Next(26));
            return sb.ToString();
        }
    }
}
