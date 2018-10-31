using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_7___Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            LinkedList<int> l = new LinkedList<int>();
            for (int i = 0; i < 10; ++i)
                if (r.Next(2) == 0)
                    l.AddLast(i);
                else
                    l.AddFirst(i);

            //Print list from manager class
            foreach(int i in l)
            { Console.Write($"{i} "); }
            Console.WriteLine();

            LinkedListNode<int> second = null;

            //Add as third node (manual traversal)
            if (l.Count >= 2)
            {
                second = l.First.Next;
                l.AddAfter(second, 99);
            }


            List<int> li = l.ToList();
           

            LinkedListNode<int> n = l.First;
            if (!(n is null))
                do
                {
                    Console.Write($"{n.Value} ");
                    n = n.Next;
                }
                while (n != null);
            Console.WriteLine();


            Stack<LinkedList<int>> slli = new Stack<LinkedList<int>>();
            for (int i = 0; i < 10; ++i)
            {
                LinkedList<int> lli = new LinkedList<int>();
                for (int j = 0; j < i; ++j)
                    lli.AddFirst(r.Next(10));
                slli.Push(lli);
            }

            while(slli.Count > 0)
            {
                LinkedList<int> lli = slli.Pop();
                foreach (int x in lli)
                {
                    Console.Write($"{x} ");
                }
            }

            Console.ReadKey();


        }
    }
}
