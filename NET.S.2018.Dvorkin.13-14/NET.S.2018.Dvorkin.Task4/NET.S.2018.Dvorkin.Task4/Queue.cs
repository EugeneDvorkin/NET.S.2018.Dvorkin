using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET.S._2018.Dvorkin.Task4
{
    /// <summary>
    /// COntains definitions for custom queue.
    /// </summary>
    /// <typeparam name="T">Type of the elements</typeparam>
    /// <seealso cref="System.Collections.IEnumerable" />
    public class Queue<T> : IEnumerable
    {
        private T[] queue;
        private int size;
        private int tail;
        private int head;

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
            this.queue = new T[capacity];
            this.size = 0;
            this.head = 0;
            this.tail = 0;
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
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return queue.GetEnumerator();
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
                throw new ArgumentException("Count of elements in the queue is 0");
            }

            T temp = this.queue[head];
            this.queue[this.head] = default(T);
            this.head = (this.head + 1) % this.queue.Length;

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
                Array.Copy(this.queue, 0, result,queue.Length-this.head,this.tail);
            }

            return result;
        }
    }
}
