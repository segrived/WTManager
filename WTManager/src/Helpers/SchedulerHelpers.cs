using Microsoft.Win32.TaskScheduler;
using System;
using System.Linq;

namespace WTManager.Helpers
{
    public static class SchedulerHelpers
    {
        private const string TASK_NAME = "WTManager";

        private static void InstallAutoStartTask()
        {
            string currentFn = System.Reflection.Assembly.GetEntryAssembly().Location;
            using (var ts = new TaskService())
            {
                var task = ts.NewTask();
                task.Triggers.Add(Trigger.CreateTrigger(TaskTriggerType.Logon));
                task.Settings.StopIfGoingOnBatteries = false;
                task.Settings.DisallowStartIfOnBatteries = false;
                task.Settings.IdleSettings.StopOnIdleEnd = false;
                task.Settings.ExecutionTimeLimit = TimeSpan.FromDays(365 * 10);
                task.Principal.RunLevel = TaskRunLevel.Highest;
                task.Actions.Add(new ExecAction(currentFn, ""));
                ts.RootFolder.RegisterTaskDefinition(TASK_NAME, task);
            }
        }

        private static void RemoveAutoStartTask()
        {
            using (var ts = new TaskService())
                ts.RootFolder.DeleteTask(TASK_NAME);
        }

        public static bool IsAutostartTaskInstalled()
        {
            using (var ts = new TaskService())
                return ts.RootFolder.AllTasks.Any(task => task.Name == TASK_NAME);
        }

        public static void UpdateAutoStartSetting(bool isAutoStart)
        {
            bool isTaskAlreadyInstalled = IsAutostartTaskInstalled();

            if (isTaskAlreadyInstalled && !isAutoStart)
                RemoveAutoStartTask();
            else if (!isTaskAlreadyInstalled && isAutoStart)
                InstallAutoStartTask();

            // otherwise we do nothing
        }
    }
}
