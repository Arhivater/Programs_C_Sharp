using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Singleton
    {
        private static Singleton instance; // класс Singleton
        private Singleton()
        {
            Console.WriteLine("Creating: Singleton . . . \n");
        }
        public static Singleton getCreated()
        {
            if (instance == null) instance = new Singleton();
            else Console.WriteLine("Singleton - Creating is Complete \n");
            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Singleton.getCreated();
            Singleton.getCreated();
            Singleton.getCreated();
            Console.Read();
        }
    }
}
