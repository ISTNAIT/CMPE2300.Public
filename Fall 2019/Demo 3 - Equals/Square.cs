using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_3
{
    class Square : IComparable
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Square(int width, int height)
        {
            Width = width > 0 ? width : 0;
            Height = height > 0 ? height : 0;
        }

        public Square() : this(0, 0) { }

        public int Area { get { return Width * Height; } }

        public override string ToString()
        {
            return "Square (" + Height + " x " + Width + ")";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Square)) return false;

            Square that = (Square)obj;
            return this.Height == that.Height &&
                this.Width == that.Width;
        }

        public int CompareTo(object obj)
        { //Three results: 0 - Equal (this - obj)
          //                 - negative 'this'< obj
          //                  - positive 'this' >obj

            //Deal with the 'what is this?' problem
            if (!(obj is Square that)) // is Square 'that' autocasts obj to Square
                throw new ArgumentException(
                    "Argument is not a valid Square object.");
            //If I'm here, then 'that' contains the square I am comparing to.
            //return (Width * Height - that.Width * that.Height);
            //Fancier...
            return (Width * Height).CompareTo(that.Width * that.Height);
        }

        //What if I want to compare in a different way?
        //I can use a Comparison<> method, that takes
        //two of my type and returns same integral value
        //as expected of IComparable implementations

        //Needs two inputs, so almost always implemented as static.
        //Recall that "internal" is public for this assembly,
        //sometimes we don't want stuff to solve a local problem
        //to propagate everywhere we use the class. I can add as
        //many of these as I like, but it can start making my class
        //interface overly complex.  There are better options...
        internal static int MyStaticCompare(Square thing1, Square thing2)
        {
            //Because this is only for comparing Squares, I don't need
            //to worry about getting passed an object.  I should, however
            //worry about NULL.

            if (thing1 == null && thing2 == null) return 0;  //Equal
            if (thing1 == null) return -1; //Null < not null
            if (thing2 == null) return 1; //Not null > null

            //Just going to compare by width 
            return thing1.Width.CompareTo(thing2.Width);
        }

        public override int GetHashCode()
        {
            //Using anonymous tuple
            return (Height, Width).GetHashCode();
            //The above is equivalent to 
            //return Tuple.Create(Height, Width).GetHashCode();
        }
    }
}
