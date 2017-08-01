using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WTManager.Lib;
using WTManager.Helpers;
using WTManager.Controls;

namespace WTManager.UI
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class LogFileViewerForm : WtManagerForm
    {
        private FileWatcher watcher { get; set; }

        private LogFileViewerForm()
        {
            this.InitializeComponent();
        }

        public LogFileViewerForm(string fileName) : this()
        {
            var lastLines = FileHelpers.ReadLastLines(fileName);

            foreach (string line in lastLines)
                this.logFileContent.AppendText(line + Environment.NewLine, Color.Gray);

            this.Text = $"Log file viewer: {fileName}";
            this.watcher = new FileWatcher(fileName);
            this.watcher.FileChanged += this.Watcher_FileChanged;
            Task.Factory.StartNew(this.watcher.StartWatch);
        }

        private void Watcher_FileChanged(object sender, FileWatcherEventArgs e)
        {
            this.logFileContent.InvokeIfRequired(() =>
            {
                this.logFileContent.AppendText(e.AppendedContent);
                this.logFileContent.ScrollToCaret();
            });
        }

        private void LogFileViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.watcher.FileChanged -= this.Watcher_FileChanged;
            this.watcher.Dispose();
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}