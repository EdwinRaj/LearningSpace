using System;
using System.Collections.Generic;
using System.Linq;
using Chapter2LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class SingleLinkedListTest
    {
        [TestMethod]
        public void TestAddNodeToTail()
        {
            var headNode = new SingleLinkedListNode<int>(1);
            var linkedList = new SingleLinkedList<int>(headNode);

            var midNode = new SingleLinkedListNode<int>(2);
            var childNode = new SingleLinkedListNode<int>(3);

            Assert.AreEqual(1, linkedList.Count);
            
            linkedList.AddToTail(midNode);
            Assert.AreEqual(2, linkedList.Count);
            
            linkedList.AddToTail(childNode);
            Assert.AreEqual(3, linkedList.Count);

            IEnumerable<int> nodeData = linkedList.GetAllNodeValues().ToList();
            Assert.AreEqual(1,nodeData.First());
            Assert.AreEqual(2, nodeData.Skip(1).First());
            Assert.AreEqual(3, nodeData.Last());

            Console.WriteLine(string.Join(",",nodeData.ToArray()));
        }

        [TestMethod]
        public void TestDeleteNode()
        {
            var headNode = new SingleLinkedListNode<int>(1);
            var linkedList = new SingleLinkedList<int>(headNode);

            var midNode = new SingleLinkedListNode<int>(2);
            var childNode = new SingleLinkedListNode<int>(3);

            linkedList.AddToTail(midNode);
            Assert.AreEqual(2, linkedList.Count);

            linkedList.AddToTail(childNode);

            IEnumerable<int> nodeData = linkedList.GetAllNodeValues().ToList();
            Assert.AreEqual(1, nodeData.First());
            Assert.AreEqual(2, nodeData.Skip(1).First());
            Assert.AreEqual(3, nodeData.Last());

            SingleLinkedListNode<int> currentLinkedList = linkedList.DeleteNode(2);
            nodeData = linkedList.GetAllNodeValues().ToList();
            Assert.AreEqual(2,nodeData.Count());
            Assert.AreEqual(1, nodeData.First());
            Assert.AreEqual(3, nodeData.Last());

        }

        [TestMethod]
        public void TestGetKthNodeFromLastUsingRunnerTechnique()
        {
            var headNode = new SingleLinkedListNode<int>(1);
            var linkedList = new SingleLinkedList<int>(headNode);

            var secondNode = new SingleLinkedListNode<int>(2);
            var thirdNode = new SingleLinkedListNode<int>(3);
            var fourthNode = new SingleLinkedListNode<int>(4);
            var fifthNode = new SingleLinkedListNode<int>(5);
            var sixthNode = new SingleLinkedListNode<int>(6);
            var seventhNode = new SingleLinkedListNode<int>(7);

            linkedList.AddToTail(secondNode);
            linkedList.AddToTail(thirdNode);
            linkedList.AddToTail(fourthNode);
            linkedList.AddToTail(fifthNode);
            linkedList.AddToTail(sixthNode);
            linkedList.AddToTail(seventhNode);

            int kthNodeFromLastUsingRunnerTechnique = linkedList.GetKthNodeFromLastUsingRunnerTechnique(5);
            Assert.AreEqual(3,kthNodeFromLastUsingRunnerTechnique);
        }
    }
}
