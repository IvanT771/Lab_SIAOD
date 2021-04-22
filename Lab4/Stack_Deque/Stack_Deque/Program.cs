using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Deque
{
    class Program
    {
        static void S()
        {
            Stack stack = new Stack(10);

            stack.Push(5);
            stack.Push(52);

            Console.WriteLine(stack.Pop());
        }
        static void D()
        {
            Deque deque = new Deque(5);
            deque.PushStart(1);
            deque.PushEnd(5);
            deque.PushEnd(22);
            deque.PushStart(56);
            deque.PushStart(31);

            Console.WriteLine(deque.GetEnd());
            Console.WriteLine(deque.GetStart());
        }

        //Задача на составление максимального числа
        static void Task3()
        {
            int N = int.Parse(Console.ReadLine());
            string[] numbers = new string[N];

            for (int i = 0; i < N; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            for (int i = 0; i < N-1; i++)
            {
                for (int j = i+1; j < N; j++)
                {
                    if(Int64.Parse(numbers[i]+numbers[j]) < Int64.Parse(numbers[j] + numbers[i]))
                    {
                        var buf = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j]= buf;
                    }
                }
            }

            string result = "";
            for (int i = 0; i < N; i++)
            {
                result+=numbers[i];
            }

            Console.WriteLine(Int64.Parse(result));

        }

        static string ReverseStr(string str)
        {
            var b = "";
            for (int i = str.Length-1; i >= 0; i--)
            {
                b+=str[i];
            }
            return b;
        }

        //Task 6
        /// <summary>
        /// Задача 6. Дан файл из символов. Используя стек, за один просмотр файла напечатать
        /// сначала все цифры, затем все буквы, и, наконец, все остальные символы, сохраняя
        /// исходный порядок в каждой группе символов.
        /// </summary>
        static void T6()
        {
            string txt = "";
            string path = "text.txt";

            using (StreamReader f = new StreamReader(path))
            {
                txt = f.ReadToEnd();
            }

            if (txt.Length <= 0) { Console.WriteLine("file isEmpty!"); return;}

            Stack numbers = new Stack(txt.Length);
            Stack chars = new Stack(txt.Length);
            Stack other = new Stack(txt.Length);

            for (int i = 0; i < txt.Length; i++)
            {
                if(txt[i]>='0' && txt[i]<='9')
                {
                    numbers.Push(txt[i]);
                }
                else if((txt[i]>= 'a' && txt[i]<= 'z') || (txt[i] >= 'A' && txt[i] <= 'Z'))
                {
                    chars.Push(txt[i]);
                }
                else
                {
                    other.Push(txt[i]);
                }
            }

            string result = "";
            string buf = "";
            while (!numbers.isEmpty())
            {
                buf += (char)numbers.Pop();
            }

            result+=ReverseStr(buf);
            buf = "";

            while (!chars.isEmpty())
            {
                buf += (char)chars.Pop();
            }

            result += ReverseStr(buf);
            buf = "";

            while (!other.isEmpty())
            {
                buf += (char)other.Pop();
            }

            result += ReverseStr(buf);
            buf = "";

            Console.WriteLine("Result out:  "+result);
        }


        /// <summary>
        /// Задача 4. Дан текстовый файл с программой на алгоритмическом языке. За один просмотр
        /// файла проверить баланс круглых скобок в тексте, используя стек
        /// </summary>
        static void T4()
        {
            string path = "T4.txt";
            string txt = "";

            using (StreamReader f = new StreamReader(path))
            {
                txt = f.ReadToEnd();
            }
            if (txt.Length <= 0) { Console.WriteLine("file isEmpty!"); return; }

            Stack stack = new Stack(txt.Length);

            for (int i = 0; i < txt.Length; i++)
            {
                if(txt[i] == '(' || txt[i] == ')')
                {
                    stack.Push(txt[i]);
                }
            }

            int open = 0;
            int close = 0;

            while (!stack.isEmpty())
            {
                
                if ((char)stack.Pop() == '(')
                {
                    close++;
                }
                else
                {
                    open++;
                }

                if (close > open)
                {                    
                    break;
                }
                
            }

            if (close != open)
            {

                Console.WriteLine("Баланс скобок нарушен!");
            }
            else
            {
                Console.WriteLine("Баланс скобок НЕ нарушен!");
            }
           
        }

        /// <summary>
        /// Задача 5. Дан текстовый файл с программой на алгоритмическом языке. За один просмотр
        ///файла проверить баланс квадратных скобок в тексте, используя дек
        /// </summary>
        static void T5()
        {
            string path = "T5.txt";
            string txt = "";

            using (StreamReader f = new StreamReader(path))
            {
                txt = f.ReadToEnd();
            }
            if (txt.Length <= 0) { Console.WriteLine("file isEmpty!"); return; }

            Deque stack = new Deque(txt.Length);

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] == '[' || txt[i] == ']')
                {
                    stack.PushEnd(txt[i]);
                }
                
            }

            int open = 0;
            int close = 0;

            while (!stack.isEmpty())
            {

                if ((char)stack.GetEnd() == '[')
                {
                    close++;
                }
                else
                {
                    open++;
                }

                if (close > open)
                {
                    break;
                }

            }

            if (close != open)
            {

                Console.WriteLine("Баланс скобок нарушен!");
            }
            else
            {
                Console.WriteLine("Баланс скобок НЕ нарушен!");
            }
        }

        static void Main(string[] args)
        {
            //Task3();
            //T6();
            //T4();
            T5();


            Console.Read();
        }
    }
}
