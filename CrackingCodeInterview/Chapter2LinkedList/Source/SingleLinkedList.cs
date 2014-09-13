using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2LinkedList
{
    public class SingleLinkedList<T>
    {
        public SingleLinkedListNode<T> HeadNode { get; set; }
        public int Count { get; private set; }
        public SingleLinkedList(SingleLinkedListNode<T> headNode)
        {
            HeadNode = headNode;
            Count++;
            
        }

        public void AddToTail(SingleLinkedListNode<T> node)
        {
            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else
            {
                SingleLinkedListNode<T> currentNode = HeadNode;
                
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = node;
                node.Next = null;
            }
            Count++;
        }


        public SingleLinkedListNode<T> DeleteNode(T data)
        {
            SingleLinkedListNode<T> currentNode = HeadNode;

            if (Count == 0)
            {
                throw new InvalidOperationException("the current linkedlist is empty");
            }

            //Ensure the data from the first node is deleted
            if (HeadNode.Data.Equals(data))
            {
                HeadNode = HeadNode.Next;
            }
            else
            {
                //Ensure the data from the rest of the node is deleted
                while (currentNode.Next != null)
                {
                    if (currentNode.Next.Data.Equals(data))
                    {
                        currentNode.Next = currentNode.Next.Next;
                        break;
                    }
                }
            }
            return HeadNode;
        }

        public IEnumerable<T> GetAllNodeValues()
        {
            var dataList = new List<T>();

            var currentNode = HeadNode;

            while (currentNode != null)
            {
                dataList.Add(currentNode.Data);

                currentNode = currentNode.Next;
            }

            return dataList;

        }

        public T GetKthNodeFromLastUsingRunnerTechnique(int kthIndex)
        {
            int firstRunnerIndex =0;

            SingleLinkedListNode<T> firstRunnerNode = HeadNode;

            while (firstRunnerNode != null)
            {
                if (firstRunnerIndex < kthIndex)
                {
                    firstRunnerNode = firstRunnerNode.Next;
                    firstRunnerIndex++;
                }
                else
                {
                    break;
                }
            }

            SingleLinkedListNode<T> secondRunnerNode = HeadNode;

            while (firstRunnerNode != null)
            {
                secondRunnerNode = secondRunnerNode.Next;
                firstRunnerNode = firstRunnerNode.Next;
            }

            return secondRunnerNode.Data;
        }

        
    }

    public class SingleLinkedListNode<T>
    {
        public T Data { get; set; }

        public SingleLinkedListNode(T data)
        {
            Data = data;
        }
        public SingleLinkedListNode<T> Next { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
