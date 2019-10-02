using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2___Properties
{
    class Prop
    {
        //Backing Store (member variables, private variable)
        //Variables that are not exposed, used for keeping 
        //track of state.
        private int x;

        //Properties.  Special 'methods' that provide and interface
        //to a value.  Syntax: 'get' is called if I try to read the
        //value and 'set' is called if I try to modifier.

        public int Ecks
        {
            get { return x; }
            set { x = value > 0 ? value : -value; }
        }

        //Auto property, anonymous backing variable, default
        public int W { get; set; }

        //Private setter is often useful for readonly
        public int readsolely { get; private set; }

        //Constructor can access private setters
        public Prop(int x, int readsolely)
        {
            //dammit! my variable names are blocking
            //my member names!
            this.x = x;
            //Use a setter.
            Ecks = x;
            //use private setters
            this.readsolely = readsolely;
        }

        //Virtual Property is one that value is calculated

        public int Product { get { return Ecks * readsolely; } }

        public Prop() : this(0, 12) { }
    }
}
