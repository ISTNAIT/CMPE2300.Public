// ///////////////////////////////////////////////////////////////////////////
// BounceBall - Documentation Standards Instructions and Demonstration
// Dec 03 2012
// By Simon Walker for Programming Courses (All lab coding activites)
//
// ball type - class definition - support class
// NOTE: The point of a file header is to let the reader know what is in the
//  file, the date, who wrote it, and any version history (out of scope here)
// ///////////////////////////////////////////////////////////////////////////

// notes on comments and code documentation
// the things to remember when documenting code are simple:
// [1] you are adding value when it comes to maintenance and readability
//     if you have nothing useful to say, don't write a comment

// [2] department of redundancy department - comments must not explain syntax but intent and context
//     i++; // increase i by one   <- NO!
//     i++; // move to the next student record

// [3] comments must be accurate (in fact, as accurate as the code)
//     stale or inaccurate comments can be lethal

// [4] write comments as though they are for someone else to understand you code
//     make no assumptions about what they do or don't know about this project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GDIDrawer;

namespace BounceBall
{
    // ///////////////////////////////////////////////////////////////////////
    // ball class - self moving and rendering 'ball', implements equals
    //  for 'overlap' equality behavior.
    // ///////////////////////////////////////////////////////////////////////
    class ball
    {
        // NOTE: the order of items found in a class should be:
        // delegate type definitions
        // delegates
        // events
        // constant/readonly fields
        // static fields    
        // static properties
        // static methods
        // non-static fields/properties        
        // non-static construction/management
        // non-static events
        // non-static helper methods

        // ball radius, a single change here will alter all related behaviours
        public const int ciRadius = 25;

        // one and only drawer, common to all ball objects
        public static CDrawer s_drawer = new CDrawer(bContinuousUpdate: false);

        // random obejct, available to all to prevent the need to create more
        public static Random s_rnd = new Random();

        // current centre point position of the ball
        private PointF m_pos;

        // current X/Y direction and speed of the ball
        private PointF m_dir;

        // current ball colour - used in rendering only
        private Color m_cColor = Color.Red;
        public Color pColor
        {
            set
            {
                m_cColor = value;
            }
        }

        // NOTE: You may use #region directives to allow rapid expansion/collapse of code regions
        #region Construction and Management

        // construction may only occur with start coordinates provided
        // ball will take on random direction/speed (-2.5 - 2.5 each axis)
        public ball(PointF startPos)
        {
            m_pos = startPos;
            m_dir = new PointF((float)(s_rnd.NextDouble() * 5 - 2.5), (float)(s_rnd.NextDouble() * 5 - 2.5));
        }

        // ///////////////////////////////////////////////////////////////////
        // equality is based entirely on ball area overlap
        // color and direction attributes are not considered
        // ///////////////////////////////////////////////////////////////////
        public override bool Equals(object obj)
        {
            // if null or not a ball, then not equal
            if (!(obj is ball))
                return false;

            // create a new object reference to target to save casting in more than one place
            ball other = (ball)obj;

            // check distance between ball center points, if less than two radii, these balls overlap
            return
                Math.Sqrt
                (
                    Math.Pow(m_pos.X - other.m_pos.X, 2) +
                    Math.Pow(m_pos.Y - other.m_pos.Y, 2)
                )
                < ball.ciRadius * 2;

            // NOTE: complex math expressions may be formatted to provide insight into function,
            //  but clarity can be better expressed by breaking down the expression into multiple steps
            //  remember that the bonus comes from clarity and maintainability, not obfuscation
            // not to mention, the IDE will not clearly support such formatting, so it can be
            //  inconsistent to write, and therefore trouble to read.
            // the above could be written as such, with little or no performance penalty:

            //double dDist = Math.Pow(m_pos.X - other.m_pos.X, 2) + Math.Pow(m_pos.Y - other.m_pos.Y, 2);
            //dDist = Math.Sqrt(dDist);
            //return dDist < ball.ciRadius * 2;
        }

        // ///////////////////////////////////////////////////////////////////
        // Provided only to suppress warnings, no hashing value at all
        // ///////////////////////////////////////////////////////////////////
        public override int GetHashCode()
        {
            return 1;
        }
        #endregion

        #region Support Methods

        public void Render()
        {
            // render a ball at the current position
            s_drawer.AddCenteredEllipse((int)m_pos.X, (int)m_pos.Y, 2 * ciRadius, 2 * ciRadius, m_cColor);
        }

        // ///////////////////////////////////////////////////////////////////
        // ball is moved by adding on each axis direction value
        // if the ball is found the leave the bounds of the drawer window
        //  it is moved to the border and the direction on that axis
        //  is reversed to add a 'bounce' effect.
        // ///////////////////////////////////////////////////////////////////
        public void Move()
        {
            // move the ball to it's new position
            m_pos.X += m_dir.X;
            m_pos.Y += m_dir.Y;

            // //////////////////////////////
            // correct for boundary violation
            if (m_pos.X >= s_drawer.m_ciWidth - ball.ciRadius)
            {
                m_pos.X = s_drawer.m_ciWidth - ball.ciRadius;
                m_dir.X *= -1;
            }
            if (m_pos.X < ball.ciRadius)
            {
                m_pos.X = ball.ciRadius;
                m_dir.X *= -1;
            }
            if (m_pos.Y >= s_drawer.m_ciHeight - ball.ciRadius)
            {
                m_pos.Y = s_drawer.m_ciHeight - ball.ciRadius;
                m_dir.Y *= -1;
            }
            if (m_pos.Y < ball.ciRadius)
            {
                m_pos.Y = ball.ciRadius;
                m_dir.Y *= -1;
            }
            // //////////////////////////////
        }
        #endregion
    }
}
