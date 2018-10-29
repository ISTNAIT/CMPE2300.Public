using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Bob = new List<int> { 1, 2, 3, 4, 5 };
            int sum = Bob.Aggregate(Addup);
            //O, more concisely
            sum = Bob.Aggregate((acc, next) => acc + next);
            Bob.ForEach(Print);
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        //Action delegate Action<T>
        public static void Print (int i) => Console.WriteLine(i);

        //The below maps to Func<Result T, Item T, Return T>
        public static int Addup(int total, int value)
        {
            return total + value;
        }

        
    }
}
