using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using WTManager.Config;

namespace WTManager.Helpers
{
    public static class ServiceHelpers
    {
        public static IEnumerable<ServiceController> GetAllServices() 
            => ServiceController.GetServices();

        private static readonly Dictionary<string, ServiceController> ControllerCache =
            new Dictionary<string, ServiceController>();

        public static ServiceController GetServiceController(string serviceName)
        {
            try
            {
                if (!ControllerCache.ContainsKey(serviceName))
                    ControllerCache[serviceName] = new ServiceController(serviceName);

                return ControllerCache[serviceName];
            }
            catch
            {
                return null;
            }
        }


        public static void StartService(this ServiceController controller)
        {
            if (controller.Status == ServiceControllerStatus.Running)
                return;

            try
            {
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running);
            } catch { /* ... TODO ... */ }
        }

        public static void StopService(this ServiceController controller)
        {
            if (controller.Status == ServiceControllerStatus.Stopped)
                return;

            try
            {
                controller.Stop();
                controller.WaitForStatus(ServiceControllerStatus.Stopped);
            } catch { /* ... TODO ... */ }
        }

        public static void RestartService(this ServiceController controller)
        {
            try
            {
                if (controller.Status == ServiceControllerStatus.Running)
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running);
            } catch { /* ... TODO ... */ }
        }

        public static IEnumerable<Service> GetServicesByGroupName(string groupName)
        {
            return ConfigManager.Instance.Config.Services.Where(s => groupName == s.Group);
        }

        public static void StartServiceGroup(string groupName)
        {
            foreach (var service in GetServicesByGroupName(groupName))
                service.Controller.StartService();
        }

        public static void StopServiceGroup(string groupName)
        {
            foreach (var service in GetServicesByGroupName(groupName))
                service.Controller.StopService();
        }

        public static void RestartServiceGroup(string groupName)
        {
            foreach (var service in GetServicesByGroupName(groupName))
                service.Controller.RestartService();
        }

        public static bool IsInPendingState(this ServiceController controller)
        {
            switch (controller.Status)
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
