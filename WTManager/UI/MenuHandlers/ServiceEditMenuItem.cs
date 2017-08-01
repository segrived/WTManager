using System.Linq;
using System.Windows.Forms;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceEditMenuItem : ServiceMenuItem
    {
        public ServiceEditMenuItem(IWtTrayMenuController controller, Service service)
            : base(controller, service) { }

        protected override string DisplayText { get; } = "Edit configuration";

        protected override string ImageKey => "config";

        protected override void Action()
        {
            using (var f = new AddEditServiceForm(this.Service))
            {
                if (f.ShowDialog() != DialogResult.OK)
                    return;

                var services = ConfigManager.Services.ToList();

                bool Predicate(Service serviceToTest) 
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