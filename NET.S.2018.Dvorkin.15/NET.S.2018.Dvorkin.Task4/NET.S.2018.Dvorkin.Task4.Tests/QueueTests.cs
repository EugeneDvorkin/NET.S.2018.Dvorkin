using System;
using NUnit.Framework;

namespace NET.S._2018.Dvorkin.Task4.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Constructor_CreateQueueWithoutParameters()
            => Assert.AreEqual(new Queue<int>().Count, 0);

        [Test]
        public void Constructor_CreateQueueFromArray()
        {
            int[] array = { 1, 2 };
            var queue = new Queue<int>(array);
            Assert.AreEqual(queue.Count, 2);
        }

        [Test]
        public void Constructor_InvalidsArgument_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Queue<int>(-1));
        }

        [Test]
        public void Enqueue_2ElementsInQueue()
        {
            int[] array = { 1, 2 };

            var queue = new Queue<int>(array);

            queue.Enqueue(3);
            queue.Enqueue(4);

            int expectedCount = 4;
            int actualCount = queue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Dequeue_ElementFromEmptyQueue_ExpectsInvalidOperationException()
        {
            var queue = new Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Clear_Queue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Clear();

            Assert.AreEqual(queue.Count, 0);
        }

        [Test]
        public void GetEnumerator_Test()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            var enumerator = queue.GetEnumerator();

            Assert.Throws<InvalidOperationException>(() => { var current = enumerator.Current; });

            foreach (var item in queue)
            {
                Assert.True(enumerator.MoveNext());
            }
        }
    }
}
