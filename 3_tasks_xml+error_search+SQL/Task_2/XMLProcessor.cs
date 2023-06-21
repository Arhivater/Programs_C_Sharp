using System.Xml;

class XMLProcessor
{
    public int MissingDiasoftIDCount { get; private set; }
    public int MissingRegistratorCount { get; private set; }
    public int MissingFIOCount { get; private set; }
    public int TotalErrorsCount => MissingDiasoftIDCount + MissingRegistratorCount + MissingFIOCount;
    public int OriginalClientCount { get; private set; }
    public int NewClientCount { get; private set; }

    private XmlDocument inputXmlDoc;
    private XmlDocument outputXmlDoc;
    private XmlElement clientsElement;
    private Dictionary<string, int> registratorIds;
    private int currentId;

    public void LoadXml(string filePath)
    {
        // Загрузка XML в XmlDocument
        inputXmlDoc = new XmlDocument();
        inputXmlDoc.Load(filePath);
    }

    public void ValidateClients()
    {
        // Выбор всех узлов <Client> в XML
        XmlNodeList clientNodes = inputXmlDoc.SelectNodes("/Clients/Client");
        OriginalClientCount = clientNodes.Count;

        MissingDiasoftIDCount = 0;
        MissingRegistratorCount = 0;
        MissingFIOCount = 0;

        registratorIds = new Dictionary<string, int>();
        currentId = 1;

        foreach (XmlNode clientNode in clientNodes)
        {
            // Проверка наличия и заполненности ключей в каждом узле <Client>
            XmlNode diasoftIDNode = clientNode.SelectSingleNode("DiasoftID");
            XmlNode registratorNode = clientNode.SelectSingleNode("Registrator");
            XmlNode fioNode = clientNode.SelectSingleNode("FIO");

            if (diasoftIDNode == null || string.IsNullOrEmpty(diasoftIDNode.InnerText))
            {
                MissingDiasoftIDCount++;
                continue;
            }

            if (registratorNode == null || string.IsNullOrEmpty(registratorNode.InnerText))
            {
                MissingRegistratorCount++;
                continue;
            }

            if (fioNode == null || string.IsNullOrEmpty(fioNode.InnerText))
            {
                MissingFIOCount++;
                continue;
            }

            string registrator = registratorNode.InnerText;

            // Генерация Id для каждого уникального Registrator
            if (!registratorIds.ContainsKey(registrator))
            {
                registratorIds.Add(registrator, currentId);
                currentId++;
            }
        }
    }

    public void GenerateOutputXml(string filePath)
    {
        // Создание нового Xml
        outputXmlDoc = new XmlDocument();
        clientsElement = outputXmlDoc.CreateElement("Clients");
        outputXmlDoc.AppendChild(clientsElement);

        // Выбор всех узлов <Client> в исходном XML
        XmlNodeList clientNodes = inputXmlDoc.SelectNodes("/Clients/Client");

        foreach (XmlNode clientNode in clientNodes){
            // Проверка наличия и заполненности ключей в каждом узле <Client>
            XmlNode diasoftIDNode = clientNode.SelectSingleNode("DiasoftID");
            XmlNode registratorNode = clientNode.SelectSingleNode("Registrator");
            XmlNode fioNode = clientNode.SelectSingleNode("FIO");

            if (diasoftIDNode == null || string.IsNullOrEmpty(diasoftIDNode.InnerText) ||
                registratorNode == null || string.IsNullOrEmpty(registratorNode.InnerText) ||
                fioNode == null || string.IsNullOrEmpty(fioNode.InnerText)) { continue; }

            // Создание нового узла <Client> в новом XML
            XmlNode newClientNode = outputXmlDoc.ImportNode(clientNode, true);
            clientsElement.AppendChild(newClientNode);

            string registrator = registratorNode.InnerText;

            // Создание и добавление узла <RegistratorID> с идентификатором
            XmlElement registratorIdElement = outputXmlDoc.CreateElement("RegistratorID");
            registratorIdElement.InnerText = registratorIds[registrator].ToString();
            newClientNode.AppendChild(registratorIdElement);
        }

        // Сохранение нового XML-файла
        outputXmlDoc.Save(filePath);
        NewClientCount = clientsElement.ChildNodes.Count;
    }
}