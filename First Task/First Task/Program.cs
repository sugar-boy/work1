using System;
using System.Diagnostics;
using System.Numerics;

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
            Console.Write("Введите делимое: ");
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("/");
            Console.Write("Введите делитель: ");
            double secondNumber = Convert.ToDouble(Console.ReadLine());

            // начинаем отсчет времени
            time.Start();

            // нахождение частного
            double result = firstNumber / secondNumber;

            Console.Write("Результат вычислений: ");
            if (result > 0)
                // если результат положительное число, то при приведении к типу (int) произойдет округление в меньшую сторону
                Console.WriteLine((BigInteger)result);
            else
                // Если результат отрицателен, то мы действуем по следующему алгоритму
                // Разберем такой пример, первое число -27, второе 10
                // При делении в result будет -2.7
                // В скобках при вычислении result - (int)result мы получим нашу дробную часть, тоесть -2.7 - (-2) = -0.7
                // Потом мы складываем => 1 + (-0.7) = 0.3
                // Получаем необходимое число, которое нужно прибавить к исходному для округления его в большую сторону
                // Итог: -2.7 - 0,3 = 3
                Console.WriteLine(result -= 1 + (result - (int)result));

            // выводим на консоль полученные результаты по времени и памяти
            Console.WriteLine($"Выделенный объем памяти: {workingSet} байт");
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
            Console.WriteLine("Нажмите Enter для закрытия проекта.");
            Console.ReadLine();

        }
    }
}
