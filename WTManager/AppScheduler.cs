using Microsoft.Win32.TaskScheduler;
using System;

namespace WTManager
{
    public static class AppScheduler
    {
        private const string TaskName = @"WTManager";

        public static void InstallTask() {
            var currentFn = System.Reflection.Assembly.GetEntryAssembly().Location;
            using (var ts = new TaskService()) {
                var task = ts.NewTask();
                task.Triggers.Add(Trigger.CreateTrigger(TaskTriggerType.Logon));
                task.Settings.StopIfGoingOnBatteries = false;
                task.Settings.DisallowStartIfOnBatteries = false;
                task.Principal.RunLevel = TaskRunLevel.Highest;
                task.Settings.IdleSettings.StopOnIdleEnd = false;
                task.Settings.ExecutionTimeLimit = TimeSpan.FromDays(365 * 10);
                task.Actions.Add(new ExecAction(currentFn, "", null));
                ts.RootFolder.RegisterTaskDefinition(TaskName, task);
            }
        }

        public static void RemoveTask() {
            using (TaskService ts = new TaskService()) {
                ts.RootFolder.DeleteTask(TaskName);
            }
        }
    }
}