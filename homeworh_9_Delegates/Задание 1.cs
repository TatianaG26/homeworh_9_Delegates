namespace homeworh_9_Delegates
{
    using System;
    using System.Collections.Generic;

    namespace ArrayFunctions
    {
        /* Задание 1
        Создайте набор методов для работы с массивами:
        ■ Метод для получения всех четных чисел в массиве;
        ■ Метод для получения всех нечетных чисел в массиве;
        ■ Метод для получения всех простых чисел в массиве;
        ■ Метод для получения всех чисел Фибоначчи в массиве.  
        Используйте механизмы делегатов.

    Чи́сла Фибона́ччи — элементы числовой последовательности, в которой первые два числа равны 0 и 1, а каждое последующее число равно сумме двух предыдущих чисел.
    Пример: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, … 
        */
        class Задание_1
        {
            public delegate int[] myDelegat(int[] arr);

            static void Main(string[] args)
            {
                int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                // создаем делегаты для каждого метода
                myDelegat getEvenNumbers = new myDelegat(GetEvenNumbers);
                myDelegat getOddNumbers =  new myDelegat(GetOddNumbers);
                myDelegat getPrimeNumbers = new myDelegat (GetPrimeNumbers);
                myDelegat getFibonacciNumbers = new myDelegat(GetFibonacciNumbers);

                // вызываем каждый метод с помощью делегата и выводим результат в консоль
                Console.WriteLine("Исходный массив: " + String.Join(' ', nums) + "\n");
                Console.WriteLine("Четные числа: " + String.Join(' ', getEvenNumbers(nums)));
                Console.WriteLine("Нечетные числа: " + String.Join(' ', getOddNumbers(nums)));
                Console.WriteLine("Простые чисела: " + String.Join(' ', getPrimeNumbers(nums)));
                Console.WriteLine("Числа Фибоначчи: " + String.Join(' ', getFibonacciNumbers(nums)));

            }
            static int[] GetEvenNumbers(int[] arr) // метод для получения всех четных чисел в массиве
            {
                var result = new List<int>();
                foreach (var num in arr)
                {
                    if (num % 2 == 0) 
                        result.Add(num);
                }
                return result.ToArray();
            }            
            static int[] GetOddNumbers(int[] arr) // метод для получения всех нечетных чисел в массиве
            {
                var result = new List<int>();
                foreach (var num in arr)
                {
                    if (num % 2 != 0) 
                        result.Add(num);
                }
                return result.ToArray();
            }
            static int[] GetPrimeNumbers(int[] arr) // метод для получения всех простых чисел в массиве
            {
                var result = new List<int>();
                foreach (var num in arr)
                {
                    if (IsPrime(num))
                        result.Add(num);
                }
                return result.ToArray();
            }
            static bool IsPrime(int num) // метод для проверки, является ли число простым
            {
                if (num < 2) return false;
                if (num == 2) return true;
                if (num % 2 == 0) return false;

                for (int i = 3; i <= Math.Sqrt(num); i += 2)
                {
                    if (num % i == 0) return false;
                }
                return true;
            }
            static int[] GetFibonacciNumbers(int[] arr) // метод для получения всех чисел Фибоначчи в массиве
            {
                var result = new List<int>();
                foreach (var num in arr)
                {
                    if (IsFibonacci(num)) result.Add(num);
                }
                return result.ToArray();
            }
            static bool IsFibonacci(int num) // метод для проверки, является ли число числом Фибоначчи
            {
                if (num == 0 || num == 1) return true;

                int a = 0, b = 1, c = 1;
                while (c < num)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return c == num;
            }
        }
    }
}

