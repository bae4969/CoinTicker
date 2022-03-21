
namespace CoinTicker
{
    internal static class start
    {
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process[] processes = null;
            string strCurrentProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper();
            processes = System.Diagnostics.Process.GetProcessesByName(strCurrentProcess);
            if (processes.Length > 1)
            {
                MessageBox.Show("Already program executed.");
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new mainForm());
        }
    }
}