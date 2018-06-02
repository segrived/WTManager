using System;
using System.Threading;
using System.Windows.Forms;
using WtManager.Forms;
using WtManager.Helpers;

namespace WtManager
{
    internal static class Program
    {
        private static readonly Mutex AppMutex = new Mutex(true, "27652D93-308D-475B-BC5D-417B06026CF3");

        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "/installtask":
                        SchedulerHelpers.AutoStartTaskState = true;
                        break;
                    case "/removetask":
                        SchedulerHelpers.AutoStartTaskState = false;
                        break;
                }
                Environment.Exit(0);
            }

            if (!AppMutex.WaitOne(TimeSpan.Zero, true))
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            AppMutex.ReleaseMutex();
        }
    }
}