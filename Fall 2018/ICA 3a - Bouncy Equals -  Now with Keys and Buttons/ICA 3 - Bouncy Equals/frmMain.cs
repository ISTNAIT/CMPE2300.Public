using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GDIDrawer;


namespace ICA_3___Bouncy_Equals
{
    public partial class frmMain : Form
    {
        private static CDrawer canvas = null;
        private Thread Animator = null;
        private List<Ball> Balls = null;
        private List<Ball> newBalls = null;
        private const int canvWidth = 800;
        private const int canvHeight = 600;
        private const int delay = 50; //ms of sleep in animate cycle

        static frmMain()
        {
            canvas = new CDrawer(canvWidth, canvHeight);
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //The set of balls that I will animate (empty at first)
            //My GUI thread will only add balls and never remove
            //or modify them, so thread safety should be good.
            //Otherwise, should probably add some locking and or
            //set up more sophisticated inter-thread communication.
            Balls = new List<Ball>(10);

            //Start animation thread
            Animator = new Thread(new ParameterizedThreadStart(Animate));
            Animator.IsBackground = true;
            Animator.Start(Balls);

            //set up my event handlers
            if (!(canvas is null))
            {
                canvas.MouseLeftClick += new GDIDrawerMouseEvent(HandleMouse);
                canvas.KeyboardEvent += new GDIDrawerKeyEvent(HandleKey);
            }
        }

        //NB: if button pushed again, we'll just add 10 more balls.
        private void btnGo_Click(object sender, EventArgs e)
        {
            //If timer is running, it could goof with my list.
            tmrAddBalls.Enabled = false;

            //Make sure I got a canvas
            if(canvas is null || canvas.DrawerWindowSize.IsEmpty) canvas = new CDrawer(canvWidth, canvHeight);

            //Set my balls to bounce on that size canvas
            Ball.SetCanvasProperties(canvas);

            //Create my list of 10 balls, obeying the rules for 
            //resolving conflicts
            newBalls = new List<Ball>(10);
            while(newBalls.Count < 10)
            {
                Ball ball = new Ball(true);
                if (!newBalls.Contains(ball)) newBalls.Add(ball);
            }
            //Sort them
            newBalls.Sort();

            //Start adding them to the animation by letting my timer go.
            tmrAddBalls.Enabled = true;
        }

        private void Animate(object ListOBalls)
        {
            //Quick and dirty erase everything (could get fancy and overwrite
            //existing balls with black just before move and redraw, but that's
            //probably premature optimization).
            if(!(ListOBalls is List<Ball> Balls)) return; //What is this thing?

            while (true)//Forevs, unless parent thread goes away.
            {
                canvas.Clear();
                //My kingdom for a foreach with mutable list elements
                lock (Balls)
                {//Added because my event handlers could crossthread
                    for (int i = 0; i < Balls.Count; ++i)
                    {
                        Ball b = Balls[i];
                        //Move first.  That makes sure everything is on the canvas.
                        b.Move();//This changes b! no other threads should be changing b, or I need to do more.
                        canvas.AddCenteredEllipse((int)b.Location.X, (int)b.Location.Y, b.Size, b.Size, b.Color);
                    }
                }
                //Show the pretty thingees
                canvas.Render();
                Thread.Sleep(delay);
            }
        }

        private void tmrAddBalls_Tick(object sender, EventArgs e)
        {
            if (newBalls.Count > 0)
            {
                //What clown didn't have RemoveAt return the item removed?
                Ball ball = newBalls[0];
                newBalls.RemoveAt(0);
                Balls.Add(ball);
            }
            else //list empty.  no real point in ticking.
                tmrAddBalls.Enabled = false;
        }

        //Event Handler for Mouse things
        private void HandleMouse(System.Drawing.Point pos, GDIDrawer.CDrawer drawer)
        {
            //add a ball when and where you click
            lock(Balls) //The other thread might be using it
            {
                Ball b = new Ball(true);
                b.Location = new PointF(pos.X, pos.Y);
                Balls.Add(b);
            }
        }

        //Event Handler for Keyboard things 
        private void HandleKey(bool bIsDown, Keys keycode, GDIDrawer.CDrawer drawer)
        {
            // Don't do anything until they release the key (the event fires multiples).
            if (bIsDown) return;
            switch (keycode)
            {
                case Keys.D:
                    //Delete a ball
                    lock (Balls)
                        if (Balls.Count > 0) Balls.RemoveAt(0);
                    break;
                case Keys.A:
                    //Add a ball
                    lock (Balls)
                        Balls.Add(new Ball(true));
                    break;
            }
        }

    }
}
