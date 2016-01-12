using System.ServiceProcess;

namespace WTManager.Helpers
{
    public static class ServiceHelpers
    {
        public static void StartService(Service s) {
            s.Controller.Start();
            s.Controller.WaitForStatus(ServiceControllerStatus.Running);

        }

        public static void StopService(Service s) {
            s.Controller.Stop();
            s.Controller.WaitForStatus(ServiceControllerStatus.Stopped);

        }

        public static void RestartService(Service s) {
            s.Controller.Stop();
            s.Controller.WaitForStatus(ServiceControllerStatus.Stopped);
            s.Controller.Start();
            s.Controller.WaitForStatus(ServiceControllerStatus.Running);

        }
    }
}
