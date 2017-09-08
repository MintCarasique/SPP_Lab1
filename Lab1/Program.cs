using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DynamicList<T>
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
        public bool Remove(T element)
        {
            return false;
        }
        public bool RemoveAt(int index)
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

    }
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();
            string choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("DynamicList TestCase:");
                Console.WriteLine("1 - Add Element");
                Console.WriteLine("2 - Print DynamicList");                
                Console.WriteLine("3 - Clear DynamicList");
                Console.WriteLine("4 - Delete element by index");
                Console.WriteLine("5 - Delete element");
                Console.WriteLine("0 - Exit"); 
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter value:");
                        int value = Convert.ToInt32(Console.ReadLine());
                        list.Add(value);
                        break;
                    case "2":
                        if (list.Count != 0)
                        {
                            for (int i = 0; i < list.Count; i++)
                                Console.Write(list[i] + " ");
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("Empty");
                        break;
                    case "3":
                        list.Clear();
                        Console.WriteLine("DynamicList cleared.");
                        break;
                    case "4":
                        Console.WriteLine("Enter index:");
                        int index = Convert.ToInt32(Console.ReadLine());
                        if (!list.RemoveAt(index))
                            Console.WriteLine("Wrong index. Element not found.");
                        break;
                }
            } while (choice != "0");
        }
    }
}
