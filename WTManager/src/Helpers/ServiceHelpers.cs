using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace WTManager.Helpers
{
    public static class ServiceHelpers
    {
        private static readonly Dictionary<Service, ServiceController> ControllerCache =
            new Dictionary<Service, ServiceController>();

        public static ServiceController[] GetAllServices() =>
            ServiceController.GetServices();

        public static void StartService(this Service s)
        {
            s.GetController().Start();
            s.GetController().WaitForStatus(ServiceControllerStatus.Running);
        }

        public static void StopService(this Service s)
        {
            s.GetController().Stop();
            s.GetController().WaitForStatus(ServiceControllerStatus.Stopped);
        }

        public static void RestartService(this Service s)
        {
            s.GetController().Stop();
            s.GetController().WaitForStatus(ServiceControllerStatus.Stopped);
            s.GetController().Start();
            s.GetController().WaitForStatus(ServiceControllerStatus.Running);
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
    }
}
