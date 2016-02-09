using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Lib;
using WTManager.Helpers;
using System.Drawing;

namespace WTManager
{
    public partial class LogFileViewer : Form
    {
        private FileWatcher watcher { get; set; }
        private CancellationTokenSource cancelToken { get; set; }

        public LogFileViewer() {
            this.InitializeComponent();
        }

        public LogFileViewer(string fileName) : this() {
            var lastLines = FileHelpers.ReadLastLines(fileName);
            foreach (var line in lastLines) {
                this.logFileContent.AppendText(line + Environment.NewLine, Color.Gray);
            }
            this.Text = $"Log file viewer: {fileName}";
            this.watcher = new FileWatcher(fileName);
            watcher.FileChanged += Watcher_FileChanged;
            Task.Factory.StartNew(watcher.StartWatch);
        }

        private void Watcher_FileChanged(object sender, FileWatcherEventArgs e) {
            this.logFileContent.InvokeIfRequired(() => {
                this.logFileContent.AppendText(e.AppendedContent + Environment.NewLine);
                this.logFileContent.ScrollToCaret();
            });
        }

        private void LogFileViewer_FormClosing(object sender, FormClosingEventArgs e) {
            watcher.FileChanged -= Watcher_FileChanged;
            this.watcher.Dispose();
        }

        private void LogFileViewer_Load(object sender, EventArgs e) {

        }
    }
}