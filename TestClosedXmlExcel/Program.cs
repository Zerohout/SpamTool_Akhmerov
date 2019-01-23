using System.Collections.Generic;

namespace TestClosedXmlExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            var docName = "Test3";
            var path = $"C:\\Users\\Zerohout\\Desktop\\{docName}.xlsx";
            var count = 10;

            var recipients = new List<TestRecipient>();

            for (var i = 1; i <= count; i++)
            {
                var j = i;

                recipients.Add(new TestRecipient(j, $"Получатель{j}", $"address{j}@server.ru"));
            }
            
            var excel = new DocumentExcel();
            excel.CreateDocument(path, recipients);
        }


    }
}
