using System;
using NUnit.Framework;
namespace NET.S._2018.Dvorkin.Task1.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [TestCase]
        public void Enumerator_Int_SortedArray()
        {
            int[] array = { 15, 25, 75, 95, 7, 65, 35 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(array);

            int i = 0;
            foreach (var el in tree)
            {
                array[i++] = el;
            }

            int[] expectedArr = { 7, 15, 25, 35, 65, 75, 95 };

            Assert.AreEqual(expectedArr, array);
        }


        [TestCase]
        public void Enumerator_String_SortedArray()
        {
            string[] array = { "15", "25", "75", "95", "7", "65", "35" };
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Add(array);

            int i = 0;
            foreach (var el in tree)
            {
                array[i++] = el;
            }

            string[] expectedArr = { "15", "25", "35", "65", "7", "75", "95" };

            Assert.AreEqual(expectedArr, array);
        }
    }
}
