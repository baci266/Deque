using System;
using System.Collections;
using System.Collections.Generic;

namespace DequeAPI
{

    public sealed class Deque<T> : IList<T>
    {
        private const int DefaultChunkCapacity = 64;
        private const int DefaultChunkCount = 2;

        private Index I;
        private DataHolder Holder;

        private struct DataHolder
        {
            internal T[,] Data;
        }

        public Deque()
        {
            FieldInit();
        }

        public Deque(IEnumerable<T> items)
        {
            FieldInit();
            foreach (var item in items)
            {
                PushBack(item);
            }
        }

        private Deque(Deque<T> other)
        {
            int front_diff = DefaultChunkCapacity - other.I.FrontInnerIndex + (other.Holder.Data.GetLength(0) - other.I.FrontOuterIndex - 1) * DefaultChunkCapacity;
            I = new Index
            {
                BackDifference = front_diff,
                BackInnerIndex = other.I.FrontInnerIndex - 1,
                BackOuterIndex = other.I.FrontOuterIndex,
                FrontInnerIndex = other.I.FrontInnerIndex,
                FrontOuterIndex = other.I.FrontOuterIndex
            };
            if (I.BackInnerIndex == -1)
            {
                I.BackInnerIndex = DefaultChunkCapacity - 1;
                I.BackOuterIndex--;
            }
            Holder = new DataHolder();
            Holder.Data = new T[other.Holder.Data.GetLength(0), DefaultChunkCapacity];
            Count = other.Count;
            foreach(var item in other)
            {
                PushBack(item);
            }
        }

        private void FieldInit()
        {
            Holder = new DataHolder
            {
                Data = new T[DefaultChunkCount, DefaultChunkCapacity]
            };
            I = new Index
            {
                BackDifference = DefaultChunkCapacity,
                FrontInnerIndex = 0,
                BackInnerIndex = DefaultChunkCapacity - 1,
                FrontOuterIndex = 1,
                BackOuterIndex = 0
            };
        }

        public void PushFront(T item)
        {
            Count++;
            Holder.Data[I.FrontOuterIndex, I.FrontInnerIndex] = item;
            I.FrontInnerIndex++;
            if (I.FrontInnerIndex == DefaultChunkCapacity)
            {
                I.FrontInnerIndex = 0;
                I.FrontOuterIndex++;
                if (I.FrontOuterIndex == Holder.Data.GetLength(0))
                {
                    Expand(true);
                }
            }
        }

        public void PushBack(T item)
        {
            Count++;
            I.BackDifference--;
            Holder.Data[I.BackOuterIndex, I.BackInnerIndex] = item;
            I.BackInnerIndex--;
            if (I.BackInnerIndex < 0)
            {
                I.BackInnerIndex = DefaultChunkCapacity - 1;
                I.BackOuterIndex--;
                if (I.BackOuterIndex < 0)
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
            I.FrontInnerIndex--;
            if (I.FrontInnerIndex < 0)
            {
                I.FrontInnerIndex = DefaultChunkCapacity - 1;
                I.FrontOuterIndex--;
            }
        }

        public void PopBack()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            I.BackDifference++;
            Count--;
            I.BackInnerIndex++;
            if (I.BackInnerIndex == DefaultChunkCapacity)
            {
                I.BackInnerIndex = 0;
                I.BackOuterIndex++;
            }
        }

        private void Expand(bool front)
        {
            int tmp = Count;
            var length = Holder.Data.GetLength(0);
            I.BackOuterIndex = length / 2 + I.BackOuterIndex;
            int frontOut =  (front) ? I.FrontOuterIndex : I.FrontOuterIndex + length/2;
            int frontIn = I.FrontInnerIndex;
            I.FrontOuterIndex = length / 2;
            I.FrontInnerIndex = (I.BackInnerIndex + 1) % DefaultChunkCapacity;
            DataHolder newData = Holder;
            Holder.Data = new T[length*2,DefaultChunkCapacity];
            foreach (var item in newData.Data)
            {
                PushFront(item);
                if (I.FrontOuterIndex == length / 2 + frontOut && I.FrontOuterIndex == frontIn)
                    break;
            }
            I.BackDifference = (DefaultChunkCapacity * length / 2) + (I.BackInnerIndex + 1) % DefaultChunkCapacity + I.BackOuterIndex * DefaultChunkCapacity;
            Count = tmp;
        }

        private void DisableReadOnly()
        {
            IsReadOnly = false;
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

            return index + I.BackDifference;
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
            I.FrontInnerIndex = 0;
            I.BackInnerIndex = DefaultChunkCapacity - 1;
            I.FrontOuterIndex = Holder.Data.GetLength(0);
            I.BackOuterIndex = Holder.Data.GetLength(0) - 1;
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

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            IsReadOnly = true;
            return new Dequemerate<T>(Holder.Data, DisableReadOnly, I);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(this[i]))
                    return i;
            }
            return -1;
        }

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
                I.BackInnerIndex++;
                I.BackDifference++;
                if (I.BackInnerIndex == DefaultChunkCapacity)
                {
                    I.BackInnerIndex = 0;
                    I.BackOuterIndex++;
                }
            }
            else
            {
                for (int i = EmptyIndex+1; i < Count; i++)
                {
                    this[i-1] = this[i];
                }
                Count--;
                I.FrontInnerIndex--;
                if (I.FrontInnerIndex == -1)
                {
                    I.FrontInnerIndex = DefaultChunkCapacity - 1;
                    I.FrontOuterIndex--;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            IsReadOnly = true;
            return new Dequemerate<T>(Holder.Data, DisableReadOnly, I);
        }

        internal Deque<T> GetReverseView()
        {
            if (IsReadOnly)
                throw new InvalidOperationException();

            return new Deque<T>(this);
        }

        #endregion
    }

    internal struct Index
    {
        internal int FrontOuterIndex;
        internal int FrontInnerIndex;
        internal int BackOuterIndex;
        internal int BackInnerIndex;
        internal int BackDifference;

        public Index(int frontOuterIndex, int frontInnerIndex, int backOuterIndex, int backInnerIndex, int backDifference)
        {
            FrontOuterIndex = frontOuterIndex;
            FrontInnerIndex = frontInnerIndex;
            BackOuterIndex = backOuterIndex;
            BackInnerIndex = backInnerIndex;
            BackDifference = backDifference;
        }
    }

    public sealed class Dequemerate<T> : IEnumerator<T>
    {
        private const int DefaultChunkCapacity = 64;

        private readonly T[,] Data;
        private readonly Action DisableReadonly;
        private readonly Index Indices;
        private int InnerPosition;
        private int OuterPosition;
        
        internal Dequemerate(T[,] data, Action disableReadonly, Index indices)
        {
            Data = data;
            DisableReadonly = disableReadonly;
            Indices = indices;
            InnerPosition = Indices.BackInnerIndex;
            OuterPosition = Indices.BackOuterIndex;
        }

        public T Current
        {
            get
            {
               return Data[OuterPosition, InnerPosition];
            }
        }
        
        object IEnumerator.Current => Current;

        public void Dispose() {}

        public bool MoveNext()
        {
            InnerPosition++;
            if (InnerPosition == DefaultChunkCapacity)
            {
                InnerPosition = 0;
                OuterPosition++;
            }
            if (InnerPosition == Indices.FrontInnerIndex && OuterPosition == Indices.FrontOuterIndex)
            {
                DisableReadonly();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            InnerPosition = Indices.BackInnerIndex;
            OuterPosition = Indices.BackOuterIndex;
        }
    }

    public static class DequeTest
    {
        public static IList<T> GetReverseView<T>(Deque<T> d)
        {
            var deque = d.GetReverseView();
            return deque;
        }
    }
}
