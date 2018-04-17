using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains methods for BinarySearch Tree
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private Comparison<T> comparison;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException">data</exception>
        /// <exception cref="ArgumentException">T</exception>
        public BinarySearchTree(Node<T> data, Comparison<T> comparison)
        {
            this.root = data ?? throw new ArgumentNullException($"{nameof(data)} is null");
            if (comparison == null)
            {
                try
                {
                    this.comparison = Comparer<T>.Default.Compare;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException($"{nameof(T)} doesn't implicit compare");
                }
            }

            this.comparison = comparison;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        public BinarySearchTree(Comparison<T> comparison) : this(null, comparison)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public BinarySearchTree(T data) : this(new Node<T>(data), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
            if (comparison == null)
            {
                try
                {
                    this.comparison = Comparer<T>.Default.Compare;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException($"{nameof(T)} doesn't implicit compare");
                }
            }
        }

        /// <summary>
        /// Determines whether [contains] [the specified element].
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified element]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T element) => ContainsElement(root, element);

        /// <summary>
        /// Adds the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="ArgumentNullException">element</exception>
        public void Add(T element)
        {
            if (element==null)
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }

            root = AddElement(root, element);
        }

        /// <summary>
        /// Adds the specified elements.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <exception cref="ArgumentNullException">elements</exception>
        public void Add(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException($"{nameof(elements)} is null");
            }

            foreach (T element in elements)
            {
                Add(element);
            }
        }

        /// <summary>
        /// Pre order way of representations.
        /// </summary>
        /// <returns>Representation of tree</returns>
        public IEnumerable<T> PreOrder() => PreorderMethod(root);

        /// <summary>
        /// Post order way of representations.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> PostOrder() => PostorderMethod(root);

        /// <summary>
        /// In order way of representations.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> InOrder() => InorderMethod(root);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds the element.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="element">The element.</param>
        /// <returns>Node with element.</returns>
        private Node<T> AddElement(Node<T> node, T element)
        {
            if (node == null)
            {
                return new Node<T>(element);
            }

            if (comparison(element, node.Data) < 0)
            {
                node.Left = AddElement(node.Left, element);
            }

            if (comparison(element, node.Data) > 0)
            {
                node.Right = AddElement(node.Right,element);
            }

            return node;
        }

        /// <summary>
        /// Determines whether the specified node contains element.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="element">The element.</param>
        /// <returns>
        ///   <c>true</c> if the specified node contains element; otherwise, <c>false</c>.
        /// </returns>
        private bool ContainsElement(Node<T> node, T element)
        {
            if (node == null)
            {
                return false;
            }

            if (comparison(node.Data, element) == 0)
            {
                return true;
            }

            if (comparison(node.Left.Data, element) == 0)
            {
                return true;
            }

            return comparison(node.Right.Data, element) == 0;
        }

        /// <summary>
        /// Preorders the method.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private IEnumerable<T> PreorderMethod(Node<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (T element in PreorderMethod(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (T element in PreorderMethod(node.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Inorders the method.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private IEnumerable<T> InorderMethod(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (T element in InorderMethod(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (T element in InorderMethod(node.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Postorders the method.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private IEnumerable<T> PostorderMethod(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (T element in PostorderMethod(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (T element in PostorderMethod(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Data;
        }
    }
}
