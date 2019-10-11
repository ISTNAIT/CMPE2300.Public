using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4
{
    class Program
    {
        public delegate int larry(int x, int y);
        static void Main(string[] args)
        {
            larry qux = foo;
            System.Diagnostics.Debugger.Log(1,"Tracing", "foo:" + qux(2, 1) + "\n");
            qux = bar;
            System.Diagnostics.Debugger.Log(1, "Tracing", "bar:" + qux(2, 1) + "\n");

            Random r = new Random();
            List<int> li = new List<int>();
            Predicate<int> Biggie = biggern5;
            for (int i = 0; i < 100; i++)
                li.Add(r.Next(0, 10));

            //li.RemoveAll(Biggie);
            //li.RemoveAll(biggern5);
            li.RemoveAll(x => x > 5);

            return;
        }

        public static bool biggern5(int i) { return i > 5; }
        
        public static int foo(int x, int y) { return x - y; }
        public static int bar(int x, int y) { return y - x; }
    }
}
