using System;

namespace DequePersonalTest
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Test1");
            {
                //Deque<int> deque = new Deque<int>();

                //for (int i = 0; i < 80; i++)
                //{
                //    deque.PushBack(i);
                //    //deque.PushFront(i);
                //}

                //Console.WriteLine("Foreach:");
                //foreach (var item in deque)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();

                //Console.WriteLine("Indexer: ");
                //Console.WriteLine(deque[54]);
                //Console.WriteLine(deque[10]);
                //Console.WriteLine(deque[23]);
                //Console.WriteLine(deque[22]);
                //Console.WriteLine();

                //int[] array = new int[80];
                //deque.CopyTo(array, 0);
                //Console.WriteLine("CopyTo:");
                //foreach (var item in array)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();

                //Console.WriteLine("Contains:");
                //Console.WriteLine(deque.Contains(70));
                //Console.WriteLine(deque.Contains(90));
                //Console.WriteLine();

                //Console.WriteLine("Remove and insert:");
                //deque.RemoveAt(10);
                //deque.Insert(10, 10);
                //deque.RemoveAt(75);
                //deque.Insert(75, 75);
                //Console.WriteLine();

                //Console.WriteLine("Index of:");
                //Console.WriteLine(deque.IndexOf(42));
                //Console.WriteLine(deque.IndexOf(25));
                //Console.WriteLine(deque.IndexOf(31));
                //Console.WriteLine(deque.IndexOf(42));
                //Console.WriteLine();

                //Console.WriteLine("Reverse:");
                //var d = DequeTest.GetReverseView(deque);
                //foreach (var item in d)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();

            }

            Console.WriteLine("Test2");
            {
                //Deque<int> d = new Deque<int>();
                //d.Add(2);
                //for (int i = 0; i < 75; i++)
                //{
                //    d.PushFront(i);
                //}
                //Console.WriteLine(d.Count);
                //Console.WriteLine(d.IndexOf(250));
                //Console.WriteLine(d.Remove(250));
                //foreach (var item in d)
                //{
                //    Console.WriteLine(item);
                //}
                //for (int i = 0; i < d.Count; i++)
                //{
                //    Console.WriteLine(d[i]);
                //}
            }
            
            Console.WriteLine("Test3");
            {
                //Console.WriteLine("             Deque:");
                //Deque<string> d = new Deque<string>();
                //d.Add("Navzdy mlady");
                //for (int i = 0; i < 80; i++)
                //{
                //    d.Insert(1, $"{i}");
                //}

                //foreach (var item in d)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();


                //Console.WriteLine("             List:");
                //System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                //list.Add("Navzdy mlady");
                //for (int i = 0; i < 80; i++)
                //{
                //    list.Insert(1, $"{i}");
                //}

                //foreach (var item in list)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();
            }

            Console.WriteLine("Test4");
            {
                Deque<A> d = new Deque<A>();

                for (int i = 0; i < 80; i++)
                {
                    d.Add(new A(i));
                }

                foreach (var item in d)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Test5");
            {

            }
        }
    }
    
    class A
    {
        public int x;

        public A(int x)
        {
            this.x = x;
        }

        public override string ToString()
        {
            return $"{x*x}";
        }
    }
}
