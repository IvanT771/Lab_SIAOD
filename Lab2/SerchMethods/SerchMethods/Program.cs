using System;
using System.Collections;
using System.Collections.Generic;

namespace SerchMethods
{
    class Task1
    {
        public int BinarySerch(int[] array, int x)
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
        public int BinaryTreeSerch(int[] array, int x)
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
        public int FeebonachiSerch(int[] array, int x)
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
    class Program
    {
        static void PullArray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
              //  arr[i] = rnd.Next(0,100);
                arr[i] = i;
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[14];
            PullArray(arr);

            Task1 task1 = new Task1();
            //Бинарный поиск
            int index = task1.BinarySerch(arr,14);
            Console.WriteLine("BinarySerch: " + index);
            //Поиск деревом
            index = task1.BinaryTreeSerch(arr,12);
            Console.WriteLine("BinaryTreeSerch " + index);
            //Поиск Фибоначи
            index = task1.FeebonachiSerch(arr,14);
            Console.WriteLine("FibonachiSerch " + index);
            Console.Read();
        }
    }
}
