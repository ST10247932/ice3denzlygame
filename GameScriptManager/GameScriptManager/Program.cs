using System;
using System.Windows.Forms;

namespace GameScriptManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Remove ApplicationConfiguration.Initialize(); for .NET Framework projects
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
