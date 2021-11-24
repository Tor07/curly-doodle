using System;
using System.Collections.Generic;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var (n, m) = (int.Parse(args[0]), int.Parse(args[1]));
            int thisNum = 1;
            while (true)
            {
                Console.Write(thisNum);
                for (int i = 0; i < m-1; i++)
                {
                    thisNum++;
                    if (thisNum > n) thisNum = 1;
                    if (i == m - 1) thisNum--;
                }
                if (thisNum == 1) break;
            }
        }
    }
}
