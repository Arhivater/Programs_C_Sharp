using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7 { 

	class Program {

		static void Main(string[] args) {
			
			// получаем путь к директории MyDocuments
			var My_Documents_Way = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
			
			// название файла для считывания кода
			var File_Name = "VhodnoyKodec.txt"; 
			
			// Заполняем строковый массив командами полученными из файла с кодом
			string[] St_Command_Lines_Arr = System.IO.File.ReadAllSt_Command_Lines_Arr($"{My_Documents_Way}/{File_Name}"); 
			
			// создаем ассоциативный массив
			var dict = new dictionary<string, string>(); 

			// запускаем цикл для строк где будет происходить проверка строки на условие
			foreach (string line in St_Command_Lines_Arr) {
				
				// Если строка не начинается с точки с запятой то пропускаем её поскольку она не подходит по главному условию
				if (line[0] != ';') {
					break;
				}
				
				// После того как строка прошла главное условие следуеют следующие проверки которые устанавливают её командное назначение 
				
				// Если в строке имеется два восклицательных знака то " !!", тогда выполняем метод который пишет в консоль
				if (line[2] == '!' && line[3] == '!') {
					Print(line);
				}

				// если содержится const string и = ", то выполнить метод инициализации значения конст
				else if (line.Contains("const string") && line.Contains("= \"")) {
					dict = AddNewValueForConstString(dict, line);
				}

				// если содержится знак умножения , то метод умножения строки
				else if (line.Contains("const string") && line.Contains("*")) {
					dict = AddNewValueForRepeat(dict, line);
				}

				// если int и отсутствует ^, то метод инициализации
				else if (line.Contains("int") && !line.Contains("^")) {
					dict = AddNewValueForInt(dict, line);
				}

				// если int и ^ есть, то возведение в степень
				else if (line.Contains("int") && line.Contains("^")) {
					dict = AddNewValueForIntPow(dict, line);
				}
			}
		}

		private static void Print(string line) {
			
			// вывести вторую часть разбитой по !! строке, которая содержит в себе текст между !!
			Console.WriteLine(line.Split("!!")[1]); 
		}

		private static dictionary<string, string> AddNewValueForConstString(dictionary<string, string> dict, string line) {
			
			// добавить название константы ключом, а значение - значением
			dict[line.Split(' ')[3]] = line.Split("\"")[1]; 
			
			// возвращаем измененный словарь для сохранения
			return dict; 
		}

		private static dictionary<string, string> AddNewValueForRepeat(dictionary<string, string> dict, string line) {
			
			// получить название константы
			var elem = line.Split(" ")[5];

			// получить число повторений 
			var countRepeat = int.Parse(line.Split(" ")[7]); 
			
		/* ключ - константа, значение - получаем последовательность из countRepeat строк, объединенных методом Concat класса string */
			dict[line.Split(' ')[3]] = string.Concat(Enumerable.Repeat(dict[elem], countRepeat)); 
																							  
			return dict; 
		}

		private static dictionary<string, string> AddNewValueForInt(dictionary<string, string> dict, string line) {
			
			// название переменной - ключ, значение - значение
			dict[line.Split(' ')[2]] = line.Split(' ')[4]; 
			
			return dict; 
		}

		private static dictionary<string, string> AddNewValueForIntPow(dictionary<string, string> dict, string line) {
			
			// получаем выражение
			var expression = line.Split(' ')[4];
 
 			//получаем число из словаря
			var elem = double.Parse(dict[expression.Split('^')[0]]);

			// получаем степень из выражения 
			var pow = double.Parse(expression.Split('^')[1]);
			
			// После чего делаем возведение в степень
			dict[line.Split(' ')[2]] = Math.Pow(elem, pow).ToString(); 

			return dict;
		}
	}
}

// VhodnoyKodec 

//; !!Hello_World_Its_Me_Mario!!
//; const string str = "123"
//; const string str1 = str * 5
//; int number1 = 5
//; int number2 = number1^3