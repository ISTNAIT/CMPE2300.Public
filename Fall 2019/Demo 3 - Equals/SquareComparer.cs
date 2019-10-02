using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_3
{
    enum SquareComparisonType
    {
        Area,
        Height,
        Width
    }
    class SquareComparer : IComparer<Square>
    {
        public SquareComparisonType ComparisonType { get; set; }
        
        public SquareComparer(SquareComparisonType ct)
            { ComparisonType = ct; }

        public SquareComparer() : this(SquareComparisonType.Area) { }

        public int Compare(Square x, Square y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            switch(ComparisonType)
            {
                case SquareComparisonType.Area:
                    return (x.Width * x.Height)
                        .CompareTo(y.Width * y.Height);
                case SquareComparisonType.Height:
                    return x.Height.CompareTo(y.Height);
                case SquareComparisonType.Width:
                    return x.Width.CompareTo(y.Width);
                default:
                    throw new 
                        NotImplementedException("Unknown Comparison Type.");
            }
        }
    }
}
