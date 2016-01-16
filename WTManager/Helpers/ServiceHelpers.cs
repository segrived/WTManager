using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace WTManager.Helpers
{
    public static class ServiceHelpers
    {
        private static HashSet<string> _installedServices =
            ServiceController.GetServices().Select(sc => sc.ServiceName).ToHashSet();

        public static bool IsServiceExists(string serviceName) {
            return _installedServices.Contains(serviceName);
        }

        public static void StartService(this Service s) {
            s.Controller.Start();
            s.Controller.WaitForStatus(ServiceControllerStatus.Running);
        }

        public static void StopService(this Service s) {
            s.Controller.Stop();
            s.Controller.WaitForStatus(ServiceControllerStatus.Stopped);
        }

        public static void RestartService(this Service s) {
            s.Controller.Stop();
            s.Controller.WaitForStatus(ServiceControllerStatus.Stopped);
            s.Controller.Start();
            s.Controller.WaitForStatus(ServiceControllerStatus.Running);
        }
    }
}
