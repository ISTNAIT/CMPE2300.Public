using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_5
{
    class CInt : IComparable
    {
        public int Value { get; set; }

        public override string ToString() => Value.ToString();

        public CInt(int value) { Value = value; }
        public CInt() : this(0) { } 
        public override bool Equals(object obj)
        {
            if (!(obj is CInt that)) return false;
            return this.Value.Equals(that.Value);
        }
        public override int GetHashCode() => 1;

        public int CompareTo(object obj)
        {
            if (!(obj is CInt that))
                throw new ArgumentException("Not a CInt");
            return this.Value.CompareTo(that.Value);
        }
    }
}
