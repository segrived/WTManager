using WTManager.Config;

namespace WTManager
{
    public interface IConfigurable
    {
        /// <summary>
        /// Apply settings to form
        /// </summary>
        void ApplySettings(Configuration configuration);

        /// <summary>
        /// Updates settings before save
        /// </summary>
        void UpdateSettings(Configuration configuration);
    }
}