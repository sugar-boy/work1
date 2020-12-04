using System;
using System.Collections.Generic;

namespace Fifth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            string[] numbers = new string[2];
            string str = "";

            while(numbers[0] != "0" && numbers[1] != "0")
            {
                str = Console.ReadLine();
                numbers = Console.ReadLine().Split(' ');
            }
        }
    }
}
