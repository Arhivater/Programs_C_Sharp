using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 { // Делегаты
    public static class Prov {   //создаю класс с функциями
        public static double subtraction(double x, double y) { return x - y; }
        public static double addition(double x, double y) { return x + y; }
        public static double Multiplication(double x, double y) { return x * y; }
        public static double division(double x, double y) { return x / y; }
    }

    class Program {
        delegate double operation(double x, double y);      // создаем делегат 
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;
            operation[] deleg = new operation[10];   //создаем массив делегатов
            for (int i = 0; i < 10; i++) deleg[i] =  Prov.addition;  //замолнение массив
            double sequence = 1;
            for (int i = 0; i < 10; i++) {      
                Console.WriteLine(sequence = deleg[i].Invoke(sequence, sequence));  // цикличный вызов функции и вывод результата
            }
            Console.Read();
        }
    }
}