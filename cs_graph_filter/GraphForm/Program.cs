using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GraphingForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 1)
            {
//                Application.Run(new GraphingForm(args[0]));
                Application.Run(new GraphingForm());
            }
            else
            {
                Application.Run(new GraphingForm());
            }
        }
    }
}

