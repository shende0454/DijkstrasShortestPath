using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using QueueLib;


namespace IndexedMinPQTests
{
    [TestClass]
    public class IndexedPQTests
    {

        class KeyValuePair : IComparable<KeyValuePair>
        {
            public int Id { get; }
            public double Key { get; set; }
            public KeyValuePair(int id, double key)
            {
                Id = id;
                Key = key;
            }

            public int CompareTo(KeyValuePair other)
            {
                return Key.CompareTo(other.Key);
            }
        }

        [TestMethod]
        public void T001_create()
        {
            IIndexedMinPriortyQueue<int, double> queue = new IndexedMinPriorityQueue<int, double>();
            Assert.IsTrue(queue.IsEmpty());
            queue.Insert(0, .5);
            Assert.IsFalse(queue.IsEmpty());
            queue.Insert(1, .8);
            queue.Insert(2, .7);

            Assert.AreEqual(3, queue.NKeysInQueue);
        }


        [TestMethod]
        public void T002_containsId()
        {
            IIndexedMinPriortyQueue<int, double> queue = new IndexedMinPriorityQueue<int, double>();
            Assert.IsTrue(queue.IsEmpty());
            queue.Insert(0, .5);
            Assert.IsFalse(queue.IsEmpty());
            queue.Insert(1, .8);
            queue.Insert(2, .7);
            Assert.IsTrue(queue.Contains(0));
            Assert.IsTrue(queue.Contains(1));
            Assert.IsTrue(queue.Contains(2));
            Assert.IsFalse(queue.Contains(3));
        }


        [TestMethod]
        public void T001_min()
        {
            IIndexedMinPriortyQueue<int, double> queue = new IndexedMinPriorityQueue<int, double>();
            queue.Insert(0, .8);
            queue.Insert(1, .5);
            queue.Insert(2, .7);

            Assert.AreEqual(.5, queue.MinKey);
            Assert.AreEqual(1, queue.MinId);
        }
        // end T001_min()


        [TestMethod]
        public void T002_checkSort()
        {
            int seed = 234511;
            Random random = new Random(seed);
            IIndexedMinPriortyQueue<int, double> queue = new IndexedMinPriorityQueue<int, double>();

            List<KeyValuePair> keys = new List<KeyValuePair>();

            int nElements = 3;
            for (int i = 0; i < nElements; i++)
            {
                keys.Add(new KeyValuePair(i, random.NextDouble()));
                queue.Insert(i, keys[i].Key);
                Assert.AreEqual(keys[i].Key, queue.KeyOf(i));
            }

            keys.Sort();

            for (int i = 0; i < nElements; i++)
            {
                Assert.AreEqual(keys[i].Id, queue.MinId);
                Assert.AreEqual(keys[i].Key, queue.MinKey);
                Assert.AreEqual(keys[i].Id, queue.DeleteMin());
            }
        }
        // end T002_testName()

        [TestMethod]
        public void T003_checkChange()
        {
            int seed = 234511;
            Random random = new Random(seed);

            IIndexedMinPriortyQueue<int, double> queue = new IndexedMinPriorityQueue<int, double>();

            List<KeyValuePair> keys = new List<KeyValuePair>();

            int nElements = 1029;
            for (int i = 0; i < nElements; i++)
            {
                keys.Add(new KeyValuePair(i, random.NextDouble()));
                queue.Insert(i, keys[i].Key);
            }

            // Change the values of 1/3 of the elements in the queue.
            for (int i = 0; i < nElements / 3; ++i)
            {
                keys[i].Key = random.NextDouble();
                queue.ChangeKey(i, keys[i].Key);
            }

            for (int i = 0; i < nElements; i++)
            {
                Assert.AreEqual(keys[i].Key, queue.KeyOf(i));
            }

            keys.Sort();

            for (int i = 0; i < nElements; i++)
            {
                Assert.AreEqual(keys[i].Id, queue.MinId);
                Assert.AreEqual(keys[i].Key, queue.MinKey);
                Assert.AreEqual(keys[i].Id, queue.DeleteMin());
            }
        }
        // end T003_testName()

        [TestMethod]
        public void T003_checkDelete()
        {
            int seed = 234511;
            Random random = new Random(seed);
            IIndexedMinPriortyQueue<int, double> queue = new IndexedMinPriorityQueue<int, double>();

            List<KeyValuePair> keys = new List<KeyValuePair>();

            int nElements = 1029;
            for (int i = 0; i < nElements; i++)
            {
                keys.Add(new KeyValuePair(i, random.NextDouble()));
                queue.Insert(i, keys[i].Key);
            }

            for (int i = 0; i < nElements / 3; ++i)
            {
                queue.Delete(i);
                keys.RemoveAt(0);
            }

            for (int i = 0; i < keys.Count; i++)
            {
                Assert.AreEqual(keys[i].Key, queue.KeyOf(keys[i].Id));
            }

            keys.Sort();

            for (int i = 0; i < keys.Count; i++)
            {
                Assert.AreEqual(keys[i].Id, queue.MinId);
                Assert.AreEqual(keys[i].Key, queue.MinKey);
                Assert.AreEqual(keys[i].Id, queue.DeleteMin());
            }
        }
        // end T003_testName()
    }

}
