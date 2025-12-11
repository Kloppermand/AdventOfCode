// Pseudocode / Plan:
// 1. Implement a generic min-heap usable as `MinHeap<T>` where T : IComparable<T>.
// 2. Provide constructor with initial capacity parameter (used in Day8 as MinHeap<Edge>(edgeCount)).
// 3. Provide Insert(T item) to add an element and bubble it up to maintain heap invariant.
// 4. Provide Pop() to remove and return the minimum element, replacing root with last and heapifying down.
// 5. Provide Peek() and Count property for basic inspection.
// 6. Ensure capacity grows automatically if Insert exceeds initial capacity.
// 7. Keep implementation compact, efficient and thread-unsafe (sufficient for Advent of Code usage).

using System;

namespace Utilities
{
    /// <summary>
    /// Simple binary min-heap implementation.
    /// </summary>
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] _items;
        public int Count { get; private set; }

        public MinHeap(int capacity = 16)
        {
            if (capacity < 1) capacity = 16;
            _items = new T[capacity];
            Count = 0;
        }

        private void EnsureCapacity()
        {
            if (Count >= _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
        }

        public void Insert(T item)
        {
            EnsureCapacity();
            int i = Count;
            _items[Count++] = item;

            // Bubble up
            while (i > 0)
            {
                int parent = (i - 1) >> 1;
                if (_items[parent].CompareTo(_items[i]) <= 0) break;
                Swap(parent, i);
                i = parent;
            }
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty");
            T result = _items[0];
            Count--;
            if (Count > 0)
            {
                _items[0] = _items[Count];
                _items[Count] = default!;
                HeapifyDown(0);
            }
            else
            {
                _items[0] = default!;
            }
            return result;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty");
            return _items[0];
        }

        private void HeapifyDown(int i)
        {
            while (true)
            {
                int left = (i << 1) + 1;
                int right = left + 1;
                int smallest = i;

                if (left < Count && _items[left].CompareTo(_items[smallest]) < 0)
                    smallest = left;
                if (right < Count && _items[right].CompareTo(_items[smallest]) < 0)
                    smallest = right;

                if (smallest == i) break;
                Swap(i, smallest);
                i = smallest;
            }
        }

        private void Swap(int a, int b)
        {
            T tmp = _items[a];
            _items[a] = _items[b];
            _items[b] = tmp;
        }
    }
}