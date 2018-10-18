using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5___Rational_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            List<Rational> rats = new List<Rational>();
            for(int i = 0; i < 10; ++i)
                rats.Add(new Rational(r.Next(10) + 1, r.Next(10)+1));
            if(r.Next(2) != 0) rats.Add(new Rational(7, 11));
            PrintRats("Random",rats);
            rats.Sort();
            PrintRats("Sorted", rats);
            int index = rats.BinarySearch(new Rational(7, 11));
            Console.Write($"{new Rational(7, 11)} ");
            if (index >= 0)
                Console.WriteLine($"found at {index}.");
            else
                Console.WriteLine($"Not found.");
            Console.Write($"The value is");
            Console.Write(rats.Contains(new Rational(7, 11)) ? " " : " not ");
            Console.WriteLine("found.");
            rats.Remove(new Rational(7, 11));
            PrintRats("Removed", rats);
            index = rats.BinarySearch(new Rational(7, 11));
            Console.Write($"{new Rational(7, 11)} ");
            if (index >= 0)
                Console.WriteLine($"found at {index}.");
            else
                Console.WriteLine($"Not found.");
            rats.Reverse();
            PrintRats("Reversed",rats);
            rats.Sort(CompareDenominators);
            PrintRats("Sorted by Denominator", rats);
            PrintRats("Minimal Form", rats.FindAll(Rational.MinimalFormP));
            PrintRats("Integral", rats.FindAll((q) => q.Denominator == 1));
            rats.Clear();
            PrintRats("Clear", rats);
            Console.ReadLine();
        }

        static void PrintRats(string s, List<Rational> l)
        {
            Console.WriteLine(s);
            foreach (char c in s)
                Console.Write('-');
            Console.WriteLine();
            for(int i = 0; i < l.Count; ++i) //Count!
                Console.Write(l[i] + " "); //Array!
            Console.WriteLine();
        }

        public static int CompareDenominators(Rational left, Rational right)
        {
            return left.Denominator.CompareTo(right.Denominator);
        }
    }
}
