using myapp1;
using System;
using System.Windows.Forms;

namespace YourNamespace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Replace Form1 with your actual form class
        }
    }
}

