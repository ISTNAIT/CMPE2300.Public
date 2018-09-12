using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ThreadyBalls
{
    public partial class frmMain : Form
    {
        public CDrawer Canvas = null;
        public Random Rand = null;
        public List<Thread> Threads = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Rand = new Random();
            Threads = new List<Thread>();
            tmrTimer.Interval = 500;
            tmrTimer.Start();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            clearThreads();
            lblThreads.Text = Threads.Count + " threads.";
        }

        private void clearThreads()
        {
            if (Threads == null || Threads.Count == 0) return;

            for (int i = 0; i < Threads.Count; )
            {
                if (Threads[i].ThreadState == ThreadState.Stopped)
                {
                    Threads.RemoveAt(i);
                    continue;
                }
                ++i;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Canvas == null) Canvas = new CDrawer();
            //NB: Start worker threads as background! Foreground threads don't
            //auto-dispose if your user kills the ui.
            Thread t = new Thread(new ParameterizedThreadStart(BallThread));
            t.IsBackground = true;
            t.Start(tbSize.Value);
            //I'm using a list of threads to demo some thread management stuff.
            //This is frequently unnecessary, especially with only on background worker.
            Threads.Add(t);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Canvas == null) return;
            Canvas.Clear();
        }

        private void BallThread(object ThreadData)
        {
            Random R = new Random();
            for(int i = 0; i < 500; ++i)
            {
                int x = R.Next(Canvas.DrawerWindowSize.Width);
                int y = R.Next(Canvas.DrawerWindowSize.Height);

                Canvas.AddEllipse(x, y, (int)ThreadData, (int)ThreadData, RandColor.GetColor());
                Thread.Sleep(50);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
