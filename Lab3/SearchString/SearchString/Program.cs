using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchString
{
    class Program
    {
        #region Algoritm-Knyta
        static int[] GetPrefix(string s)
        {
            int[] result = new int[s.Length];
            result[0] = 0;
            int index = 0;

            for (int i = 1; i < s.Length; i++)
            {
                while (index >= 0 && s[index] != s[i]) { index--; }
                index++;
                result[i] = index;
            }

            return result;
        }

        static int FindSubstring(string pattern, string text, out float time)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            int[] pf = GetPrefix(pattern);
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (index > 0 && pattern[index] != text[i]) { index = pf[index - 1]; }
                if (pattern[index] == text[i]) index++;
                if (index == pattern.Length)
                {
                    myStopwatch.Stop();
                    time = myStopwatch.ElapsedMilliseconds;
                    return (i - index + 1);
                }
            }
            myStopwatch.Stop();
            time = myStopwatch.ElapsedMilliseconds;

            return -1;
        }
        #endregion

        #region Algoriym Boyera-Moore

        public static int[] tableshift;

        ///<summary>Составление таблицы смещений</summary>
        ///<param name="readtemplate">Введнный шаблон</param>
        public static void TableShift(string readtemplate)
        {
            tableshift = new int[char.MaxValue];

            for (int i = 0; i < tableshift.Length; i++)
            {
                tableshift[i] = readtemplate.Length;
            }

            for (int i = 0; i < readtemplate.Length; i++)
            {
                tableshift[readtemplate[i]] = readtemplate.Length - i;
            }
        }

        ///<summary>Собственно, сам алгоритма Бойера-Мура</summary>
        ///<param name="text">Введенная исходная строка</param>
        ///<param name="pattern">Введенный шаблон</param>
        ///<param name="sensitivity">Чувствительность к регистру</param>
        public static int BoyerMoore(string pattern, string text, out float time)
        {
            var source = text;
            var template = pattern;

            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();


            TableShift(template); //инициализация таблици

            if (template.Length > source.Length)
            {
                time = 0;
                return -1;
            }

            if (template == source)
            {
                Console.WriteLine("Шаблон и исходная строка равны");
                time = 0;
                return -1;
            }

            for (int i = template.Length; i < source.Length + 1;)                        
            {
                for (int j = template.Length - 1; j >= 0; j--)                          
                {
                    if (template[j] == source[i - template.Length + j])                   
                    {
                        if (j == 0)                                                      
                        {

                            myStopwatch.Stop();
                            time = myStopwatch.ElapsedMilliseconds;
                            return ((i - template.Length));
                        }
                    }
                    else
                    {
                        i += tableshift[source[i]];
                        break;
                    }
                }
            }
            myStopwatch.Stop();
            time = myStopwatch.ElapsedMilliseconds;
            return -1;
        }
        #endregion

        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            Console.Write("Введите подстроку: ");
            string pattern = Console.ReadLine();
            Console.Write("Чувствительность к регистру?(yes/no): ");
            string register = Console.ReadLine();

            if (register.Contains("no"))
            {
                text = text.ToLower();
                pattern = pattern.ToLower();
            }

            float timeWorck = 0;


            Console.WriteLine("");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Алгоритм Кнута-Морриса-Пратта");
            Console.WriteLine("Индекс первого вхождения: " + FindSubstring(pattern,text,out timeWorck));
            Console.WriteLine("Время работы алгоритма: "+timeWorck+"ms");

            Console.WriteLine("");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Алгоритм Бойера-Мура");
            Console.WriteLine("Индекс первого вхождения: " + BoyerMoore(pattern, text, out timeWorck));
            Console.WriteLine("Время работы алгоритма: " + timeWorck + "ms");

            Console.ReadKey();

        }
    }
}
