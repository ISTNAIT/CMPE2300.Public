using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<string> pets = new List<string> { "dog","cat", "fish", "mongoose" };
            //How many of these species have short names?

            int iNum = pets.FindAll(BiggerThan3).Count;
            int iNum2 = pets.FindAll(s => s.Length > 3).Count;

            //Set operations
            List<CInt> things = new List<CInt>(5);
            for (int i = 0; i < things.Capacity; ++i)
                things.Add(new CInt(r.Next(10)));
            for (int i = 0; i < 3; ++i)
                things.Add(things[i]);

            PrintThings(things);
            PrintThings(things.Distinct().ToList());
            PrintThings(things);

            List<CInt> thangs = new List<CInt>(5);
            for (int i = 0; i < thangs.Capacity; ++i)
                thangs.Add(new CInt(r.Next(10)));
            for (int i = 0; i < 3; ++i)
                thangs.Add(things[i]);

            //This is a really long way of saying 'Union'
            PrintThings(things.Concat(thangs).ToList().Distinct().ToList());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            PrintThings(things);
            PrintThings(thangs);
            PrintThings(things.Union(thangs).ToList());
            PrintThings(things.Intersect(thangs).ToList());

            //Except
            //A truly roundabout way to get the odd items.
            List<CInt> Thongs = 
                things.Except(things.FindAll(i => (i.Value % 2) == 0)).ToList();
            PrintThings(Thongs);
            Console.ReadKey();
        }

        static public void PrintThings(List<CInt> l)
        {
            foreach (CInt i in l) { Console.Write($"{i.Value} "); }
                Console.WriteLine();
        }

        static public bool BiggerThan3(string s) => s.Length > 3;
    }
}
