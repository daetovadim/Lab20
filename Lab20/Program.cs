using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab20
{
    class Program
    {
        delegate double MyDelegate(double R);
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\tРабота с делегатами");

            Console.Write("\n Введите длину окружности: ");
            try
            {
                double R = Double.Parse(Console.ReadLine());

                MyDelegate myDelegate = CircleLength;
                if (myDelegate != null)
                {
                    double D = myDelegate(R);
                    Console.WriteLine(" Длина окружности с радиусом {0} = {1:.000}", R, D);
                }

                MyDelegate myDelegate1 = new MyDelegate(CircleArea);
                Console.WriteLine("\n Площадь окружности с радиусом {0} = {1:.000}", R, myDelegate1?.Invoke(R));

                MyDelegate myDelegate2 = r =>  //Пробую различный синтаксис объявления делегата
                {
                    double v = 4 / 3 * Math.PI * Math.Pow(r, 3);
                    return v;
                };
                double V = myDelegate2(R);
                Console.WriteLine("\n Объём сферы с радиусом {0} = {1:.000}", R, V);
            }
            catch (FormatException)
            {
                Console.WriteLine(" Введите численное значение!");
            }
            Console.ReadKey();
        }

        static double CircleLength(double R)
        {
            double D = 2 * Math.PI * R;
            return D;
        }
        static double CircleArea(double R)
        {
            double S = Math.PI * R * R;
            return S;
        }
    }
}
