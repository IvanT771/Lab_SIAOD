using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Deque
{
    public class Stack
    {
        private int currentIndex=0;
        private int[] array;

        public Stack(int size)
        {
            if (size <= 0) { size = 100;}
            array = new int[size];
            currentIndex = 0;
        }

        //Операция добавления элемента в стэк
        public void Push(int args)
        {
            if (array.Length <= currentIndex) { Console.WriteLine("Stack full!!!"); return; }

            array[currentIndex] = args;
            currentIndex++;
        }

        //Операция удаления последнего элемента
        public void Delete()
        {
            if ((currentIndex-1) < 0) { Console.WriteLine("Stack is empty!"); return; }
            currentIndex--;
        }

        //Операция получения элемента
        public int Peek()
        {
            if (currentIndex <= 0) { Console.WriteLine("Stack is empty!");  return 0;}
            return array[currentIndex-1];
        }

        //Операция получения элемента и его удаления
        public int Pop()
        {
            if (currentIndex <= 0) { Console.WriteLine("Stack is empty!"); return 0; }
            currentIndex--;
            return array[currentIndex];
        }

        //Операция получения размера стека
        public int GetLength()
        {
            return currentIndex;
        }

        //Операция проверки на пустоту
        public bool isEmpty()
        {
            if (currentIndex <= 0) { return true;}
            return false;
        }
    }
    public class Deque
    {
        private int indexEnd = 0;
        private int indexStart = 0;
        private int[] array;

        public Deque(int size)
        {
            if (size <= 0) { size = 100; }
            array = new int[size];
            indexEnd = 0;
        }

        //Операция добавления элемента в конец
        public void PushEnd(int args)
        {
            if (array.Length <= (indexEnd)) { Console.WriteLine("Stack full!!!"); return; }

            array[indexEnd] = args;
            indexEnd++;
        }

        //Операция добавления элемента в начало
        public void PushStart(int args)
        {
            if (array.Length <= (indexEnd+1)) { Console.WriteLine("Stack full!!!"); return; }

            if (!isEmpty()) { 
            for (int i = indexEnd; i>=1; i--)
            {
                array[i+1] = array[i];

            }
            }
            array[0] = args;  
            indexEnd++;
        }

        //Операция удаления последнего элемента
        public void DeleteEnd()
        {
            if (isEmpty()) { Console.WriteLine("Stack is empty!"); return; }
            indexEnd-=1;
            indexEnd = Math.Max(0,indexEnd);
        }

        //Операция получения последнего элемента
        public int GetEnd()
        {
            if (indexEnd-1 < 0) { Console.WriteLine("Stack is empty!"); return 0; }
            indexEnd--;
            return array[indexEnd];
        }

        //Операция получения первого элемента
        public int GetStart()
        {
            if (isEmpty()) { Console.WriteLine("Stack is empty!"); return 0; }

            var buf= array[0];
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i+1];
            }
            indexEnd--;
            return buf;
        }

        public int GetLength()
        {
            return indexEnd;
        }

        //Операция проверки на пустоту
        public bool isEmpty()
        {
            if (indexEnd-1 < 0) { return true; }
            return false;
        }
    }
}
