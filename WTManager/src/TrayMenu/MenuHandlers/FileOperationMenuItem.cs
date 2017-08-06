namespace WTManager.TrayMenu.MenuHandlers
{
    public class FileOperationMenuItem : WtMenuItem
    {
        protected string FileName { get; private set; }

        protected FileOperationMenuItem(ITrayController controller, string fileName)
            : base(controller)
        {
            this.FileName = fileName;
        }
    }
}