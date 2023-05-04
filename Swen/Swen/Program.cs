using System;

namespace Swen
{
    internal class Program
    {
        public static double f(double x)
        {
            return x * x - 2 * x + 1.5;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите интервал:");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите x0: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите t: ");
            double t = double.Parse(Console.ReadLine());

            double fx_t, fxt, fx, fxn, x_next, d = 0;
            int k = 0;
            fx_t = f(x - t);
            fxt = f(x + t);
            fx = f(x);

            if(fx < fx_t && fx < fxt)
            {
                Console.WriteLine($"Интервал неопределённости найден: [{x - t}; {x + t}]");
                Console.ReadKey();
                return;
            }
            else if(fx >= fx_t && fx >= fxt)
            {
                Console.WriteLine("Функция не является унимодальной");
                Console.ReadKey();
                return;
            }   
            else if (fx_t >= fx && fx >= fxt)
            {
                a = x;
                d = t;
            }
            else
            {
                b = x;
                d = -t;
            }
            x += d;

            while (true)
            {
                k++;
                x_next = x + Math.Pow(2, k) * d;
                fxn = f(x_next);
                if (fxn < fx)
                {
                    if (d == t)
                        a = x;
                    else 
                        b = x;
                    x = x_next;
                    fx = fxn;
                }
                else
                {
                    if (d == t)
                        b = x_next;
                    else
                        a = x_next;
                    break;
                }
            }
            Console.WriteLine($"Интервал неопределённости найден: [{a}; {b}]");
            Console.ReadKey();
        }
    }
}
