using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Controls;
using WTManager.Helpers;
using WTManager.Lib;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class LogFileViewerForm : WtManagerForm
    {
        private FileWatcher Watcher { get; set; }

        private LogFileViewerForm()
        {
            this.InitializeComponent();
        }

        public LogFileViewerForm(string fileName) : this()
        {
            this.AppendLines(this.ReadLastLines(fileName), true);

            this.Text = $"Log file viewer: {fileName}";
            this.Watcher = new FileWatcher(fileName);
            this.Watcher.FileChanged += this.Watcher_FileChanged;
            Task.Factory.StartNew(this.Watcher.StartWatch);
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
            this.Watcher.FileChanged -= this.Watcher_FileChanged;
            this.Watcher.Dispose();
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        #region Utils

        private void AppendLines(IEnumerable<string> text, bool addNewLine)
        {
            foreach (string line in text)
            {
                this.logFileContent.SelectionStart = this.logFileContent.TextLength;
                this.logFileContent.SelectionLength = 0;
                this.logFileContent.SelectionColor = Color.Gray;
                this.logFileContent.AppendText(line + (addNewLine ? Environment.NewLine : String.Empty));
                this.logFileContent.SelectionColor = this.logFileContent.ForeColor;
            }
        }

        private IEnumerable<string> ReadLastLines(string fileName, int linesCount = 10)
        {
            var queue = new LimitedQueue<string>(linesCount);
            
            using (var s = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (var reader = new StreamReader(s))
            {
                while (reader.ReadLine() != null)
                    queue.Enqueue(reader.ReadLine());
            }
            return queue.ToList();
        }

        #endregion
    }
}