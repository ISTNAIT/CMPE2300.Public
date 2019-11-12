using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_10
{
    internal class Vehicle //Internal is default
    {
        private double velocity = 0;
        public double MaxVelocity { get; set; }
        public double Velocity
        {
            get => velocity;
            set => velocity = (value > MaxVelocity) ? velocity : value;
        }

        public Vehicle() 
        {
            Trace.WriteLine("Vehicle Constructing...");
            Velocity = 0;
            MaxVelocity = 0;
        }
        
        public Vehicle(double maxVel)
        {
            MaxVelocity = maxVel;
            Velocity = 0;
            Trace.WriteLine($"Vehicle constructing with maxvel {MaxVelocity}");
        }

        public double Accelerate(double increment)
        {
            Velocity += increment;
            return Velocity;
        }

        public override string ToString() //Override base class
        {
            //Base returns "thing I inherited from", so 
            //I can access the original method in here.
            return $"Vehicle (was {base.ToString()})";
        }

        public string MyName() //Non-virtual string method to show difference
        {
            return "Vehicle";
        }
    }
    internal class Car:Vehicle,IComparable //Inherits from vehicle (Inherit from one class, multiple interfaces)
    {
        public String VIN { get; set; }

        public Car() : base(210) //Decide which base ctor to run
        {

            Trace.WriteLine("Car Constructing...");
        }

        //"New" Means hide (replace) the other one.
        public new double Accelerate(double increment)
        {
            //Cars can only accelate max 10 per thing
            increment = increment > 10 ? 10 : increment;
            Velocity = (Velocity + increment > MaxVelocity)?MaxVelocity: Velocity + increment;
            return Velocity;
        }

        public override string ToString()
        {
            return $"Car with maxvel {this.MaxVelocity}(was {base.ToString()})";
        }

        public new string MyName() //Non-virtual string method to show difference
        {
            return "Car";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
