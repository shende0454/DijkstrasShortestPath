using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    public interface IIndexedMinPriortyQueue<IdType, KeyType> 
        where KeyType : IComparable<KeyType>
        where IdType : IEquatable<IdType>
    {
        // Insert key into the priority queue
        // Provide an id so that we can update that item if necessary
        void Insert(IdType id, KeyType key);

        // Change a key in a item that is already in the queue
        void ChangeKey(IdType id, KeyType newKey);

        bool Contains(IdType id);

        void Delete(IdType id);

        KeyType MinKey { get;  }

        IdType MinId { get;  }

        IdType DeleteMin();

        bool IsEmpty();

        int NKeysInQueue { get;  }

        KeyType KeyOf(IdType id);
    }
}
