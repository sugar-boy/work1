using System;
using System.Diagnostics;
using System.Text;

namespace Fourth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // заводим переменную для вычисления объема выделенной памяти
            long workingSet = Process.GetCurrentProcess().WorkingSet64;

            // объявляем класс, используемый для вычисления затраченного времени
            Stopwatch time = new Stopwatch();

            // объявляем требуемые переменные
            Console.Write("Введите числа: ");
            string[] array = Console.ReadLine().Split(" ");
            int n = Convert.ToInt32(array[0]);
            int m = Convert.ToInt32(array[1]);

            time.Start();
            string str = getPeriod(n, m);
            time.Stop();

            Console.WriteLine($"Результат вычислений: {str}" );
            Console.WriteLine();
            Console.WriteLine($"Выделенный объем памяти: {workingSet} байт");
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
            Console.WriteLine("Нажмите Enter для закрытия проекта.");
            Console.ReadLine();
        }

        // создаем метод для вычисления периода
        public static string getPeriod(int numerator, int denominator)
        {
            StringBuilder s = new StringBuilder();

            // частное в десятичном виде
            float x = (float)numerator / denominator;

            // целая часть
            int dev = numerator / denominator;

            if (numerator > denominator)
            {
                // неправильная дробь. вычисляем дробную часть 
                float rest = x - numerator / denominator;

                s.Append(dev.ToString());

                if (rest > 0)
                {
                    // остаток > 0,  уменьшаем numerator и ищем период
                    numerator -= dev * denominator;

                    s.Append("," + GetFraction(numerator, denominator));
                }
            }
            // правильная дробь: 0 < numerator < denominator
            else if (denominator % 2 == 0 || denominator % 5 == 0)
                s.Append(x.ToString());
            else
                // остаток деления (дробная часть)
                s.Append(dev.ToString() + "," + GetFraction(numerator, denominator));
            return s.ToString();
        }

        // создаем метод для отображения периода
        static string GetFraction(int numerator, int denominator)
        {
            int[] digits = new int[denominator];

            int k = 0, n = numerator;
            // вычисляем период
            do
            {
                n *= 10;
                digits[k++] = n / denominator;
                n %= denominator;
            }
            while (n != numerator);

            int[] period = new int[k];
            // записываем период
            for (n = 0; n < k; ++n)
            {
                period[n] = digits[n];
            }

            StringBuilder s = new StringBuilder();

            // прибавляем период к строке
            if (period.Length > 0)
            {
                s.Append("(");
                for (int i = 0; i <= period.Length - 1; i++)
                {
                    s.Append(period[i]);
                }
                s.Append(")");
            }

            return s.ToString();
        }
    }
}
