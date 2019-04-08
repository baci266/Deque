using System;
using System.Collections;
using System.Collections.Generic;

namespace DequeAPI
{
    public sealed class Deque<T> : IList<T>
    {
        private const int DefaultChunkCapacity = 64;
        private const int DefaultChunkCount = 2;

        private int FrontOuterIndex;
        private int FrontInnerIndex;
        private int BackOuterIndex;
        private int BackInnerIndex;
        private int BackDifference;
        private bool Readonly = false;
        private DataHolder Holder;

        private struct DataHolder
        {
            internal T[,] Data;
        }

        public Deque()
        {
            FieldInit();
        }

        private void FieldInit()
        {
            Holder = new DataHolder
            {
                Data = new T[DefaultChunkCount, DefaultChunkCapacity]
            };
            BackDifference = 64;
            FrontInnerIndex = 0;
            BackInnerIndex = DefaultChunkCapacity - 1;
            FrontOuterIndex = 1;
            BackOuterIndex = 0;
        }

        public Deque(IEnumerable<T> items)
        {
            FieldInit();
            foreach (var item in items)
            {
                PushBack(item);
            }
        }

        public void PushFront(T item)
        {
            Count++;
            Holder.Data[FrontOuterIndex, FrontInnerIndex] = item;
            FrontInnerIndex++;
            if (FrontInnerIndex == DefaultChunkCapacity)
            {
                FrontInnerIndex = 0;
                FrontOuterIndex++;
                if (FrontOuterIndex == Holder.Data.GetLength(0))
                {
                    Expand(true);
                }
            }
        }

        public void PushBack(T item)
        {
            Count++;
            BackDifference--;
            Holder.Data[BackOuterIndex, BackInnerIndex] = item;
            BackInnerIndex--;
            if (BackInnerIndex < 0)
            {
                BackInnerIndex = DefaultChunkCapacity - 1;
                BackOuterIndex--;
                if (BackOuterIndex < 0)
                {
                    Expand(false);
                    //BackOuterIndex = (Queue.GetLength(0) / 4) - 1;
                }
            }
        }

        public void PopFront()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            Count--;
            FrontInnerIndex--;
            if (FrontInnerIndex < 0)
            {
                FrontInnerIndex = DefaultChunkCapacity - 1;
                FrontOuterIndex--;
            }
        }

        public void PopBack()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            BackDifference++;
            Count--;
            BackInnerIndex++;
            if (BackInnerIndex == DefaultChunkCapacity)
            {
                BackInnerIndex = 0;
                BackOuterIndex++;
            }
        }

        private void Expand(bool front)
        {
            int tmp = Count;
            var length = Holder.Data.GetLength(0);
            BackOuterIndex = length / 2 + BackOuterIndex;
            int frontOut =  (front) ? FrontOuterIndex : FrontOuterIndex + length/2;
            int frontIn = FrontInnerIndex;
            FrontOuterIndex = length / 2;
            FrontInnerIndex = (BackInnerIndex + 1) % DefaultChunkCapacity;
            DataHolder newData = Holder;
            Holder.Data = new T[length*2,DefaultChunkCapacity];
            foreach (var item in newData.Data)
            {
                PushFront(item);
                if (FrontOuterIndex == length / 2 + frontOut && FrontOuterIndex == frontIn)
                    break;
            }
            BackDifference = (DefaultChunkCapacity * length / 2) + (BackInnerIndex + 1) % DefaultChunkCapacity + BackOuterIndex * DefaultChunkCapacity;
            Count = tmp;
        }

        #region IList

        public T this[int index] { 
            get
            {
                index = CountActualIndex(index);

                return Holder.Data[index / DefaultChunkCapacity, index % DefaultChunkCapacity];
            }
            set
            {
                index = CountActualIndex(index);

                Holder.Data[index / DefaultChunkCapacity, index % DefaultChunkCapacity] = value;
            }
        }

        private int CountActualIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            return index + BackDifference;
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly
        {
            get => IsReadOnly;
            private set => IsReadOnly = value;
        }

        public void Add(T item)
        {
            if (IsReadOnly)
                throw new InvalidOperationException();

            PushBack(item);
        }

        public void Clear()
        {
            FrontInnerIndex = 0;
            BackInnerIndex = DefaultChunkCapacity - 1;
            FrontOuterIndex = Holder.Data.GetLength(0);
            BackOuterIndex = Holder.Data.GetLength(0) - 1;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
