using System;
using System.IO;
using System.Threading;

namespace WTManager.Lib
{
    public class FileWatcherEventArgs : EventArgs
    {
        public string AppendedContent { get; private set; }

        public FileWatcherEventArgs(string appendedContent) {
            this.AppendedContent = appendedContent;
        }
    }

    public class FileWatcher : IDisposable
    {
        private CancellationTokenSource token;
        private FileStream _fileStream;

        public event EventHandler<FileWatcherEventArgs> FileChanged;

        public string FileName { get; }
        public int Interval { get; }

        public FileWatcher(string fileName, int interval = 100) {
            this.token = new CancellationTokenSource();
            this.FileName = fileName;
        }

        public void StartWatch() {
            var fileShare = FileShare.ReadWrite | FileShare.Delete;
            this._fileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, fileShare);
            var reader = new StreamReader(this._fileStream);
            this._fileStream.Seek(0, SeekOrigin.End);
            while (true) {
                if (this.token.IsCancellationRequested) {
                    return;
                }
                string line = reader.ReadToEnd().Trim();
                if (line != String.Empty) {
                    this.OnFileChanged(new FileWatcherEventArgs(line));
                }
                Thread.Sleep(this.Interval);
            }
        }

        public void Dispose() {
            this.token?.Cancel();
            this._fileStream?.Dispose();
        }

        protected virtual void OnFileChanged(FileWatcherEventArgs e) {
            FileChanged?.Invoke(this, e);
        }
    }
}
