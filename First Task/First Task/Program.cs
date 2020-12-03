using System;
using System.Diagnostics;

namespace First_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // заводим переменную для вычисления объема выделенной памяти
            long workingSet = Process.GetCurrentProcess().WorkingSet64;

            // объявляем класс, используемый для вычисления затраченного времени
            Stopwatch time = new Stopwatch();

            // объявляем две переменные: первая делимое, вторая делитель
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("/");
            double secondNumber = Convert.ToDouble(Console.ReadLine());

            // начинаем отсчет времени
            time.Start();

            // нахождение частного
            double result = firstNumber / secondNumber;

            // условная конструкция if else используется для корректировки результата вычислений по правилам математики и вывода результата на печать
            if (result > 0)
                // если результат больше 0, округляем в меньшую сторону
                Console.WriteLine(Math.Round(result, MidpointRounding.ToEven));
            else
                // если результат меньше 0, округляем "дальше от нуля до целого числа", тоесть в большую сторону
                Console.WriteLine(Math.Round(result, MidpointRounding.AwayFromZero));
            
            // заканчиваем осчет времени
            time.Stop();

            // выводим на консоль полученные результаты по времени и памяти
            Console.WriteLine($"Выделенный объем памяти: {workingSet} байт");
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
            
        }
    }
}
