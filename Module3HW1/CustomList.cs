using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Module2HW2
{
    public class CustomList<T> : ICollection<T>
    {
        private T[] _listContent;

        public CustomList()
        {
            Capacity = 1;
            Size = 0;
            Count = 0;
            _listContent = new T[Capacity];
        }

        public int Capacity { get; private set; }
        public int Size { get; private set; }
        public int Count { get; set; }
        public bool IsReadOnly { get; }

        public T this[int index]
        {
            get { return _listContent[index]; }
            set { _listContent[index] = value; }
        }

        public void Add(T item)
        {
            if (Size + 1 < _listContent.Length)
            {
                _listContent[Size] = item;
                Size++;
                Count++;
            }
            else
            {
                ResizeArrayAndAdd(ref _listContent, item);
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Sort()
        {
            Array.Sort(_listContent, new ArrayContentComparer<T>());
        }

        public void Clear()
        {
            _listContent = new T[4];
            Capacity = 4;
            Size = 0;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return _listContent.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_listContent, 0, array, arrayIndex, Size);
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf(_listContent, item);
            RemoveAt(index);
            Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            Size--;
            Count--;
            Array.Copy(_listContent, index + 1, _listContent, index, Size - index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _listContent.Length; i++)
            {
                yield return _listContent[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ResizeArrayAndAdd(ref T[] items, T item)
        {
            Capacity = Capacity * 2;
            Array.Resize(ref items, Capacity);
            Add(item);
        }
    }
}