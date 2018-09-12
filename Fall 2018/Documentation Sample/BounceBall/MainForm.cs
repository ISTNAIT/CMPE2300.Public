// ///////////////////////////////////////////////////////////////////////////
// BounceBall - Documentation Standards Instructions and Demonstration
// Dec 03 2012
// By Simon Walker for Programming Classes (All lab coding activites)
//
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////

// See ball class for more details on style

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BounceBall
{
    public partial class MainForm : Form
    {
        // active balls in play (NOTE: All fields are commented)
        private List<ball> m_llBalls = new List<ball>();

        #region Construction and Management

        public MainForm()
        {
            InitializeComponent();

            // start with a single ball, centered in the drawer
            //  this should cue the user that clicking or somehting might add more...
            m_llBalls.Add(new ball(new PointF (400,300)));            
        }

        #endregion

        #region Event Handlers
        // ///////////////////////////////////////////////////////////////////
        // Main animation timer 
        // Balls are added, moved, and rendered in this event        
        // ///////////////////////////////////////////////////////////////////
        private void UI_Tim_Main_Tick(object sender, EventArgs e)
        {
            Point pt;
            
            // if there is a new left-click, add a new ball at the click position
            if (ball.s_drawer.GetLastMouseLeftClick(out pt))
                m_llBalls.Add(new ball(new PointF(pt.X, pt.Y)));


            // start of scene presentation 
            ball.s_drawer.Clear();

            // ////////////////////////////////////////////////////////
            // move and render each ball in the scene            
            foreach (ball b in m_llBalls)
            {
                b.Move();
                b.Render();
            }
            // ////////////////////////////////////////////////////////

            // ///////////////////////////////////////////////////////////////////////////
            // check each ball against every other ball to look for overlap (using equals)
            //  if balls are found to overlap, change color to green to mark as such
            for (int iOut = 0; iOut < m_llBalls.Count; iOut++)
            {
                for (int iIn = 0; iIn < m_llBalls.Count; iIn++)
                {
                    // ensure ball is not itself, and check for overlap
                    if (iOut != iIn && m_llBalls[iOut].Equals(m_llBalls[iIn]))
                    {
                        // ball are different and overlapping, change to green
                        m_llBalls[iOut].pColor = Color.Green;
                        m_llBalls[iIn].pColor = Color.Green;
                    }
                }                
            }
            // ///////////////////////////////////////////////////////////////////////////

            // end of scene presentation
            ball.s_drawer.Render();
        }

        #endregion
    }
}
