using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA_8___Intersect
{
    public class Quadrilateral
    {
        #region fields
        private Rectangle rectangle;
        #endregion

        #region Constructors
        public Quadrilateral(Rectangle r) => Value = r;
        public Quadrilateral() => Value = new Rectangle();
        #endregion

        #region Properties
        public Rectangle Value { get => rectangle; set => rectangle = value; }
        #endregion

        #region Methods
        public void Render(CDrawer canvas, Color color)
            => canvas.AddCenteredRectangle(Value.Location, Value.Width, Value.Height, color);
        #endregion

        #region Overrides
        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => (obj is Quadrilateral that) ?
            this.Value.IntersectsWith(that.Value) : false;
        public override int GetHashCode() => 1;
        #endregion

        #region Interfaces
        #endregion

        #region Extensions
        #endregion

        #region Delegate Functions
        #endregion
    }
}
