using System;
using System.Collections.Generic;
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

            Console.WriteLine(stack.Get());
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

        static void Main(string[] args)
        {

            Task3();
            Console.Read();
        }
    }
}
