using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Хф_1 {
    class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green; // меняем немножко цвет
            string str;
            int caseSwitch;
            do {
                Console.WriteLine("\n(1) Считать текст из текстовго файла NOT_Encoded_TEXT.txt и закодировать его \n");
                Console.WriteLine("(2) Считать текст из с консоли и закодировать его, результат будет записан в Encoded_TEXT.txt \n");
                Console.WriteLine("(3) Раскодировать текст из файла Encoded_TEXT.txt и записать результат Uno_TEXT.txt \n");
                Console.WriteLine("(4) Выход \n");
                Console.Write("Введите номер варианта действия: ");
                caseSwitch = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                switch (caseSwitch)
                {
                    case 1:
                        string Text_From_a_Text_file = new StreamReader("NOT_Encoded_TEXT.txt").ReadToEnd(); // Считывание текстового файла
                        str = Text_From_a_Text_file;
                        Hf(ref str);
                        Console.WriteLine("Текст из файла NOT_Encoded_TEXT.txt закодирован и записан в Encoded_TEXT.txt , для просмотра перейдите в Хф_1 -> Хф_1 -> bin -> Debug \n");
                        break;
                    case 2:
                        Console.WriteLine("Введите текст: ");
                        str = Console.ReadLine();
                        Hf(ref str);
                        Console.WriteLine("Текст из консоли закодирован и  записан в Encoded_TEXT.txt , для просмотра перейдите в Хф_1 -> Хф_1 -> bin -> Debug \n");
                        break;
                    case 3:
                        Uno();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                }
            } while (caseSwitch < 4);
        }
        static void Hf(ref string str) {
            Dictionary<char, string> symbol_arr = new Dictionary<char, string>();
            List<BinaryTree> arr = new List<BinaryTree>();
            char[] chars = str.ToCharArray().Distinct().ToArray(); //Составление списка кодируемых символов
            foreach (char x in chars)
            {
                int count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == x) count++;
                }
                symbol_arr.Add(x, "");
                arr.Add(new BinaryTree(count, x));
            }
            while (arr.Count() > 1) { //Формирование итогового дерева
                arr = arr.OrderBy(o => o.root.value).ToList();
                arr.Add(new BinaryTree(arr[0].root.value + arr[1].root.value));
                arr[arr.Count - 1].AddNode(arr[0].root);
                arr[arr.Count - 1].AddNode(arr[1].root);
                arr.RemoveAt(0);
                arr.RemoveAt(0);
            }
            arr[0].CLR(arr[0].root, ref symbol_arr, ""); //Создание кодировки на основе полученного дерева
            StreamWriter sw = new StreamWriter("Encoded_TEXT.txt");
            sw.WriteLine(symbol_arr.Count());
            foreach (var item in symbol_arr) {
                sw.WriteLine(item.Key + " " + item.Value); // Добавление бинарного дерева в файл
            }
            chars = str.ToCharArray().ToArray();
            foreach (char x in chars) {
                foreach (var item in symbol_arr)
                    if (x.Equals(item.Key))
                        sw.Write(item.Value + " "); // Запись закодированной строки
            }
            sw.Close();
        }

        static void Uno() {
            StreamReader sr = new StreamReader("Encoded_TEXT.txt");
            Dictionary<char, string> symbol_arr = new Dictionary<char, string>();
            int count = int.Parse(sr.ReadLine()); // Количество закодированных символов
            while (count != 0) {
                var s = sr.ReadLine().ToList<char>(); // Считываем строку с закодированным символом
                char symbol = s[0];
                s.RemoveAt(0);
                symbol_arr.Add(symbol, String.Join("", s.ToArray()).Trim()); // Заполняем массив кодировок
                count--;
            }
            string[] str = sr.ReadToEnd().Trim().Split(' '); // Считываем закодированную строку
            sr.Close();
            StreamWriter sw = new StreamWriter("Uno_Text.txt");
            foreach (string s in str) foreach (var item in symbol_arr) if (item.Value.Equals(s)) sw.Write(item.Key); // Раскодируем и записываем в файл
            sw.Close();
        }
    }
    public class BinaryTree { // бинарное древо
        public class BinaryNode { //узлы дерева
            public BinaryNode left { get; set; } // левое ответвление 
            public BinaryNode right { get; set; } // правое ответвление
            public int value; // вес
            public char sybmol; // символ
            public BinaryNode(int val)
            {
                value = val;
                left = null;
                right = null;
            }
            public BinaryNode(int val, char sym)
            {
                sybmol = sym;
                value = val;
                left = null;
                right = null;
            }
        }

        public BinaryNode root; //корень дерева
        
        //конструктор (по умолчанию) создания дерева
        public BinaryTree() { root = null; } //при создании корень не определен

        public BinaryTree(int value) { root = new BinaryNode(value); } //если изначально задаём корневое значение
        public BinaryTree(int value, char sym) { root = new BinaryNode(value, sym); } // Если изначально задаётся корневое значение
        public void AddNode(BinaryNode node) {  // Добавление узла к дереву (узел, значение узла)
            BinaryNode current = root; //текущий равен корневому
            bool added = false;
            do { // обход дерева
                if (current.right == null) {
                    current.right = node;
                    added = true;
                }
                else {
                    if (current.left == null) {
                        current.left = node;
                        added = true;
                    }
                    else current = current.left;
                    current = current.right;
                }
            }
            while (!added);
        }

        public void CLR(BinaryNode node, ref Dictionary<char, string> arr, string s) { // Прямой обход дерева для состовления кодировки
            if (node != null) {
                if (node.sybmol != '\0') {
                    arr[node.sybmol] = s;
                }
                CLR(node.left, ref arr, s + "0"); // Обход левого ответвление дерева
                CLR(node.right, ref arr, s + "1"); // Обход правого ответвление дерева
            }
        }
    }
}