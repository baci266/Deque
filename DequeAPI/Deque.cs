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
            BackDifference = DefaultChunkCapacity;
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

        public bool IsReadOnly { get; private set; } = false;

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
            if (IndexOf(item) != -1)
                return true;
            else
                return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException();

            int tmpInner = BackInnerIndex + 1;
            int tmpOuter = BackOuterIndex;
            if ( tmpInner == DefaultChunkCapacity)
            {
                tmpInner = 0;
                tmpOuter++;
            }
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = Holder.Data[tmpOuter, tmpInner];
                tmpInner++;
                if (tmpInner == DefaultChunkCapacity)
                {
                    tmpInner = 0;
                    tmpOuter++;
                }
            }
        }

        //TODO:
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            int tmpInner = BackInnerIndex + 1;
            int tmpOuter = BackOuterIndex;
            if (tmpInner == DefaultChunkCapacity)
            {
                tmpInner = 0;
                tmpOuter++;
            }
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(Holder.Data[tmpOuter, tmpInner]))
                    return i;
                tmpInner++;
                if (tmpInner == DefaultChunkCapacity)
                {
                    tmpInner = 0;
                    tmpOuter++;
                }
            }
            return -1;
        }

        //TODO:
        public void Insert(int index, T item)
        {
            if (IsReadOnly)
                throw new InvalidOperationException();

            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            if (index < Count / 2)
            {
                PushBack(this[0]);
                for (int i = 0; i < index; i++)
                {
                    this[i] = this[i + 1];
                }
                this[index] = item;
            }
            else
            {
                PushFront(this[0]);
                for (int i = Count - 1; i > index; i--)
                {
                    this[i] = this[i - 1];
                }
                this[index] = item;
            }
        }

        private void ShiftData(int EmptyIndex)
        {            
            if (EmptyIndex < Count / 2)
            {
                for (int i = EmptyIndex; i >= 1; i--)
                {
                    this[i] = this[i - 1];
                }
                Count--;
                BackInnerIndex++;
                BackDifference++;
                if (BackInnerIndex == DefaultChunkCapacity)
                {
                    BackInnerIndex = 0;
                    BackOuterIndex++;
                }
            }
            else
            {
                for (int i = EmptyIndex+1; i < Count; i++)
                {
                    this[i-1] = this[i];
                }
                Count--;
                FrontInnerIndex--;
                if (FrontInnerIndex == -1)
                {
                    FrontInnerIndex = DefaultChunkCapacity - 1;
                    FrontOuterIndex--;
                }
            }
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
                throw new InvalidOperationException();

            int index = IndexOf(item);

            if (index == -1)
                return false;
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
                throw new InvalidOperationException();

            ShiftData(index);
        }

        //TODO:
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
