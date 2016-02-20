using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace WTManager.Helpers
{
    public static class ServiceHelpers
    {
        private static HashSet<string> _installedServices = GetAllServices()
            .Select(sc => sc.ServiceName).ToHashSet();

        private static Dictionary<Service, ServiceController> _controllerCache =
            new Dictionary<Service, ServiceController>();

        public static ServiceController[] GetAllServices() =>
            ServiceController.GetServices();

        public static bool IsServiceExists(string name) =>
            ServiceController.GetServices().Select(s => s.ServiceName).Contains(name);

        public static void StartService(this Service s) {
            s.GetController().Start();
            s.GetController().WaitForStatus(ServiceControllerStatus.Running);
        }

        public static void StopService(this Service s) {
            s.GetController().Stop();
            s.GetController().WaitForStatus(ServiceControllerStatus.Stopped);
        }

        public static void RestartService(this Service s) {
            s.GetController().Stop();
            s.GetController().WaitForStatus(ServiceControllerStatus.Stopped);
            s.GetController().Start();
            s.GetController().WaitForStatus(ServiceControllerStatus.Running);
        }

        public static ServiceController GetController(this Service s) {
            try {
                if (!_controllerCache.ContainsKey(s)) {
                    _controllerCache[s] = new ServiceController(s.ServiceName);
                }
                return _controllerCache[s];
            } catch (Exception) {
                return null;
            }
        }
    }
}
