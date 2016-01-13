using System.Collections.Generic;
using System.IO;
using System.Linq;
using WTManager.Lib;

namespace WTManager.Helpers
{
    public static class FileHelpers
    {
        public static List<string> ReadLastLines(string fileName, int linesCount = 10) {
            string line;

            var queue = new LimitedQueue<string>(linesCount);
            var shareMode = FileShare.ReadWrite | FileShare.Delete;
            using (var s = new FileStream(fileName, FileMode.Open, FileAccess.Read, shareMode))
            using (var reader = new StreamReader(s)) {
                while ((line = reader.ReadLine()) != null) {
                    queue.Enqueue(reader.ReadLine());
                }
            }
            return queue.ToList();
        }
    }
}
