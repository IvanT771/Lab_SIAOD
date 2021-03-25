using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;

namespace SerchMethods
{
    class Task1
    {
        public int BinarySearch(int[] array, int x)
        {
            Array.Sort(array);

            int i = 0;
            int j = array.Length-1;

            while (i < j)
            {
                int m = (i+j)/2;
                if (x > array[m])
                {
                    i = m+1;
                }
                else
                {
                    j = m;
                }

                if(array[j] == x)
                {
                    return j;
                }

            }
            return -1;
        }
        public int BinaryTreeSearch(int[] array, int x)
        {
            BinaryTree1 binaryTree = new BinaryTree1();
            //Заполняем дерево
            for (int i = 0; i < array.Length; i++)
            {
               binaryTree.Add(array[i]);
            }
            
            return binaryTree.Serch(x);
        }
        private void pullFib(int[] fib)
        {
            if (fib.Length > 2) { 
                fib[0] = 0;
                fib[1] = 1;
                fib[2] = 2;
            }
            else
            {
                for(int i=0; i < fib.Length; i++)
                {
                    fib[i] = i;
                }
                return;
            }
            for(int i = 3; i<fib.Length; i++)
            {
                fib[i] = fib[i-2]+fib[i-1];
            }
        }
        public int FeebonachiSearch(int[] array, int x)
        {
            Array.Sort(array);

            int[] fib = new int[array.Length];
            pullFib(fib);
            int i = 0;
            int start = 0;
            while (true)
            {
                if(start+fib[i] >= array.Length) {

                    if (start >= array.Length) { return -1;}
                    if (i < 1) { return -1; }
                    if (fib[i] - fib[i - 1] <= 1) { return -1; }
                    start += fib[i-1];
                    i=0;}

                if (x == array[start+fib[i]]) { return start+fib[i];}

                if (x > array[start+fib[i]])
                {
                    i++;
                }
                else
                {
                    if (i < 1) { return -1;}
                    if (fib[i] - fib[i - 1] <= 1) { return -1; }

                    start += fib[i - 1];
                    i=0;
                }
            }
            
        }
        public int InterpolationSearch(int[] array, int x)
        {
            Array.Sort(array);
            int start = 0;
            int end = array.Length-1;

            while (start<x && end>x)
            {
                int d = start+((end-start)*(x-array[start]))/(array[end]-array[start]);

                if(array[d] == x) { return d;}

                if (array[d] > x)
                {
                    end = d-1;
                }
                else
                {
                    start = d+1;
                }
            }
            return -1;
        }
        class BinaryTree1
        {
            private int _root;
            private bool isTree;
            private BinaryTree1 leftTree;
            private  BinaryTree1 rightTree;

           public BinaryTree1()
            {
                this._root = 0;
                this.isTree = false;
                
            }

            public int Serch(int element)
            {
                int el = -1;
                if (!isTree) { return -1;}
                if(_root == element) { return _root;}

                if (element > _root)
                {
                    if(rightTree == null)
                    {
                        return -1;
                    }
                    
                   el = rightTree.Serch(element);
                }else
                {
                    if(leftTree == null)
                    {
                        return -1;
                    }
                    el = leftTree.Serch(element);
                }

                return el;
            }
            public void Add(int element)
            {
                if (!isTree)
                {
                    _root = element;
                    isTree = true;
                }
                else
                {
                    if (element > _root)
                    {
                        if (rightTree == null)
                        {
                            rightTree = new BinaryTree1();
                        }
                        rightTree.Add(element);
                    }
                    else
                    {
                        if (leftTree == null)
                        {
                            leftTree = new BinaryTree1();
                        }

                        leftTree.Add(element);
                    }
                }
            }
           
         
        }

    }
    class Task2
    {
        public void SearchHash(int value)
        {
            SimplHash simplHash = new SimplHash(100);

            for (int i = 0; i < 50; i++)
            {
                simplHash.Add(i);
            }
            Console.WriteLine("Search Hash get key = "+simplHash.GetKey(value));

        }
        class SimplHash
        {
            
            private int[] map;
           public SimplHash(int size)
            {
                map = new int[size];

                for (int i = 0; i < map.Length; i++)
                {
                    map[i] = -1;
                }
            }
            int Hash(int key,int layer)
            {
               
                return ((key+layer)%map.Length);
            }

            public void Add(int value)
            {
                int layer = 0;
                int h = Hash(value,layer);

                if(map[h] == -1)
                {
                    map[h] = value;
                }
                else
                {
                    for (int i = 1; i < map.Length; i++)
                    {
                        if(Hash(value,i) == h)
                        {
                            throw new OutOfMemoryException();
                        }
                        if (map[Hash(value, i)] != -1)
                        {
                            map[h] = value;
                            return;
                        }
                    }
                }
            }
            public int SearchKey(int key)
            {
                if(key<0 || key >= map.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return map[key];
            }
            public int SearchValue(int value)
            {
                int layer = 0;
                int h = Hash(value,layer);

                if(map[h] == value) { return value;}

                for (int i = 1; i < map.Length; i++)
                {
                    if (Hash(value, i) == h)
                    {
                        return -1;
                    }
                    if (map[Hash(value, i)] == value)
                    {
                        
                        return value;
                    }
                }

                return -1;
            }
            public int GetKey(int value)
            {
                int layer = 0;
                int h = Hash(value, layer);

                if (map[h] == value) { return h; }

                for (int i = 1; i < map.Length; i++)
                {
                    if (Hash(value, i) == h)
                    {
                        return -1;
                    }
                    if (map[Hash(value, i)] == value)
                    {

                        return Hash(value, i);
                    }
                }

                return -1;
            }
            public void RemoveValue(int value)
            {
                int layer = 0;
                int h = Hash(value, layer);

                if (map[h] == value) { map[h] =-1; }

                for (int i = 0; i < map.Length; i++)
                {
                    if (Hash(value, i) == h)
                    {
                        return;
                    }
                    if (map[Hash(value, i)] == value)
                    {

                        map[Hash(value, i)] = -1;
                    }
                }
            }

        }
    }
    class Program
    {
        static void PullArray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0,10000);
                //arr[i] = i;
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[100000];
            PullArray(arr);
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();

            Task1 task1 = new Task1();
            int index = 0;
            //Бинарный поиск
            myStopwatch.Start();
            // index = task1.BinarySearch(arr,12);
            myStopwatch.Stop();
            Console.WriteLine("BinarySerch: " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds+" ms");

            //Поиск деревом
            myStopwatch.Reset();
            myStopwatch.Start();
            index = task1.BinaryTreeSearch(arr,12);
            myStopwatch.Stop();
            Console.WriteLine("BinaryTreeSerch " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");

            //Поиск Фибоначи
            myStopwatch.Reset();
            myStopwatch.Start();
            index = task1.FeebonachiSearch(arr,12);
            myStopwatch.Stop();
            Console.WriteLine("FibonachiSerch " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");

            //Интерполяционный поиск
            myStopwatch.Reset();
            myStopwatch.Start();
            index = task1.InterpolationSearch(arr,12);
            myStopwatch.Stop();
            Console.WriteLine("InterpolationSerch " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");

            //Простое рехеширование
            Task2 task2 = new Task2();

            myStopwatch.Reset();
            myStopwatch.Start();
            task2.SearchHash(10);
            myStopwatch.Stop();
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");
            Console.Read();
        }
    }
}
