using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Forms;

namespace WTManager.Tray.MenuHandlers.Service
{
    public class ServiceEditMenuItem : ServiceMenuItem
    {
        public ServiceEditMenuItem(ITrayController controller, Config.Service service)
            : base(controller, service) { }

        protected override string DisplayText { get; } = "Edit configuration";

        protected override string ImageKey => "service-config";

        protected override void Action()
        {
            using (var f = new AddEditServiceForm(this.Service))
            {
                if (f.ShowDialog() != DialogResult.OK)
                    return;

                var services = ConfigManager.Instance.Config.Services.ToList();

                bool Predicate(Config.Service serviceToTest) 
                    => Equals(serviceToTest.GetHashCode(), this.Service.GetHashCode());
                int index = services.IndexOf(services.First(Predicate));

                if (index == -1)
                    return;

                services[index] = f.Service;
                ConfigManager.Instance.SaveConfig();
            }
        }
    }
}