using System;
using System.Diagnostics;
using System.Numerics;

namespace Second_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // заводим переменную для вычисления объема выделенной памяти
            long workingSet = Process.GetCurrentProcess().WorkingSet64;

            // объявляем класс, используемый для вычисления затраченного времени
            Stopwatch time = new Stopwatch();
            
            Console.Write("Введите количество чисел: ");
            // переменная для хранения количества введеных чисел
            int rounds = Convert.ToInt32(Console.ReadLine());
            // создаем массив, для хранения этих чисел
            BigInteger[] array = new BigInteger[rounds];

            int cnt = 0;


            // создаем цикл, который работает rounds раз, в цикле мы считываем введеные числа и заносим их в массив
            for (int i = 0; i < rounds; i++)
            {
                array[i] = BigInteger.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Порядковые номера чисел, являющийся полным квадратом: ");

            time.Start();

            for (int i = 0; i < array.Length; i++)
            {
                string number = Convert.ToString(array[i]);
                char symbol = number[^1];
                cnt = 0;

                if (symbol == '2' || symbol == '3'|| symbol == '7' || symbol == '8')
                    continue;

                while(symbol == '0')
                {
                    symbol = number[number.Length - 1 - cnt];
                    cnt++;
                }
                if (cnt % 2 != 0)
                    continue;

                cnt = 0;

                if(array[i] % 4 == 0 || array[i] % 8 == 1 || array[i] % 9 == 0 || array[i] % 3 == 1)
                {
                    for (int j = 2; j <= array[i] / 2; j++)
                    {
                        // в if else мы проверяем, сходится ли наше условие
                        // например array[0] = 9, заходя во внутренний массив мы начинаем сверять числа, сначала берем 0, 1, 2, 3 и тд
                        // эти числа подставляются в j
                        // если условие выполнилось, мы выводим порядковый номер числа, который является полным квадратом и выходим из цикла
                        // если не выполнилось, продолжаем
                        if (array[i] == j * j)
                        {
                            Console.WriteLine(i + 1);
                            break;
                        }
                    }
                }
                
            }

            time.Stop();

            Console.WriteLine();
            Console.WriteLine($"Выделенный объем памяти: {workingSet} байт");
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
            Console.WriteLine("Нажмите Enter для закрытия проекта.");
            Console.ReadLine();


        }
    }
}
