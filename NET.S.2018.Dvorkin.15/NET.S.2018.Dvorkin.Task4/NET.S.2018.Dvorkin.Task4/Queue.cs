using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task4
{
    /// <summary>
    /// Contains definitions for custom queue.
    /// </summary>
    /// <typeparam name="T">Type of the elements</typeparam>
    /// <seealso cref="System.Collections.IEnumerable" />
    public class Queue<T> : IEnumerable<T>
    {
        private T[] queue;
        private int size;
        private int tail;
        private int head;
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue() : this(capacity: 8)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="ArgumentNullException">collection</exception>
        public Queue(IEnumerable<T> collection) : this(capacity: collection.Count())
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"{nameof(collection)} is null");
            }

            foreach (T item in collection)
            {
                Enqueue(item);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public Queue(int capacity)
        {
            if (capacity<0)
            {
                throw new ArgumentException($"{nameof(capacity)} is less than 0");
            }
            this.queue = new T[capacity];
            this.size = 0;
            this.head = 0;
            this.tail = 0;
            this.version = 0;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get => size;
            private set => size = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>Element at current index.</returns>
        public T this[int index]
        {
            get => queue[index];
            set => queue[index] = value;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            if (this.head < this.tail)
            {
                Array.Clear(this.queue, head, size);
            }
            else
            {
                Array.Clear(this.queue, this.head, this.queue.Length - this.head);
                Array.Clear(this.queue, 0, this.tail);
            }

            head = 0;
            tail = 0;
            Count = 0;
            version++;
        }

        /// <summary>
        /// Enqueues the specified elem.
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <exception cref="ArgumentNullException">elem</exception>
        public void Enqueue(T elem)
        {
            if (ReferenceEquals(elem, null))
            {
                throw new ArgumentNullException($"{nameof(elem)} is null");
            }

            if (this.size == queue.Length)
            {
                Array.Resize(ref queue, queue.Length * 2);
            }

            this.queue[this.tail] = elem;
            this.tail = (this.tail + 1) % this.queue.Length;
            Count++;
            version++;
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns>Element.</returns>
        /// <exception cref="ArgumentException">Count of elements in the queue is 0</exception>
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Count of elements in the queue is 0");
            }

            T temp = this.queue[head];
            this.queue[this.head] = default(T);
            this.head = (this.head + 1) % this.queue.Length;
            this.Count--;
            this.version++;

            return temp;
        }

        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">there is 0 argument in queue</exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("there is 0 argument in queue");
            }

            return this.queue[this.head];
        }

        /// <summary>
        /// Determines whether [contains] [the specified elem].
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified elem]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T elem)
        {
            int index = this.head;
            int size = this.size;
            while (size-- > 0)
            {
                if (elem == null)
                {
                    if (this.queue[index] == null)
                    {
                        return true;
                    }
                }
                else if (this.queue[index] != null && EqualityComparer<T>.Default.Equals(this.queue[index], elem))
                {
                    return true;
                }

                index = (index + 1) % this.queue.Length;
            }

            return false;
        }

        /// <summary>
        /// Copies to array.
        /// </summary>
        /// <returns></returns>
        public T[] CopyToArray()
        {
            T[] result = new T[size];

            if (this.head < this.tail)
            {
                Array.Copy(this.queue, this.head, result, 0, size);
            }
            else
            {
                Array.Copy(this.queue, this.head, result, 0, queue.Length - head);
                Array.Copy(this.queue, 0, result, queue.Length - this.head, this.tail);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct CustomIterator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private int currentIndex;
            private int version;

            public CustomIterator(Queue<T> queue)
            {
                this.currentIndex = -1;
                this.queue = queue;
                this.version = queue.version;
            }

            public bool MoveNext()
            {
                if (this.version != queue.version)
                {
                    throw new InvalidOperationException($"{nameof(queue)} has been changed");
                }

                return ++currentIndex < queue.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            object IEnumerator.Current => Current;

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Count)
                    {
                        throw new InvalidOperationException($"{nameof(currentIndex)} is wrong");
                    }

                    return queue[currentIndex];
                }
            }

            void IDisposable.Dispose()
            {
            }
        }
    }
}
