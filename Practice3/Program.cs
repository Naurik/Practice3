using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
                while (true)
                {
                    Tasks();
                    Console.Write("\n\nВыберите задание: ");
                    int choice = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (choice)
                    {
                        case 1: Task1(); break;
                        case 2: Task2(); break;
                        case 3: Console.WriteLine(Task3()); break;
                        case 4: Task4(); break;
                        case 5: Task5(); break;
                        default:
                            Console.WriteLine("Ошибочный выбор!!!"); break;
                    }
                    Console.Write("\nНажмите ENTER чтобы продолжить...");
                    Console.ReadKey();
                    Console.Clear();
                }
        }
        static void Tasks()
        {
            Console.WriteLine("1. Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) " +
    "\n   дробных чисел с именем B. Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, а двумерный массив В " +
    "\n   случайными числами с помощью циклов. Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. " +
    "\n   Найти в данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, общее произведение " +
    "\n   всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В." +
"\n2. Даны 2 массива размерности M и N соответственно.Необходимо переписать в третий массив общие элементы первых двух массивов без повторений." +
"\n3. Пользователь вводит строку.Проверить, является ли эта строка палиндромом.Палиндромом называется строка, " +
    "\n   которая одинаково читается слева направо и справа налево." +
"\n4. Подсчитать количество слов во введенном предложении." +
"\n5. Дан двумерный массив размерностью 5?5, заполненный случайными числами из диапазона от –100 до 100. Определить сумму элементов массива, " +
    "\n   расположенных между минимальным и максимальным элементами.");
        }
        static void Task1()
        {
            const int ARRAY_LENGTH = 5;
            const int ARRAY_ROWS = 3, ARRAY_COLS = 4;
            double[] arrayA = new double[ARRAY_LENGTH];
            double[,] arrayB = new double[ARRAY_ROWS, ARRAY_COLS];
            Random rnd = new Random();

            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write("Введите " + (i + 1) + "-число: ");
                arrayA[i] = double.Parse(Console.ReadLine());
            }

            Console.Clear();
            double multiplication = 1;      // произведение значений 2-х массивов
            double evenSum = 0;             // сумма четных элементов 1-массива

            Console.WriteLine("Массив A");
            for (int i = 0; i < arrayA.Length; i++)
            {
                Console.Write(arrayA[i] + "\t");
                multiplication *= arrayA[i];
                if (i % 2 == 0) evenSum += arrayA[i];
            }

            double max = double.MinValue;   // максимальное значенеи 2-массива
            double min = double.MaxValue;   // минимальное значение 2-массива
            double sum = arrayA.Sum();      // общая сумма значений 2-х массивов
            double oddSum = 0;              // сумма нечетных столбцов массива В

            Console.WriteLine("\n\nМассив B");
            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    arrayB[i, j] = rnd.Next(10, 100) + rnd.Next(1, 10) / 10.0 + rnd.Next(1, 10) / 100.0;
                    if (max < arrayB[i, j]) max = arrayB[i, j];
                    if (min > arrayB[i, j]) min = arrayB[i, j];
                    if (j % 2 == 1) oddSum += arrayB[i, j];
                    sum += arrayB[i, j];
                    multiplication *= arrayB[i, j];
                    Console.Write(arrayB[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nОбщий максимальный элемент: " + (arrayA.Max() > max ? arrayA.Max() : max));
            Console.WriteLine("\nОбщий минимальный элемент: " + (arrayA.Min() < min ? arrayA.Min() : min));
            Console.WriteLine("\nОбщая сумма 2-х массивов: " + sum);
            Console.WriteLine("\nОбщее произведение 2-х массивов: " + multiplication);
            Console.WriteLine("\nСумма четных элементов массива A: " + evenSum);
            Console.WriteLine("\nCумма нечетных столбцов массива В: " + oddSum);
        }
        static void Task2()
        {
            const int SIZE_M = 8, SIZE_N = 10;
            int[] arrayA = new int[SIZE_M] { 2, 5, 4, 0, 8, 8, 6, 2 };
            int[] arrayB = new int[SIZE_N] { 3, 8, 5, 2, 2, 4, 8, 7, 3, 6 };

            Console.WriteLine("Массив A:\n" + string.Join("  ", arrayA));
            Console.WriteLine("\nМассив B:\n" + string.Join("  ", arrayB));

            int[] arrayC = arrayA.Intersect(arrayB).ToArray();

            Console.WriteLine("\nМассив C:\n" + string.Join("  ", arrayC));
        }

        static string Task3()
        {
            Console.Write("Введите текст или слово (работает только c латиницей)\n");
            string str = Console.ReadLine();
            char[] symbolsArray = new char[1];

            for (int i = 0, j = 0; i < str.Length; i++)
            {
                if ((str[i] >= 65 && str[i] <= 90) || (str[i] >= 97 && str[i] <= 122))
                {
                    if (symbolsArray.Length == j)
                    {
                        Array.Resize(ref symbolsArray, j + 1);
                    }
                    symbolsArray[j] = str[i];
                    j++;
                }
            }

            for (int i = 0; i < symbolsArray.Length; i++)
            {
                if (symbolsArray[i] != symbolsArray[symbolsArray.Length - i - 1] &&
                    symbolsArray[i] != symbolsArray[symbolsArray.Length - i - 1] + 32 &&
                    symbolsArray[i] != symbolsArray[symbolsArray.Length - i - 1] - 32)
                    return "\nСтрока не является палиндромом";
            }
            return "\nСтрока является палиндромом";
        }

        static void Task4()
        {
            Console.WriteLine("Введите предложение:");
            string str = Console.ReadLine();
            string[] words = str.Split(' ');

            Console.WriteLine("\nКоличество слов в предложении: " + words.Length);
        }

        static void Task5()
        {
            Random rnd = new Random();
            const int ROWS_OF_ARRAY = 5, COLS_OF_ARRAY = 5;
            int[,] twoDimensialArray = new int[ROWS_OF_ARRAY, COLS_OF_ARRAY];
            int min = int.MaxValue, max = int.MinValue;
            int beginOfRange = 0, endOfRange = 0;
            int sumBetweenMinMax = 0;

            for (int i = 0; i < ROWS_OF_ARRAY; i++)
            {
                for (int j = 0; j < COLS_OF_ARRAY; j++)
                {
                    twoDimensialArray[i, j] = rnd.Next(-100, 100);
                    Console.Write(twoDimensialArray[i, j] + "\t");
                    if (min > twoDimensialArray[i, j])
                    {
                        min = twoDimensialArray[i, j];
                        beginOfRange = ROWS_OF_ARRAY * i + j;
                    }
                    if (max < twoDimensialArray[i, j])
                    {
                        max = twoDimensialArray[i, j];
                        endOfRange = ROWS_OF_ARRAY * i + j;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nИндекс минимального элемента: " + beginOfRange +
                "\nИндекс максимального элемента: " + endOfRange);

            if (beginOfRange > endOfRange) Swap(ref beginOfRange, ref endOfRange);

            for (int i = beginOfRange; i < endOfRange + 1; i++)
            {
                sumBetweenMinMax += twoDimensialArray[i / ROWS_OF_ARRAY, i % ROWS_OF_ARRAY];
            }
            Console.WriteLine("\nСумма чисел в этом диапазоне: " + sumBetweenMinMax);
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }

}
