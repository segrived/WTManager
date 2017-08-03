using System.Collections.Generic;

namespace WTManager.Lib
{
    public class LimitedQueue<T> : Queue<T>
    {
        public int Limit { get; set; }

        public LimitedQueue(int limit) : base(limit) {
            this.Limit = limit;
        }

        public new void Enqueue(T item) {
            while (this.Count >= this.Limit) {
                this.Dequeue();
            }
            base.Enqueue(item);
        }
    }
}
