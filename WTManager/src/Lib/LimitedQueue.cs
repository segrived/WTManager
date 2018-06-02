using System.Collections.Generic;

namespace WtManager.Lib
{
    public class LimitedQueue<T> : Queue<T>
    {
        private int Limit { get; set; }

        public LimitedQueue(int limit) : base(limit)
        {
            this.Limit = limit;
        }

        public new void Enqueue(T item)
        {
            while (this.Count >= this.Limit)
                this.Dequeue();

            base.Enqueue(item);
        }
    }
}
