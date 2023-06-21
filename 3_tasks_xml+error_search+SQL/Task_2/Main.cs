using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputXmlFilePath = "Clients.xml";
            string outputXmlFilePath = "output.xml";

            try
            {
                // Создание экземпляра XMLProcessor
                XMLProcessor processor = new XMLProcessor();

                // Загрузка исходного XML
                processor.LoadXml(inputXmlFilePath);

                // Проверка записей Clients
                processor.ValidateClients();

                // Запись нового XML-файла
                processor.GenerateOutputXml(outputXmlFilePath);

                // Вывод
                Console.WriteLine($"Не указан DiasoftID: {processor.MissingDiasoftIDCount} записей");
                Console.WriteLine($"Не указан Регистратор: {processor.MissingRegistratorCount} записей");
                Console.WriteLine($"Не указано ФИО: {processor.MissingFIOCount} записей");
                Console.WriteLine($"Всего ошибочных записей: {processor.TotalErrorsCount}");
                //Console.WriteLine($"Количество узлов <Client> в исходном XML: {processor.OriginalClientCount}");
                //Console.WriteLine($"Количество узлов <Client> в новом XML: {processor.NewClientCount}");
                Console.WriteLine($"XML-файл сохранен в: {Path.GetFullPath(outputXmlFilePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке XML: {ex.Message}");
            }
        }
    }
}