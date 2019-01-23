using ClosedXML.Excel;
using System.Collections.Generic;

namespace TestClosedXmlExcel
{
    public class DocumentExcel
    {
        public void CreateSimpleDocument(string path)
        {
            var wb = new XLWorkbook();

            var ws = wb.Worksheets.Add("Recipients");

            ws.Cell("B2").Value = "Recipients";

            ws.Cell("B3").Value = "Name";
            ws.Cell("C3").Value = "Address";

            var rngTable = ws.Range("B2:C6");

            rngTable.FirstCell().Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.CornflowerBlue)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            rngTable.FirstRow().Merge(); // rngTable.Range("A1:E1").Merge() or rngTable.Row(1).Merge()

            var rngHeaders = rngTable.Range("A2:B2"); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontColor = XLColor.DarkBlue;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            var rngData = ws.Range("B3:C6");
            var excelTable = rngData.CreateTable();

            excelTable.ShowTotalsRow = true;

            ws.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            ws.Columns().AdjustToContents(); // You can also specify the range of columns to adjust, e.g.
            // ws.Columns(2, 6).AdjustToContents(); or ws.Columns("2-6").AdjustToContents();

            wb.SaveAs(path);
        }

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

        public void CreateAverageDocument(string path, List<TestRecipient> recipients)
        {
            var recCount = recipients.Count;

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Получатели");

            ws.Cell("B3").Value = "ID";
            ws.Cell("C3").Value = "Имя";
            ws.Cell("D3").Value = "Адрес почты";

            var rngTable = ws.Range("B2", $"D{3 + recCount}");

            foreach (var row in rngTable.Rows(rngTable.FirstRow().RowNumber(), rngTable.LastRow().RowNumber()))
            {
                row.Style
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Font.SetFontName("Comic Sans MS");

                if (row.RowNumber() == rngTable.FirstRow().RowNumber())
                {
                    row.Style
                        .Font.SetFontSize(22)
                        .Font.SetBold()
                        .Font.SetFontColor(XLColor.GoldenBrown)
                        .Fill.SetBackgroundColor(XLColor.CandyAppleRed)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                    row.Merge();
                    row.Value = "Получатели";

                    continue;
                }

                if (row.RowNumber() == (rngTable.FirstRow().RowNumber() + 1))
                {
                    row.Style
                        .Font.SetBold()
                        .Font.SetFontSize(20)
                        .Font.SetFontColor(XLColor.CoralRed)
                        .Fill.SetBackgroundColor(XLColor.AshGrey);
                    continue;
                }

                row.Style
                    .Font.SetFontColor(row.RowNumber() % 2 != 0 ? XLColor.RedMunsell : XLColor.VioletRyb)
                    .Fill.SetBackgroundColor(row.RowNumber() % 2 != 0 ? XLColor.DebianRed : XLColor.FloralWhite)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thick);
            }

            ws.Column("B").Width = 150;
            ws.Column("C").Width = 500;
            ws.Column("C").Width = 700;

            var rngData = ws.Range($"B3:D{3 + (recCount - 1)}");
            rngData.CreateTable();
            //excelTable.ShowTotalsRow = true;

            ws.FirstColumn().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
            ws.LastColumn().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

            var dataCount = 4;

            foreach (var recipient in recipients)
            {
                ws.Cell($"B{dataCount}").Value = recipient.Id;
                ws.Cell($"C{dataCount}").Value = recipient.Name;
                ws.Cell($"D{dataCount}").Value = recipient.Address;
                dataCount++;
            }

            wb.SaveAs(path);

        }
    }
}
