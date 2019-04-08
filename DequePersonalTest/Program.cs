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
                deque.PushBack(i);
                //deque.PushFront(i);
            }
            Console.WriteLine(deque[54]);
            Console.WriteLine(deque[10]);
            Console.WriteLine(deque[23]);
            Console.WriteLine(deque[22]);
            Console.ReadLine();
        }
    }
}
