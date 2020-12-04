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
            List<string> arr = new List<string>();
            string str = "";

            while(str != "0 0")
            {
                str = Console.ReadLine();
                arr.Add(str);
            }

        }
    }
}
