using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Helpers;
using WTManager.Tray;

namespace WTManager.Lib
{
    public class ServiceTaskProcessor
    {
        private readonly ServiceTask _task;
        private readonly ITrayController _trayController;

        private bool _isExpired;

        public ServiceTaskProcessor(ServiceTask task, ITrayController trayController)
        {
            this._task = task;
            this._trayController = trayController;
            this._isExpired = task.ExecuteTime < DateTime.Now;
        }

        public bool IsNeedToExecute 
            => !this._isExpired && this._task.ExecuteTime < DateTime.Now;

        private void ExecuteTask()
        {
            var controller = ServiceHelpers.GetServiceController(this._task.ServiceName);
            if (controller == null)
                return;

            switch (this._task.OperationType)
            {
                case ServiceGroupOperationType.Start:
                    controller.StartService();
                    break;

                case ServiceGroupOperationType.Stop:
                    controller.StopService();
                    break;

                case ServiceGroupOperationType.Restart:
                    controller.RestartService();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this._trayController.ShowBaloon("Executed", $"Task was executed", ToolTipIcon.Info);
        }

        public void ExecuteTaskAsync()
        {
            this._isExpired = true;

            Task.Factory.StartNew(this.ExecuteTask);
        }
    }

    public class ServiceTasksManager
    {
        private readonly ITrayController _trayController;
        private readonly Dictionary<ServiceTask, ServiceTaskProcessor> _processorCache;

        public ServiceTasksManager(ITrayController trayController)
        {
            this._trayController = trayController;
            this._processorCache = new Dictionary<ServiceTask, ServiceTaskProcessor>();
        }

        public void Process()
        {
            foreach (var serviceTask in ConfigManager.Instance.Config.Tasks)
            {
                if (!this._processorCache.TryGetValue(serviceTask, out var processor))
                {
                    this._processorCache[serviceTask] = new ServiceTaskProcessor(serviceTask, this._trayController);
                    processor = this._processorCache[serviceTask];
                }

                if (processor == null)
                    return;

                if (processor.IsNeedToExecute)
                    processor.ExecuteTaskAsync();
            }   
        }
    }
}
