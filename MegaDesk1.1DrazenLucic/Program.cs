using System;
using System.Windows.Forms;

namespace MegaDesk
{
    public static class Program
    {
        public static readonly DeskQuotes Quotes = new DeskQuotes();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
