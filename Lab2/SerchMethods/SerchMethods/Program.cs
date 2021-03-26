using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SerchMethods
{
    class Task1
    {
        public int BinarySearch(int[] array, int x)
        {
            Array.Sort(array);

            int i = 0;
            int j = array.Length - 1;

            while (i < j)
            {
                int m = (i + j) / 2;
                if (x > array[m])
                {
                    i = m + 1;
                }
                else
                {
                    j = m;
                }

                if (array[j] == x)
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
            if (fib.Length > 2)
            {
                fib[0] = 0;
                fib[1] = 1;
                fib[2] = 2;
            }
            else
            {
                for (int i = 0; i < fib.Length; i++)
                {
                    fib[i] = i;
                }
                return;
            }
            for (int i = 3; i < fib.Length; i++)
            {
                fib[i] = fib[i - 2] + fib[i - 1];
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
                if (start + fib[i] >= array.Length)
                {

                    if (start >= array.Length) { return -1; }
                    if (i < 1) { return -1; }
                    if (fib[i] - fib[i - 1] <= 1) { return -1; }
                    start += fib[i - 1];
                    i = 0;
                }

                if (x == array[start + fib[i]]) { return start + fib[i]; }

                if (x > array[start + fib[i]])
                {
                    i++;
                }
                else
                {
                    if (i < 1) { return -1; }
                    if (fib[i] - fib[i - 1] <= 1) { return -1; }

                    start += fib[i - 1];
                    i = 0;
                }
            }

        }
        public int InterpolationSearch(int[] array, int x)
        {
            Array.Sort(array);
            int start = 0;
            int end = array.Length - 1;

            while (start < x && end > x)
            {
                int d = start + ((end - start) * (x - array[start])) / (array[end] - array[start]);

                if (array[d] == x) { return d; }

                if (array[d] > x)
                {
                    end = d - 1;
                }
                else
                {
                    start = d + 1;
                }
            }
            return -1;
        }
        class BinaryTree1
        {
            private int _root;
            private bool isTree;
            private BinaryTree1 leftTree;
            private BinaryTree1 rightTree;

            public BinaryTree1()
            {
                this._root = 0;
                this.isTree = false;

            }

            public int Serch(int element)
            {
                int el = -1;
                if (!isTree) { return -1; }
                if (_root == element) { return _root; }

                if (element > _root)
                {
                    if (rightTree == null)
                    {
                        return -1;
                    }

                    el = rightTree.Serch(element);
                }
                else
                {
                    if (leftTree == null)
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


            public void Remove(int element)
            {
                int el = -1;
                if (!isTree) { return; }
                if (_root == element)
                {
                    _root = -1;
                    return;
                }

                if (element > _root)
                {
                    if (rightTree == null)
                    {
                        return;
                    }

                    rightTree.Remove(element);
                }
                else
                {
                    if (leftTree == null)
                    {
                        return;
                    }
                    leftTree.Remove(element);
                }

                return;
            }

        }

    }
    class Task2
    {
        public void ShowHash_table()
        {
            // Создаем новую хеш таблицу.
            var hashTable = new HashTable();

            // Добавляем данные в хеш таблицу в виде пар Ключ-Значение.
            hashTable.Insert("Little Prince", "I never wished you any sort of harm; but you wanted me to tame you...");
            hashTable.Insert("Fox", "And now here is my secret, a very simple secret: It is only with the heart that one can see rightly; what is essential is invisible to the eye.");
            hashTable.Insert("Rose", "Well, I must endure the presence of two or three caterpillars if I wish to become acquainted with the butterflies.");
            hashTable.Insert("King", "He did not know how the world is simplified for kings. To them, all men are subjects.");

            // Выводим хранимые значения на экран.
            //  ShowHashTable(hashTable, "Created hashtable.");
            Console.ReadLine();

            // Удаляем элемент из хеш таблицы по ключу
            // и выводим измененную таблицу на экран.
            hashTable.Delete("King");
            //  ShowHashTable(hashTable, "Delete item from hashtable.");
            Console.ReadLine();

            // Получаем хранимое значение из таблицы по ключу.
            Console.WriteLine("Little Prince say:");
            var text = hashTable.Search("Little Prince");
            Console.WriteLine(text);

        }

        public void SearchHash(int value)//For simple hash
        {
            SimplHash simplHash = new SimplHash(1000);

            for (int i = 0; i < 1000; i++)
            {
                simplHash.Add(i);
            }
            Console.WriteLine("Search Hash get key = " + simplHash.GetKey(value));

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
            int Hash(int key, int layer)
            {

                return ((key + layer) % map.Length);
            }

            public void Add(int value)
            {
                int layer = 0;
                int h = Hash(value, layer);

                if (map[h] == -1)
                {
                    map[h] = value;
                }
                else
                {
                    for (int i = 1; i < map.Length; i++)
                    {
                        if (Hash(value, i) == h)
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
                if (key < 0 || key >= map.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return map[key];
            }
            public int SearchValue(int value)
            {
                int layer = 0;
                int h = Hash(value, layer);

                if (map[h] == value) { return value; }

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

                if (map[h] == value) { map[h] = -1; }

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
        public class Item
        {
            /// <summary>
            /// Ключ.
            /// </summary>
            public string Key { get; private set; }

            /// <summary>
            /// Хранимые данные.
            /// </summary>
            public string Value { get; private set; }

            /// <summary>
            /// Создать новый экземпляр хранимых данных Item.
            /// </summary>
            /// <param name="key"> Ключ. </param>
            /// <param name="value"> Значение. </param>
            public Item(string key, string value)
            {
                // Проверяем входные данные на корректность.
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                // Устанавливаем значения.
                Key = key;
                Value = value;
            }

            /// <summary>
            /// Приведение объекта к строке.
            /// </summary>
            /// <returns> Ключ объекта. </returns>
            public override string ToString()
            {
                return Key;
            }
        }
        public class HashTable
        {
            /// <summary>
            /// Максимальная длина ключевого поля.
            /// </summary>
            private readonly byte _maxSize = 255;

            /// <summary>
            /// Коллекция хранимых данных.
            /// </summary>
            /// <remarks>
            /// Представляет собой словарь, ключ которого представляет собой хеш ключа хранимых данных,
            /// а значение это список элементов с одинаковым хешем ключа.
            /// </remarks>
            private Dictionary<int, List<Item>> _items = null;

            /// <summary>
            /// Коллекция хранимых данных в хеш-таблице в виде пар Хеш-Значения.
            /// </summary>
            public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();

            /// <summary>
            /// Создать новый экземпляр класса HashTable.
            /// </summary>
            public HashTable()
            {
                // Инициализируем коллекцию максимальным количество элементов.
                _items = new Dictionary<int, List<Item>>(_maxSize);
            }

            /// <summary>
            /// Добавить данные в хеш таблицу.
            /// </summary>
            /// <param name="key"> Ключ хранимых данных. </param>
            /// <param name="value"> Хранимые данные. </param>
            public void Insert(string key, string value)
            {
                // Проверяем входные данные на корректность.
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (key.Length > _maxSize)
                {
                    throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                // Создаем новый экземпляр данных.
                var item = new Item(key, value);

                // Получаем хеш ключа
                var hash = GetHash(item.Key);

                // Получаем коллекцию элементов с таким же хешем ключа.
                // Если коллекция не пустая, значит заначения с таким хешем уже существуют,
                // следовательно добавляем элемент в существующую коллекцию.
                // Иначе коллекция пустая, значит значений с таким хешем ключа ранее не было,
                // следовательно создаем новую пустую коллекцию и добавляем данные.
                List<Item> hashTableItem = null;
                if (_items.ContainsKey(hash))
                {
                    // Получаем элемент хеш таблицы.
                    hashTableItem = _items[hash];

                    // Проверяем наличие внутри коллекции значения с полученным ключом.
                    // Если такой элемент найден, то сообщаем об ошибке.
                    var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                    if (oldElementWithKey != null)
                    {
                        throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. Ключ должен быть уникален.", nameof(key));
                    }

                    // Добавляем элемент данных в коллекцию элементов хеш таблицы.
                    _items[hash].Add(item);
                }
                else
                {
                    // Создаем новую коллекцию.
                    hashTableItem = new List<Item> { item };

                    // Добавляем данные в таблицу.
                    _items.Add(hash, hashTableItem);
                }
            }

            /// <summary>
            /// Удалить данные из хеш таблицы по ключу.
            /// </summary>
            /// <param name="key"> Ключ. </param>
            public void Delete(string key)
            {
                // Проверяем входные данные на корректность.
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (key.Length > _maxSize)
                {
                    throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
                }

                // Получаем хеш ключа.
                var hash = GetHash(key);

                // Если значения с таким хешем нет в таблице, 
                // то завершаем выполнение метода.
                if (!_items.ContainsKey(hash))
                {
                    return;
                }

                // Получаем коллекцию элементов по хешу ключа.
                var hashTableItem = _items[hash];

                // Получаем элемент коллекции по ключу.
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);

                // Если элемент коллекции найден, 
                // то удаляем его из коллекции.
                if (item != null)
                {
                    hashTableItem.Remove(item);
                }
            }

            /// <summary>
            /// Поиск значения по ключу.
            /// </summary>
            /// <param name="key"> Ключ. </param>
            /// <returns> Найденные по ключу хранимые данные. </returns>
            public string Search(string key)
            {
                // Проверяем входные данные на корректность.
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (key.Length > _maxSize)
                {
                    throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
                }

                // Получаем хеш ключа.
                var hash = GetHash(key);

                // Если таблица не содержит такого хеша,
                // то завершаем выполнения метода вернув null.
                if (!_items.ContainsKey(hash))
                {
                    return null;
                }

                // Если хеш найден, то ищем значение в коллекции по ключу.
                var hashTableItem = _items[hash];

                // Если хеш найден, то ищем значение в коллекции по ключу.
                if (hashTableItem != null)
                {
                    // Получаем элемент коллекции по ключу.
                    var item = hashTableItem.SingleOrDefault(i => i.Key == key);

                    // Если элемент коллекции найден, 
                    // то возвращаем хранимые данные.
                    if (item != null)
                    {
                        return item.Value;
                    }
                }

                // Возвращаем null если ничего найдено.
                return null;
            }

            /// <summary>
            /// Хеш функция.
            /// </summary>
            /// <remarks>
            /// Возвращает длину строки.
            /// </remarks>
            /// <param name="value"> Хешируемая строка. </param>
            /// <returns> Хеш строки. </returns>
            private int GetHash(string value)
            {
                // Проверяем входные данные на корректность.
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Length > _maxSize)
                {
                    throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(value));
                }

                // Получаем длину строки.
                var hash = value.Length;
                return hash;
            }
        }
    }
    public class Task3
    {
        public int[,] board = new int[8, 8];
        public void resetQ(int i, int j)
        {
            for (int x = 0; x < 8; ++x)
            {
                --board[x, j];
                --board[i, x];
                int k;
                k = j - i + x;
                if (k >= 0 && k < 8)
                    --board[x, k];
                k = j + i - x;
                if (k >= 0 && k < 8)
                    --board[x, k];
            }
            board[i, j] = 0;
        }

        public bool tryQ(int i)
        {
            bool result = false;
            for (int j = 0; j < 8; ++j)
            {
                if (board[i, j] == 0)
                {
                    setQ(i, j);
                    if (i == 7)
                        result = true;
                    else
                    {
                        if (!(result = tryQ(i + 1)))
                            resetQ(i, j);
                    }
                }
                if (result)
                    break;
            }
            return result;
        }



        public void setQ(int i, int j)
        {
            for (int x = 0; x < 8; ++x)
            {
                ++board[x, j];
                ++board[i, x];
                int k;
                k = j - i + x;
                if (k >= 0 && k < 8)
                    ++board[x, k];
                k = j + i - x;
                if (k >= 0 && k < 8)
                    ++board[x, k];
            }
            board[i, j] = -1;
        }
    }
    class Program
    {
        static void PullArray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 10000);
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
            index = task1.BinarySearch(arr, 12);
            myStopwatch.Stop();
            Console.WriteLine("BinarySerch: " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");

            //Поиск деревом
            myStopwatch.Reset();
            myStopwatch.Start();
            index = task1.BinaryTreeSearch(arr, 12);
            myStopwatch.Stop();
            Console.WriteLine("BinaryTreeSerch " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");

            //Поиск Фибоначи
            myStopwatch.Reset();
            myStopwatch.Start();
            index = task1.FeebonachiSearch(arr, 12);
            myStopwatch.Stop();
            Console.WriteLine("FibonachiSerch " + index);
            Console.WriteLine("Time: " + myStopwatch.ElapsedMilliseconds + " ms");

            //Интерполяционный поиск
            myStopwatch.Reset();
            myStopwatch.Start();
            index = task1.InterpolationSearch(arr, 12);
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






            //Задача на растановку
            Task3 p = new Task3();
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                    p.board[i, j] = 0;
            p.tryQ(0);
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (p.board[i, j] == -1)
                        Console.Write(" * ");
                    else
                        Console.Write(" . ");
                }
                Console.Write("\n");

            }

        }
    }
}
