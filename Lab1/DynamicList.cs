using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DynamicList<T> : IEnumerable<T>
    {
        private T[] array = new T[0];
        public object this[int index]
        {
            get
            {
                if (IsInside(index))
                {
                    return array[index];
                }
                Count = 0;

                return null;
            }
            private set
            {
                if (IsInside(index))
                    array[index] = (T)value;
            }
        }

        public int Count { get; private set; }
        public void Add(T elem)
        {
            Count++;
            Array.Resize(ref array, Count);
            array[Count - 1] = elem;
        }
        private bool IsInside(int index)
        {
            if (index >= 0 || index < Count)
            {
                return true;
            }
            return false;
        }
        public void Remove(T element)
        {
            var i = 0;
            foreach (var item in array)
            {
                if (Equals(item, element))
                {
                    RemoveAt(i);
                }
                i++;
            }
        }
        public bool RemoveAt(long index)
        {
            if (!(index < 0 || index >= Count))
            {
                T[] tmp = new T[array.Length - 1];
                int j = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i != index)
                    {
                        tmp[j] = array[i];
                        j++;
                    }
                }
                array = tmp;
                Count--;
                return true;
            }
            else
                return false;
        }
        public void Clear()
        {
            array = null;
            Count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return array.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
