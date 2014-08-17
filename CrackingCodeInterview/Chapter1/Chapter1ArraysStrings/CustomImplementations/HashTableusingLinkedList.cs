using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomImplementations
{
    /// <summary>
    /// Container for both key and value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TV"></typeparam>
    internal class KeyValuePair<T,TV>
    {
        public T Key { get; set; }
        public TV ObjectValue { get; set; }

        public KeyValuePair(T key,TV objectValue)
        {
            Key = key;
            ObjectValue = objectValue;
        }

        public override string ToString()
        {
            return string.Format("Key: {0}, Value: {1}", Key, ObjectValue);
        }

        protected bool Equals(KeyValuePair<T, TV> other)
        {
            return EqualityComparer<T>.Default.Equals(Key, other.Key) && EqualityComparer<TV>.Default.Equals(ObjectValue, other.ObjectValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((KeyValuePair<T, TV>) obj);
        }

        /// <summary>
        /// Generate code ensures unique hashcode for each keyvalue pair
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(Key)*397) ^ EqualityComparer<TV>.Default.GetHashCode(ObjectValue);
            }
        }
    }


    public class HashTableusingLinkedList<K,V>
    {
        private int _size;
        private readonly LinkedList<KeyValuePair<K,V>>[] _internalArray;
        private int _length;

        public HashTableusingLinkedList()
            : this(10)
        {
            
        }

        public HashTableusingLinkedList(int size)
        {
            _size = size;
            _internalArray = new LinkedList<KeyValuePair<K, V>>[_size];
        }

        public void Insert(K key, V value)
        {
            int hashCode = Math.Abs( key.GetHashCode() % _size);
            LinkedList<KeyValuePair<K, V>> currentEntry = _internalArray[hashCode];
            
            if (currentEntry == null)
            {
                currentEntry = new LinkedList<KeyValuePair<K, V>>();
                _internalArray[hashCode] = currentEntry;
            }

            var currentKeyValuePair = new KeyValuePair<K, V>(key, value);
            var node = new LinkedListNode<KeyValuePair<K, V>>(currentKeyValuePair);

            //To check if the key already exists
            LinkedListNode<KeyValuePair<K, V>> matchedEntry = Find(currentKeyValuePair,currentEntry);
            if (matchedEntry == null)
            {
                currentEntry.AddLast(node);
            }
            else
            {
                throw new ApplicationException("Key Already exists");
            }

            _length++;

            //If threshold is reached
            //Redefine the array and reset the threshold
        }

        private LinkedListNode<KeyValuePair<K, V>> Find(KeyValuePair<K, V> currentKeyValuePair, LinkedList<KeyValuePair<K, V>> currentEntry)
        {
            for (LinkedListNode<KeyValuePair<K, V>> nodeEntry = currentEntry.First;
                nodeEntry != null;
                nodeEntry = nodeEntry.Next)
            {
                if (nodeEntry.Value.Key.Equals(currentKeyValuePair.Key))
                {
                    return nodeEntry;
                }
            }
            return null;
        }


        public void PrintTable()
        {
            foreach (LinkedList<KeyValuePair<K, V>> dataList in _internalArray.Where(entry=>entry!=null))
            {
                foreach (KeyValuePair<K, V> node in dataList)
                {
                    Console.WriteLine(node.ToString());
                }
            }
        }

        public int Count
        {
            get
            {
                int count = 0,localSize = 0;
                while (localSize < _size)
                {
                    if (_internalArray[localSize] != null)
                        count++;
                    localSize++;
                }
                return count;
            }
        }
        //public V Find(K key)
        //{
            
        //}
    }
}
