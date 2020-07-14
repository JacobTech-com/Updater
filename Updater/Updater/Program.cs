using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 2 && args.Length < 5)
            {
                string files = null;
                if (args.Length > 3) files = args[3];
                string[] info = new string[4] { args[0], args[1], args[2], files };
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main_Form(info[0], info[1], info[2], info[3]));
            }
            else if (args.Length > 4)
            {
                MessageBox.Show("To many arguments were given");
            }
            else
            {
                MessageBox.Show("Not nough arguments were given");
            }
        }
    }
}
