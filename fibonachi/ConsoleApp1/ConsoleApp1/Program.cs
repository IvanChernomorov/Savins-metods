using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    static double f(double x)
    {
        return 2 * x * x - 2 * x + 1.5;
    }

    static List<int> fib(double end)
    {
        List<int> fibNums = new List<int>();
        fibNums.Add(1);
        fibNums.Add(1);
        while (fibNums[fibNums.Count - 1] < end)
            fibNums.Add(fibNums[fibNums.Count - 1] + fibNums[fibNums.Count - 2]);
        return fibNums;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Введите интервал:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите погрешность (эпсилон и дельта): ");
        double e = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double L = e * 2;

        List<int> fibNums = fib((b - a) / L);
        int N = fibNums.Count - 1;

        Console.WriteLine();
        Console.WriteLine("N = " + N);

        double y = a + ((double)fibNums[N - 2] / fibNums[N]) * (b - a);
        double z = a + ((double)fibNums[N - 1] / fibNums[N]) * (b - a);
        double f_y = f(y), f_z = f(z);
        int k = 0;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Итерация " + k);
            Console.WriteLine("y" + k + " = " + y);
            Console.WriteLine("z" + k + " = " + z);
            Console.WriteLine("f(y" + k + ") = " + f_y);
            Console.WriteLine("f(z" + k + ") = " + f_z);

            if (f_y <= f_z)
            {
                b = z;
                z = y;
                f_z = f_y;
                y = a + ((double)fibNums[N - k - 3] / fibNums[N - k - 1]) * (b - a);
                f_y = f(y);
            }
            else
            {
                a = y;
                y = z;
                f_y = f_z;
                z = a + ((double)fibNums[N - k - 2] / fibNums[N - k - 1]) * (b - a);
                f_z = f(z);
            }

            if (k == N - 3)
                break;
            k++;
        }

        z = y + d;
        f_z = f(z);
        if (f_y < f_z)
            b = z;
        else
            a = y;

        Console.WriteLine();
        Console.WriteLine($"Минимум = {(a + b) / 2}, на интервале [{a}; {b}]");
        Console.WriteLine($"Значение функции в точке минимума = {f((a + b) / 2)}");
        Console.ReadKey();
    }
}