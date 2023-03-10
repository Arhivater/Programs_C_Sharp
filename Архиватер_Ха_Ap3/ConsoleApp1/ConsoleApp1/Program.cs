using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    public class BinaryTree //дерево
    {
        public class BinaryNode //узел дерева
        {
            public BinaryNode left { get; set; } //левая ветвь
            public BinaryNode right { get; set; } //правая ветвь
            public int value; //вес
            public char sybmol; //символ

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
        public BinaryTree() //конструктор (по умолчанию) создания дерева
        {
            root = null; //при создании корень не определен
        }

        public BinaryTree(int value)
        {
            root = new BinaryNode(value); //если изначально задаём корневое значение
        }

        public BinaryTree(int value, char sym)
        {
            root = new BinaryNode(value, sym); //если изначально задаём корневое значение
        }

        //Добавление узла к дереву
        public void AddNode(BinaryNode node) //узел и его значение
        {
            BinaryNode current = root; //текущий равен корневому
            bool added = false;
            //обходим дерево
            do
            {
                if (current.right == null)
                {
                    current.right = node;
                    added = true;

                }
                else
                {
                    if (current.left == null)
                    {
                        current.left = node;
                        added = true;
                    }
                    else
                    {
                        current = current.left;
                    }
                    current = current.right;
                }
            } while (!added);
        }

        //Прямой обход дерева для состовления кодировки
        public void CLR(BinaryNode node, ref Dictionary<char, string> arr, string s)
        {
            /*
             Аргументы метода:
             1. BinaryNode node - текущий "элемент дерева" (ref  передача по ссылке)       
             2. ref Dictionary<char, string> arr -  словарь с кодировками символов
             3. string s - текущая кодировка
            */
            if (node != null)
            {
                if (node.sybmol != '\0')
                {
                    arr[node.sybmol] = s;
                }
                CLR(node.left, ref arr, s + "0"); // обойти левое поддерево
                CLR(node.right, ref arr, s + "1"); // обойти правое поддерево
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = new StreamReader("uncode.txt").ReadToEnd(); // Считывание текстового файла
            Dictionary<char, string> symbol_arr = new Dictionary<char, string>();
            List<BinaryTree> arr = new List<BinaryTree>();
            //Составление списка кодируемых символов
            char[] chars = str.ToCharArray().Distinct().ToArray();
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

            //Формирование итогового дерева
            while (arr.Count() > 1)
            {
                arr = arr.OrderBy(o => o.root.value).ToList();
                arr.Add(new BinaryTree(arr[0].root.value + arr[1].root.value));
                arr[arr.Count - 1].AddNode(arr[0].root);
                arr[arr.Count - 1].AddNode(arr[1].root);
                arr.RemoveAt(0);
                arr.RemoveAt(0);
            }

            //Создание кодировки на основе полученного дерева
            arr[0].CLR(arr[0].root, ref symbol_arr, "");

            //Вывод кодировки
            StreamWriter sw = new StreamWriter("Encode.txt");
            sw.WriteLine(symbol_arr.Count());
            foreach (var item in symbol_arr)
            {
                sw.WriteLine(item.Key + " " + item.Value); // Добавление бинарного дерева в файл
            }

            foreach (char x in chars)
            {
                foreach (var item in symbol_arr)
                    if (x.Equals(item.Key))
                        sw.Write(item.Value + " "); // Запись закодированной строки
            }
            sw.Close();
            Console.ReadLine();
        }
    }
}
