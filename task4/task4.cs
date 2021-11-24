using System;
using System.Collections.Generic;
using System.IO;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            var lines = File.ReadLines(args[0]);

            foreach (var num in lines)
            {
                nums.Add(int.Parse(num));
            }

            int counter = 0;
            nums.Sort();
            int optimalNum = nums[nums.Count / 2];

            for (int i = 0; i < nums.Count; i++)
            {
                if (i == nums.Count / 2) continue;
                counter += Math.Abs(optimalNum - nums[i]);
            }

            Console.WriteLine(counter);
        }
    }
}
