using System;
using System.Linq;

namespace _2_2_Методы_расширения_Extention
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input number: ");
            string Num = Console.ReadLine();
            String answer = StrExtension.StrPalindrome(Num);
            Console.Write(answer);
            Console.Read();
            Environment.Exit(0);
        }
    }

    public static class StrExtension
    {
        public static string StrPalindrome(this string number)
        {
            string answer_Extension = number.ToLower().SequenceEqual(number.ToLower().Reverse())
             ? answer_Extension = number + " is palindrome" : answer_Extension = number + " not a palindrome";

            return answer_Extension;
        }
    }
}

// Console.WriteLine("Hallo Welt!");