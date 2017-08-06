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
        private const FileShare FILE_SHARE_MODE = FileShare.ReadWrite | FileShare.Delete;

        private string FileName { get; }
        private int Interval { get; }

        private readonly CancellationTokenSource _token;
        private FileStream _fileStream;

        public FileWatcher(string fileName, int interval = 100)
        {
            this._token = new CancellationTokenSource();

            this.FileName = fileName;
            this.Interval = interval;
        }
        
        public event EventHandler<FileWatcherEventArgs> FileChanged;

        public void StartWatch() {
            
            this._fileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, FILE_SHARE_MODE);
            var reader = new StreamReader(this._fileStream);
            this._fileStream.Seek(0, SeekOrigin.End);

            while (true)
            {
                if (this._token.IsCancellationRequested)
                    return;

                try
                {
                    string line = reader.ReadToEnd();
                    if (! String.IsNullOrEmpty(line))
                        this.FileChanged?.Invoke(this, new FileWatcherEventArgs(line));
                }
                catch (IOException)
                {
                    // nothin to do, jsut wait
                }
                Thread.Sleep(this.Interval);
            }
        }

        public void Dispose()
        {
            this._token?.Cancel();
            this._fileStream?.Dispose();
        }
    }
}
