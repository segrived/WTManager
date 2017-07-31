using Microsoft.Win32.TaskScheduler;
using System;

namespace WTManager.Helpers
{
    public static class SchedulerHelpers
    {
        public static void InstallTask(string taskName)
        {
            string currentFn = System.Reflection.Assembly.GetEntryAssembly().Location;
            using (var ts = new TaskService())
            {
                var task = ts.NewTask();
                task.Triggers.Add(Trigger.CreateTrigger(TaskTriggerType.Logon));
                task.Settings.StopIfGoingOnBatteries = false;
                task.Settings.DisallowStartIfOnBatteries = false;
                task.Principal.RunLevel = TaskRunLevel.Highest;
                task.Settings.IdleSettings.StopOnIdleEnd = false;
                task.Settings.ExecutionTimeLimit = TimeSpan.FromDays(365 * 10);
                task.Actions.Add(new ExecAction(currentFn, ""));
                ts.RootFolder.RegisterTaskDefinition(taskName, task);
            }
        }

        public static void RemoveTask(string taskName)
        {
            using (var ts = new TaskService())
                ts.RootFolder.DeleteTask(taskName);
        }
    }
}
