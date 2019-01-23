using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestOpenXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentName = "MainTest";
            var path = $"E:\\IT-learning\\C# уровень 3\\Урок 7. Базы данных\\{documentName}.docx";
            const int count = 10;

            var testList = new List<TestRecipient>();

            for (var i = 1; i <= count; i++)
            {
                var j = i;
                testList.Add(new TestRecipient(name: $"Получатель{j}", email: $"address{j}@server.ru"));
            }

            var doc = new GeneratedClass();
            doc.TestListRecipients = testList;
            doc.CreatePackage(path);
            doc.OpenDocument(path);
        }
    }
}
