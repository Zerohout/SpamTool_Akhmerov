using ClosedXML.Excel;
using System.Collections.Generic;

namespace TestClosedXmlExcel
{
    public class DocumentExcel
    {
        public void CreateDocument(string path, List<TestRecipient> recipients)
        {
            var count = recipients.Count;

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Получатели");

            var rngTable = ws.Range("A1", $"C{count + 2}");

            ws.Column(1).Width = 16;
            ws.Column(2).Width = 55;
            ws.Column(3).Width = 77;
            ws.Row(1).Height = 42;
            ws.Row(2).Height = 36;

            rngTable.FirstRow().Merge();
            rngTable.FirstRow().Value = "Получатели";
            rngTable.FirstRow().Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Thick)
                .Fill.SetBackgroundColor(XLColor.FromArgb(r: 230, g: 184, b: 184))
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Font.SetFontName("Comic Sans MS")
                .Font.SetBold()
                .Font.SetFontSize(22)
                .Font.SetFontColor(XLColor.FromArgb(r: 98, g: 32, b: 32));

            rngTable.Row(2).Style
                .Border.SetOutsideBorder(XLBorderStyleValues.Thick)
                .Fill.SetBackgroundColor(XLColor.FromArgb(r: 217, g: 217, b: 217))
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                .Font.SetFontName("Comic Sans MS")
                .Font.SetBold()
                .Font.SetFontSize(20)
                .Font.SetFontColor(XLColor.FromArgb(r: 180, g: 6, b: 4));

            rngTable.Cell(2, 1).Value = "ID";
            rngTable.Cell(2, 2).Value = "Имя";
            rngTable.Cell(2, 2).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
            rngTable.Cell(2, 3).Value = "Адрес почты";

            var rngData = ws.Range("A3", $"C{count + 2}");
            rngData.Column(2).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

            var num = 0;

            for (var i = 3; i <= count + 2; i++, num++)
            {
                var j = i;
                ws.Row(j).Height = 33;
                ws.Row(j).Cell(1).Value = recipients[num].Id;
                ws.Row(j).Cell(2).Value = recipients[num].Name;
                ws.Row(j).Cell(3).Value = recipients[num].Address;

                rngData.Row(num + 1).Style
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thick)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Font.SetFontName("Comic Sans MS")
                    .Font.SetFontSize(18);

                if (j % 2 != 0)
                {
                    rngData.Row(num + 1).Style
                        .Fill.SetBackgroundColor(XLColor.FromArgb(r: 241, g: 220, b: 219))
                        .Font.SetFontColor(XLColor.FromArgb(r: 152, g: 86, b: 32));
                    continue;
                }

                rngData.Row(num + 1).Style
                    .Fill.SetBackgroundColor(XLColor.FromArgb(r: 229, g: 229, b: 229))
                    .Font.SetFontColor(XLColor.FromArgb(r: 109, g: 102, b: 133));
            }

            ws.Range("A2", $"C{count + 2}").CreateTable();

            wb.SaveAs(path);
        }
    }
}
