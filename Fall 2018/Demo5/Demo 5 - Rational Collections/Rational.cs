using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5___Rational_Collections
{
    class Rational : IComparable
    {
        private int denominator = 1;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be 0.");
            Numerator = numerator;
            this.denominator = denominator;
        }

        public Rational(int numerator) : this(numerator, 1) { }

        public int Numerator { get; set; }
        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException("Denominator cannot be 0.");
                denominator = value;
            }
        }

        private double RealValue
        {
            get { return (double)Numerator / Denominator; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rational that)) return false;
            //FIXME: should 1/2 == 2/4?
            return (this.Numerator.Equals(that.Numerator)
                && this.Denominator.Equals(that.Denominator));
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString() => $"{Numerator}/{Denominator}";

        public int CompareTo(object obj)
        {
            if (!(obj is Rational that))
                throw new ArgumentException("Comparison to non-rational.");
            return this.RealValue.CompareTo(that.RealValue);
        }

        //Predicate for minimal form
        //Fixme: Brute force and ugly
        public static bool MinimalFormP(Rational r)
        {
            //Choose larges of num, den
            int limit = r.Numerator > r.Denominator ? r.Numerator : r.Denominator;
            //Iterate over available possible common factors
            for(int i = 2; i <= limit; ++i)
            {
                if (r.Numerator % i + r.denominator % i == 0) // Both divisable
                    return false;
            }
            return true;
        }

    }

    
}
