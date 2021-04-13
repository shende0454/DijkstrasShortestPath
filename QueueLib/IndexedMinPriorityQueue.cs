using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    public class IndexedMinPriorityQueue<IdType, KeyType> : IIndexedMinPriortyQueue<IdType, KeyType> 
        where KeyType : IComparable<KeyType>
        where IdType : IEquatable<IdType>
    {
        class QueueEntry
        {
            public QueueEntry(IdType id, KeyType key)
            {
                Key = key;
                Id = id;
            }

            public KeyType Key;
            public IdType Id;
        }

        List<QueueEntry> _priorityQueue = new List<QueueEntry>();
        Dictionary<IdType, int> _idToQueueIndex = new Dictionary<IdType, int>();

        public IndexedMinPriorityQueue()
        {
            // Burn the 0th element.
            _priorityQueue.Add(new QueueEntry(default(IdType), default(KeyType)));
        }

        public int NextAvailableQueueIndex
        {
            get { return _priorityQueue.Count; }
        }

        public KeyType MinKey 
        { 
            get
            {
                return _priorityQueue[1].Key;
            }
        }

        public IdType MinId 
        { 
            get
            {
                return _priorityQueue[1].Id;
            }
        }

        public int NKeysInQueue 
        { 
            get
            {
                return _priorityQueue.Count - 1;
            }
        }

        public void ChangeKey(IdType id, KeyType newKey)
        {
            int index = _idToQueueIndex[id];

            // Update the key value
            _priorityQueue[index].Key = newKey;

            Swim(index);

            // Where am I now? (after swimming)
            index = _idToQueueIndex[id];

            // Sink as far as necessary.
            Sink(index);
        }


        void Sink(int sinkerIndex)
        {
            bool doneSinking = false;

            // While not done sinking and have at least one child.
            while (!doneSinking && 2 * sinkerIndex < _priorityQueue.Count)
            {
                int smallerSoFar = sinkerIndex * 2;
                int secondChild = smallerSoFar + 1;

                // Set smaller so far to the smaller of the two children
                if (secondChild < _priorityQueue.Count &&
                    _priorityQueue[smallerSoFar].Key.CompareTo(_priorityQueue[secondChild].Key) > 0)
                {
                    smallerSoFar = secondChild;
                }

                // Compare the parent with the smaller of the children
                if (_priorityQueue[sinkerIndex].Key.CompareTo(_priorityQueue[smallerSoFar].Key) > 0)
                {
                    // Child is smaller - swap
                    SwapQueuePositions(sinkerIndex, smallerSoFar);
                    sinkerIndex = smallerSoFar;
                }
                else
                {
                    // Parent is smaller - done sinking.
                    doneSinking = true;
                }
            }
        }

        public bool Contains(IdType id)
        {
            // Look up the id in the idToQueueIndex dictionary.
            return _idToQueueIndex.ContainsKey(id);
        }

        public void Delete(IdType id)
        {
            // Find the item in the heap
            int index = _idToQueueIndex[id];

            // Swap the last item in the heap with the item that we are deleting
            SwapQueuePositions(index, _priorityQueue.Count - 1);

            // Remove the deleted item.
            _priorityQueue.RemoveAt(_priorityQueue.Count - 1);
            _idToQueueIndex.Remove(id);

            IdType idOfReplacement = _priorityQueue[index].Id;

            // Swim as high as we can.
            Swim(index);

            // Find the new location after swimming
            int indexOfReplacement = _idToQueueIndex[idOfReplacement];

            // Sink as low as we can.
            Sink(indexOfReplacement);
        }

        public IdType DeleteMin()
        {
            // Find the Id of the first item in the priority queue
            // Remove that id from the dictionary.
            IdType idOfMin = _priorityQueue[1].Id;
            _idToQueueIndex.Remove(idOfMin);

            // If the queue has more than one item.
            // Move the last item in the heap to the top of the heap
            // if (NKeysInQueue > 1)
            {
                // Copy the last item in the heap to the first position.
                IdType idOfLast = _priorityQueue[_priorityQueue.Count - 1].Id;
                _priorityQueue[1] = _priorityQueue[_priorityQueue.Count - 1];
                _idToQueueIndex[idOfLast] = 1;
            }

            // Remove the last item from the heap
            _priorityQueue.RemoveAt(_priorityQueue.Count - 1);

            // Sink the item that we just moved to the top of the queue
            Sink(1);

            return idOfMin;
        }

        public void SwapQueuePositions(int firstIndex, int secondIndex)
        {
            QueueEntry temp = _priorityQueue[firstIndex];
            _priorityQueue[firstIndex] = _priorityQueue[secondIndex];
            _priorityQueue[secondIndex] = temp;

            // Update the dictionary entries 
            _idToQueueIndex[_priorityQueue[firstIndex].Id] = firstIndex;
            _idToQueueIndex[_priorityQueue[secondIndex].Id] = secondIndex;
        }

        public void Swim(int swimmerIndex)
        {
            while (swimmerIndex > 1 &&
                _priorityQueue[swimmerIndex].Key.CompareTo(_priorityQueue[swimmerIndex / 2].Key) < 0)
            {
                SwapQueuePositions(swimmerIndex, swimmerIndex / 2);
                swimmerIndex = swimmerIndex / 2;
            }
        }

        public void Insert(IdType id, KeyType key)
        {
            if (!_idToQueueIndex.ContainsKey(id))
            {
                int index = NextAvailableQueueIndex;

                _idToQueueIndex.Add(id, index);

                // Add to the end of the queue
                _priorityQueue.Add(new QueueEntry(id, key));

                Swim(index);
            }
            else
            {
                throw new Exception(String.Format("Insert: id {0} is already in the queue.",
                    id));
            }
        }

        public bool IsEmpty()
        {
            return _priorityQueue.Count == 1;
        }

        public KeyType KeyOf(IdType id)
        {
            // Find the index with the id
            int index = _idToQueueIndex[id];

            // Return the key.
            return _priorityQueue[index].Key;
        }
    }
}
