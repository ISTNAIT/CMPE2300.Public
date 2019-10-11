using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5
{

    class Program
    {
        //Predicate Function for testing if an int is even.
        public static bool evenp(int val) { return val % 2 == 0; }
        public static bool threevianp(int val) { return val % 3 == 0; }
        static void Main(string[] args)
        {
            //Hey, let's have some fun.  We'll be looking at this later in the
            //course, but for now feast your eyes on this groovy way to get a 
            //random list of 100 ints.
            Random r = new Random();
            List<int> l = Enumerable.Range(0, 100)
                .Select(x => r.Next(100))
                .ToList();
            //The above creates a list of 100 ints 0->10 (Range)
            //although here I'm just using that to create a set
            //of the correct length (so that I have 100 slots to fill)
            //We then use Select (and a lambda for extra nerd cred) on 
            //that set to replace each element of that list with whatever
            //the Random gives us (select is kind of weird, and should
            //probably be named "modify" or something like that. But what
            //can you expect from a company that calls a vector "List"?)

            //Anyway, neat, huh?

            //Ok. Let's use our delegate to get rid of all the even numbers:
            Predicate<int> IsThisThingEven = new Predicate<int>(evenp);
            l.RemoveAll(IsThisThingEven); //Note no parenthesis () for delgate

            //Of course, we could always just pass a reference to the predicate
            //without creating a named delegate. Let's kill all those divisible by 3:
            l.RemoveAll(threevianp);

            //Now, let's try it with a simple inline anonymous but explicit
            //method to kill those divisible by 5:
            l.RemoveAll(delegate (int ival) { return ival % 5 == 0; });
            //Note no need for a name. This method will cease to exist after the
            //call, and the compiler only needs a reference to it once.

            //That looks pretty good. But another thing that anonymous methods give
            //us is the ability to capture local state (in this case, a variable 
            //named factor) and create a closure on the fly.
            int factor = 7;
            l.RemoveAll(delegate (int ival) { return ival % factor == 0; });

            //It may not be immediately obvious how interesting and useful
            //closures are. This may help:
            factor = r.Next(8, 100); //I don't know what the factor will be
            //But I can create a method that doesn't care, and grabs the value
            //from the running program when it is first instantiated:
            l.RemoveAll(delegate (int ival)
            {
                System.Diagnostics.Trace
                  .WriteLine($"Die, you foul descendants of {factor}!");
                //Note that the variable "factor" is not declared
                //In this little method.  It is grabbed from the 
                //program the moment this delegate is created.
                //That is a very powerful feature.
                return ival % factor == 0;
            }); //It doesn't have to be all on one line, natch.

            //Finally, we can also just use lambdas.  Lambdas are also anonymous 
            //methods, but they aren't explictly declared as a method like the
            //delegates in the two methods above.  They use a much cleaner
            //syntax, and things like data types are inferred from the context.
            //We're sick of the multiple depravities of numbers descending from 11:
            l.RemoveAll(x => x % 11 == 0);
            //This is operating on a List<int> and RemoveAll is looking for a predicate, 
            //the compiler can infer that the type of x must be int. The value returned
            //from x % 11 == 0 if x is an int is boolean, so that must be my return type
            //which is acceptable as a predicate, so no errors will be generated.

            //Finally, we can create closures with lambdas as well (in fact, closures
            //plus lambdas will end up being a valuable tool for you. Note that a lambda can
            //have multiple lines (although it's common to use a more explicit syntax
            //if you need more complex methods). However, if we want more than one expression
            //we have to scope the lambda with a type and parenthesis (eg (int x) => ...)

            int lambdafactor = r.Next(12, 100);
            l.RemoveAll((int x) =>
            {
                System.Diagnostics.Trace
                    .WriteLine($"Die, you foul descendants of {lambdafactor}!");
                return x % lambdafactor == 0;

            });
        }

    }
}

