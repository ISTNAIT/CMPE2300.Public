using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_8___Hash_Dict
{

    //Simple object for demonstrating containers
    class Thing
    {
        //Some counters to see how often methods get called
        public static int HashCount { get; private set; }
        public static int EqualsCount { get; private set; }
        public string Name { get; set; }
        public int Value { get; set; }

        static Thing() => HashCount = EqualsCount = 0;
        public Thing() : this("", 0) { }
        public Thing(string name, int value) { Name = name; Value = value; }

        public override string ToString() =>  $"{Value:D6} - {Name}";
        public override bool Equals(object obj)
        {
            ++EqualsCount;
            if (!(obj is Thing that)) return false;
            return this.Name.Equals(that.Name) && this.Value.Equals(that.Value);
        }

        public override int GetHashCode()
        {
            HashCount++;
            //Compare this to just returning one.  I dare you.
            //Another way: return new Tuple<int, string>(Value, Name).GetHashCode();
            return Value.GetHashCode() + Name.GetHashCode();
        }

        public static void Reset() => HashCount = EqualsCount = 0;
    }
}
