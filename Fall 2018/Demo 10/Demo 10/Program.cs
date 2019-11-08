using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("==========================");
            Trace.WriteLine("---Creating Vehicle---");
            Vehicle v = new Vehicle();
            Trace.WriteLine("---Creating Car---");
            Car c = new Car();
            c.Accelerate(100);
            Trace.WriteLine($"Velocity = {c.Velocity}");
            c.Accelerate(100);
            Trace.WriteLine($"Velocity = {c.Velocity}");
            c.Accelerate(100);
            Trace.WriteLine($"Velocity = {c.Velocity}");
            Trace.WriteLine($"The car named '{c}' was created");
            Trace.WriteLine("==========================");
            Trace.WriteLine($"Car's MyName():{c.MyName()}");
            Trace.WriteLine($"Car's MyName() after cast to Vehicle:{((Vehicle)c).MyName()}");
            Trace.WriteLine($"Car's ToString() after cast to Vehicle:{((Vehicle)c).ToString()}");
            Trace.WriteLine($"Car's ToString() after cast to Object:{((Object)c).ToString()}");
        }
    }
}
