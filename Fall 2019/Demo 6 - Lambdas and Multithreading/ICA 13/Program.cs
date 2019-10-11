using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadyBalls
{
    static class Program
    {
        /// <summary>
        /// This is an update to the original demo "Thready Balls" to
        /// replace all the delegate type call with a nive clean lambda.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
