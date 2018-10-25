using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using Extensions;

namespace ICA_8___Intersect
{
    public class Ball
    {
        #region fields
        private Point point;
        #endregion

        #region Constructors
        static Ball(){ Size = 10; Tolerance = 0;}
        public Ball(Point p) => Value = p;
        public Ball() => Value = new Point();
        #endregion

        #region Properties
        public Point Value { get => point; set => point = value; }
        public static int Size { get; set; }
        public static int Tolerance { get; set; }
        #endregion

        #region Methods
        public void Render(CDrawer canvas, Color color)
            => canvas.AddCenteredEllipse(Value,Size,Size,color);
        #endregion

        #region Overrides
        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => (obj is Ball that) ?
            this.Value.Distance(that.Value) <= Tolerance : false;
        public override int GetHashCode() => 1;
        #endregion

        #region Interfaces
        #endregion

        #region Delegate Functions
        #endregion
    }
}
