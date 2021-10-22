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
            if (args == null || args.Length == 0) args = new string[] { "", "Luski", "Luski.exe" };
            if (args.Length > 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main_Form(args[0], args[1], args[2], args.Skip(3).ToArray()));
            }
            else
            {
                MessageBox.Show("Not nough arguments were given");
            }
        }
    }
}
