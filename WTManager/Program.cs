using System;
using System.Threading;
using System.Windows.Forms;
using WTManager.Helpers;
using WTManager.UI;

namespace WTManager
{
    internal static class Program
    {
        private static readonly Mutex AppMutex = new Mutex(true, "27652D93-308D-475B-BC5D-417B06026CF3");

        private const string TASK_NAME = "WTManager";

        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "/installtask")
                    SchedulerHelpers.InstallTask(TASK_NAME);
                else if (args[0] == "/removetask")
                    SchedulerHelpers.RemoveTask(TASK_NAME);
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