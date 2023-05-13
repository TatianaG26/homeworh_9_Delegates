using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworh_9_Delegates
{
    /*Задание 2
    Создайте набор методов:
    ■ Метод для отображения текущего времени;
    ■ Метод для отображения текущей даты;
    ■ Метод для отображения текущего дня недели;
    ■ Метод для подсчёта площади треугольника;
    ■ Метод для подсчёта площади прямоугольника.
    Для реализации проекта используйте делегаты Action, Predicate, Func. */
    internal class Задание_2
    {
        static void DisplayTime() // Метод для отображения текущего времени
        {
            Console.WriteLine("Текущее время: " + DateTime.Now.ToString("HH:mm:ss"));
        }
        static void DisplayDate() // Метод для отображения текущей даты
        {
            Console.WriteLine("Текущая дата: " + DateTime.Today.ToString("d"));
        }
        static void DisplayDayOfWeek() // Метод для отображения текущего дня недели
        {
            Console.WriteLine("Текущий день недели: " + DateTime.Today.DayOfWeek.ToString());
        }
        static double TriangleArea(double side, double height) // Метод для подсчёта площади треугольника
        {
            return side * height / 2;
        }
        static double RectangleArea(double width, double height) // Метод для подсчёта площади прямоугольника
        {
            return width * height;
        }
        static void Main()
        {
            // Использование делегата Action для вызова методов без параметров
            Action actionDelegate = new Action(DisplayTime);
            actionDelegate += DisplayDate;
            actionDelegate += DisplayDayOfWeek;
            actionDelegate();

            // Использование делегата Func для вызова методов с параметрами и возвращаемым значением
            Func<double, double, double> triangleAreaDelegate =  TriangleArea;
            double triangleArea = triangleAreaDelegate(4, 6);
            Console.WriteLine("Площадь треугольника: " + triangleArea);

            Func<double, double, double> rectangleAreaDelegate = RectangleArea;
            double rectangleArea = rectangleAreaDelegate(5, 7);
            Console.WriteLine("Площадь прямоугольника: " + rectangleArea);

            // Использование делегата Predicate для проверки условия и возвращения булевого значения
            Predicate<double> isPositiveDelegate = new Predicate<double>((x) => x > 0);
            bool isPositive = isPositiveDelegate(5);
            Console.WriteLine("Число 5 положительное? " + isPositive);
            isPositive = isPositiveDelegate(-2);
            Console.WriteLine("Число -2 положительное? " + isPositive);

        }
    }
}

