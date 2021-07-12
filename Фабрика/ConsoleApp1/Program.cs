using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        abstract class Driver {    //  Два abstract класса с водителями                                                            
            abstract public Car Init();
        }

        class Old_car_Driver : Driver {
            public override Car Init() {
                return new Old_car();
            }
        }
        class Supercar_Driver : Driver {
            public override Car Init() {
                return new Supercar();
            }
        }

        abstract class Car {  //  Два abstract класса с машинами
        }

        class Old_car : Car {
            public Old_car() {
                double Middle_Speed = 67.35; 
                Console.WriteLine("Second: Old car: Speed = " + Middle_Speed + "\n");
            }
        }
        class Supercar : Car {
            public Supercar() {
                double Middle_Speed = 120.64;
                Console.WriteLine("The first: Supercar: Speed = " + Middle_Speed + "\n");
            }
        }

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;
            Driver driver1 = new Supercar_Driver();
            Car car1 = driver1.Init();
            Driver driver2 = new Old_car_Driver();
            Car car2 = driver2.Init();
            Console.Read();
        }
    }

}