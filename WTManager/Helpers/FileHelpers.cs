using System.Collections.Generic;
using System.IO;
using System.Linq;
using WTManager.Lib;

namespace WTManager.Helpers
{
    public static class FileHelpers
    {
        private const FileShare SHARE_MODE = FileShare.ReadWrite | FileShare.Delete;

        public static List<string> ReadLastLines(string fileName, int linesCount = 10)
        {
            var queue = new LimitedQueue<string>(linesCount);
            
            using (var s = new FileStream(fileName, FileMode.Open, FileAccess.Read, SHARE_MODE))
            using (var reader = new StreamReader(s))
            {
                while (reader.ReadLine() != null)
                    queue.Enqueue(reader.ReadLine());
            }
            return queue.ToList();
        }
    }
}
