using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FilesSystem
{
    class Program {
        public static void Directory_Search(string dirs) { 
            try {
                foreach (string str in Directory.GetDirectories(dirs)) { //Рекурсивный вывод каталогов
                    Console.WriteLine(str + " \n");
                    Directory_Search(str);
                }
            }
            catch (System.Exception e) { Console.WriteLine(e.Message); }
        }

        public static void Copy_File(string initPath, string finPath) //Копирование файла
        {
            FileInfo File_Info = new FileInfo(initPath);//Получаем файл по начальному пути
            if (File_Info.Exists)//Если файл найден
            {
                try
                {
                    File_Info.CopyTo(finPath); //Копируем в новый каталог
                }
                catch { }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nФайл скопирован!");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nФайл не найден");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public static IEnumerable<string> File_Search(string path, string searchPattern) { //Поиск файла
            IEnumerable<string> files = null;
            try {
                files = Directory.EnumerateFiles(path, searchPattern); // Получение файла
            }
            catch { }

            if (files != null) { //Если файл получен, возвращаем его
                foreach (var file in files) yield return file;
            }

            IEnumerable<string> directories = null;
            try {
                directories = Directory.EnumerateDirectories(path); // Если файл не был найден то поиск его в последующих каталогах 
            }
            catch { }

            if (directories != null) { // Если поиск привел в следующий каталог
                foreach (var file in directories.SelectMany(dir => File_Search(dir, searchPattern))) { yield return file; } // Рекурсивный поиск файла
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int caseSwitch;
            do
            {
                Console.WriteLine("\n(1) Копирование файла из одного католого в другой \n");
                Console.WriteLine("(2) Вывод дерева каталога \n");
                Console.WriteLine("(3) Выход \n");
                Console.Write("Введите номер варианта действия: ");
                caseSwitch = Convert.ToInt32(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        Console.Write("\nВведите путь каталога в котором лежит файл: ");
                        string First_Path = Console.ReadLine();
                        Console.Write("\nВведите име файла который хотите скопировать: ");
                        string File_Name = Console.ReadLine();
                        Console.Write("\nВведите путь который хотите скопировать файл: ");
                        string Second_Path = Console.ReadLine();
                        foreach (var value in File_Search(First_Path, File_Name))
                        Copy_File(value, Second_Path + "/" + File_Name);
                        Console.WriteLine("\n");
                        File_Name = "";
                        First_Path = "";
                        Second_Path = "";
                        break;
                    case 2:
                        Console.Write("\nВведите путь каталога: ");
                        string directory = Console.ReadLine();
                        Console.WriteLine("\n");
                        Directory_Search(directory);
                        Console.WriteLine("\n");
                        directory = "";
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        break;                        
                }
            } while (caseSwitch < 3);
        }
    }
}
