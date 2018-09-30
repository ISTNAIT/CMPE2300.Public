using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA_3___Bouncy_Equals
{
    class Ball : IComparable
    {
        #region Static Properties
        public static int CanvasWidth { set; get; }
        public static int CanvasHeight { set; get; }
        public static int MaxSize { set; get; }
        public static int MaxSpeed { set; get; }
        private static Random Random { get; }
        #endregion

        #region Properties
        public PointF Location { set; get; }
        public PointF Velocity { set; get; }
        public Color Color { set; get; }
        public int Size { set; get; }
        #endregion

        #region Constructors
        static Ball()
        {
            //Bases on scaled width, height, etc.
            CanvasWidth = 800;
            CanvasHeight = 600;
            MaxSize = 50;
            MaxSpeed = 5;
            Random = new Random();
        }

        public Ball() //Default ctor Randomificates
        {
            Location = new PointF(Random.Next(CanvasWidth),
                Random.Next(CanvasHeight));
            Velocity = new PointF((float)Random.NextDouble() * 2 * MaxSpeed - MaxSpeed, 
                (float)Random.NextDouble() * 2 * MaxSpeed - MaxSpeed);
            Color = RandColor.GetColor();
            Size = Random.Next(MaxSize);
        }

        public Ball(bool b):this() //Dummy overload for the ICA
        {
            //Could do this with enums and case statements,
            //but anonymous initializer lists are fun!
            Color = new List<Color> { Color.Red, Color.Blue,
                Color.Green, Color.Yellow, Color.Purple}[Random.Next(5)];
            Size = MaxSize / 5 * (Random.Next(5) + 1);
        }
        #endregion

        #region Methods
        public static void SetCanvasProperties(CDrawer canvas)
        {
            //Reset static canvas size based on the sample I just got
            CanvasWidth = canvas.ScaledWidth;
            CanvasHeight = canvas.ScaledHeight;
            MaxSize = CanvasWidth / 5;
        }

        //Reset position+=velocity, corrected with bounce
        //Returns new position
        //TODO:  Eww.  PointFs aren't editable.  Redo with 
        //       a tuple or something.
        //NB! Assumes 'Location' is CENTER of ball.
        //Remember to paint with CenteredEllipse
        public PointF Move() 
        {
            Location = new PointF(Location.X + Velocity.X,
                Location.Y + Velocity.Y);

            //Check if now out of bounds, correct
            if(Location.X - Size/2 < 0) //Left edge
            {
                Location = new PointF(Size / 2, Location.Y);
                Velocity = new PointF(-Velocity.X, Velocity.Y); //Boing!
            }
            if (Location.X + Size / 2 > CanvasWidth) //Right edge
            {
                Location = new PointF(CanvasWidth - Size / 2, Location.Y);
                Velocity = new PointF(-Velocity.X, Velocity.Y); //Boing!
            }

            //Check if now out of bounds, correct
            if (Location.Y - Size / 2 < 0) //Top edge
            {
                Location = new PointF(Location.X, Size/2);
                Velocity = new PointF(Velocity.X, -Velocity.Y); //Boing!
            }
            if (Location.Y + Size / 2 > CanvasHeight) //Bottom edge
            {
                Location = new PointF(Location.X, CanvasHeight - Size / 2);
                Velocity = new PointF(Velocity.X, -Velocity.Y); //Boing!
            }

            return Location;
        }
        #endregion

        #region Overrides
        //Override base class methods
        public override bool Equals(object obj)
        {
            if (!(obj is Ball that))
                return false;
            return that.Size == this.Size &&
                that.Color == this.Color;
        }

        public override int GetHashCode()
        {
            //for now, we're just going to make sure it isn't broken
            return 1;
        }

        public override string ToString()
        {
            return $"Ball (Size: {Size}, Color: {Color.Name})";
        }
        #endregion

        #region IComparable
        //Required for IComparable
        public int CompareTo(object obj)
        {
            if (!(obj is Ball that))
                throw new ArgumentException("Invalid object passed to Ball.CompareTo()");
            if (this.Size == that.Size) //Same size
                //Fun fact: you can convert a System.Drawing.Color to an int
                //with .ToArgb  I'll just use that for my ordering.
                return this.Color.ToArgb() - that.Color.ToArgb();
            else return this.Size - that.Size;
        }
        #endregion
    }
}
