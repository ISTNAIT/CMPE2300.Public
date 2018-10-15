using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStringExtension //Need a namespace for the using directive
{
    //Extension methods are always static (we can add to the class, not to objects).

    public static class AJStringExtension
    {
        //I really wish I could count words in a string
        //Create an extension to the String class

        public static int WordCount(this String str) //This is the syntax for an extension to string
        {
            //Calculate how many words in the string str
            //using an anonymous character array
            return str.Split(new char[] { ' ', '.', '!', '?', ';', ':', '\t', '"','\r', '\n','-' }, 
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

namespace AJGradeEnum
{  
    public enum Grade {F=0, D, C, B, A};
    public static class EnumExtensions
    {
        private const Grade minPass = Grade.C;
        public static bool Passing(this Grade grade)
        {
            return grade >= minPass;
        }
    }
}
