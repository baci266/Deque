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
                //    Console.Write($"{d[i]} ");
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
                //Deque<A> d = new Deque<A>();

                //for (int i = 0; i < 80; i++)
                //{
                //    d.Add(new A(i));
                //}

                //foreach (var item in d)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();
            }

            Console.WriteLine("Test5");
            {
                //Deque<int> d = new Deque<int>();

                //for (int i = 0; i < 80; i++)
                //{
                //    d.Insert(0, i);
                //    d.RemoveAt(0);
                //}

                //foreach (var item in d)
                //{
                //    Console.Write($"{item} ");
                //}
            }

            Console.WriteLine("Test6");
            {
                //Deque<int> d = new Deque<int>();
                //for (int i = 0; i < 80; i++)
                //{
                //    d.Add(i);
                //}
                //foreach (var item in d)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();
                //Console.WriteLine($"Count: {d.Count}");
                //Console.WriteLine($"Index of 40: {d.IndexOf(40)}");

                //var d2 = DequeTest.GetReverseView(d);
                //foreach (var item in d2)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();
                //Console.WriteLine($"Count: {d2.Count}");
                //Console.WriteLine($"Index of 40: {d2.IndexOf(40)}");
                //for (int i = 0; i < d2.Count; i++)
                //{
                //    Console.WriteLine($"{i}-th item is: {d2[i]}");
                //}
                //Console.WriteLine();
            }

            Console.WriteLine("Test7");
            {
                //Deque<int> d = new Deque<int>();
                //for (int i = 0; i < 2000; i++)
                //{
                //    d.Add(i);
                //}

                //for (int i = 0; i < d.Count; i++)
                //{
                //    if (i%100 == 0)
                //        Console.WriteLine($"{i}-th item is: {d[i]}");
                //}

                //var d2 = DequeTest.GetReverseView(d);

                //for (int i = 0; i < 4000; i++)
                //{
                //    d2.Add(i);
                //}

                //for (int i = 0; i < d2.Count; i++)
                //{
                //    if (i % 100 == 0)
                //        Console.WriteLine($"{i}-th item is: {d2[i]}");
                //}
            }

            Console.WriteLine("Test8");
            {
                //Deque<string> d = new Deque<string>();
                //d.Add(null);
                //foreach (var item in d)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine(d.IndexOf(null));
                //for (int i = 0; i < 80; i++)
                //{
                //    d.Add(i.ToString());
                //}
                //foreach (var item in d)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();
                //for (int i = 0; i < d.Count; i++)
                //{
                //    Console.Write($"{d[i]} ");
                //}
                //Console.WriteLine();
                //Console.WriteLine(d.IndexOf("30"));
                //Console.WriteLine(d.IndexOf("55"));
                //Console.WriteLine();
                //var d2 = DequeTest.GetReverseView(d);
                //foreach (var item in d2)
                //{
                //    Console.Write($"{item} ");
                //}
                //Console.WriteLine();
                //for (int i = 0; i < d2.Count; i++)
                //{
                //    Console.Write($"{d2[i]} ");
                //}
                //Console.WriteLine();
                //Console.WriteLine(d2.IndexOf("30"));
                //Console.WriteLine(d2.IndexOf("55"));
            }

            Console.WriteLine("Test9");
            {
                //Deque<int> d = new Deque<int>();
                //for (int i = 0; i < 80; i++)
                //{
                //    d.PushBack(i);
                //}
                //for (int i = 0; i < 80; i++)
                //{
                //    Console.WriteLine("Removing: " + d[d.Count - 1]);
                //    d.RemoveAt(d.Count - 1);
                //}
                //for (int i = 0; i < 80; i++)
                //{
                //    d.PushBack(i);
                //}
                //for (int i = 0; i < 80; i++)
                //{
                //    Console.WriteLine("Removing: " + d[0]);
                //    d.RemoveAt(0);
                //}
                //foreach (var item in d)
                //{
                //    Console.WriteLine(item);
                //}
            }

            Console.WriteLine("Test10");
            {
                //Deque<int> d = new Deque<int>();
                //for (int i = 0; i < 80; i++)
                //{
                //    d.Add(i);
                //}
                //System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
                //for (int i = 0; i < 80; i++)
                //{
                //    l.Add(i);
                //}
                //Random rnd = new Random();
                //for (int i = 0; i < 50; i++)
                //{
                //    var x = rnd.Next(79-i);
                //    Console.WriteLine(l[x] + " " + d[x]);
                //    l.RemoveAt(x);
                //    d.RemoveAt(x);
                //    try
                //    {
                //        Console.WriteLine(l[x] + " " + d[x]);
                //    }
                //    catch
                //    {
                //        Console.WriteLine();
                //        continue;
                //    }
                //    Console.WriteLine();
                //}              
            }

            Console.WriteLine("Test11");
            {
                //Deque<A> d = new Deque<A>();
                //System.Collections.Generic.List<A> l = new System.Collections.Generic.List<A>();
                //for (int i = 0; i < 10000000; i++)
                //{
                //    d.Add(new A(i));
                //    l.Add(new A(i));
                //}
                //Console.WriteLine(d.Count == l.Count);
                //for (int i = 0; i < d.Count; i++)
                //{
                //    if (!d[i].Equals(l[i]))
                //        Console.WriteLine(i);
                //}
                //l.Reverse();
                //var d2 = DequeTest.GetReverseView(d);
                //Console.WriteLine(d2.Count == l.Count);
                //for (int i = 0; i < d2.Count; i++)
                //{
                //    if (!d2[i].Equals(l[i]))
                //        Console.WriteLine(i);
                //}
            }

            Console.WriteLine("Test12");
            {
                //Deque<int> d = new Deque<int>();
                //System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
                //for (int i = 0; i < 100000; i++)
                //{
                //    d.Insert(0, i);
                //    l.Insert(0, i);
                //}
                //Console.WriteLine(d.Count == l.Count);
                //for (int i = 0; i < d.Count; i++)
                //{
                //    if (d[i] != l[i])
                //        Console.WriteLine(i);
                //}
                //Random rnd = new Random();
                //for (int i = 0; i < 8000; i++)
                //{
                //    var x = rnd.Next(-100000, 100000);
                //    if (l.IndexOf(x) != d.IndexOf(x))
                //        Console.WriteLine(x);
                //}
            }

            Console.WriteLine("Final all-in big data vs list test");
            {
                //Deque<int> d = new Deque<int>();
                //System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
                //for (int i = 0; i < 5000; i++)
                //{
                //    d.Add(i);
                //    l.Add(i);
                //}
                //d.Clear();
                //l.Clear();
                //if (d.Count != l.Count)
                //    Console.WriteLine("Clear issue");
                //for (int i = 0; i < 100000; i++)
                //{
                //    d.Add(i);
                //    l.Add(i);
                //}
                //if (l.Count != d.Count)
                //    Console.WriteLine("Wrong Count");
                //for (int i = 0; i < d.Count; i++)
                //{
                //    if (d[i] != l[i])
                //        Console.WriteLine("Mismatch at " + i);
                //}
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //foreach (var item in l)
                //{
                //    sb.Append(item);
                //}
                //System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
                //foreach (var item in d)
                //{
                //    sb2.Append(item);
                //}
                //if (sb.ToString() != sb2.ToString())
                //    Console.WriteLine("Foreach error");
                //Random rnd = new Random();
                //int x;
                //for (int i = 0; i < 10000; i++)
                //{
                //    x = rnd.Next(-1000000, 1000000);
                //    if (d.IndexOf(x) != l.IndexOf(x))
                //        Console.WriteLine("Indexof mismatch in " + x);
                //    if (d.Contains(x) != l.Contains(x))
                //        Console.WriteLine("Contains mismatch in " + x);
                //}
                //try

                //{
                //    foreach (var item in d)
                //    {
                //        d.Add(item);
                //    }
                //    Console.WriteLine("SUCCESSFULY FAILED");
                //}
                //catch { }

                //for (int i = 0; i < 40000; i++)
                //{
                //    if (d.Remove(i) != l.Remove(i))
                //        Console.WriteLine("Remove mismatch at " + i);
                //}

                //for (int i = 0; i < 40000; i++)
                //{
                //    d.RemoveAt(0);
                //    l.RemoveAt(0);
                //}
                //if (d.Count != l.Count)
                //    Console.WriteLine("Wrong counts after RemoveAt test");
                //for (int i = 0; i < d.Count; i++)
                //{
                //    if (d[i] != l[i])
                //        Console.WriteLine("Mismatch after removeat at " + i);
                //}
                //if (d.Count != l.Count)
                //    Console.WriteLine("Wrong counts ending");
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

        public override bool Equals(object obj)
        {
            if (obj is A)
            {
                return (x == ((A)obj).x);
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
