namespace WTManager.UI.MenuHandlers
{
    public sealed class SeparatorMenuItem : WtMenuItem
    {
        public SeparatorMenuItem(IWtTrayMenuController controller)
            : base(controller) { }

        protected override string DisplayText { get; } = "-";

        protected override void Action()
        {
        }
    }
}