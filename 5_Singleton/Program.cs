using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;
            Singleton singleton1 = Singleton.Instance;
            Singleton singleton2 = Singleton.Instance;
            Singleton singleton3 = Singleton.Instance;
            Console.ReadKey();
        }

        public sealed class Singleton
        {
            private static Singleton instance = null;
            private static readonly object padlock = new object();

            Singleton()
            {
                Console.WriteLine("CREATED");
            }

            public static Singleton Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                        return instance;
                    }
                }
            }
        }

    }
}
