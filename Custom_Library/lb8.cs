// код приложения 8ой лабы

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {

            Double TestDLL = DmitriyLibrary.MyCodec.Slojeniye(11, 20); // создаем переменную типа Duble и присваиваем ей значение спомощью метода из подключенной библиотеки

            Console.WriteLine(TestDLL);

            Console.ReadLine();
        }
    }
}

// код DLL библиотеки

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmitriyLibrary
{
    public class MyCodec
    {

        public static double Slojeniye(double FirstNumber, double SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
    }
}

