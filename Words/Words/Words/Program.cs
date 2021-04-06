using System;
using System.Threading;

namespace Words
{
    class Program
    {
        /// <summary>
        /// Метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        /// </summary>
        static void FindShortestWord()
        {
            Console.Write("Введите слова: ");
            string row = Console.ReadLine();
            string[] arr_words = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int min_word = arr_words[0].Length;            //в переменную записал длину первого слова в массиве
            string word = arr_words[0];

            for (int i = 0; i < arr_words.Length; i++)
            {
                if (arr_words[i].Length < min_word)
                {
                    min_word = arr_words[i].Length;
                    word = arr_words[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Самое короткое слово : {0}", word);
            Console.ReadKey();
        }
        /// <summary>
        /// Метод, принимающий текст и возвращающий слово (слова) с максимальным количеством букв
        /// </summary>
        static void FindLongerWord()
        {
            Console.Write("Введите слова: ");

            string row;
            while ((row = Console.ReadLine()) == "")
            {
                Console.WriteLine("Вы не ввели слова");
                Console.WriteLine();
            }

            var words = row.Split(' ');

            var position = 0;
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (word.Length > words[position].Length)
                {
                    position = i;
                }

            }
            Console.WriteLine();
            Console.WriteLine("Самое длинное слово: {0}", words[position]);

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (word.Length == words[position].Length)
                {
                    position = i;
                }
            }
            Console.WriteLine($"Слова с такой же длиной: {words[position]}");

            Console.ReadLine();
        }
        /// <summary>
        /// Метод, удаляющий повторяющиеся символы
        /// </summary>
        static void RemoveExtraLetter()
        {
            Console.Write("Введите слова: ");
            string row = Console.ReadLine();
            string row_lower = row.ToLower();
            char[] arr_words = row_lower.ToCharArray();

            Console.Write(arr_words[0] + "");

            for (int i = 1; i < arr_words.Length; i++)
            {
                if (arr_words[i] != arr_words[i - 1])
                {
                    Console.Write(arr_words[i] + "");
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Метод для проверки на арифметическую или геометрическую прогрессию
        /// </summary>
        public static void DetermineTypeOfProgression()
        {
            double number;
            bool isCorrect;
            string nums;
            string[] arr_nums;

            do
            {
                Console.Write("Введите последовательность чисел через пробелы: ");
                nums = Console.ReadLine();
                arr_nums = nums.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                isCorrect = true;
                foreach (var value in arr_nums)
                {
                    if (!Double.TryParse(value, out number))
                    {
                        Console.WriteLine("\nСимвол '{0}' вводить нельзя, вводите только цифры.", value);
                        isCorrect = false;
                        break;
                    }
                    if (arr_nums.Length < 2)
                    {
                        Console.WriteLine("\nПрогрессия не может состоять из одного числа.", value);
                        isCorrect = false;
                        break;
                    }
                }
            } while (!isCorrect);

            double[] arr_nums1 = new double[arr_nums.Length];

            for (int i = 0; i < arr_nums.Length; i++)
            {
                arr_nums1[i] = Double.Parse(arr_nums[i]);
            }

            double ar_prog = arr_nums1[1] - arr_nums1[0];
            double ge_prog = arr_nums1[1] / arr_nums1[0];

            bool ar_prog_const = true;
            bool ge_prog_const = true;

            for (int i = 0; i < arr_nums1.Length-1; i++)
            {
                if (ar_prog_const == true)
                {
                    if (arr_nums1[i + 1] - arr_nums1[i] != ar_prog)
                    {
                        ar_prog_const = false;
                    }
                }
            }
                                                                //для проверки на 0 пришлось создать вспомогательный массив
            double[] arr_nums2 = new double[arr_nums.Length];   //вспомогательный массив для сортировки
            Array.Copy(arr_nums1, arr_nums2, arr_nums.Length);  //копирование из основного во вспомогательный
            Array.Sort(arr_nums2);                              //сортировка вспомогательного

            for (int i = 0; i < arr_nums1.Length-1; i++)
            {
                if (arr_nums1[i] == 0)
                {
                    Console.Write("Данная последовательность не может являться геометрической прогрессией, поскольку включает в себя 0");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    if (ge_prog_const == true && arr_nums2[0] != 0)
                    {
                        if (arr_nums1[i + 1] / arr_nums1[i] != ge_prog)
                        {
                            ge_prog_const = false;
                        }
                    }
                }
            }
            
            if (ar_prog_const == true)
            {
                Console.Write("Данная последовательность является арифметической");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Данная последовательность не является арифметической");
                Console.WriteLine();
            }

            if (ge_prog_const == true && arr_nums2[0] != 0)
            {
                Console.Write("Данная последовательность является геометрической");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Данная последовательность не является геометрической");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод для вычисления значения функции Аккермана
        /// </summary>
        public static int FindAckermannResult(int n, int m)
        {
            if (n == 0)
                return m + 1;
            else
                if ((n != 0) && (m == 0))
                return FindAckermannResult(n - 1, 1);
            else
                return FindAckermannResult(n - 1, FindAckermannResult(n, m - 1));
        }
        static void Main(string[] args)

        {
            //FindShortestWord();
            //FindLongerWord();
            //RemoveExtraLetter();
            DetermineTypeOfProgression();
            //int n = 1;
            //int m = 2;
            //int A = FindAckermannResult(n, m);
            //Console.WriteLine($"А= {A}");
            Console.ReadKey();
        }
    }
}

