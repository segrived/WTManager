using System;
using WTManager.Helpers;

namespace WTManager
{
    public class Preferences
    {
        public string EditorPath { get; set; }

        public int BaloonTipTime { get; set; }

        public bool ShowBaloon { get; set; }

        public static readonly Lazy<Preferences> _prefs
            = new Lazy<Preferences>(SerializationHelpers.ReadPreferencesConfFile);

        public static Preferences Prefs => _prefs.Value;
    }
}