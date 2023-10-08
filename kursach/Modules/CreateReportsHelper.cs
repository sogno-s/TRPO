using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using kursach.Model;
using Microsoft.Win32;
using NodaTime;


namespace kursach.Modules
{
    public class CreateReportsHelper
    {
        public static void GenerateSalesReportByEmployeeDOCX(int IdEmployee)
        {
            var employee = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Idemployee == Reserv.IdPerson);
            if (employee == null)
            {
                throw new Exception("Сотрудник не найден.");
            }

            var sales = ModelPublic.GetContext().Payments
                .Where(w => w.Idemployee == employee.Idemployee)
                .SelectMany(sm => sm.Paymentproducts)
                .GroupBy(gb => gb.Idproduct)
                .Select(s => new
                {
                    IdProduct = s.Key,
                    Quantity = s.Sum(ss => ss.Quantity)
                })
                .ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                using (var document = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    var mainPart = document.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = mainPart.Document.AppendChild(new Body());

                    // Добавление заголовка
                    var titleParagraph = new Paragraph();
                    var titleRun = new Run(new Text("Отчет о продажах сотрудника"));
                    titleParagraph.AppendChild(titleRun);
                    body.AppendChild(titleParagraph);

                    // Добавление имени сотрудника
                    var employeeNameParagraph = new Paragraph();
                    var employeeNameRun = new Run(new Text($"Сотрудник: {employee.Surname}  {employee.Firstname}  {employee.Lastname}"));
                    employeeNameParagraph.AppendChild(employeeNameRun);
                    body.AppendChild(employeeNameParagraph);

                    // Добавление даты формирования отчета
                    var generationDateParagraph = new Paragraph();
                    var generationDateRun = new Run(new Text($"Дата формирования отчета: {DateTime.Now.ToShortDateString()}"));
                    generationDateParagraph.AppendChild(generationDateRun);
                    body.AppendChild(generationDateParagraph);

                    // Добавление данных о продажах
                    var salesTable = new Table();
                    var salesHeaderRow = new TableRow(new TableCell(new Paragraph(new Run(new Text("Название товара")))),
                        new TableCell(new Paragraph(new Run(new Text("Количество")))));
                    salesTable.AppendChild(salesHeaderRow);

                    var test = ModelPublic.GetContext().Payments.Where(w => w.Idemployee == employee.Idemployee).Sum(s => s.Totalsumm);

                    // Добавление ИТОГОВОЙ СУММЫ формирования отчета
                    var generationPriceParagraph = new Paragraph();
                    var generationPriceRun = new Run(new Text($"Итоговая сумма всех продаж: {test}"));
                    generationDateParagraph.AppendChild(generationPriceRun);
                    body.AppendChild(generationPriceParagraph);

                    foreach (var sale in sales)
                    {
                        var product = ModelPublic.GetContext().Products.FirstOrDefault(p => p.Idproduct == sale.IdProduct);
                        var row = new TableRow(new TableCell(new Paragraph(new Run(new Text(product.Naming)))),
                            new TableCell(new Paragraph(new Run(new Text(sale.Quantity.ToString())))));
                        salesTable.AppendChild(row);
                    }

                    body.AppendChild(new Paragraph(new Run(new Text("Список продаж:"))));
                    body.AppendChild(salesTable);
                }
            }
        }

        public static void GenerateSalesReportByEmployeeWithPeriodDOCX(int IdEmployee, DateTime dateStart, DateTime dateEnd)
        {
            var employee = ModelPublic.GetContext().Employees.FirstOrDefault(f => f.Idemployee == Reserv.IdPerson);
            if (employee == null)
            {
                throw new Exception("Сотрудник не найден.");
            }
            DateOnly dateStartOnly = new DateOnly(dateStart.Year, dateStart.Month, dateStart.Day);
            DateOnly dateEndOnly = new DateOnly(dateEnd.Year, dateEnd.Month, dateEnd.Day);

            var sales = ModelPublic.GetContext().Payments
                .Where(w => w.Idemployee == employee.Idemployee && w.Dateofpay >= dateStartOnly && w.Dateofpay <= dateEndOnly)
                .Select(p => new
                {
                    Sale = p,
                    Products = p.Paymentproducts.Select(pp => new
                    {
                        Product = pp.IdproductNavigation,
                        Quantity = pp.Quantity,
                        Price = pp.IdproductNavigation.Price
                    })
                })
                .ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word документ (*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавление заголовка
                    Paragraph titleParagraph = new Paragraph(new Run(new Text("Отчет о количестве продаж сделанных сотрудником")));
                    body.AppendChild(titleParagraph);

                    // Добавление ФИО сотрудника
                    Paragraph employeeNameParagraph = new Paragraph(new Run(new Text($"Сотрудник: {employee.Surname} {employee.Firstname} {employee.Lastname}")));
                    body.AppendChild(employeeNameParagraph);

                    // Добавление периода за который делается отчет
                    Paragraph periodParagraph = new Paragraph(new Run(new Text($"Период: {dateStart.ToShortDateString()} - {dateEnd.ToShortDateString()}")));
                    body.AppendChild(periodParagraph);

                    int saleNumber = 1;
                    foreach (var sale in sales)
                    {
                        Paragraph saleHeaderParagraph = new Paragraph(new Run(new Text($"ПРОДАЖА №{saleNumber}:")));
                        body.AppendChild(saleHeaderParagraph);
                        var salesTable = new Table();

                        // Добавление заголовка таблицы
                        var salesHeaderRow = new TableRow(
                            new TableCell(new Paragraph(new Run(new Text("Название товара")))),
                            new TableCell(new Paragraph(new Run(new Text("Количество")))),
                            new TableCell(new Paragraph(new Run(new Text("Цена")))),
                            new TableCell(new Paragraph(new Run(new Text("Итоговая сумма")))));
                        salesTable.AppendChild(salesHeaderRow);

                        decimal? saleTotalAmount = 0;

                        foreach (var product in sale.Products)
                        {
                            var row = new TableRow(
                                new TableCell(new Paragraph(new Run(new Text(product.Product.Naming)))),
                                new TableCell(new Paragraph(new Run(new Text(product.Quantity.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(product.Price.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text((product.Quantity * product.Price).ToString())))));
                            salesTable.AppendChild(row);

                            saleTotalAmount += product.Quantity * product.Price;
                        }

                        body.AppendChild(salesTable);

                        // Добавление итоговой суммы для текущей продажи
                        Paragraph saleTotalAmountParagraph = new Paragraph(new Run(new Text($"ИТОГО(сумма) для продажи №{saleNumber}: {saleTotalAmount}")));
                        body.AppendChild(saleTotalAmountParagraph);

                        saleNumber++;
                    }

                    // Добавление итоговой суммы
                    decimal? totalAmount = sales.Sum(s => s.Sale.Totalsumm);
                    Paragraph totalAmountParagraph = new Paragraph(new Run(new Text($"ИТОГО(сумма): {totalAmount}")));
                    body.AppendChild(totalAmountParagraph);
                }
            }
        }

        
    }
}
