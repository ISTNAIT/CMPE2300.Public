using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Square Charles = new Square();
            Square Roger = new Square();

            Random r = new Random();

            if (Charles.Equals(Roger)) Console.WriteLine("Equal!");
            else Console.WriteLine("Not Equal!");

            if (Charles.Equals(r)) Console.WriteLine("What the...");
            if (Charles.Equals(null)) Console.WriteLine("The universe makes no sense!");

            List<Square> squares = new List<Square>();
            for (int i = 0; i < 25; ++i)
                squares.Add(new Square(r.Next(100), r.Next(100)));

            Console.WriteLine("Unsorted\n" +
                              "--------");
            foreach (Square s in squares)
                Console.Write(s + ", ");
            Console.WriteLine();
            Console.WriteLine();

            //Use default compare to sort
            squares.Sort();

            Console.WriteLine("Sort by Area\n" +
                              "------------");
            foreach (Square s in squares)
                Console.Write(s + ", ");
            Console.WriteLine();
            Console.WriteLine();

            //Use custom compare (packaged with class) to sort
            //This is cool, and gives us lots of options, but wait
            //until you see IComparer<T>, and lambdas.

            squares.Sort(Square.MyStaticCompare);
            Console.WriteLine("Sort by Width\n" +
                              "-------------");
            foreach (Square s in squares)
                Console.Write(s + ", ");
            Console.WriteLine();

            //Use custom ICompararer<T> object...
            SquareComparer sc = new SquareComparer(
                SquareComparisonType.Height);

            squares.Sort(sc);
            Console.WriteLine("Sort by Height\n" +
                              "--------------");
            foreach (Square s in squares)
                Console.Write(s + ", ");
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
