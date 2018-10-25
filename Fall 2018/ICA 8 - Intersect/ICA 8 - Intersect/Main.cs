using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using Extensions;

namespace ICA_8___Intersect
{
    public partial class Main : Form
    {
        private static int WindowCount;
        private static int RectangleSize;
        private static int BallSize;
        private static int Tolerance;
        private static List<Color> Colors;
        private static List<Color> BallColors;
        private static Color IntersectColor;
        private static Color UnionColor;
        private List<CDrawer> drawers;
        private List<List<Quadrilateral>> squares;
        private List<List<Ball>> balls;
        public List<CDrawer> Drawers
        {
            get => drawers;
            private set => drawers = value;
        }
        public List<List<Quadrilateral>> Squares
        {
            get => squares;
            private set => squares = value;
        }
        public List<List<Ball>> Balls
        {
            get => balls;
            private set => balls = value;
        }

        static Main()
        {
            WindowCount = 2;
            RectangleSize = 50;
            BallSize = Ball.Size = 10;
            Tolerance = Ball.Tolerance = 0;
            Colors = new List<Color>(WindowCount) {
                Color.Red,Color.Yellow};
            BallColors = new List<Color>(WindowCount){
                Color.Purple, Color.Salmon };
            IntersectColor = Color.Gold;
            UnionColor = Color.Fuchsia;
        }
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Set up drawer windows and events
            Drawers = new List<CDrawer>(WindowCount);
            for (int i = 0; i < Drawers.Capacity; ++i)
            {
                Drawers.Add(new CDrawer());
                Drawers[i].MouseLeftClick += ClickLeftDrawer;
                Drawers[i].MouseMove += MoveDrawer;
            }
            foreach (CDrawer cd in Drawers)
                cd.ContinuousUpdate = true;

            //Set up objects
            Squares = new List<List<Quadrilateral>>(WindowCount);
            for (int i = 0; i < Squares.Capacity; ++i)
                Squares.Add(new List<Quadrilateral>());
            Balls = new List<List<Ball>>(WindowCount);
            for (int i = 0; i < Balls.Capacity; ++i)
                Balls.Add(new List<Ball>());
        }

        public void Render()
        {
            for (int i = 0; i < WindowCount; ++i)
            {
                Drawers[i].Clear();
                foreach (Quadrilateral q in Squares[i])
                    q.Render(Drawers[i], Colors[i]);
                foreach (Ball b in Balls[i])
                    b.Render(Drawers[0], BallColors[i]);
            }
        }

        private void ClickLeftDrawer(Point pos, CDrawer dr)
        {
            //I'm in the drawer thread here--need to bounce over to the form
            Invoke(new GDIDrawerMouseEvent(ClickLeftForm), pos, dr);
        }

        private void ClickLeftForm(Point pos, CDrawer dr)
        {
            //Yeah, I got a little too fancy.  Probably would have been
            //better to just have a different handler for each window.
            //Which window
            int index = Drawers.IndexOf(dr);
            if (index < 0) return; //I don't know where you found that drawer window.
            if (index == 1) return; //Ignoring right window clicks for now

            //Get a rectangle ready
            Quadrilateral q = new Quadrilateral(new Rectangle(pos,
                     new Size(RectangleSize, RectangleSize)));

            //Special conditions
            switch (index)
            {
                case 0: //Left Window
                    if (Squares[0].Contains(q)) //Overlapping
                        Squares[1].Add(q);
                    else
                        Squares[0].Add(q);
                    break;
                default: //Nothing to do
                    break;
            }
        }

        private void MoveDrawer(Point pos, CDrawer dr)
        {
            //I'm in the drawer thread here--need to bounce over to the form
            Invoke(new GDIDrawerMouseEvent(MoveForm), pos, dr);
        }
        private void MoveForm(Point pos, CDrawer dr)
        {
            int index = Drawers.IndexOf(dr);
            if (index < 0) return; //I don't know where you found that drawer window.
            tmrClock.Enabled = true; //Restart rendering if it wasn't already

            //Get a ball ready
            Ball b = new Ball(pos);

            //Special conditions
            switch (index)
            {
                case 1: //Right Window
                    if (rbPurple.Checked) Balls[0].Add(b);
                    if (rbSalmon.Checked) Balls[1].Add(b);
                    break;
                default: //Nothing to do
                    break;
            }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            Render();
        }

        private void btnDuplicates_Click(object sender, EventArgs e)
        {
            Squares[1] = Squares[1].Distinct().ToList();
        }

        private void btnClips_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < WindowCount; ++i)
                Squares[i].RemoveAll(q => q.Value.Clipped(Drawers[i], RectangleSize));
        }

        private void tbTolerance_Scroll(object sender, EventArgs e)
        {
            Tolerance = Ball.Tolerance = tbTolerance.Value;
        }

        private void btnUnion_Click(object sender, EventArgs e)
        {
            //Kill the timer to look at the pretty picture
            tmrClock.Enabled = false;
            Drawers[1].Clear();
            List<Ball> Union = Balls[0].Union(Balls[1]).ToList();
            foreach (Ball b in Union) b.Render(Drawers[1], UnionColor);
        }

        private void btnIntersect_Click(object sender, EventArgs e)
        {
            //Kill the timer to look at the pretty picture
            tmrClock.Enabled = false;
            Drawers[1].Clear();
            List<Ball> Intersect = Balls[0].Intersect(Balls[1]).ToList();
            foreach (Ball b in Intersect) b.Render(Drawers[1], IntersectColor);
        }
    }
}
#region Extensions
namespace Extensions
{
    public static class Tests
    {
        //Extension method for rectangle is clipped on Canvas
        public static bool Clipped(this Rectangle rect, CDrawer canvas, int size)
        {
            return (rect.Location.X - size / 2 < 0
                || rect.Location.Y - size / 2 < 0
                || rect.Location.X + size / 2 > canvas.ScaledWidth
                || rect.Location.Y + size / 2 > canvas.ScaledHeight);
        }

        public static double Distance(this Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(first.X - second.X), 2)
                + Math.Pow(Math.Abs(first.Y - second.Y), 2));
        }
    }


  
}
#endregion


