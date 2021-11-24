using System;
using System.IO;

namespace task_2
{
    class Program
    {
        static double x0, y0, radius = 0;

        static int BelongsToCircle((double x, double y) position)
        {
            double r = (double) (Math.Pow((position.x - x0), 2) + Math.Pow((position.y - y0), 2));
            if (r == Math.Pow(radius, 2)) return 0;
            if (r < Math.Pow(radius, 2)) return 1;
            return 2;
        }

        static void Main(string[] args)
        {
            using (TextReader reader = File.OpenText(args[0]))
            {
                string str = reader.ReadLine();
                (x0, y0) = (double.Parse(str.Split()[0]), double.Parse(str.Split()[1]));
                radius = double.Parse(reader.ReadLine());
            }

            using (StreamReader reader = File.OpenText(args[1]))
            {
                while (!reader.EndOfStream)
                {
                    string[] str = reader.ReadLine().Split();
                    int i = BelongsToCircle((double.Parse(str[0]), double.Parse(str[1])));
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}
