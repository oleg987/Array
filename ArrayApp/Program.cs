using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp
{
    class Program
    {
        //n! = n*(n-1)!       
        static void Main(string[] args)
        {

            // Варианты инициализации массивов
            int[] arr1; // Объявление переменной типа массив значений int(создание ссылки). Значений не присвоено.
            int size = 5;
            int[] arr2 = new int[size]; // Переменная типа массив значений int c размером size. 
                                        // Значения элементов массива - значения по умолчанию для типа(в данном примере для целочисленных типов = 0)
            int[] arr3 = { 1, 5, 8 }; // Переменная типа массив значений int с размером равным кол-ву инициализаторов(в данном примере 3) 
            int[] arr4 = new int[] { 4, 8, 1 }; // Излишняя декларация
            int[] arr5 = new int[3] { 55, 12, 46 }; // Излишняя декларация

            //// Обращение к элементам массива. имя_переменной[индекс_элемента]

            Console.WriteLine("Массив arr3 элемент с индексом 0 = " + arr3[0]); // Индексация элементов начинается с 0
            Console.WriteLine($"Сумма arr3[0] + arr4[1] = {arr3[0] + arr4[1]}"); // C элементами массивов можно проводить все действия которые можно делать с переменными

            //// Работа с массивами с помощью циклов
            //// Цикл FOR
            ///
            for (int i = 0; i < arr5.Length; i++) // arr2.Length - свойство массива которое возвращает длину(!) массива
            {
                Console.WriteLine($"Элемент с индексом {i} = {arr5[i]}");
            }

            //// Цикл FOREACH
            foreach (int item in arr5)
            {
                Console.WriteLine(item);
            }

            Random rand = new Random();

            int[] randNums = new int[100];

            for (int i = 0; i < randNums.Length; i++)
            {
                randNums[i] = rand.Next(500);
            }           

            Array.Sort(randNums);
            Array.Reverse(randNums);

            Array.Clear(arr3, 0, 3);

            foreach (int item in arr3)
            {
                Console.WriteLine("Array 3 - " + item);
            }

            int[] randNumsCopy = new int[150];

            //randNums.CopyTo(randNumsCopy, 20);

            //Array.Copy(randNums, randNumsCopy, 100);

            foreach (int item in randNumsCopy)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = -1;
            }

            foreach (int item in arr3)
            {
                Console.WriteLine("Array 3 - " + item);
            }

            //Console.WriteLine(Array.IndexOf(arr5, 46));

            //int[,] b = { { 1, 2 }, { 3, 4 } };
            //foreach (int item in b)
            //{
            //    Console.WriteLine(item);
            //}

            int[] binarySearch = new int[1000];

            for (int i = 0; i < binarySearch.Length; i++)
            {
                binarySearch[i] = i;
            }

            Console.WriteLine("Search " + Array.BinarySearch(binarySearch, 452));

            Array.Resize(ref binarySearch, binarySearch.Length + 24);

            Console.WriteLine(binarySearch.Length);

            // Двумерные массивы

            
            int[,] arr2D = new int[5, 5];

            Console.WriteLine("Length " + arr2D.Rank);

            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    arr2D[i, j] = rand.Next() % 10;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(arr2D[i, j]);
                }
            }
            
            Console.WriteLine("Foreach");
            foreach (int item in arr2D)
            {
                Console.WriteLine(item);
            }

            int[][] arr2Dr = { new int[2], new int[4] };

            Console.WriteLine(arr2D.GetType());

            //Test1Arr1D();
            Test2();

        }

        private static void Test2()
        {
            double[] output = new double[12]; // Расходы
            double[] input = new double[12]; // Поступления
            double[] delta = new double[12]; // Прибыль
            double deltaYear = 0;
            int minValueMonth = 0, maxValueMonth = 0 , countPositiveBallance = 0;
            double minValue = 0, maxValue;


            Random random = new Random();

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = Math.Round(random.NextDouble() * 1000, 2);
            }

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Math.Round(random.NextDouble() * 1000, 2);
            }

            for (int i = 0; i < delta.Length; i++)
            {
                delta[i] = input[i] - output[i];
            }

            for (int i = 0; i < delta.Length; i++)
            {
                deltaYear += delta[i]; //Общая прибыль; deltaYear = deltaYear + delta[i];

                if (delta[i] < minValue)
                {
                    minValue = delta[i];
                    minValueMonth = i;
                }

                if (delta[i] > 0)
                {
                    countPositiveBallance++;
                }
            }

            maxValue = minValue;
            for (int i = 0; i < delta.Length; i++)
            {
                if (delta[i] > maxValue)
                {
                    maxValue = delta[i];
                    maxValueMonth = i;
                }
            }

            maxValueMonth++;
            minValueMonth++;

            string result = "";
            result += "Прибыль по месяцам:\n";
            for (int i = 0; i < delta.Length; i++)
            {
                result += "Месяц " + (i + 1) + " баланс " + delta[i] + "\n";
            }

            result += "Общая прибыль " + deltaYear + "\n";
            result += "Min " + minValueMonth + "\n";
            result += "Max " + maxValueMonth + "\n";
            result += "Положительный балланс " + countPositiveBallance + " месяцев\n";
            Console.WriteLine(result);
        }

        private static void Test1Arr1D()
        {
            double[] bank = new double[20];
            Random rand = new Random();
            double maxValue = 0;

            for (int i = 1; i < bank.Length; i+=2)
            {
                bank[i] = Math.Round(rand.NextDouble() * (30 - 25) + 25, 2);
            }

            for (int i = 0; i < bank.Length; i++)
            {
                if (bank[i] > maxValue)
                {
                    maxValue = bank[i];
                }
            }

            Console.WriteLine("Max Value = " + maxValue);
        }

        private static int Factorial(int n)
        {
            if (n < 0)
            {
                throw new Exception("Число не может быть отрицательным!");
            }

            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public static void Message(string msg)
        {
            Console.WriteLine("String msg" + msg);
        }

        public static void Message(int msg)
        {
            Console.WriteLine("Int msg" + msg);
        }

    }
}
