using System;
using System.Collections.Generic;
using System.ServiceProcess;
using WTManager.Config;

namespace WTManager.Helpers
{
    public static class ServiceHelpers
    {
        public static IEnumerable<ServiceController> GetAllServices() 
            => ServiceController.GetServices();

        private static readonly Dictionary<Service, ServiceController> ControllerCache =
            new Dictionary<Service, ServiceController>();

        public static ServiceControllerStatus Status(this Service service) 
            => service.GetController().Status;

        public static bool IsStarted(this Service service) 
            => service.Status() == ServiceControllerStatus.Running;

        public static bool IsStopped(this Service service) 
            => service.Status() == ServiceControllerStatus.Stopped;

        public static void StartService(this Service s)
        {
            var controller = s.GetController();

            controller.Start();
            controller.WaitForStatus(ServiceControllerStatus.Running);
        }

        public static void StopService(this Service s)
        {
            var controller = s.GetController();

            controller.Stop();
            controller.WaitForStatus(ServiceControllerStatus.Stopped);
        }

        public static void RestartService(this Service s)
        {
            var controller = s.GetController();

            controller.Stop();
            controller.WaitForStatus(ServiceControllerStatus.Stopped);
            controller.Start();
            controller.WaitForStatus(ServiceControllerStatus.Running);
        }

        public static ServiceController GetController(this Service s)
        {
            try
            {
                if (!ControllerCache.ContainsKey(s))
                    ControllerCache[s] = new ServiceController(s.ServiceName);

                return ControllerCache[s];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool IsInPendingState(this Service service)
        {
            switch (service.GetController().Status)
            {
                case ServiceControllerStatus.StopPending:
                case ServiceControllerStatus.ContinuePending:
                case ServiceControllerStatus.PausePending:
                case ServiceControllerStatus.StartPending:
                    return true;
                default:
                    return false;
            }
        }
    }
}
