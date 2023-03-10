using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Encode.txt");
            Dictionary<char, string> symbol_arr = new Dictionary<char, string>();
            int count = int.Parse(sr.ReadLine()); // Количество закодированных символов
            while (count != 0)
            {
                var s = sr.ReadLine().ToList<char>(); // Считываем строку с закодированным символом
                char symbol = s[0];
                s.RemoveAt(0);
                symbol_arr.Add(symbol, String.Join("", s.ToArray()).Trim()); // Заполняем массив кодировок
                count--;
            }
            string[] str = sr.ReadToEnd().Trim().Split(' '); // Считываем закодированную строку
            sr.Close();
            StreamWriter sw = new StreamWriter("Uncode.txt");
            foreach (string s in str)
                foreach (var item in symbol_arr)
                    if (item.Value.Equals(s))
                        sw.Write(item.Key); // Раскодируем и записываем в файл
            sw.Close();
        }
    }
}
