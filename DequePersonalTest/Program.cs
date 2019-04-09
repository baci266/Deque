using System;
using DequeAPI;

namespace DequePersonalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();

            for (int i = 0; i < 80; i++)
            {
                //deque.PushBack(i);
                deque.PushFront(i);
            }

            Console.WriteLine("Foreach:");
            foreach (var item in deque)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine("Indexer: ");
            Console.WriteLine(deque[54]);
            Console.WriteLine(deque[10]);
            Console.WriteLine(deque[23]);
            Console.WriteLine(deque[22]);
            Console.WriteLine();

            int[] array = new int[80];
            deque.CopyTo(array, 0);
            Console.WriteLine("CopyTo:");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine("Contains:");
            Console.WriteLine(deque.Contains(70));
            Console.WriteLine(deque.Contains(90));
            Console.WriteLine();

            Console.WriteLine("Remove and insert:");
            deque.RemoveAt(10);
            deque.Insert(10, 10);
            deque.RemoveAt(75);
            deque.Insert(75, 75);
            Console.WriteLine();

            Console.WriteLine("Index of:");
            Console.WriteLine(deque.IndexOf(42));
            Console.WriteLine(deque.IndexOf(25));
            Console.WriteLine(deque.IndexOf(31));
            Console.WriteLine(deque.IndexOf(42));
            Console.WriteLine();

            Console.WriteLine("Reverse:");
            var d = DequeTest.GetReverseView(deque);
            foreach (var item in d)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
