using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTManager
{
    public partial class LogFileViewer : Form
    {
        private CancellationTokenSource cancelToken { get; set; }

        public LogFileViewer() {
            this.InitializeComponent();
        }

        public LogFileViewer(string fileName) : this() {
            this.OpenFile(fileName);
        }

        public void OpenFile(string fileName) {
            this.logFileNameLbl.Text = fileName;
            Task.Factory.StartNew(() => {
                this.cancelToken = new CancellationTokenSource();
                const FileShare fileShare = FileShare.ReadWrite | FileShare.Delete;
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, fileShare))
                using (var reader = new StreamReader(fs)) {
                    fs.Seek(0, SeekOrigin.End);
                    while (true) {
                        if (this.cancelToken.IsCancellationRequested) {
                            fs.Dispose();
                            return;
                        }
                        string line = reader.ReadToEnd();
                        if (!String.IsNullOrWhiteSpace(line))
                            if (this.logFileContent.InvokeRequired) {
                                this.logFileContent.BeginInvoke((MethodInvoker)(() => {
                                    this.logFileContent.AppendText(line + Environment.NewLine);
                                }));
                            }
                        Thread.Sleep(100);
                    }
                }
            }, new CancellationToken());
        }

        private void LogFileViewer_FormClosing(object sender, FormClosingEventArgs e) {
            this.cancelToken.Cancel();
        }
    }
}