﻿using System;
using System.Collections.Generic;
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
            Console.WriteLine(deque[54]);
            Console.WriteLine(deque[10]);
            Console.WriteLine(deque[23]);
            Console.WriteLine(deque[22]);
            int[] array = new int[80];
            deque.CopyTo(array, 0);
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            for (int i = 0; i < deque.Count; i++)
            {
                Console.Write($"{deque[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(deque.IndexOf(24));
            Console.WriteLine(deque.Contains(70));
            Console.WriteLine(deque.Contains(90));
            deque.RemoveAt(10);
            deque.Insert(10, 10);
            deque.RemoveAt(75);
            deque.Insert(75, 75);
            Console.ReadLine();
        }
    }
}
